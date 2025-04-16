namespace BaseBallApp.API.Data
{
	public class TrophyClass
	{
		public int IDX { get; set; } = 0;
		public required string TITLE { get; set; }
		public required string CONTENT { get; set; }
		public required string FILE { get; set; }
		public required string FILENAME { get; set; }
		public int USE { get; set; } = 0;
		public DateTime REG_DATE { get; set; }
	}
}
