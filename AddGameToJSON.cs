using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Stash
{
    public partial class AddGameToJSON : Form
    {
        private string generalFileLoc;
        private Form1 parentForm;
        public AddGameToJSON(Form1 parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void addGame_Click(object sender, EventArgs e)
        {
            // Get the values from the textboxes
            string gameName = GameNameTB.Text;
            gameName = gameName.Replace("'", ""); // Removes quote char as it breaks google drive
            string imageName = GameNameTB.Text;
            string saveFileLoc = SaveFileLocTB.Text;

            string saveFileLocUpdate = SaveFileLocTB.Text + "\\";

            // Load existing data from the file if it exists
            List<GameData> existingData = LoadGameData();

            // Create a new object for the current data
            var newGameData = new GameData
            {
                GameName = gameName,
                ImageName = imageName,
                SaveFileLoc = saveFileLocUpdate,
                GeneralFileLoc = generalFileLoc
            };

            // Add the new data to the existing list
            existingData.Add(newGameData);

            // Serialize the updated list to JSON
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(existingData);

            // Save the JSON to a file
            string filePath = "gameinfo.json"; // Specify the path where you want to save the file
            System.IO.File.WriteAllText(filePath, json);

            // Optionally, you can show a message to indicate successful save
            MessageBox.Show("Game data saved successfully!");
            labelImage.Visible = false;
            parentForm.LoadData();
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
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<GameData>>(json);
                }
            }

            return new List<GameData>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GameNameTB.Text))
            {
                MessageBox.Show("Write down game name first");
                return;
            }
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All Files|*.*";
                openFileDialog.Title = "Select an image file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Get the selected file path
                        string filePath = openFileDialog.FileName;

                        // Get the destination directory (GameImages)
                        string destinationDirectory = Path.Combine(Application.StartupPath, "GameImages");

                        // Create the destination directory if it doesn't exist
                        if (!Directory.Exists(destinationDirectory))
                        {
                            Directory.CreateDirectory(destinationDirectory);
                        }

                        // Get the new file name from the TextBox
                        string newFileName = Path.Combine(destinationDirectory, GameNameTB.Text + ".jpg");

                        // Move and rename the file
                        File.Move(filePath, newFileName);

                        //MessageBox.Show("Image sucessfuly taken");
                        labelImage.Visible = true; 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            generalFileLoc = "SteamUserData";
        }

        private void radioButtonSteamApp_CheckedChanged(object sender, EventArgs e)
        {
            generalFileLoc = "SteamCommonApps";
        }

        private void radioButtonDocs_CheckedChanged(object sender, EventArgs e)
        {
            generalFileLoc = "Documents";
        }

        private void radioButtonUserdataLoc_CheckedChanged(object sender, EventArgs e)
        {
            generalFileLoc = "UserDataLocal";
        }
    }
}
