using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Stash
{

    public class GoogleDriveAPIManager
    {
        private DriveService _service;

        public GoogleDriveAPIManager()
        {
            InitializeService();
        }

        private void InitializeService()
        {
            UserCredential credential;

            string credentialsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "credentials.json");
            string tokenPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "token.json");

            using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { DriveService.Scope.DriveFile },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(tokenPath, true)).Result;
            }

            _service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "StashC#",
            });
        }

        public string GetOrCreateFolder(string folderName, string parentFolderId = null)
        {
            var query = $"name='{folderName}' and mimeType='application/vnd.google-apps.folder'";
            if (!string.IsNullOrEmpty(parentFolderId))
            {
                query += $" and '{parentFolderId}' in parents";
            }

            var fileListRequest = _service.Files.List();
            fileListRequest.Q = query;
            var fileList = fileListRequest.Execute().Files;

            if (fileList != null && fileList.Count > 0)
            {
                return fileList.First().Id;
            }
            else
            {
                var folderMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = folderName,
                    MimeType = "application/vnd.google-apps.folder",
                };

                if (!string.IsNullOrEmpty(parentFolderId))
                {
                    folderMetadata.Parents = new List<string> { parentFolderId };
                }

                var folderRequest = _service.Files.Create(folderMetadata);
                folderRequest.Fields = "id";
                var folder = folderRequest.Execute();

                return folder.Id;
            }
        }

        public Google.Apis.Drive.v3.Data.File GetFileByName(string fileName, string parentFolderId)
        {
            var query = $"name='{fileName}' and '{parentFolderId}' in parents";

            var fileListRequest = _service.Files.List();
            fileListRequest.Q = query;
            var fileList = fileListRequest.Execute().Files;

            return fileList?.FirstOrDefault();
        }

        public void UploadFiles(string folderPath, string parentFolderId)
        {
            var filesToUpload = Directory.GetFiles(folderPath);

            if (filesToUpload.Length == 0)
            {
                Console.WriteLine("No files found in the folder to upload.");
                return;
            }

            foreach (var filePath in filesToUpload)
            {
                var fileName = Path.GetFileName(filePath);

                var existingFile = GetFileByName(fileName, parentFolderId);

                if (existingFile != null)
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        var updateRequest = _service.Files.Update(new Google.Apis.Drive.v3.Data.File(), existingFile.Id, fileStream, "application/octet-stream");
                        updateRequest.Upload();
                    }
                }
                else
                {
                    var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                    {
                        Name = fileName,
                        Parents = new List<string> { parentFolderId },
                    };

                    using (var fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        var createRequest = _service.Files.Create(fileMetadata, fileStream, "application/octet-stream");
                        createRequest.Upload();
                    }
                }
            }

            MessageBox.Show("Upload completed.");
        }

        public void DownloadFiles(string folderPath, string parentFolderId)
        {
            var fileListRequest = _service.Files.List();
            fileListRequest.Q = $"'{parentFolderId}' in parents";
            var fileList = fileListRequest.Execute().Files;

            if (fileList == null || fileList.Count == 0)
            {
                Console.WriteLine("No files found in the Google Drive folder to download.");
                return;
            }

            foreach (var driveFile in fileList)
            {
                var localFilePath = Path.Combine(folderPath, driveFile.Name);

                using (var fileStream = new FileStream(localFilePath, FileMode.Create))
                {
                    var request = _service.Files.Get(driveFile.Id);
                    request.Download(fileStream);
                }
            }

            MessageBox.Show("Download completed.");
        }
    }
}
