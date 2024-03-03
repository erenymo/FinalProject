using Core.Entities;

namespace Entities.Concrete;

// internal : bu class'a sadece bu katmandakiler erişebilir
public class Product:IEntity // public: bu class'a diğer katmanlar da erişebilir
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string ProductName { get; set; }
    public short UnitsInStock { get; set; }
    public decimal UnitPrice { get; set; }
}
