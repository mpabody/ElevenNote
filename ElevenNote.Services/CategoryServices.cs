using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        public CategoryService()
        {

        }

        public bool CreateCategory(CategoryCreate model)
        {
            var entity = new Category()
            {
                CategoryName = model.CategoryName
            };

            using (var _db = new ApplicationDbContext())
            {
                _db.Categories.Add(entity);
                return _db.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var _db = new ApplicationDbContext())
            {
                var query = _db.Categories
                        .Select(
                            c =>
                                new CategoryListItem
                                {
                                    CategoryID = c.CategoryID,
                                    CategoryName = c.CategoryName
                                }
                        );
                return query.ToList();
            }
        }

        public bool UpdateCategory(CategoryListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryID == model.CategoryID);

                entity.CategoryID = model.CategoryID;
                entity.CategoryName = model.CategoryName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int categoryID)
        {
            using (var _db = new ApplicationDbContext())
            {
                var entity =
                    _db
                    .Categories
                    .Find(categoryID);

                _db.Categories.Remove(entity);

                return _db.SaveChanges() == 1;
            }
        }
    }
}
