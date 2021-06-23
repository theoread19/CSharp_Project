
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_Project.Services
{
    public interface ICategoryService 
    {
        IEnumerable<List<CategoryRequest>> GetAll();
        CategoryRequest GetById(long id);
        void Insert(CategoryRequest req);
        void Update(CategoryRequest req);
        void Delete(long id);
    }
}
