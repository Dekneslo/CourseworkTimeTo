using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly CharityDBContext _context;

        public MediaRepository(CharityDBContext context)
        {
            _context = context;
        }

        public async Task UploadPostMediaAsync(int postId, Domain.Models.File media)
        {
            var postMedia = new PostMedium { IdPost = postId, IdFile = media.IdFile };
            await _context.PostMedia.AddAsync(postMedia);
            await _context.SaveChangesAsync();
        }

        public async Task UploadCourseMediaAsync(int courseId, Domain.Models.File media)
        {
            var courseMedia = new CourseMedium { IdCourse = courseId, IdFile = media.IdFile };
            await _context.CourseMedia.AddAsync(courseMedia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMediaAsync(int mediaId, Domain.Models.File newMedia)
        {
            var existingMedia = await _context.Files.FindAsync(mediaId);
            if (existingMedia != null)
            {
                existingMedia.FilePath = newMedia.FilePath;
                existingMedia.FileSize = newMedia.FileSize;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteMediaAsync(int mediaId)
        {
            var media = await _context.Files.FindAsync(mediaId);
            if (media != null)
            {
                _context.Files.Remove(media);
                await _context.SaveChangesAsync();
            }
        }
    }
}
