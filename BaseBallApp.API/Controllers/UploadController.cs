using Microsoft.AspNetCore.Mvc;

namespace BaseBallApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public UploadController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> Upload()
        {
            var files = Request.Form.Files;
            if (files.Count == 0)
                return BadRequest(new { Message = "업로드할 파일이 없습니다." });

            var uploadFolder = "gallery"; // wwwroot/gallery
            var uploadPath = Path.Combine(_env.WebRootPath, uploadFolder);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var savedFileUrls = new List<string>();

            foreach (var file in files)
            {
                var originalName = Path.GetFileName(file.FileName);
                var uniqueFileName = GetUniqueFileName(uploadPath, originalName);
                var fullPath = Path.Combine(uploadPath, uniqueFileName);

                using var stream = new FileStream(fullPath, FileMode.Create);
                await file.CopyToAsync(stream);

                // 브라우저 접근 가능한 URL 경로로 저장 (예: /gallery/파일명)
                savedFileUrls.Add($"/{uploadFolder}/{uniqueFileName}");
            }

            return Ok(new UploadResult
            {
                Success = true,
                Files = savedFileUrls
            });
        }

        // 중복 파일명 처리 로직
        private string GetUniqueFileName(string folderPath, string fileName)
        {
            var name = Path.GetFileNameWithoutExtension(fileName);
            var ext = Path.GetExtension(fileName);
            var uniqueName = fileName;
            int count = 1;

            while (System.IO.File.Exists(Path.Combine(folderPath, uniqueName)))
            {
                uniqueName = $"{name}_{count}{ext}";
                count++;
            }

            return uniqueName;
        }

        public class UploadResult
        {
            public bool Success { get; set; }
            public List<string> Files { get; set; } = new();
        }
    }
}
