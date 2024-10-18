using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models1;

namespace DataAccess.Repositories
{
    public class FileAccessRepository : RepositoryBase<Domain.Models1.FileAccess>, IFileAccessRepository
    {
        public FileAccessRepository(CharityDB1Context repositoryContext) : base(repositoryContext)
        {
        }
    }
}
