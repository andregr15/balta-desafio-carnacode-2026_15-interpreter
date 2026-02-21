namespace src.Models;

public class Context(ShoppingCartV2 cart)
{
    public ShoppingCartV2 Cart { get; } = cart;
}
