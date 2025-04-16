using BaseBallApp.Pages;
using BaseBallApp.Shared.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Json;


namespace BaseBallApp.Data
{
	public class DataService
	{
		private readonly HttpClient _http;

		public DataService(HttpClient http)
		{
			_http = http;
		}

		public async Task<List<TrophyClass>> GetTrophiesAsync()
		{
			return await _http.GetFromJsonAsync<List<TrophyClass>>("api/Trophy");
		}
		//private readonly SqlConnectionConfiguration _configuration;

		//public DataService(SqlConnectionConfiguration configuration)
		//{
		//	_configuration = configuration;
		//}

		//public async Task<IEnumerable<TrophyClass>> GetTrophyData()
		//{
		//	IEnumerable<TrophyClass> rs = Enumerable.Empty<TrophyClass>();
		//	using (var conn = new SqlConnection(_configuration.Value))
		//	{
		//		string query = @" SELECT * FROM Trophy WHERE USE = '0' ";
		//		if (conn.State == ConnectionState.Closed)
		//			conn.Open();
		//		try
		//		{
		//			rs = await conn.QueryAsync<TrophyClass>(query);
		//		}
		//		catch (Exception ex)
		//		{
		//			//throw ex;
		//			Console.WriteLine(ex);
		//		}
		//		finally
		//		{
		//			if (conn.State == ConnectionState.Open)
		//				conn.Close();
		//		}
		//	}


		//	return rs;
		//}
	}
}
