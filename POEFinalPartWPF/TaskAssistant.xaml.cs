using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static POEFinalPartWPF.Question;

namespace POEFinalPartWPF
{
    /// <summary>
    /// Interaction logic for TaskAssistant.xaml
    /// </summary>
   
    public partial class TaskAssistant : Window
    { 
    
    Question question = new Question();

    MainWindow home = new MainWindow();

    MiniGame miniGame = new MiniGame();

        private List<string> keywords = new List<string> { "add", "task", "remove", "edit", "show", "review", "view", "no"};

        private QuestionDelegate questionDelegate;

        private string askQuestion1 = "";

        private string answer2 = "";

        private int askQuestionCount = 10;

        private int saveQuestionCount = 1;

        public TaskAssistant()
        {
            InitializeComponent();
        }

        private void askQuestion()
        {

            string userName = question.getName();

            switch (askQuestionCount)
            {

                case 1:
                    //================== Asking how was the day so far ==================

                    askQuestion1 = "--------------------------------------------------\n\n-Please give a task name, \n, " + userName + "?  -\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;
                    saveQuestionCount = 2;
                    break;

                case 2:

                    //================== Asking for favourite topics from the user ==================
                    askQuestion1 = "--------------------------------------------------\n\nPlease give a description\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;
                    saveQuestionCount = 3;
                    break;

                case 3:

                    askQuestion1 = "--------------------------------------------------\n\nPlease give a reminder date, tommorrow or next week for example, Or say no thanks\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;
                    saveQuestionCount = 4;

                    break;

                case 4:

                    askQuestion1 = "--------------------------------------------------\n\nWhat do you wish to do? review or add and edit a task?\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;

                    break;

                case 5:

                    askQuestion1 = "--------------------------------------------------\n\nEnter task name that you wish to delete\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;
                    saveQuestionCount = 5;

                    break;

                case 6:

                    askQuestion1 = "--------------------------------------------------\n\nAre you sure?\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;
                    saveQuestionCount = 6;

                    break;

                case 7:

                    askQuestion1 = "--------------------------------------------------\n\nWhat do you wish to do? review or add and edit a task?\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;

                    break;

                case 8:

                    askQuestion1 = "--------------------------------------------------\n\nWhat task do you wish to edit\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;
                    saveQuestionCount = 7;

                    break;

                case 9:

                    askQuestion1 = "--------------------------------------------------\n\nDo you want to edit? task name, task description or task date\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;

                    break;

                case 10:

                    askQuestion1 = "--------------------------------------------------\n\nWhat is the new description you wish to give?\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;
                    saveQuestionCount = 8;

                    break;

                case 11:

                    askQuestion1 = "--------------------------------------------------\n\nWhat is the new name you wish to give\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;
                    saveQuestionCount = 8;

                    break;

                case 12:

                    askQuestion1 = "--------------------------------------------------\n\nwhat is the new task date you wish to change\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;
                    saveQuestionCount = 8;

                    break;

                default:
                    break;
            }
        }

        private void saveQuestion()
        {
            string saveQuestion = "";

            questionDelegate = question.LogQuestions;

            List<string> recognizedKeywordsInterest = RecognizeKeywords(userInput.Text.ToLower(), keywords);

            foreach (string keyword in recognizedKeywordsInterest)
            {
                saveQuestion = keyword;
            }

            if (saveQuestion.ToLower().Equals("add"))
            {
                ChatBotReply.Content = questionDelegate("");
                askQuestionCount = 1;
            }

            else if (saveQuestion.ToLower().Equals("remove"))
            {

                ChatBotReply.Content = questionDelegate("");
                askQuestionCount = 5;
            }

            else if (saveQuestion.ToLower().Equals("edit"))
            {

                ChatBotReply.Content = questionDelegate("");
                askQuestionCount = 8;
            }

            else if (saveQuestion.ToLower().Equals("description"))
            {

                ChatBotReply.Content = questionDelegate("");
                askQuestionCount = 10;
            }

            else if (saveQuestion.ToLower().Equals("name"))
            {

                ChatBotReply.Content = questionDelegate("");
                askQuestionCount = 11;
            }

            else if (saveQuestion.ToLower().Equals("date"))
            {

                ChatBotReply.Content = questionDelegate("");
                askQuestionCount = 12;
            }

            else if (saveQuestion.ToLower().Equals("show") || saveQuestion.ToLower().Equals("review") || saveQuestion.ToLower().Equals("view")) ChatBotReply.Content.Equals(questionDelegate);

            else
            {

                switch (saveQuestionCount)
                {

                    case 2:
                        ChatBotReply.Content = questionDelegate("");
                        askQuestionCount = 2;
                        break;

                    case 3:
                        ChatBotReply.Content = questionDelegate("");
                        askQuestionCount = 3;
                        break;

                    case 4:
                        ChatBotReply.Content = questionDelegate("");
                        askQuestionCount = 4;
                        break;

                    case 5:
                        ChatBotReply.Content = questionDelegate("");
                        askQuestionCount = 6;
                        break;

                    case 6:
                        ChatBotReply.Content = questionDelegate("");
                        askQuestionCount = 7;
                        break;

                    case 7:
                        ChatBotReply.Content = questionDelegate("");
                        askQuestionCount = 8;
                        break;

                    case 8:
                        ChatBotReply.Content = questionDelegate("");
                        break;

                    default:
                        break;
                }
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !userInput.Text.Equals(null))
            {
                try
                {
                    ChatBotReply.Content = "...";

                    Thread.Sleep(3000); //wait for 3 seconds

                    saveQuestion();

                    askQuestion();

                    if (askQuestionCount == 0) this.Close();

                }
                catch (NullReferenceException ex)
                {
                    ChatBotReply.Content = ex.Message;
                }

                catch (FormatException ex)
                {
                    ChatBotReply.Content = ex.Message;
                }

                catch (FileNotFoundException ex)
                {
                    ChatBotReply.Content = ex.Message;
                }

                catch (ArgumentException ex)
                {
                    ChatBotReply.Content = ex.Message;
                }

                catch (Exception ex)
                {
                    ChatBotReply.Content = ex.Message;
                }
            }
        }

        private void Respond_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ChatBotReply.Content = "...";

                Thread.Sleep(3000); //wait for 3 seconds

                saveQuestion();

                askQuestion();

                if (askQuestionCount == 0) this.Close();

            }
            catch (NullReferenceException ex)
            {
                ChatBotReply.Content = ex.Message;
            }

            catch (FormatException ex)
            {
                ChatBotReply.Content = ex.Message;
            }

            catch (FileNotFoundException ex)
            {
                ChatBotReply.Content = ex.Message;
            }

            catch (ArgumentException ex)
            {
                ChatBotReply.Content = ex.Message;
            }

            catch (Exception ex)
            {
                ChatBotReply.Content = ex.Message;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            userInput.Text = null;
        }

        private void MiniGame_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            miniGame.Show();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            home.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            var result = MessageBox.Show("Are You Sure?",
                                         "Question",
                                         MessageBoxButton.YesNo);

            // User doesn't want to close, cancel closure
            if (result == MessageBoxResult.No)
                e.Cancel = true;

            else { }
        }

        private static List<string> RecognizeKeywords(string text, List<string> keywords)
        {

            List<string> recognizedKeywords = new List<string>();

            foreach (string keyword in keywords)
            {
                if (text.Contains(keyword))
                {
                    recognizedKeywords.Add(keyword);
                }
            }
            return recognizedKeywords;
        }
    }
}
