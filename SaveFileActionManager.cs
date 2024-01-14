using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stash
{
    class SaveFileActionManager
    {
        private static GoogleDriveAPIManager driveManager = new GoogleDriveAPIManager();

        public void UploadFiles(string folderPath, string GameName)
        {
            // Create or get the "Stash" folder ID
            string stashFolderId = driveManager.GetOrCreateFolder("Stash");

            // Create or get the "Fear and Hunger" folder ID inside the "Stash" folder
            string fearAndHungerFolderId = driveManager.GetOrCreateFolder(GameName, stashFolderId);

            if (string.IsNullOrEmpty(stashFolderId) || string.IsNullOrEmpty(fearAndHungerFolderId))
            {
                Console.WriteLine("Failed to create or get required folders.");
                return;
            }

            driveManager.UploadFiles(folderPath, fearAndHungerFolderId);

        }

        public void DownloadFiles(string folderPath, string GameName)
        {

            // Create or get the "Stash" folder ID
            string stashFolderId = driveManager.GetOrCreateFolder("Stash");

            // Create or get the "Fear and Hunger" folder ID inside the "Stash" folder
            string fearAndHungerFolderId = driveManager.GetOrCreateFolder(GameName, stashFolderId);

            if (string.IsNullOrEmpty(stashFolderId) || string.IsNullOrEmpty(fearAndHungerFolderId))
            {
                Console.WriteLine("Failed to create or get required folders.");
                return;
            }

            driveManager.DownloadFiles(folderPath, fearAndHungerFolderId);

        }
    }
}
