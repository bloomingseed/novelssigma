# Novels Sigma
It is a simple Windows console application that lets you enter a URL to a novel page on a supported website then download all chapters from that page until the latest chapter of that novel.
## Scope
- Made for **online** readers to read their desired novel **offline**.
- Windows console application.
## Key Features
- Download chapters in **HTML file format (.html)**. User read them using **their favourite browser**.
- Downloaded chapters are grouped by **website name** (e.g. truyenfull.vn) then by their **novel name** (that is, the name appeared in the URL. E.g. doc-ton-tam-gioi). **Existed** chapters are **overwritten**.
- Download all chapters from the provided URL **onward**. That is, if the URL is *the front-page* of the novel, all chapters from *earliest* until latest are downloaded; if the URL *isn't*, then all chapters from *that page* toward the latest are downloaded.
- If not using command-line parameters, the app provides a simple **command-line interface** (CLI) and user keeps entering commands or URLs **once per process**.
- Accept list of URL as **command-line arguments**: User specifies list of novel URLs, separated by space character `' '`, then the app download all chapters from *each* URL. E.g. 
```
NovelsSigma.exe https://truyenfull.vn/yeu-than-ky/ https://sstruyen.com/yeu-than-ky/trang-15/#s_c_content https://truyenfull.vn/yeu-than-ky/trang-1/#list-chapter
```
- Chapters are downloaded follow the order they appear in **the HTML format of the downloading page** and are downloaded once a time, thus with *creation date sorting*, user can reorder them.
## Upcoming Features
- Use colors for better visualizing.
- Provide support for other novel reading websites.
## System Requirements
- Windows OS.
- App built with .NET Framework 4.5, built for .NET Framework 4.6.1.
## Latest Release
Version 1.0.