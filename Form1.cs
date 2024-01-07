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


        private static string CreateFolder(DriveService service, string folderName, string parentFolderId = null)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = folderName,
                MimeType = "application/vnd.google-apps.folder"
            };
            if (!string.IsNullOrEmpty(parentFolderId))
            {
                fileMetadata.Parents = new List<string> { parentFolderId };
            }
            var request = service.Files.Create(fileMetadata);
            request.Fields = "id";
            var file = request.Execute();
            Console.WriteLine("Folder ID: " + file.Id);
            return file.Id;
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

            // Create the "Stash" folder if it doesn't exist
            string stashFolderId = CreateFolder(service, "Stash");

            // Create the "Fear and Hunger" folder inside the "Stash" folder if it doesn't exist
            string fearAndHungerFolderId = CreateFolder(service, "Fear and Hunger", stashFolderId);

            var filesToUpload = Directory.GetFiles(folderPath);

            // Upload all files in the folder
            foreach (var filePath in Directory.GetFiles(folderPath))
            {
                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = Path.GetFileName(filePath),
                    Parents = new List<string> { fearAndHungerFolderId },
                };

                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    // Upload each file.
                    var request = service.Files.Create(fileMetadata, fileStream, "application/octet-stream");
                    request.Upload();
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
        }




        private void DownFearHunger_Click(object sender, EventArgs e)
        {

        }
    }
}
