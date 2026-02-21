using src.Interfaces;
using src.Models;

namespace src.TerminalExpressions;

public class CategoryExpression(string category) : IExpression
{
    private readonly string _category = category;

    public bool Evaluate(Context context)
    {
        var cart = context.Cart;
        return cart.CustomerCategory.Equals(_category, StringComparison.OrdinalIgnoreCase);
    }

}
