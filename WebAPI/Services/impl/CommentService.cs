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
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;
        private CommentConverter converter = new CommentConverter();

        public CommentService(ICommentRepository commentRepository)
        {
            this._commentRepository = commentRepository;
        }
        public void Delete(long id)
        {
            _commentRepository.Delete(id);
            _commentRepository.Save();
        }

        public IEnumerable<List<CommentRequest>> GetAll()
        {
            List<CommentTable> tables = _commentRepository.GetAll();
            List<CommentRequest> reqs = new List<CommentRequest>();
            foreach(CommentTable item in tables)
            {
                var req = new CommentRequest();
                req = converter.toReq(item);
                reqs.Add(req);
            }
            yield return reqs;
        }

        public CommentRequest GetById(long id)
        {
            return converter.toReq(_commentRepository.GetById(id));
        }

        public void Insert(CommentRequest req)
        {
            _commentRepository.Insert(converter.toTable(req));
            _commentRepository.Save();
        }

        public void Update(CommentRequest req)
        {
            var table = _commentRepository.GetById(req.Id);
            converter.toTable(ref table, req);
            _commentRepository.Update(table);
            _commentRepository.Save();
        }
    }
}
