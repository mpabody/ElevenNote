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

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var _db = new ApplicationDbContext())
            {
                var query = _db.Categories
                        .Select(
                            n =>
                                new CategoryListItem
                                {
                                    CategoryName = n.CategoryName
                                }
                        );
                return query.ToList();
            }
        }
        // No need for details view -- 'Notes' instead - lists all notes associated with category
        
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
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryID == categoryID);

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
