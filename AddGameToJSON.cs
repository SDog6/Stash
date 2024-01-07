using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stash
{
    public partial class AddGameToJSON : Form
    {
        public AddGameToJSON()
        {
            InitializeComponent();
        }

        private void addGame_Click(object sender, EventArgs e)
        {
            // Get the values from the textboxes
            string gameName = GameNameTB.Text;
            string imageName = ImageNameTB.Text;
            string saveFileLoc = SaveFileLocTB.Text;

            // Load existing data from the file if it exists
            List<GameData> existingData = LoadGameData();

            // Create a new object for the current data
            var newGameData = new GameData
            {
                GameName = gameName,
                ImageName = imageName,
                SaveFileLoc = saveFileLoc
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
    }
}
