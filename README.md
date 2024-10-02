# Alpha Video Downloader

Alpha Video Downloader is a Windows Forms application built in C# that allows users to download videos and audio from YouTube and other platforms. The app supports downloading entire YouTube playlists and can handle video resolutions up to 8K.

## Features

- **Multi-format Support**: Download videos in various formats, including MP4 and MP3, with quality options.
- Supports entire YouTube playlists
- Handles video resolutions up to 8K
- **Dependency Management**: Automatically validates and downloads necessary dependencies (`yt-dlp`, `ffmpeg`) to ensure smooth operation.
- **Real-time Feedback**: Stay informed during the download process with loading messages and completion notifications.
- **File Management**: Check file existence, delete files, and verify file integrity through checksums (MD5).
- **User-Friendly Interface**: Intuitive design for easy navigation and operation.

## Technologies Used

- **C#**: The primary programming language used for development.
- **.NET Framework**: The framework that supports the application.
- **Windows Forms**: The GUI framework used for creating the user interface.
- **[yt-dlp](https://github.com/yt-dlp/yt-dlp)**: A command-line program used for downloading videos from YouTube and other platforms.
- **[ffmpeg](https://ffmpeg.org/)**: A tool for handling multimedia files, used for processing audio and video.
- **GitHub**: Used for version control and collaboration.
- **Windows OS**
- **[.NET Framework](https://dotnet.microsoft.com/download)** (version .NET 8.0)

## Installation

### From Source Code
1. Clone the repository:
   ```bash
   git clone https://github.com/Ahmed-Hesham-F5/Alpha-Video-Downloader
2. Open the solution in Visual Studio.
3. Build and run the project.   


### From Release
1. Go to the [Releases](https://github.com/Ahmed-Hesham-F5/Alpha-Video-Downloader/releases) page of the repository.
2. Download the latest release package (usually a .zip file).
3. Extract the contents of the downloaded file.
4. Navigate to the extracted folder and run the setup.exe file to setup and run the application

