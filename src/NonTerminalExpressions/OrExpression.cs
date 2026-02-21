using src.Interfaces;
using src.Models;

namespace src.NonTerminalExpressions;

public class OrExpression(IExpression right, IExpression left) : IExpression
{
    private readonly IExpression _right = right;
    private readonly IExpression _left = left;

    public bool Evaluate(Context context)
    {
        return _right.Evaluate(context) || _left.Evaluate(context);
    }
}
