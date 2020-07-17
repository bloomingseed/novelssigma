using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelDownloader
{
	public partial class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Novel Downloader v1.0");
			Welcome();
			string userInput = null;
			do
			{
				Console.Write(">");
				userInput = Console.ReadLine();
				try
				{
					if (userInput.Trim() == ".help") Help();
					else if(userInput.Trim() != ".exit") Process(userInput);
				} 
				catch(UnauthorizedAccessException err) { Console.WriteLine(err.Message + ". Try running this program as Administrator or moving to non-system directory.\nCurrent path: " + Environment.CurrentDirectory); }
				catch(Exception err) { Console.WriteLine(err.Message); }
			} while (userInput.Trim() != ".exit");
		}
		
	}
}
