using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repository;
using WebAPI.DTOs.Converters;
using Domain.Models;
using WebAPI.DTOs.Request;

namespace WebAPI.Services.impl
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private CategoryConverter converter = new CategoryConverter();

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public void Delete(long id)
        {
            _categoryRepository.Delete(id);
            _categoryRepository.Save();
        }

        public IEnumerable<List<CategoryRequest>> GetAll()
        {
            List<CategoryTable> tables = _categoryRepository.GetAll();
            List<CategoryRequest> reqs = new List<CategoryRequest>();
            foreach (CategoryTable item in tables)
            {
                var req = converter.toReq(item);
                reqs.Add(req);
            }
            yield return reqs;
        }

        public CategoryRequest GetById(long id)
        {
            return converter.toReq(_categoryRepository.GetById(id));
        }

        public void Insert(CategoryRequest req)
        {
            _categoryRepository.Insert(converter.toTable(req));
            _categoryRepository.Save();
        }

        public void Update(CategoryRequest req)
        {
            var table = _categoryRepository.GetById(req.Id);
            converter.toTable(ref table, req);
            _categoryRepository.Update(table);
            _categoryRepository.Save();
        }
    }
}
