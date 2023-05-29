using static System.Windows.Forms.Design.AxImporter;
using System.Text.Json;

namespace PlanesGame
{
	public static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		/// 
		public static MainForm MainForm = new MainForm();
		public static GameForm Game = new GameForm();

		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			Application.Run(MainForm);
		}
		public static double DistanceBetweenTwoPoints(Point p1, Point p2)
		{
			return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
		}
	}
	public class UserData
	{
        public List<int> Scores { get; set; }
		public string Username { get; set; }

		public UserData()
		{
			Username = "Default";
			Scores = new List<int>();
		}
		public override string ToString() { 
			return Username + " " + Scores.Count.ToString();
		}
		public static List<UserData> ReadUsersFromFile()
		{
			try
			{
				using FileStream json = File.OpenRead(@"..\..\..\users.json");
				return JsonSerializer.Deserialize<List<UserData>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});
			} 
			catch 
			{
				return new List<UserData>();
			}
		}
		public static async void WriteUsersToFile(IEnumerable<UserData> u)
		{
			await using var fileStream = File.Create(@"..\..\..\users.json");
			await JsonSerializer.SerializeAsync(fileStream, u);
		}
	}	
}