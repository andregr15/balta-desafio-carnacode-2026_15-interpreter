using src.Interfaces;
using src.Models;

namespace src.TerminalExpressions;

public class ValueExpression(decimal value) : IExpression
{
    private readonly decimal _value = value;

    public bool Evaluate(Context context)
    {
        var cart = context.Cart;
        return cart.TotalValue > _value;
    }
}
