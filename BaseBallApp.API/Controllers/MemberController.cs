using BaseBallApp.API.Data;
using BaseBallApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BaseBallApp.API.Controllers
{
    [ApiController]
    [Route("api/member")]
    public class MemberController : ControllerBase
    {
        private readonly AppDbContext _db;
        public MemberController(AppDbContext db) => _db = db;

        [HttpPost("register")]
        public async Task<IActionResult> Register(MemberClass model)
        {
            if (_db.Members.Any(m => m.UserId == model.UserId))
                return Conflict("이미 존재하는 아이디입니다.");

            var member = new MemberClass
            {
                UserId = model.UserId,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                Name = model.Name,
                Nickname = model.Nickname,
                Email = model.Email,
                Role = model.Role,
                CreatedAt = DateTime.Now  // 현재 시간 할당
            };

            _db.Members.Add(member);
            await _db.SaveChangesAsync();

            return Ok("회원가입 성공");
        }
    }
}
