namespace BackendBusinessObject;

public class Products
{
    public int Id { get; set; }
    public DateOnly RegistrationDate { get; set; }
    public DateOnly UpdateDate { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}

public class CartProducts
{
    public int Id { get; set; }
    public List<Products> ProductsInCart { get; set; }
}