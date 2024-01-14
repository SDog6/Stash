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
using Microsoft.Win32;
using System.Globalization;

namespace Stash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Load existing data from the file if it exists
            LoadData();
        }

        public void LoadData()
        {
            flowLayoutPanel.Controls.Clear();

            List<GameData> existingData = LoadGameData();

            // Create controls for each game and add them to the flow layout panel
            foreach (var gameData in existingData)
            {
                CreateGameControls(gameData);
                // Commented out a Debug the path
                //MessageBox.Show(BuildFullPath(gameData.GeneralFileLoc, gameData.SaveFileLoc));
            }
        }

        // Helper method to load existing data from the file
        private List<GameData> LoadGameData()
        {
            string filePath = "gameinfo.json"; // Specify the path where you want to save the file

            if (System.IO.File.Exists(filePath))
            {
                string json = System.IO.File.ReadAllText(filePath);

                // Check if the JSON is an array
                if (!string.IsNullOrEmpty(json) && json[0] == '[')
                {
                    List<GameData> loadedData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GameData>>(json);

                    // Check for duplicates and remove them
                    loadedData = loadedData.Distinct().ToList();

                    return loadedData;
                }
            }

            return new List<GameData>();
        }

        // Create controls for a game and add them to the flow layout panel
        private void CreateGameControls(GameData gameData)
        {
            SaveFileActionManager saveFileAction = new SaveFileActionManager();
            // Create PictureBox
            PictureBox pictureBox = new PictureBox();
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "GameImages", gameData.ImageName);
            path = Path.ChangeExtension(path, "jpg");
            pictureBox.ImageLocation = path;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Width = 140; // Set the width as per your requirements
            pictureBox.Height = 87; // Set the height as per your requirements


            // Create Label 1
            Label label1 = new Label();
            label1.Text = gameData.GameName;
            label1.Margin = new Padding(10, 35, 0, 0); // Set left and top margins

            // Create Label 2
            Label label2 = new Label();
            label2.Name = gameData.GameName + "Action";
            label2.Text = "Please Select Action";
            label2.Width = 100;
            label2.Margin = new Padding(40, 35, 0, 0); // Set left and top margins


            // Create Button 1
            Button button1 = new Button();
            button1.Text = "Upload"; // Customize the button text as needed
            button1.Width = 100; // Set the width as per your requirements
            button1.Height = 45; // Set the height as per your requirements
            button1.Margin = new Padding(110, 20, 0, 0); // Set left and top margins
            string fullpath = BuildFullPath(gameData.GeneralFileLoc, gameData.SaveFileLoc);
            button1.Click += (sender, e) =>
            {
                label2.Text = "Uploading";
                saveFileAction.UploadFiles(fullpath, gameData.GameName);
                label2.Text = "Done";
            };



            // Create Button 2
            Button button2 = new Button();
            button2.Text = "Download"; // Customize the button text as needed
            button2.Width = 100; // Set the width as per your requirements
            button2.Height = 45; // Set the height as per your requirements
            button2.Margin = new Padding(35, 20, 0, 0); // Set left and top margins
            button2.Click += (sender, e) =>
            {
                label2.Text = "Downloading";
                saveFileAction.DownloadFiles(fullpath, gameData.GameName);
                label2.Text = "Done";
            };

            // Add event handlers for the buttons if needed

            // Add controls to the flow layout panel
            flowLayoutPanel.Controls.Add(pictureBox);
            flowLayoutPanel.Controls.Add(label1);
            flowLayoutPanel.Controls.Add(label2);
            flowLayoutPanel.Controls.Add(button1);
            flowLayoutPanel.Controls.Add(button2);
        }

        private void AddGame_Click(object sender, EventArgs e)
        {
            AddGameToJSON form = new AddGameToJSON(this);
            form.Show();
        }

        public static string BuildFullPath(string generalFileLoc, string exactFileLoc)
        {
            string fullPath = "";

            // Check if GeneralFileLoc is either "SteamUserData" or "SteamCommonApps"
            if (generalFileLoc.Equals("SteamUserData", StringComparison.OrdinalIgnoreCase) ||
                generalFileLoc.Equals("SteamCommonApps", StringComparison.OrdinalIgnoreCase))
            {
                // Check Program Files (x86) and Program Files for the Steam folder
                string steamPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Steam");
                if (!Directory.Exists(steamPath))
                {
                    steamPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Steam");
                }

                // If Steam folder exists, append path to ExactFileLoc
                if (Directory.Exists(steamPath))
                {
                    if (generalFileLoc.Equals("SteamUserData")) 
                    {
                        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam\ActiveProcess");
                        object activeUserValue = key.GetValue("ActiveUser");
                        string steamIdHex = ((int)activeUserValue).ToString("X");
                        int steamId = (int)activeUserValue;
                        int steamId2 = int.Parse(steamIdHex, NumberStyles.HexNumber);
                        string steamUserPath1 = Path.Combine(steamPath, "userdata");
                        string steamUserPath2 = Path.Combine(steamUserPath1, steamId2.ToString());
                        fullPath = Path.Combine(steamUserPath2, exactFileLoc);
                    }
                    else if (generalFileLoc.Equals("SteamCommonApps"))
                    {
                        string steamAppPath = Path.Combine(steamPath, "steamapps\\common");
                        fullPath = Path.Combine(steamAppPath, exactFileLoc);
                    }
                }
            }
            // Check if GeneralFileLoc is "Documents"
            else if (generalFileLoc.Equals("Documents", StringComparison.OrdinalIgnoreCase))
            {
                // Get the Documents path and append it to ExactFileLoc
                fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), exactFileLoc);
            }
            // Check if GeneralFileLoc is "UserDataLocal"
            else if (generalFileLoc.Equals("UserDataLocal", StringComparison.OrdinalIgnoreCase))
            {
                // Get the AppData local path and append it to ExactFileLoc
                fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), exactFileLoc);
            }

            return fullPath;
        }

    }
}
