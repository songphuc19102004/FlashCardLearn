using Repositories.Models;
using Services.DTOs;
using Services.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
            var dtos = flashcards.Select(fc => fc.ToFlashCardDTO());
            string jsonContent = JsonSerializer.Serialize(dtos, new JsonSerializerOptions {WriteIndented = true});
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

        public static List<FlashCardDTO> ImportJsonToFlashcardList()
        {
            //TODO:
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Choose Your Import File",
                Filter = "JSON files (*.json)|*.json",
                DefaultExt = "json"
            };

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    string jsonContent = File.ReadAllText(filePath);
                    List<FlashCardDTO> importedFlashcards = JsonSerializer.Deserialize<List<FlashCardDTO>>(jsonContent);
                    return importedFlashcards;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }
    }
}
