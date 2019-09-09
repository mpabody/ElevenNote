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
        private readonly Guid _userID;
        public CategoryService(Guid userID)
        {
            _userID = userID;
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

        ////////////////////////////////////////
    }
}
