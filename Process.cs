using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HapCss;
using System.IO;
using System.ComponentModel;

namespace NovelsSigma
{

	public class Downloader
	{
		public Uri SaveLocation { get; set; }
		public ProcessResult Resource { get; set; }
		public int[] checkedIndices { get; set; }


		public Downloader(ProcessResult result, Uri saveLocation = null)
		{
			if (result == null)
				throw new Exception("Result is null");
			Resource = result;
			if (saveLocation == null)
				ResetSaveLocation();
		}
		public Downloader(Downloader otherDownloader)
		{
			SaveLocation = otherDownloader.SaveLocation == null ? null : new Uri(otherDownloader.SaveLocation.OriginalString);
			Resource = new Downloader.ProcessResult(otherDownloader.Resource);
			if (otherDownloader.checkedIndices == null)
				checkedIndices = null;
			else if(otherDownloader.checkedIndices.Length == 0)
				throw new ArgumentException("Please select (check) at least 1 chapter to download.");
			else if (otherDownloader.checkedIndices.Length > 0 && otherDownloader.checkedIndices.Length < otherDownloader.Resource.Chapters.Count)
			{
				checkedIndices = new int[otherDownloader.checkedIndices.Length];
				for (int i = 0; i < otherDownloader.checkedIndices.Length; ++i)
					checkedIndices[i] = otherDownloader.checkedIndices[i];
			}
		}
		public void Download(BackgroundWorker worker, DoWorkEventArgs e)
		{
			try
			{
				Directory.CreateDirectory(SaveLocation.OriginalString);
				double avrPercent = 0, taskPercent = 0;


				using (WebClient client = new WebClient())
					if (checkedIndices == null)
					{
						avrPercent = (double)100 / Resource.Chapters.Count;

						
						foreach (var link in Resource.Chapters)
						{
							if (worker.CancellationPending)
							{
								e.Cancel = true;
								return;
							}

							client.Headers["Content-Type"] = "text/html";
							client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
							client.Encoding = Encoding.UTF8;

							worker.ReportProgress((int)taskPercent, $"Downloading {link.Key}..");
							client.DownloadFile(link.Value, Path.Combine(SaveLocation.OriginalString, link.Key + ".html"));
							worker.ReportProgress((int)(taskPercent+=avrPercent), null);
						}
					}
					else
					{
						KeyValuePair<string, string> chapter;
						avrPercent = (double)100 / checkedIndices.Length;

						
						foreach (int i in checkedIndices)
						{
							if (worker.CancellationPending)
							{
								e.Cancel = true;
								return;
							}

							chapter = Resource.Chapters.ElementAt(i);
							client.Headers["Content-Type"] = "text/html";
							client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
							client.Encoding = Encoding.UTF8;

							worker.ReportProgress((int)taskPercent, $"Downloading {chapter.Key}..");
							client.DownloadFile(chapter.Value, Path.Combine(SaveLocation.OriginalString, chapter.Key + ".html"));
							worker.ReportProgress((int)(taskPercent += avrPercent), null);
						}
					}
			}
			catch (Exception err) { throw err; }
		}

		public class DownloadingEventArgs : EventArgs
		{
			public KeyValuePair<string,string> Target { get; protected set; }
			public DownloadingEventArgs(KeyValuePair<string,string> valuePair)
			{
				Target = valuePair;
			}
		}
		public class ProcessResult
		{
			public string SiteName { get; protected set; }
			public string NovelName { get; set; }
			public Dictionary<string,string> Chapters { get; set; }
			public string[] PreProcessResult { get; protected set; }

			public ProcessResult(string siteName, string novelName, string[] chapterLinks, string[] preprocess)
			{
				SiteName = siteName;
				NovelName = novelName;
				Chapters = new Dictionary<string, string>();
				PreProcessResult = preprocess;

				foreach(string link in chapterLinks)
				{
					try
					{
						Chapters.Add(link.Substring(0, link.Length - 1).Split('/').Last(), link);
					}
					catch(ArgumentException argError) { continue; }
				}
			}
			public ProcessResult(ProcessResult otherResult)
			{
				SiteName = otherResult.SiteName;
				NovelName = otherResult.NovelName;
				Chapters = new Dictionary<string, string>();
				foreach (KeyValuePair<string, string> pair in otherResult.Chapters)
					Chapters.Add(pair.Key, pair.Value);
				PreProcessResult = null;
			}
		}


		public void ResetSaveLocation()
		{
			SaveLocation = new Uri(Path.Combine(Environment.CurrentDirectory, Resource.SiteName, Resource.NovelName) + "\\");
		}

		public static string[] PreProcess(string input, BackgroundWorker worker, DoWorkEventArgs e)
		{
			Uri frontpageUrl = null;
			
			try
			{
				frontpageUrl = new Uri(input);
				List<string> pageLinks = new List<string>();
				HtmlDocument frontpage = new HtmlDocument();
				string resource = null;
				double avrPercent = 50 / 3, progressPercent = 0;


				//
				// 1. download the chapters index page

				if (worker.CancellationPending)
				{
					e.Cancel = true;
					return null;
				}
				worker.ReportProgress((int)progressPercent,"Downloading the index page..");
				using (WebClient webClient = new WebClient())
				{
					webClient.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
					resource = webClient.DownloadString(frontpageUrl);
				}
				worker.ReportProgress((int)(progressPercent += avrPercent), null);

				//
				// 2. load it to frontpage

				if (worker.CancellationPending)
				{
					e.Cancel = true;
					return null;
				}
				worker.ReportProgress((int)progressPercent, "Loading index page..");
				frontpage.LoadHtml(resource);
				worker.ReportProgress((int)(progressPercent += avrPercent), null);

				//
				// 3. find links

				if (worker.CancellationPending)
				{
					e.Cancel = true;
					return null;
				}
				if (frontpageUrl.Host == "sstruyen.com")
				{
					worker.ReportProgress((int)progressPercent, "Fetching index pages from sstruyen.com..");
					string lastPageLink = frontpage.QuerySelector(".nexts").FirstChild.Attributes["href"].Value;
					int start = lastPageLink.IndexOf("trang-");
					pageLinks.Add(frontpageUrl.AbsoluteUri);

					if (start != -1)
					{
						//int lastPage = int.Parse(lastPageLink.Substring(start + 6, lastPageLink.LastIndexOf('/')));
						int lastPage = int.Parse(Substring(lastPageLink,start + 6, lastPageLink.IndexOf('/',start+6)));


						for (int i = 2; i <= lastPage; ++i)
						{
							if (worker.CancellationPending)
							{
								e.Cancel = true;
								return null;
							}
							string link = lastPageLink.Replace("trang-" + lastPage, "trang-" + i);
							//
							// 3.1 add found page to list
							pageLinks.Add(frontpageUrl.GetLeftPart(UriPartial.Authority) + link);
							
						}
					}
				}
				else if (frontpageUrl.Host == "truyenfull.vn")
				{
					worker.ReportProgress((int)progressPercent, "Fetching index pages from truyenfull.vn..");
					var listItems = frontpage.QuerySelectorAll(".pagination li");
					pageLinks.Add(frontpageUrl.AbsoluteUri);
					if (listItems.Count == 0) ;
					else if (listItems.Last().GetClassList().Contains("dropup") || listItems.Last().GetClassList().Contains("page-nav"))
					{
						string lastPageLink = listItems.Last().FirstChild.Attributes["href"].Value;
						int start = lastPageLink.IndexOf("trang-");
						//int lastPage = int.Parse(lastPageLink.Substring(start + 6, lastPageLink.IndexOf('/', start + 6)));
						int lastPage = int.Parse(Substring(lastPageLink, start + 6, lastPageLink.IndexOf('/', start + 6)));

						for (int i = 2; i <= lastPage; ++i)
						{
							if (worker.CancellationPending)
							{
								e.Cancel = true;
								return null;
							}
							string link = lastPageLink.Replace("trang-" + lastPage, "trang-" + i);
							//
							// 3.1 add found page to list
							pageLinks.Add(link);
						}
					}
					else
					{

						for (int i = 0; i < listItems.Count; ++i)
						{
							if (worker.CancellationPending)
							{
								e.Cancel = true;
								return null;
							}
							pageLinks.Add(listItems[i].FirstChild.Attributes["href"].Value);
						}
					}

				}
				worker.ReportProgress((int)(progressPercent += avrPercent), "Fetching index pages done.");
				return pageLinks.ToArray();
				}
			catch (Exception err) { throw err; }
		}
		public static ProcessResult Process(string[] preprocess, BackgroundWorker worker, DoWorkEventArgs e)
		{
			try
			{
				//if (preprocess == null || preprocess.Length == 0)
				//	throw new Exception("Preprocess value is invalid");
				if (preprocess == null)
				{
					e.Cancel = true;
					return null;
				}
				if (preprocess.Length == 0)
					throw new Exception("Can't find any index pages.\r\nPlease try a different URL.");

				Uri frontpageUrl = new Uri(preprocess[0]);
				List<string> chapterLinks = new List<string>();
				string siteName = frontpageUrl.Host;
				string novelName = frontpageUrl.Segments[1].TrimEnd('/');
				IList<HtmlNode> links = null;
				string resource = null;
				HtmlDocument frontpage = new HtmlDocument();

				if (frontpageUrl.Host == "sstruyen.com")
				{
					for(int i = 0; i<preprocess.Length;++i)
					{
						//
						// download the chapters index page
						if (worker.CancellationPending)
						{
							e.Cancel = true;
							return null;
						}
						worker.ReportProgress(50, "Fetching index page from "+preprocess[i]+"..");
						using (WebClient webClient = new WebClient())
						{
							webClient.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
							resource = webClient.DownloadString(preprocess[i]);
						}
						//
						// load it to frontpage
						frontpage.LoadHtml(resource);
						//
						// find links
						links = frontpage.QuerySelectorAll(".list-chap a");
						worker.ReportProgress(50, "Fetching chapters..");
						foreach (HtmlNode link in links)
						{
							
							chapterLinks.Add(frontpageUrl.GetLeftPart(UriPartial.Authority) + link.Attributes["href"].Value);
						}

						if (i == preprocess.Length / 2)
							worker.ReportProgress(75, null);
					}
					
				}
				else if (frontpageUrl.Host == "truyenfull.vn")
				{
					for (int i = 0; i < preprocess.Length; ++i)
					{
						//
						// download the chapters index page
						if (worker.CancellationPending)
						{
							e.Cancel = true;
							return null;
						}
						worker.ReportProgress(50, "Fetching index page from " + preprocess[i] + "..");
						using (WebClient webClient = new WebClient())
						{
							webClient.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
							resource = webClient.DownloadString(preprocess[i]);
						}
						//
						// load it to frontpage
						frontpage.LoadHtml(resource);
						//
						// find links
						links = frontpage.QuerySelectorAll(".list-chapter a");
						worker.ReportProgress(50, "Fetching chapters..");
						foreach (HtmlNode link in links)
						{
							chapterLinks.Add(link.Attributes["href"].Value);
						}

						if (i == preprocess.Length / 2)
							worker.ReportProgress(75, null);
					}
				}
				worker.ReportProgress(100, null);

				return new ProcessResult(siteName, novelName, chapterLinks.ToArray(), preprocess);
			}
			catch (Exception err) { throw err; }
		}
		public static string Substring(string src, int startIndex, int endIndex)
		{
			StringBuilder builder = new StringBuilder();
			for (int i = startIndex; i < endIndex; ++i)
				builder.Append(src[i]);
			return builder.ToString();
		}
	}
}
