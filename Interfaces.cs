using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelDownloader
{
	public partial class Program
	{
		public static void Welcome()
		{
			Console.WriteLine("You are at main interface.");
			Console.WriteLine("Enter the novel's frontpage..");
			HorizontalLine();
		}
		public static void HorizontalLine()
		{
			Console.WriteLine(new string('-', Console.WindowWidth));
		}
		public static void Help()
		{
			Console.WriteLine("You are at 'help' interface.");
			Console.WriteLine("Available commands are listed below:");
			Console.WriteLine(".supported\t - To list all supported novel websites.");
			Console.WriteLine(".exit\t- To exit the application.");
			Console.WriteLine("At main interface, enter the novel's front-page url to automatically download all available chapters.");
			HorizontalLine();
			Welcome();
		}
	}
}
