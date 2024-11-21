using BackendBusinessObject;

using BackendDatabaseAccess;

using Microsoft.EntityFrameworkCore;

namespace BackendBusinessLogic.Services;

public class ShopServices(Context _context)
{

    /// <summary>
    /// Calls endpoint to read data
    /// </summary>
    /// <returns>Data from database</returns>
    public async Task<List<Products>> GetProducts()
    {
        List<Products> result = await _context.ProductData.ToListAsync();
        return result;

    }

    /// <summary>
    /// Calls endpoint to create data
    /// </summary>
    /// <returns>Data to database</returns>
    public async Task<Products> AddProducts(Products products)
    {
        _ = await _context.ProductData.AddAsync(products);
        _ = await _context.SaveChangesAsync();
        return products;
    }

    /// <summary>
    /// Calls endpoint to delete data
    /// </summary>
    /// <returns>Nothing</returns>
    public async Task<bool> DeleteProducts(int Id)
    {
        Products? product = await _context.ProductData.FindAsync(Id);
        if (product == null)
        {
            return false;
        }

        _ = _context.ProductData.Remove(product);
        _ = await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Calls endpoint to update data
    /// </summary>
    /// <returns>Data to database</returns>
    public async Task<Products?> UpdateProducts(int id, Products updatedProduct)
    {
        Products? product = await _context.ProductData.FindAsync(id);
        if (product == null)
        {
            return null;
        }

        product.Name = updatedProduct.Name;
        product.UpdateDate = updatedProduct.UpdateDate;
        product.RegistrationDate = updatedProduct.RegistrationDate;


        _ = _context.ProductData.Update(product);
        _ = await _context.SaveChangesAsync();
        return product;
    }
}
