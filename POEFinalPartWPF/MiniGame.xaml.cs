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
    /// Interaction logic for MiniGame.xaml
    /// </summary>
    public partial class MiniGame : Window
    {

        Question question = new Question();

        MainWindow home = new MainWindow();

        TaskAssistant taskAssistant = new TaskAssistant();

        private int askQuestionCount = 10;

        private int saveQuestionCount = 1;

        private string askQuestion1 = "";

        public MiniGame()
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

                    askQuestion1 = "--------------------------------------------------\n\n-Question 1-\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;
                    break;

                case 2:

                    //================== Asking for favourite topics from the user ==================
                    askQuestion1 = "--------------------------------------------------\n\n-Question 2-\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;

                    break;

                case 3:

                    askQuestion1 = "--------------------------------------------------\n\n-Question 3-\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;

                    break;

                case 4:

                    askQuestion1 = "--------------------------------------------------\n\n-Question 4-\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;

                    break;

                case 5:

                    askQuestion1 = "--------------------------------------------------\n\n-Question 5-\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;

                    break;

                case 6:

                    askQuestion1 = "--------------------------------------------------\n\n-Question 6-\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;

                    break;

                case 7:

                    askQuestion1 = "--------------------------------------------------\n\n-Question 7-\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;

                    break;

                case 8:

                    askQuestion1 = "--------------------------------------------------\n\n-Question 8-\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;

                    break;

                case 9:

                    askQuestion1 = "--------------------------------------------------\n\n-Question 9-\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;

                    break;

                case 10:

                    askQuestion1 = "--------------------------------------------------\n\n-Question 10-\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;

                    break;

                default:
                    break;
            }
        }

        int quizResult = 0;

        private void saveQuestion()
        {
            if (saveQuestionCount.Equals(12)) { }

            else {

                switch (saveQuestionCount)
                {

                    case 1:

                        if (userInput.Text.ToLower().Equals("")) quizResult++;

                        ChatBotReply.Content = "...";

                        askQuestionCount = 1;

                        saveQuestionCount++;

                        break;

                    case 2:

                        if (userInput.Text.ToLower().Equals("")) quizResult++;

                        ChatBotReply.Content = "...";

                        askQuestionCount++;

                        saveQuestionCount++;

                        break;

                    case 3:

                        if (userInput.Text.ToLower().Equals("")) quizResult++;

                        ChatBotReply.Content = "...";

                        askQuestionCount++;

                        saveQuestionCount++;

                        break;

                    case 4:

                        if (userInput.Text.ToLower().Equals("")) quizResult++;

                        ChatBotReply.Content = "...";

                        askQuestionCount++;

                        saveQuestionCount++;

                        break;

                    case 5:

                        if (userInput.Text.ToLower().Equals("")) quizResult++;

                        ChatBotReply.Content = "...";

                        askQuestionCount++;

                        saveQuestionCount++;

                        break;

                    case 6:

                        if (userInput.Text.ToLower().Equals("")) quizResult++;

                        ChatBotReply.Content = "...";

                        askQuestionCount++;

                        saveQuestionCount++;

                        break;

                    case 7:

                        if (userInput.Text.ToLower().Equals("")) quizResult++;

                        ChatBotReply.Content = "...";

                        askQuestionCount++;

                        saveQuestionCount++;

                        break;

                    case 8:

                        if (userInput.Text.ToLower().Equals("")) quizResult++;

                        ChatBotReply.Content = "...";

                        askQuestionCount++;

                        saveQuestionCount++;

                        break;

                    case 9:

                        if (userInput.Text.ToLower().Equals("")) quizResult++;

                        ChatBotReply.Content = "...";

                        askQuestionCount++;

                        saveQuestionCount++;

                        break;

                    case 10:

                        if (userInput.Text.ToLower().Equals("")) quizResult++;

                        ChatBotReply.Content = "...";

                        askQuestionCount++;

                        saveQuestionCount++;

                        break;

                    case 11:

                        if (userInput.Text.ToLower().Equals("")) quizResult++;

                        ChatBotReply.Content = "...";

                        askQuestionCount++;

                        saveQuestionCount++;

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

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            home.Show();
        }

        private void TaskAssistant_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            taskAssistant.Show();
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
