using _22_NguyenThaiThinh_Assignment2.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace _22_NguyenThaiThinh_Assignment2.Repository
{
    public class ProductRepository
    {
        public ProductRepository() { }
        public void Add(Product p)
        {
            try
            {
                var db = new Ass2_Prn221_Bl5Context();
                if(db.Products.FirstOrDefault(pr=>pr.ProductName == p.ProductName) == null)
                {
                    db.Products.Add(p);
                    db.SaveChanges();
                }
                else
                {
                    p.QuantityPerUnit += db.Products.FirstOrDefault(pr => pr.ProductName == p.ProductName).QuantityPerUnit;
                    db.Entry(p).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }catch (Exception ex)
            {

            }
        }
    }
}
