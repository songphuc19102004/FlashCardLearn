using FlashCardLearn.Services;
using FlashCardLearn.Stores;
using FlashCardLearn.ViewModel;
using FlashCardLearn.Views;
using Repositories.Models;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;

namespace FlashCardLearn
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
        //    FlashCardLearnContext context = new FlashCardLearnContext();
        //    var historyFlashcards = new List<FlashCard>
        //{
        //    new FlashCard { Question = "In which year did World War II end?", Answer = "1945", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the first President of the United States?", Answer = "George Washington", FlashcardsetId = 1 },
        //    new FlashCard { Question = "What year did the French Revolution begin?", Answer = "1789", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the leader of the Soviet Union during World War II?", Answer = "Joseph Stalin", FlashcardsetId = 1 },
        //    new FlashCard { Question = "In which year did Christopher Columbus first reach the Americas?", Answer = "1492", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who wrote the Declaration of Independence?", Answer = "Thomas Jefferson", FlashcardsetId = 1 },
        //    new FlashCard { Question = "What was the name of the first successful English settlement in North America?", Answer = "Jamestown", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the leader of Nazi Germany during World War II?", Answer = "Adolf Hitler", FlashcardsetId = 1 },
        //    new FlashCard { Question = "In which year did the American Civil War begin?", Answer = "1861", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the first woman to fly solo across the Atlantic Ocean?", Answer = "Amelia Earhart", FlashcardsetId = 1 },
        //    new FlashCard { Question = "What was the name of the ship that brought the Pilgrims to America in 1620?", Answer = "Mayflower", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the leader of the Civil Rights Movement in the United States?", Answer = "Martin Luther King Jr.", FlashcardsetId = 1 },
        //    new FlashCard { Question = "In which year did the Berlin Wall fall?", Answer = "1989", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the first man to walk on the moon?", Answer = "Neil Armstrong", FlashcardsetId = 1 },
        //    new FlashCard { Question = "What was the name of the ancient wonder of the world in Egypt?", Answer = "The Great Pyramid of Giza", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who painted the Mona Lisa?", Answer = "Leonardo da Vinci", FlashcardsetId = 1 },
        //    new FlashCard { Question = "In which year did the United States declare independence?", Answer = "1776", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the first female Prime Minister of the United Kingdom?", Answer = "Margaret Thatcher", FlashcardsetId = 1 },
        //    new FlashCard { Question = "What was the name of the ship that sank on its maiden voyage in 1912?", Answer = "Titanic", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the ancient Greek philosopher who taught Alexander the Great?", Answer = "Aristotle", FlashcardsetId = 1 },
        //    new FlashCard { Question = "In which year did World War I begin?", Answer = "1914", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the Egyptian queen famous for her relationship with Mark Antony?", Answer = "Cleopatra", FlashcardsetId = 1 },
        //    new FlashCard { Question = "What was the name of the economic plan that helped Western Europe recover after World War II?", Answer = "Marshall Plan", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who wrote 'The Communist Manifesto'?", Answer = "Karl Marx and Friedrich Engels", FlashcardsetId = 1 },
        //    new FlashCard { Question = "In which year did the Russian Revolution occur?", Answer = "1917", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the leader of China during the Cultural Revolution?", Answer = "Mao Zedong", FlashcardsetId = 1 },
        //    new FlashCard { Question = "What was the name of the peace treaty that ended World War I?", Answer = "Treaty of Versailles", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who discovered penicillin?", Answer = "Alexander Fleming", FlashcardsetId = 1 },
        //    new FlashCard { Question = "In which year did the Korean War begin?", Answer = "1950", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the Roman emperor when Christianity became the official religion of the Roman Empire?", Answer = "Constantine I", FlashcardsetId = 1 },
        //    new FlashCard { Question = "What was the name of the first artificial satellite launched into space?", Answer = "Sputnik 1", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the last pharaoh of Ancient Egypt?", Answer = "Cleopatra VII", FlashcardsetId = 1 },
        //    new FlashCard { Question = "In which year did the Vietnam War end?", Answer = "1975", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the first Emperor of Rome?", Answer = "Augustus", FlashcardsetId = 1 },
        //    new FlashCard { Question = "What was the name of the period of renewed interest in art and learning in Europe?", Answer = "Renaissance", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who wrote 'The Prince', a treatise on political power?", Answer = "Niccolò Machiavelli", FlashcardsetId = 1 },
        //    new FlashCard { Question = "In which year did the Industrial Revolution begin?", Answer = "Mid-18th century (around 1760)", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the leader of the Bolsheviks during the Russian Revolution?", Answer = "Vladimir Lenin", FlashcardsetId = 1 },
        //    new FlashCard { Question = "What was the name of the first successful powered, sustained, and controlled airplane flight?", Answer = "Wright Flyer", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the principal author of the Emancipation Proclamation?", Answer = "Abraham Lincoln", FlashcardsetId = 1 },
        //    new FlashCard { Question = "In which year did the Black Death pandemic peak in Europe?", Answer = "1348-1350", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the leader of the Indian independence movement against British rule?", Answer = "Mahatma Gandhi", FlashcardsetId = 1 },
        //    new FlashCard { Question = "What was the name of the atomic bomb dropped on Hiroshima?", Answer = "Little Boy", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the first woman to win a Nobel Prize?", Answer = "Marie Curie", FlashcardsetId = 1 },
        //    new FlashCard { Question = "In which year did the Ottoman Empire fall?", Answer = "1922", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was the leader of Cuba during the Cuban Missile Crisis?", Answer = "Fidel Castro", FlashcardsetId = 1 },
        //    new FlashCard { Question = "What was the name of the conference where European powers partitioned Africa?", Answer = "Berlin Conference", FlashcardsetId = 1 },
        //    new FlashCard { Question = "Who was known as the 'Iron Chancellor' of Germany?", Answer = "Otto von Bismarck", FlashcardsetId = 1 },
        //    new FlashCard { Question = "In which year did the Chinese Communist Revolution end?", Answer = "1949", FlashcardsetId = 1 }
        //};
        //    context.FlashCards.AddRange(historyFlashcards);
        //    context.SaveChanges();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        //private HomeViewModel CreateHomeViewModel()
        //{
        //    return new HomeViewModel(_navigationStore);
        //}

        //private FlashCardManagerViewModel CreateFlashCardManagerViewModel()
        //{
        //    return new FlashCardManagerViewModel(_navigationStore);
        //}

        //private LearnViewModel CreateLearnViewModel()
        //{
        //    return new LearnViewModel(new NavigationService(_navigationStore);
        //}
    }

}
