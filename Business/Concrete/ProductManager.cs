using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public IDataResult<List<Product>> GetAll()
    {
        // İş Kodları (bir iş sınıfı başka sınıfları newlemez!)

        if (DateTime.Now.Hour == 16)
        {
            return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
        }
        
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
    }

    public IDataResult<List<Product>> GetAllByCategoryId(int id)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=> p.CategoryId == id));
    }

    public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice <= max && p.UnitPrice >= min));
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
    }

    public IDataResult<Product> GetById(int productId)
    {
        return new SuccessDataResult<Product>( _productDal.Get(p => p.ProductId == productId));
    }
    
    [ValidationAspect(typeof(ProductValidator))] // Product Validator'deki kurallara göre Add methodunu Doğrula
    public IResult Add(Product product)
    {
        _productDal.Add(product);
        
        return new SuccessResult(Messages.ProductAdded);
    }
}