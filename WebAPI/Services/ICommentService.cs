using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs.Request;

namespace WebAPI.Services
{
    public interface ICommentService
    {
        IEnumerable<List<CommentRequest>> GetAll();
        CommentRequest GetById(long id);
        void Insert(CommentRequest req);
        void Update(CommentRequest req);
        void Delete(long id);
    }
}
