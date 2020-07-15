using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelDownloader
{
	public partial class Program
	{
		public static void Process(string input)
		{
			Uri destinationFolder = null,
				frontpageUrl = null;
			try
			{
				frontpageUrl = new Uri(input);
				destinationFolder = new Uri(Environment.CurrentDirectory);
				Console.WriteLine(destinationFolder);
				Console.WriteLine(frontpageUrl);
			}
			catch (Exception err) { throw err; }
		}
	}
}
