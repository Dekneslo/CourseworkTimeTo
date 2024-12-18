﻿using Domain.Contracts.FileContracts;
using Domain.Interfaces;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController (IFileService fileService)
        {
            _fileService = fileService;
        }

        /// <summary>
        /// Получение файлов пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     GET /api/File/1
        /// 
        /// </remarks>
        /// <param name="userId">ID пользователя</param>
        /// <returns>Список файлов пользователя</returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFilesByUser(int userId)
        {
            var files = await _fileService.GetFilesByUserAsync(userId);
            return Ok(files);
        }

        /// <summary>
        /// Загрузка файла
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /api/File/upload
        ///     {
        ///        "FileName" : "example.jpg",
        ///        "FilePath" : "base64encodeddata",
        ///        "FileType" : "image/jpeg",
        ///        "IdUser" : 1
        ///     }
        /// 
        /// </remarks>
        /// <param name="request">Запрос на загрузку файла</param>
        /// <returns>Информация о загруженном файле</returns>
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromBody] UploadFileRequest request)
        {
            var result = await _fileService.UploadFileAsync(request);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data); 
        }


        /// <summary>
        /// Обновление информации о файле
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /api/File
        ///     {
        ///         "IdFile": 1,
        ///         "FileName": "NewFileName.pdf",
        ///         "FileType": "application/pdf"
        ///     }
        /// 
        /// </remarks>
        /// <param name="request">Запрос на обновление файла</param>
        /// <returns>Результат операции</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateFile([FromBody] UpdateFileRequest request)
        {
            var result = await _fileService.UpdateFileAsync(request);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

        /// <summary>
        /// Удаление файла
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     DELETE /api/File/1
        /// 
        /// </remarks>
        /// <param name="id">ID файла</param>
        /// <returns>Результат операции</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            var result = await _fileService.DeleteFileAsync(id);
            if (!result.Success) return BadRequest(result.Errors);
            return NoContent();
        }

        /// <summary>
        /// Управление доступом к файлам
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /api/File/1/access
        ///     {
        ///        "UserId": 1,
        ///        "AccessType": "read"
        ///     }
        ///
        /// </remarks>
        /// <param name="fileId">ID файла</param>
        /// <param name="request">Запрос на управление доступом</param>
        /// <returns>Результат операции</returns>
        [HttpPost("{fileId}/access")]
        public async Task<IActionResult> ManageFileAccess(int fileId, [FromBody] AccessRequest request)
        {
            var result = await _fileService.SetFileAccessAsync(fileId, request.UserId, request.AccessType);
            if (!result.Success) return BadRequest(result.Errors);
            return Ok(result.Data);
        }

    }
}
