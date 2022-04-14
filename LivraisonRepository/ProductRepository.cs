using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivraisonRepository
{
   public class ProductRepository
    {
        private readonly LivraisonEntities db;
        public ProductRepository()
        {
            db = new LivraisonEntities();
        }

        public Product Get(int id)
        {
            return db.Products.FirstOrDefault(x => x.Id == id);
        }

        public Product Get(string reference)
        {
            return db.Products.FirstOrDefault(x => x.Reference.ToLower() == reference.ToLower());
        }

        public Product Add(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            var p = Get(product.Reference);
            if (p != null)
                throw new DuplicateWaitObjectException($"Product code {product.Reference} already exist !");


            product = db.Products.Add(product);
            db.SaveChanges();

            return product;
        }

        public Product Set(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            var currentDb = new LivraisonEntities();
            var oldProduct = currentDb.Products.Find(product.Id);

            if (oldProduct == null)
                throw new KeyNotFoundException($"Product not found !");

            var u = currentDb.Products.FirstOrDefault(x => x.Reference.ToLower() == product.Reference.ToLower());
            if (u != null && u.Id != oldProduct.Id)
                throw new DuplicateWaitObjectException($"Product code {product.Reference} already exist !");

            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return product;
        }

        public Product Delete(int id)
        {
            var product = Get(id);
            db.Products.Remove(product);
            db.SaveChanges();

            return product;
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return db.Products.Where(predicate).ToArray();
        }
    }
}

