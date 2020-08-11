using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HapCss;
using System.IO;

namespace NovelsSigma
{
	public class Downloader
	{

		public delegate void DownloadingEventHandler(object sender, DownloadingEventArgs args);
		public event DownloadingEventHandler Downloading;
		public Uri SaveLocation { get; set; }
		public ProcessResult Resource { get; protected set; }
		public Downloader(ProcessResult result, Uri saveLocation = null)
		{
			if (result == null)
				throw new Exception("Result is null");
			Resource = result;
			if (saveLocation == null)
				ResetSaveLocation();
		}
		public void ResetSaveLocation()
		{
			SaveLocation = new Uri(Path.Combine(Environment.CurrentDirectory, Resource.SiteName, Resource.NovelName) + "\\");
		}
		public void Download(int[] checkedIndices = null)
		{
			try
			{
				Directory.CreateDirectory(SaveLocation.AbsolutePath);

				using (WebClient client = new WebClient())
					if (checkedIndices == null)
						foreach (var link in Resource.Chapters)
						{
							client.Headers["Content-Type"] = "text/html";
							client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
							client.Encoding = Encoding.UTF8;
							Downloading?.Invoke(this, new DownloadingEventArgs(link));

							client.DownloadFile(link.Value, Path.Combine(SaveLocation.AbsolutePath, link.Key + ".html"));
						}
					else
					{
						KeyValuePair<string, string> chapter;
						foreach (int i in checkedIndices)
						{
							chapter = Resource.Chapters.ElementAt(i);
							client.Headers["Content-Type"] = "text/html";
							client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
							client.Encoding = Encoding.UTF8;
							Downloading?.Invoke(this, new DownloadingEventArgs(chapter));

							client.DownloadFile(chapter.Value, Path.Combine(SaveLocation.AbsolutePath, chapter.Key + ".html"));
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
			public ProcessResult(string siteName, string novelName, string[] chapterLinks)
			{
				SiteName = siteName;
				NovelName = novelName;
				Chapters = new Dictionary<string, string>();
				foreach(string link in chapterLinks)
				{
					Chapters.Add(link.Substring(0, link.Length - 1).Split('/').Last(), link);
				}
			}
		}
		public static ProcessResult Process(string input)
		{
			Uri frontpageUrl = null;
			try
			{
				frontpageUrl = new Uri(input); 
				IList<HtmlNode> anchorNode = null;
				IList<HtmlNode> links = null;

				List<string> chapterLinks = new List<string>();
				string siteName = frontpageUrl.Host;
				string novelName = frontpageUrl.Segments[1].TrimEnd('/');

				HtmlDocument frontpage = new HtmlDocument();
				string resource = null;
				string rawLink = null;
				if (frontpageUrl.Host == "sstruyen.com")
				{
					do
					{
						//
						// download the chapters index page
						using (WebClient webClient = new WebClient())
						{
							webClient.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
							resource = webClient.DownloadString(frontpageUrl);
						}
						//
						// load it to frontpage
						frontpage.LoadHtml(resource);
						//
						// find links
						anchorNode = frontpage.QuerySelectorAll(".next");
						links = frontpage.QuerySelectorAll(".list-chap a");
						foreach (HtmlNode link in links)
						{
							rawLink = link.Attributes["href"].Value;
							chapterLinks.Add(frontpageUrl.GetLeftPart(UriPartial.Authority) + rawLink);
						}
						//
						// try continue
						if (anchorNode == null)
							frontpageUrl = null;
						else
						{
							HtmlNode node = anchorNode[0].QuerySelector("a");
							if (node.Attributes["href"].Value == "#")
								frontpageUrl = null;
							else
								frontpageUrl = new Uri(new Uri(frontpageUrl.GetLeftPart(UriPartial.Authority)), node.Attributes["href"].Value);

						}


					} while (frontpageUrl != null);
				}
				else if (frontpageUrl.Host == "truyenfull.vn")
				{
					do
					{
						using (WebClient webClient = new WebClient())
						{
							webClient.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
							resource = webClient.DownloadString(frontpageUrl);
						}
						frontpage.LoadHtml(resource);
						anchorNode = frontpage.QuerySelectorAll(".pagination li");
						links = frontpage.QuerySelectorAll(".list-chapter a");
						foreach (HtmlNode link in links)
						{
							chapterLinks.Add(link.Attributes["href"].Value);
						}
						if (anchorNode == null)
							frontpageUrl = null;
						else
						{
							int i = 0;
							for (i = 0; i < anchorNode.Count; ++i)
								if (anchorNode[i].GetClassList().Contains("active"))
								{
									i += 1;
									break;
								}
							if (i < anchorNode.Count)
							{
								HtmlNode node = anchorNode[i].QuerySelector("a");
								if (node.Attributes["href"].Value == "javascript: void(0)")
									frontpageUrl = null;
								else
									frontpageUrl = new Uri(node.Attributes["href"].Value);
							}
							else
								frontpageUrl = null;
						}
					} while (frontpageUrl != null);
				}
				else throw new Exception("Not supported website");
				//
				//download attempt success
				return new ProcessResult(siteName, novelName, chapterLinks.ToArray());
			}
			catch(UnauthorizedAccessException err) { throw err; }
			catch (Exception err) { throw err; }
		}
	}
}
