﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HapCss;
using System.IO;

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
				HtmlDocument frontpage = new HtmlDocument();
				string resource = null;
				IList<HtmlNode> anchorNode = null;
				IList<HtmlNode> links = null;
				int count = 0;
				//destinationFolder = new Uri(Directory.CreateDirectory(Path.Combine(destinationFolder.AbsolutePath, DateTime.Now.ToString("yyyyMMddTHHmm"))).FullName);
				string novelName = frontpageUrl.Segments[1];
				destinationFolder = new Uri(Directory.CreateDirectory(destinationFolder.AbsolutePath + "/" + novelName).FullName);
				if (frontpageUrl.Host == "sstruyen.com")
				{
					do
					{
						using (WebClient webClient = new WebClient())
						{
							webClient.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
							resource = webClient.DownloadString(frontpageUrl);
						}
						frontpage.LoadHtml(resource);
							anchorNode = frontpage.QuerySelectorAll(".next");
							links = frontpage.QuerySelectorAll(".list-chap a");
						
						using (WebClient client = new WebClient())
							foreach (HtmlNode link in links)
							{
								client.Headers["Content-Type"] = "text/html";
								client.Encoding = Encoding.UTF8;
								string raw = link.Attributes["href"].Value;
								raw = raw.Substring(0, raw.Length - 1);
								string fileName = raw.Split('/').Last();
								Console.WriteLine("Downloading file " + (count + 1) + ": " + fileName + ".html");
								client.DownloadFile(frontpageUrl.GetLeftPart(UriPartial.Authority) + raw,
									Path.Combine(destinationFolder.AbsolutePath, fileName + ".html"));
								++count;
							}
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
							//IList<HtmlNode> tmp = frontpage.QuerySelectorAll(".pagination li");
							//for (int i = 0; i < tmp.Count; ++i)
							//	if (tmp[i].GetClassList().Contains("active"))
							//		anchorNode = tmp[i + 1].QuerySelector("a");
							links = frontpage.QuerySelectorAll(".list-chapter a");
						
						using (WebClient client = new WebClient())
							foreach (HtmlNode link in links)
							{
								client.Headers["Content-Type"] = "text/html";
								client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
								client.Encoding = Encoding.UTF8;
								string raw = link.Attributes["href"].Value;
								raw = raw.Substring(0, raw.Length - 1);
								string fileName = raw.Split('/').Last();
								Console.WriteLine("Downloading file " + (count + 1) + ": " + fileName + ".html");
								client.DownloadFile(link.Attributes["href"].Value,
									Path.Combine(destinationFolder.AbsolutePath, fileName + ".html"));
								++count;
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
				Console.WriteLine("Download completed!");
			}
			catch(UnauthorizedAccessException err) { throw err; }
			catch (Exception err) { throw err; }
		}
	}
}
