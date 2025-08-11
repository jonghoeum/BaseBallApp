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

        [HttpPost("login")]
        public async Task<IActionResult> Login(MemberClass model)
        {
            var member = await _db.Members.FirstOrDefaultAsync(m => m.UserId == model.UserId);
            if (member == null)
                return Unauthorized("아이디 또는 비밀번호가 틀렸습니다.");

            bool verified = BCrypt.Net.BCrypt.Verify(model.Password, member.Password);
            if (!verified)
                return Unauthorized("아이디 또는 비밀번호가 틀렸습니다.");

            // 성공 시, 세션 토큰 생성 및 반환 예시 (간단히 UserId만 반환)
            // JWT 토큰이나 쿠키 방식은 별도 구현 필요.
            return Ok(new { UserId = member.UserId, Role = member.Role, Name = member.Name });
        }

    }
}