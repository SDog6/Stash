using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;
using System.Reflection;

namespace Stash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void UpFearHunger_Click(object sender, EventArgs e)
        {
            UserCredential credential;

            string filePath1 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"credentials.json");

            using (var stream = new FileStream(filePath1, FileMode.Open, FileAccess.Read))
            {
                string credPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "token.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { DriveService.Scope.DriveFile },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "StashC#",
            });

            // Specify the file to upload.
            string folderPath = @"C:\Program Files (x86)\Steam\steamapps\common\Fear & Hunger\www\save\";

            // Create or get the "Stash" folder ID
            string stashFolderId = GetOrCreateFolder(service, "Stash");

            // Create or get the "Fear and Hunger" folder ID inside the "Stash" folder
            string fearAndHungerFolderId = GetOrCreateFolder(service, "Fear and Hunger", stashFolderId);

            if (string.IsNullOrEmpty(stashFolderId) || string.IsNullOrEmpty(fearAndHungerFolderId))
            {
                MessageBox.Show("Failed to create or get required folders.");
                return;
            }

            // Get the list of files in the folder
            var filesToUpload = Directory.GetFiles(folderPath);

            if (filesToUpload.Length == 0)
            {
                MessageBox.Show("No files found in the folder to upload.");
                return;
            }

            // Upload or update each file only once
            foreach (var filePath in filesToUpload)
            {
                var fileName = Path.GetFileName(filePath);

                // Check if the file already exists
                var existingFile = GetFileByName(service, fileName, fearAndHungerFolderId);

                if (existingFile != null)
                {
                    // File exists, update it
                    using (var fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        var updateRequest = service.Files.Update(new Google.Apis.Drive.v3.Data.File(), existingFile.Id, fileStream, "application/octet-stream");
                        updateRequest.Upload();
                    }
                }
                else
                {
                    // File doesn't exist, create it
                    var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                    {
                        Name = fileName,
                        Parents = new List<string> { fearAndHungerFolderId },
                    };

                    using (var fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        var createRequest = service.Files.Create(fileMetadata, fileStream, "application/octet-stream");
                        createRequest.Upload();
                    }
                }
            }

            MessageBox.Show("Upload completed.");
        }

        private Google.Apis.Drive.v3.Data.File GetFileByName(DriveService service, string fileName, string parentFolderId)
        {
            // Check if the file already exists
            var query = $"name='{fileName}' and '{parentFolderId}' in parents";

            var fileListRequest = service.Files.List();
            fileListRequest.Q = query;
            var fileList = fileListRequest.Execute().Files;

            return fileList?.FirstOrDefault();
        }


        private string GetOrCreateFolder(DriveService service, string folderName, string parentFolderId = null)
        {
            // Check if the folder already exists
            var query = $"name='{folderName}' and mimeType='application/vnd.google-apps.folder'";
            if (!string.IsNullOrEmpty(parentFolderId))
            {
                query += $" and '{parentFolderId}' in parents";
            }

            var fileListRequest = service.Files.List();
            fileListRequest.Q = query;
            var fileList = fileListRequest.Execute().Files;

            if (fileList != null && fileList.Count > 0)
            {
                // Folder already exists, return its ID
                return fileList.First().Id;
            }
            else
            {
                // Folder doesn't exist, create it
                var folderMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = folderName,
                    MimeType = "application/vnd.google-apps.folder",
                };

                if (!string.IsNullOrEmpty(parentFolderId))
                {
                    folderMetadata.Parents = new List<string> { parentFolderId };
                }

                var folderRequest = service.Files.Create(folderMetadata);
                folderRequest.Fields = "id";
                var folder = folderRequest.Execute();

                return folder.Id;
            }
        }




        //// Create file metadata.
        //var fileMetadata = new Google.Apis.Drive.v3.Data.File()
        //{
        //    Name = "config.rpgsave",
        //    Parents = new List<string> { fearAndHungerFolderId },
        //};

        //// Create a FileStream for the file content.
        //using (var stream = new FileStream(filePath, FileMode.Open))
        //{
        //    // Upload the file.
        //    var request = service.Files.Create(fileMetadata, stream, "application/octet-stream");
        //    request.Upload();
        //}




        private void DownFearHunger_Click(object sender, EventArgs e)
        {

        }
    }
}
