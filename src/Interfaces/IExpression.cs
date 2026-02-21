using src.Models;

namespace src.Interfaces;

public interface IExpression
{
    bool Evaluate(Context context);
}
