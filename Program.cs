using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelDownloader
{
	class Program
	{
		static void Main(string[] args)
		{

			Console.WriteLine(args.Length);
			foreach (string arg in args)
				Console.WriteLine(arg);
			Console.ReadKey(false);

		}
	}
}
