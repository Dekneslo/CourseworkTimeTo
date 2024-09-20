using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTO;

namespace BusinessLogic.Interfaces
{
    public interface IPostService
    {
        Task<List<PostDTO>> GetAllPostsAsync();
        Task CreatePostAsync(PostDTO postDto);
        Task UpdatePostAsync(int id, PostDTO postDto);
        Task DeletePostAsync(int id);
    }
}
