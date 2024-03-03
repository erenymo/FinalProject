using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI;

class Program
{
    static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        // SOLID (Open Closed Principle = Projene yeni bir özellik ekliyorsan mevcuttaki hiçbir koda dokunamazsın. (InMemory'den EntityFramework'e geçiş.) )
        foreach (var product in productManager.GetByUnitPrice(40,100))
        {
            Console.WriteLine(product.ProductName);
        }
    }
}
