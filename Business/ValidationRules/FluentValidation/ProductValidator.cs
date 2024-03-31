using System.Data;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class ProductValidator:AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.ProductName).NotEmpty(); // ProductName kısmı boş olamaz.
        RuleFor(p => p.ProductName).MinimumLength(2); // ProductName minimum 2 karakter uzunlugunda olmalı.
        RuleFor(p => p.UnitPrice).NotEmpty(); // UnitPrice boş olamaz.
        RuleFor(p => p.UnitPrice).GreaterThan(0); // UnitPrice 0'dan büyük olmalı.
        RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
        RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
    }

    private bool StartWithA(string arg) // gönderdiğin productName
    {
        return arg.StartsWith("A"); // A ile başlıyorsa true döndürür.
    }
}
