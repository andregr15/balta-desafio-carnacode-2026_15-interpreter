using src.Interfaces;
using src.Models;

namespace src.TerminalExpressions;

public class FirstPurchaseExpression(bool firstPurchase) : IExpression
{
    private readonly bool _firstPurchase = firstPurchase;

    public bool Evaluate(Context context)
    {
        var cart = context.Cart;
        return cart.IsFirstPurchase == _firstPurchase;
    }
}
