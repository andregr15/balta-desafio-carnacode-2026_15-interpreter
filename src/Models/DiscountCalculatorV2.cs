using src.TerminalExpressions;
using src.NonTerminalExpressions;

namespace src.Models;

public class DiscountCalculatorV2
{
    public decimal CalculateDiscount(ShoppingCartV2 cart, string ruleText)
    {
        // Novo: Parsing com padrão Interpreter
        Console.WriteLine($"Avaliando regra: {ruleText}");

        // 1. Separar condição da ação
        var parts = ruleText.Split("ENTAO", StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2)
        {
            Console.WriteLine("✗ Regra malformada");
            return 0;
        }
        var condition = parts[0].Trim();
        var action = parts[1].Trim();

        // 2. Parse da condição para árvore de expressões
        var expression = ParseCondition(condition);
        if (expression == null)
        {
            Console.WriteLine("✗ Não foi possível interpretar a condição");
            return 0;
        }

        // 3. Avaliar expressão
        var context = new Context(cart);
        if (expression.Evaluate(context))
        {
            if (decimal.TryParse(action, out decimal discount))
            {
                Console.WriteLine($"✓ Regra aplicada: {discount}% desconto");
                return discount;
            }
        }

        Console.WriteLine("✗ Regra não aplicável");
        return 0;
    }

    // Parser simples para condições com "E" e expressões terminais
    private Interfaces.IExpression? ParseCondition(string condition)
    {
        // Suporta apenas "E" (And) por enquanto
        var andParts = condition.Split(" E ", StringSplitOptions.RemoveEmptyEntries);
        if (andParts.Length > 1)
        {
            var left = ParseCondition(andParts[0].Trim());
            var right = ParseCondition(andParts[1].Trim());
            if (left != null && right != null)
            {
                return new AndExpression(left, right);
            }
            return null;
        }

        // Expressões terminais
        if (condition.StartsWith("quantidade>"))
        {
            if (decimal.TryParse(condition[11..], out decimal qtd))
                return new QuantityExpression(qtd);
        }
        else if (condition.StartsWith("valor>"))
        {
            if (decimal.TryParse(condition[6..], out decimal val))
                return new ValueExpression(val);
        }
        else if (condition.StartsWith("categoria="))
        {
            var cat = condition[10..].Trim();
            return new CategoryExpression(cat);
        }
        else if (condition.StartsWith("primeiraCompra="))
        {
            if (bool.TryParse(condition[15..], out bool first))
                return new FirstPurchaseExpression(first);
        }

        return null;
    }
}
