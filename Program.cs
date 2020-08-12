using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NovelsSigma
{
	public partial class Program
	{

		[STAThread]
		public static void Main(string[] args)
		{


			//if (args.Length == 0)
			//{
			//	//Welcome();
			//	//string userInput = null;
			//	//do
			//	//{
			//	//	Console.Write(">");
			//	//	userInput = Console.ReadLine();
			//	//	try
			//	//	{
			//	//		if (userInput.Trim() == ".help") Help();
			//	//		else if (userInput.Trim() == ".supported") Supported();
			//	//		else if (userInput.Trim() == ".version") Version();
			//	//		else if (userInput.Trim() != ".exit") Process(userInput);
			//	//	}
			//	//	catch (UnauthorizedAccessException err) { Console.WriteLine(err.Message + ". Try running this program as Administrator or moving to non-system directory.\nCurrent path: " + Environment.CurrentDirectory); }
			//	//	catch (Exception err) { Console.WriteLine(err.Message); }
			//	//} while (userInput.Trim() != ".exit");
			try
			{
				Application.Run(new MainForm());
			}
			catch (Exception err) { MessageBox.Show(err.Message + "\r\nPlease visit development site for help.", "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error); }

			//}
			//else
			//{
			//	for(int i = 0; i<args.Length; ++i)
			//	{
			//		Console.WriteLine($"Attempting download link no.{i + 1}..");
			//		//Process(args[i]);
			//	}
			//}
		}

	}
}
