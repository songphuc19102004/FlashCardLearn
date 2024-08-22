using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services
{
    public static class ImportExportHelper
    {

        public static List<FlashCard> QuizletImportToFlashCardList(string content)
        {
            string[] contentArray = content.Split("\r\n");
            string[] foo = new string[100];
            List<FlashCard> flashcards = new List<FlashCard>();
            int i = 0;
            FlashCard flashCard = new FlashCard();
            while(i < contentArray.Length)
            {
                if(contentArray[i].Contains("\t"))
                {
                    foo = contentArray[i].Split("\t");
                    flashCard.Question += $"\n{foo[0]}";
                    for(int j = 1; j < foo.Length; j++)
                    {
                        flashCard.Answer += $"{foo[j]} ";
                    }
                    
                    flashcards.Add(flashCard);
                    flashCard = new FlashCard();
                }
                else
                {
                    flashCard.Question += $"\n{contentArray[i]}";
                }
                i++;
            }
            return flashcards;
        }

        public static void ExportFlashcardListToFile(IEnumerable<FlashCard> flashcards)
        {
            string jsonContent = JsonSerializer.Serialize(flashcards, new JsonSerializerOptions {WriteIndented = true});
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Choose Export File Location",
                Filter = "JSON files (*.json)|*.json",
                DefaultExt = "json",
            };
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the chosen file path
                string filePath = saveFileDialog.FileName;

                try
                {
                    // Write the JSON string to the chosen file
                    File.WriteAllText(filePath, jsonContent);
                    MessageBox.Show("File exported!", "Status", MessageBoxButtons.OK);
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving the file: {ex.Message}");
                }
            }
        }

        public static void ImportJsonToFlashcardList()
        {
            //TODO:
        }
    }
}
