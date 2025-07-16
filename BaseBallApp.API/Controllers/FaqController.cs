using BaseBallApp.API.Data;
using BaseBallApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BaseBallApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FaqController : ControllerBase
    {
        private readonly AppDbContext _db;
        public FaqController(AppDbContext db) => _db = db;

        [HttpGet("Faqs")]
        public async Task<ActionResult<IEnumerable<FaqViewModel>>> GetFaqsAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            string query = $@"
            WITH FaqsWithRowNum AS (
                SELECT 
                    CAST(ROW_NUMBER() OVER (ORDER BY CreatedAt DESC) AS INT) AS NO,
                    Idx, Title, Content, FileName1, FilePath1, ViewCount, CreatedAt,
                    CAST(COUNT(*) OVER() AS BIGINT) AS TotalCount
                FROM dbo.Faq
            )
            SELECT * 
            FROM FaqsWithRowNum
            WHERE NO BETWEEN {(pageNumber - 1) * pageSize + 1} AND {pageNumber * pageSize}
            ORDER BY NO";

            var result = await _db.FaqViewModel.FromSqlRaw(query).ToListAsync();

            return Ok(result);
            //var rawResult = await _db.Faq
            //.FromSqlRaw(query)
            //.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FaqClass>> GetFaqByIdAsync(int id)
        {
            try
            {
                var query = $@"
                SELECT TOP 1
                    Idx,
                    Title,
                    Content,
                    FileName1,
					FilePath1,
                    ViewCount,
                    CreatedAt
                FROM dbo.Faq
                WHERE Idx = @id";

                var param = new SqlParameter("@id", id);
                var result = await _db.Recruit.FromSqlRaw(query, param).FirstOrDefaultAsync();

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"상세 조회 실패: {ex.Message}");
            }
        }// =>
            //await _db.Faq.FirstOrDefaultAsync(f => f.IDX == id) ?? NotFound();

        [HttpPost("insert")]
        public async Task<IActionResult> InsertFaqAsync([FromBody] FaqClass faq)
        {
            _db.Faq.Add(faq);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateFaqAsync([FromBody] FaqClass faq)
        {
            var exist = await _db.Faq.FindAsync(faq.IDX);
            if (exist == null) return NotFound();

            exist.Title = faq.Title;
            exist.Content = faq.Content;
            exist.FileName1 = faq.FileName1;
            exist.FilePath1 = faq.FilePath1;

            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteFaqAsync(int id)
        {
            var faq = await _db.Faq.FindAsync(id);
            if (faq == null) return NotFound();

            _db.Faq.Remove(faq);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("increment-view")]
        public async Task<IActionResult> IncrementView([FromBody] int id)
        {
            var faq = await _db.Faq.FindAsync(id);
            if (faq == null) return NotFound();

            faq.ViewCount++;
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest("파일 없음");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "faq");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var path = Path.Combine(uploadsFolder, fileName);
            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);

            return Ok($"/faq/{fileName}");
        }
    }
}
