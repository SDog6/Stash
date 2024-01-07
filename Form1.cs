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
            GoogleDriveAPIManager driveManager = new GoogleDriveAPIManager();

            // Specify the file to upload.
            string folderPath = @"C:\Program Files (x86)\Steam\steamapps\common\Fear & Hunger\www\save\";

            // Create or get the "Stash" folder ID
            string stashFolderId = driveManager.GetOrCreateFolder("Stash");

            // Create or get the "Fear and Hunger" folder ID inside the "Stash" folder
            string fearAndHungerFolderId = driveManager.GetOrCreateFolder("Fear and Hunger", stashFolderId);

            if (string.IsNullOrEmpty(stashFolderId) || string.IsNullOrEmpty(fearAndHungerFolderId))
            {
                Console.WriteLine("Failed to create or get required folders.");
                return;
            }

            driveManager.UploadFiles(folderPath, fearAndHungerFolderId);
        }




        private void DownFearHunger_Click(object sender, EventArgs e)
        {
            GoogleDriveAPIManager driveManager = new GoogleDriveAPIManager();

            // Specify the local folder to download the files.
            string folderPath = @"C:\Program Files (x86)\Steam\steamapps\common\Fear & Hunger\www\save\";

            // Create or get the "Stash" folder ID
            string stashFolderId = driveManager.GetOrCreateFolder("Stash");

            // Create or get the "Fear and Hunger" folder ID inside the "Stash" folder
            string fearAndHungerFolderId = driveManager.GetOrCreateFolder("Fear and Hunger", stashFolderId);

            if (string.IsNullOrEmpty(stashFolderId) || string.IsNullOrEmpty(fearAndHungerFolderId))
            {
                Console.WriteLine("Failed to create or get required folders.");
                return;
            }

            driveManager.DownloadFiles(folderPath, fearAndHungerFolderId);
        }
    }
}
