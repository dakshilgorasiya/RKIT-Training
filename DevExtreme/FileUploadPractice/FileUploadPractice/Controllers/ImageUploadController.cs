using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FileUploadPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            // Path to bin folder
            var binPath = Path.Combine(Directory.GetCurrentDirectory(), "bin");

            if (!Directory.Exists(binPath))
                Directory.CreateDirectory(binPath);

            var filePath = Path.Combine(binPath, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new
            {
                fileName = file.FileName,
                filePath = filePath
            });
        }

        [HttpPost("uploadMultiple")]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return BadRequest("No files uploaded");

            var binPath = Path.Combine(Directory.GetCurrentDirectory(), "bin");

            if (!Directory.Exists(binPath))
                Directory.CreateDirectory(binPath);

            foreach (var file in files)
            {
                var filePath = Path.Combine(binPath, file.FileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);
            }

            return Ok("Uploaded");
        }

        [HttpPost("chunk-upload")]
        public async Task<IActionResult> ChunkUpload(
        IFormFile file,
        [FromForm] string chunkMetadata)
        {
            if (file == null || chunkMetadata == null)
                return BadRequest();

            var metadata = JsonSerializer.Deserialize<ChunkMetadata>(chunkMetadata, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Console.WriteLine($"ChunkIndex: {metadata.Index}, TotalChunks:  {metadata.TotalCount}, FileGuid: {metadata.FileGuid}, FileName:  {metadata.FileName}");

            var tempPath = Path.Combine(Directory.GetCurrentDirectory(), "bin", "temp");

            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);

            var tempFilePath = Path.Combine(tempPath, metadata.FileGuid + ".tmp");

            using (var stream = new FileStream(tempFilePath, FileMode.Append))
            {
                await file.CopyToAsync(stream);
            }

            // If last chunk → move to final file
            if (metadata.Index == metadata.TotalCount - 1)
            {
                var finalPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "bin",
                    metadata.FileName
                );

                System.IO.File.Move(tempFilePath, finalPath, true);
            }

            return Ok();
        }
    }

    public class ChunkMetadata
    {
        public int Index { get; set; }
        public int TotalCount { get; set; }
        public string FileGuid { get; set; }
        public string FileName { get; set; }
    }
}

