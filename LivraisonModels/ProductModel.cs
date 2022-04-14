using System;
using System.Collections.Generic;
using System.Text;

namespace LivraisonModels
{
   public class ProductModel
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Lieu { get; set; }
        public string Photo { get; set; }

        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
      
        public DateTime CreatedAt { get; set; }

        public string CreatedAtToString
        {
            get => CreatedAt.ToString();
            set => CreatedAtToString = value;
        }
        public ProductModel(int v)
        {

        }

        public ProductModel(int id,string reference,string lieu,
        string photo, int categoryId, DateTime createdAt) : this()
        {
            Id = id;
            Reference = reference;
            Lieu = lieu;
            Photo = photo;
            CategoryId = categoryId;
            CreatedAt = createdAt;
        }

        public ProductModel(int id,string reference, string lieu, string photo, int categoryId, CategoryModel category,  DateTime createdAt)
            : this(id,reference,lieu , photo, categoryId,  createdAt)
        {

            Category = category;
          
        }

        public ProductModel(int v, Func<object, bool> equals1, Func<object, bool> equals2, Func<object, bool> equals3, DateTime now) : this(v)
        {
        }

        public static string SerializeObject(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public static T DeserializeObject<T>(string data)
        {
            throw new NotImplementedException();
        }
    }
}
