using CSharp_Project.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_Project.Services
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
