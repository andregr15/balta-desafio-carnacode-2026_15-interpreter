using src.Interfaces;
using src.Models;

namespace src.TerminalExpressions;

public class QuantityExpression(decimal quantity) : IExpression
{
    private readonly decimal _quantity = quantity;

    public bool Evaluate(Context context)
    {
        var cart = context.Cart;
        return cart.ItemQuantity > _quantity;
    }
}
