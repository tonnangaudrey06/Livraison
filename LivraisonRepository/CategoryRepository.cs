﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivraisonRepository
{
   public class CategoryRepository
    {
        private readonly LivraisonEntities db;
        public CategoryRepository()
        {
            db = new LivraisonEntities();
        }

        public Category Get(int id)
        {
            return db.Categories.FirstOrDefault(x => x.Id == id);
        }

        public Category Get(string name)
        {
            return db.Categories.FirstOrDefault(x => x.Name == name);
        }

        public Category Add(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            var u = Get(category.Name);
            if (u != null)
                throw new DuplicateWaitObjectException($"Category name {category.Name} already exist !");

            category = db.Categories.Add(category);
            db.SaveChanges();

            return category;
        }

        public Category Set(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return category;
        }

        public Category Delete(int id)
        {
            var category = Get(id);
            db.Categories.Remove(category);
            db.SaveChanges();

            return category;
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return db.Categories.Where(predicate).ToArray();
        }
    }
}
