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
			Console.WriteLine("Enter your commands here. Use .help command to show available commands.");
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
			Console.WriteLine(".exit\t\t- To exit the application.");
			Console.WriteLine(".help\t\t- To show this help interface.");
			Console.WriteLine(".supported\t - To list all supported novel websites.");
			Console.WriteLine(".version\t- To show this application's version.");
			Console.WriteLine();
			Console.WriteLine("Notes:");
			Console.WriteLine("\t- At main interface, enter the novel's front-page url to automatically download all chapters from that page until latest chapter.");
			Console.WriteLine("\t- Visit this github repo to receive more support and information: https://github.com/bloomingseed/novelssigma");
			HorizontalLine();
			Welcome();
		}
		public static void Supported()
		{
			Console.WriteLine("You are at 'supported' interface.");
			Console.WriteLine("Currently, downloading from these websites are fully supported:");
			Console.WriteLine("truyenfull.vn\t*");
			Console.WriteLine("sstruyen.com");
			Console.WriteLine();
			Console.WriteLine("Notes:");
			Console.WriteLine("\t- Websites marked with '*' are highly recommended.\n");
			HorizontalLine();
			Welcome();
		}
		public static void Version()
		{
			Console.WriteLine("You are at 'version' interface.");
			Console.WriteLine("Novels Sigma, version 1.0 .");
			HorizontalLine();
			Welcome();
		}
	}
}
