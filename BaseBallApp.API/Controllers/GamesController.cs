using BaseBallApp.API.Data;
using BaseBallApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using static System.Net.WebRequestMethods;

namespace BaseBallApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly AppDbContext _db;
        public GamesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("games")]
        public async Task<ActionResult<IEnumerable<GameClass>>> GetGamesAsync()
        {
            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                var query = @"SELECT 
                            G.IDX,
                            G.HOMETEAM,
                            G.AWAYTEAM,
                            G.STATUS,
                            G.PLACE,
                            G.CATEGORY,
                            G.STARTTIME,
                            E1.[FILE] AS HomeTeamFile,
                            E2.[FILE] AS AwayTeamFile
                        FROM 
                            BaseBall.dbo.Game G
                        LEFT JOIN 
                            BaseBall.dbo.TeamEmblem E1 ON G.HOMETEAM = E1.TEAMNAME
                        LEFT JOIN 
                            BaseBall.dbo.TeamEmblem E2 ON G.AWAYTEAM = E2.TEAMNAME;";
                var games = await _db.Game
                                        .FromSqlRaw(query)
                                        .ToListAsync();

                await transaction.CommitAsync();  // 성공 시 커밋
                return Ok(games);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();  // 실패 시 롤백
                return StatusCode(500, $"오류 발생: {ex.Message}");
            }
        }

        [HttpGet("gamescore")]
        public async Task<ActionResult<IEnumerable<GameScoreClass>>> GetGamesScoreAsync()
        {
            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                var query = @"SELECT * 
                            FROM GAMESCORE ";
                var gamescore = await _db.GameScores
                                        .FromSqlRaw(query)
                                        .ToListAsync();

                await transaction.CommitAsync();  // 성공 시 커밋
                return Ok(gamescore);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();  // 실패 시 롤백
                return StatusCode(500, $"오류 발생: {ex.Message}");
            }
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertGameAsync([FromBody] GameWithScores request)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                //var sql = "INSERT INTO dbo.Trophy (TITLE, CONTENT, [FILE], FILENAME) VALUES (@P0, @P1, @P2, @P3)";
                //var result = await _db.Database.ExecuteSqlRawAsync(sql, request.TITLE, request.CONTENT, request.FILE, request.FILENAME);
                //기존 쿼리
                //var sql = @"INSERT INTO dbo.Game (HOMETEAM, AWAYTEAM, STATUS, PLACE, CATEGORY, STARTTIME) VALUES (@p0, @p1, @p2, @p3, @p4, @p5); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                //int newIdx = await _db.Database.ExecuteSqlRawAsync(sql,
                //    request.Game.HOMETEAM,
                //    request.Game.AWAYTEAM,
                //    request.Game.STATUS,
                //    request.Game.PLACE,
                //    request.Game.CATEGORY,
                //    request.Game.STARTTIME
                //    );
                var sql = @"
                            INSERT INTO dbo.Game (HOMETEAM, AWAYTEAM, STATUS, PLACE, CATEGORY, STARTTIME)
                            VALUES (@p0, @p1, @p2, @p3, @p4, @p5);
                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                int gameId;

                using var cmd = _db.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = sql;
                cmd.Transaction = _db.Database.CurrentTransaction.GetDbTransaction();

                cmd.Parameters.Add(new SqlParameter("@p0", request.Game.HOMETEAM));
                cmd.Parameters.Add(new SqlParameter("@p1", request.Game.AWAYTEAM));
                cmd.Parameters.Add(new SqlParameter("@p2", request.Game.STATUS));
                cmd.Parameters.Add(new SqlParameter("@p3", request.Game.PLACE));
                cmd.Parameters.Add(new SqlParameter("@p4", request.Game.CATEGORY));
                cmd.Parameters.Add(new SqlParameter("@p5", request.Game.STARTTIME));

                await _db.Database.OpenConnectionAsync();
                var result = await cmd.ExecuteScalarAsync();
                gameId = Convert.ToInt32(result); //참조키
                if (request.Scores.Count() > 0)
                {
                    foreach(var score in request.Scores)
                    {
                        
                        var sql2 = " INSERT INTO dbo.GameScore (REF_IDX, TEAM, S1 ,S2 ,S3 ,S4 ,S5, S6 ,S7, S8, S9, RUNS, HITS, ERRORS, BALLS) VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14) ";
                        
                        using var scoreCmd = _db.Database.GetDbConnection().CreateCommand();
                        scoreCmd.CommandText = sql2;
                        scoreCmd.Transaction = _db.Database.CurrentTransaction.GetDbTransaction();
                        //cmd.CommandText = sql2;
                        //cmd.Transaction = _db.Database.CurrentTransaction.GetDbTransaction();

                        scoreCmd.Parameters.Add(new SqlParameter("@p0", gameId));
                        scoreCmd.Parameters.Add(new SqlParameter("@p1", score.TEAM));
                        scoreCmd.Parameters.Add(new SqlParameter("@p2", score.S1));
                        scoreCmd.Parameters.Add(new SqlParameter("@p3", score.S2));
                        scoreCmd.Parameters.Add(new SqlParameter("@p4", score.S3));
                        scoreCmd.Parameters.Add(new SqlParameter("@p5", score.S4));
                        scoreCmd.Parameters.Add(new SqlParameter("@p6", score.S5));
                        scoreCmd.Parameters.Add(new SqlParameter("@p7", score.S6));
                        scoreCmd.Parameters.Add(new SqlParameter("@p8", score.S7));
                        scoreCmd.Parameters.Add(new SqlParameter("@p9", score.S8));
                        scoreCmd.Parameters.Add(new SqlParameter("@p10", score.S9));
                        scoreCmd.Parameters.Add(new SqlParameter("@p11", score.RUNS));
                        scoreCmd.Parameters.Add(new SqlParameter("@p12", score.HITS));
                        scoreCmd.Parameters.Add(new SqlParameter("@p13", score.ERRORS));
                        scoreCmd.Parameters.Add(new SqlParameter("@p14", score.BALLS));

                        // INSERT 실행
                        await scoreCmd.ExecuteNonQueryAsync();
                    }
                }

                await transaction.CommitAsync();
                return Ok();
                //return Ok($"{result}개의 행이 추가되었습니다.");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, $"INSERT 실패: {ex.Message}");
            }
        }
        //수정은 확인필요 - 내일 확인해봐야함.
        [HttpPost("edit")]
        public async Task<IActionResult> EditGameAsync([FromBody] GameWithScores request)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                var sql = @"
                            UPDATE dbo.Game SET HOMETEAM = @p0, AWAYTEAM = @p1, STATUS = @p2, PLACE = @p3, CATEGORY = @p4, STARTTIME = @p5
                            WHERE [IDX] = @p6;
                            ";

                //int gameId;

                using var cmd = _db.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = sql;
                cmd.Transaction = _db.Database.CurrentTransaction.GetDbTransaction();

                cmd.Parameters.Add(new SqlParameter("@p0", request.Game.HOMETEAM));
                cmd.Parameters.Add(new SqlParameter("@p1", request.Game.AWAYTEAM));
                cmd.Parameters.Add(new SqlParameter("@p2", request.Game.STATUS));
                cmd.Parameters.Add(new SqlParameter("@p3", request.Game.PLACE));
                cmd.Parameters.Add(new SqlParameter("@p4", request.Game.CATEGORY));
                cmd.Parameters.Add(new SqlParameter("@p5", request.Game.STARTTIME));
                cmd.Parameters.Add(new SqlParameter("@p6", request.Game.IDX));

                await _db.Database.OpenConnectionAsync();
                await cmd.ExecuteNonQueryAsync();
                //var result = await cmd.ExecuteScalarAsync();
                //gameId = Convert.ToInt32(result); //참조키
                if (request.Scores.Count() > 0)
                {
                    foreach (var score in request.Scores)
                    {
                        //업데이트
                        if(score.UPDATE == true) 
                        { 
                        //var sql2 = " INSERT INTO dbo.GameScore (REF_IDX, TEAM, S1 ,S2 ,S3 ,S4 ,S5, S6 ,S7, S8, S9, RUNS, HITS, ERRORS, BALLS) VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14) ";
                            var sql2 = " UPDATE dbo.GameScore SET TEAM = @p0, S1 = @p1 ,S2 = @p2 ,S3 = @p3 ,S4 = @p4 ,S5 = @p5, S6 = @p6,S7 = @p7, S8 = @p8, S9 = @p9, RUNS = @p10, HITS = @p11, ERRORS = @p12, BALLS = @p13  WHERE IDX = @p14";

                            using var scoreCmd = _db.Database.GetDbConnection().CreateCommand();
                            scoreCmd.CommandText = sql2;
                            scoreCmd.Transaction = _db.Database.CurrentTransaction.GetDbTransaction();
                            //cmd.CommandText = sql2;
                            //cmd.Transaction = _db.Database.CurrentTransaction.GetDbTransaction();

                            //scoreCmd.Parameters.Add(new SqlParameter("@p0", gameId));
                            scoreCmd.Parameters.Add(new SqlParameter("@p0", score.TEAM));
                            scoreCmd.Parameters.Add(new SqlParameter("@p1", score.S1));
                            scoreCmd.Parameters.Add(new SqlParameter("@p2", score.S2));
                            scoreCmd.Parameters.Add(new SqlParameter("@p3", score.S3));
                            scoreCmd.Parameters.Add(new SqlParameter("@p4", score.S4));
                            scoreCmd.Parameters.Add(new SqlParameter("@p5", score.S5));
                            scoreCmd.Parameters.Add(new SqlParameter("@p6", score.S6));
                            scoreCmd.Parameters.Add(new SqlParameter("@p7", score.S7));
                            scoreCmd.Parameters.Add(new SqlParameter("@p8", score.S8));
                            scoreCmd.Parameters.Add(new SqlParameter("@p9", score.S9));
                            scoreCmd.Parameters.Add(new SqlParameter("@p10", score.RUNS));
                            scoreCmd.Parameters.Add(new SqlParameter("@p11", score.HITS));
                            scoreCmd.Parameters.Add(new SqlParameter("@p12", score.ERRORS));
                            scoreCmd.Parameters.Add(new SqlParameter("@p13", score.BALLS));
                            scoreCmd.Parameters.Add(new SqlParameter("@p14", score.IDX));
                            await scoreCmd.ExecuteNonQueryAsync();
                        }
                        // INSERT 실행
                        else
                        {
                            var sql2 = " INSERT INTO dbo.GameScore (REF_IDX, TEAM, S1 ,S2 ,S3 ,S4 ,S5, S6 ,S7, S8, S9, RUNS, HITS, ERRORS, BALLS) VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14) ";

                            using var scoreCmd = _db.Database.GetDbConnection().CreateCommand();
                            scoreCmd.CommandText = sql2;
                            scoreCmd.Transaction = _db.Database.CurrentTransaction.GetDbTransaction();
                            //cmd.CommandText = sql2;
                            //cmd.Transaction = _db.Database.CurrentTransaction.GetDbTransaction();

                            scoreCmd.Parameters.Add(new SqlParameter("@p0", request.Game.IDX));
                            scoreCmd.Parameters.Add(new SqlParameter("@p1", score.TEAM));
                            scoreCmd.Parameters.Add(new SqlParameter("@p2", score.S1));
                            scoreCmd.Parameters.Add(new SqlParameter("@p3", score.S2));
                            scoreCmd.Parameters.Add(new SqlParameter("@p4", score.S3));
                            scoreCmd.Parameters.Add(new SqlParameter("@p5", score.S4));
                            scoreCmd.Parameters.Add(new SqlParameter("@p6", score.S5));
                            scoreCmd.Parameters.Add(new SqlParameter("@p7", score.S6));
                            scoreCmd.Parameters.Add(new SqlParameter("@p8", score.S7));
                            scoreCmd.Parameters.Add(new SqlParameter("@p9", score.S8));
                            scoreCmd.Parameters.Add(new SqlParameter("@p10", score.S9));
                            scoreCmd.Parameters.Add(new SqlParameter("@p11", score.RUNS));
                            scoreCmd.Parameters.Add(new SqlParameter("@p12", score.HITS));
                            scoreCmd.Parameters.Add(new SqlParameter("@p13", score.ERRORS));
                            scoreCmd.Parameters.Add(new SqlParameter("@p14", score.BALLS));

                            // INSERT 실행
                            await scoreCmd.ExecuteNonQueryAsync();
                        }
                    }
                }

                await transaction.CommitAsync();
                return Ok();
                //return Ok($"{result}개의 행이 추가되었습니다.");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, $"UPDATE 실패: {ex.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteGame(int id) // 또는 string id
        {
            //var games = await _db.Game.FindAsync(id);
            //if (games == null) return NotFound(new { success = false, message = "데이터를 찾을 수 없습니다." });

            //_db.Game.Remove(games);
            //await _db.SaveChangesAsync();

            //return Ok(new { success = true, message = "삭제가 완료되었습니다." });

            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                var sql = "DELETE FROM dbo.Game WHERE IDX = @id";

                using var cmd = _db.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = sql;
                cmd.Transaction = _db.Database.CurrentTransaction.GetDbTransaction();

                cmd.Parameters.Add(new SqlParameter("@id", id));

                await _db.Database.OpenConnectionAsync();

                var result = await cmd.ExecuteNonQueryAsync();

                //gamescore 도 삭제
                var sql2 = "DELETE FROM dbo.GameScore WHERE REF_IDX = @id";
                using var cmd2 = _db.Database.GetDbConnection().CreateCommand();
                cmd2.CommandText = sql2;
                cmd2.Transaction = _db.Database.CurrentTransaction.GetDbTransaction();
                cmd2.Parameters.Add(new SqlParameter("@id", id));

                if (result == 0)
                {
                    await transaction.RollbackAsync();
                    return NotFound(new { success = false, message = "삭제할 데이터가 없습니다." });
                }

                await transaction.CommitAsync();
                return Ok(new { success = true, message = "삭제가 완료되었습니다." });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, $"삭제 실패: {ex.Message}");
            }
        }
    }
}
