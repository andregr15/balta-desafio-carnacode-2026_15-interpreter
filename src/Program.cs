using src.Models;

Console.WriteLine("=== Sistema de Regras de Desconto ===\n");

var calculator = new DiscountCalculatorV2();

var cart1 = new ShoppingCartV2
{
    TotalValue = 1500.00m,
    ItemQuantity = 15,
    CustomerCategory = "Regular",
    IsFirstPurchase = false
};

var cart2 = new ShoppingCartV2
{
    TotalValue = 500.00m,
    ItemQuantity = 5,
    CustomerCategory = "VIP",
    IsFirstPurchase = false
};

var cart3 = new ShoppingCartV2
{
    TotalValue = 200.00m,
    ItemQuantity = 2,
    CustomerCategory = "Regular",
    IsFirstPurchase = true
};

// Regras definidas como strings (idealmente viriam de banco de dados)
var rules = new List<string>
{
    "quantidade>10 E valor>1000 ENTAO 15",
    "categoria=VIP ENTAO 20",
    "primeiraCompra=true ENTAO 10"
};

Console.WriteLine("=== Carrinho 1 ===");
var context = new Context(cart1);
foreach (var rule in rules)
{
    calculator.CalculateDiscount(cart1, rule);
}

Console.WriteLine("\n=== Carrinho 2 ===");
context = new Context(cart2);
foreach (var rule in rules)
{
    calculator.CalculateDiscount(cart2, rule);
}

Console.WriteLine("\n=== Carrinho 3 ===");
context = new Context(cart3);
foreach (var rule in rules)
{
    calculator.CalculateDiscount(cart3, rule);
}