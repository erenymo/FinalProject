using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using NotImplementedException = System.NotImplementedException;

namespace DataAccess.Concrete.EntityFramework;

public class EfProductDal:EfEntityRepositoryBase<Product, NorthwindContext>,IProductDal
{
    
}