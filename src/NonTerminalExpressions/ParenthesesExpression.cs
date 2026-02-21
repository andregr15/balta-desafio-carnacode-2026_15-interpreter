using src.Interfaces;
using src.Models;

namespace src.NonTerminalExpressions;

public class ParenthesesExpression(IExpression left, IExpression right) : IExpression
{
    private readonly IExpression _left = left;
    private readonly IExpression _right = right;

    public bool Evaluate(Context context)
    {
        return _left.Evaluate(context) && _right.Evaluate(context);
    }
}
