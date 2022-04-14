using System;
using System.Collections.Generic;
using System.Text;

namespace LivraisonModels
{
   public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
      

        public CategoryModel()
        {

        }

        public CategoryModel(int id, string name) : this()
        {
            Id = id;
            Name = name;
          
        }

        

        public override string ToString()
        {
            return Name;
        }

        public static T DeserializeObject<T>(string data)
        {
            throw new NotImplementedException();
        }
    }
}
