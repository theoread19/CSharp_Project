using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repository
{
    public interface ICommentRepository : IRepository<CommentTable>
    {
    }
}
