# Novels Sigma
It is a simple Windows console application that lets you enter a URL to a novel page on a supported website then download all chapters from that page until the latest chapter of that novel.
## Scope
- Made for **online** readers to read their desired novel **offline**.
- Windows ~~console~~ application.
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
- [ ] Use *colors* for better visualizing.
- [ ] Provide support for *other novel reading websites*.
- [x] An alternative version with *Graphical User Interface*.
- [ ] Improve the *installer*.
## Install Location Warning
- It is recommended that the app is installed in a *non-system* drive, which normally is any drive **but** `C:` drive, otherwise the app may not run properly.
## System Requirements
- Windows *version*: *Windows 7* or *newer*; either *32 bits* or *64 bits*.
- Required .NET Framework version: *4.6.1* or *newer*. To see if your Windows version supports .NET Framework 4.6.1, see [this table](https://docs.microsoft.com/en-us/dotnet/framework/get-started/system-requirements#supported-client-operating-systems).
## App Support and Details
- Please copy the **exact** URL of the novel webpage that the browser provide. For example: `https://truyenfull.vn/yeu-than-ky/`, **not** `https://www.truyenfull.vn/yeu-than-ky/`.
- Visit *https://github.com/bloomingseed/novelssigma* for more app support and details.
### *For version 1.x.y*
- If you happened to install the app in a *system* drive, you can do:
- - Run the app with **Run as Administrator** option.
- - **Reinstall** (uninstall, then install again) the app in a non-system drive.
- - **Move** the parent folder of application to a non-system drive. *Notice* that after doing so you need to retarget all **shortcuts** to the app for the shortcuts to point to the app's *new location*.
- To uninstall the app:
- - If you are running portable version, simply delete the whole parent folder of the app.
- - Otherwise, you can either uninstaller it with Windows' **Add or remove programs** panel, or:
- - Delete manually: Delete the parent folder and all shortcuts to the app, or:
- - Run the previously used installer and choose to remove the app.
### *For version 2.x.y*
- Downloading files into **system drive's folder** (usually `C:` drive) may sometimes **doesn't appear** in Windows Explorer. In such case, you can try downloading the chapters into a **non-system drive's folder**.
