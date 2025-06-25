using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static POEFinalPartWPF.Question;

namespace POEFinalPartWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Question question = new Question();

        TaskAssistant taskAssistant = new TaskAssistant();

        MiniGame miniGame = new MiniGame();

        public MainWindow()
        {      
           
            InitializeComponent();

            this.Show();

            mediaElement.Play();

        }

        private List<string> otherKeywords = new List<string> { "car", "cars", "trucks", "truck", "bike", "bikes", "no" };

        private List<string> keywords = new List<string> { "passwords", "password", "phishing", "safe browsing", "no" };

        private List<string> emotionKeywords = new List<string> { "worried", "curious", "frustrated" };

        private List<string> interestedKeywords = new List<string> { "passwords", "password", "phishing", "safe browsing", };

        //================== Calling Delegate ==================

        private QuestionDelegate questionDelegate;

        //private StreamWriter writer = new StreamWriter("C:\\Users\\lab_services_student\\Documents\\GitHub\\PROG6221FinalPOE\\POEFinalPartWPF\\userInformation.txt.txt");

        private string askQuestion1 = "";

        private string answer2 = "";

        private string emotion = "";

        private int askQuestionCount = 10;

        private int saveQuestionCount = 1;

        private void askQuestion()
        {

            string userName = question.getName();

            switch (askQuestionCount)
            {

                case 1:
                        //================== Asking how was the day so far ==================

                        askQuestion1 = "--------------------------------------------------\n\n- How was your day so far, " + userName + "?  -\n\n--------------------------------------------------";

                        ChatBotReply.Content = askQuestion1;
                        break;

                case 2:

                        //================== Asking for favourite topics from the user ==================
                        askQuestion1 = "--------------------------------------------------\n\n- What are you interest in, " + userName + "?, mainly in cyberSecurity  -\n\n--------------------------------------------------";

                        ChatBotReply.Content = askQuestion1;

                        break;

                case 3:

                    askQuestion1 = "--------------------------------------------------\n\n- Any Questions before we continue to cyberSecurity, " + userName + "?, 'Yes', or 'No'  -\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;

                    break;

                case 4:

                    askQuestion1 = "--------------------------------------------------\n\n-  What type of question would you like to ask, " + userName + "?  -\n\n--------------------------------------------------";

                    ChatBotReply.Content = askQuestion1;
                    
                    break;

                case 5:

                    string userInterest = question.getFavouriteTopic()[0];

                        askQuestion1 = "\n--------------------------------------------------\n\n-  " +
                                "\nWhat Question do you wish to ask about cyber security, " + userName + "?, Enter 'No' for exit\n\n--------------------------------------------------\n\n";


                    if (userInterest.Equals("password") || userInterest.Equals("passwords")) askQuestion1 = askQuestion1 +
                            "\nAs someone interested in Passwords, i recommend you ask about Password security" +
                        "\n--------------------------------------------------\n\n";

                    else if (userInterest.Equals("phishing")) askQuestion1 = askQuestion1 +
                            "\nAs someone interested in Phishing, i recommend you ask about Phishing security" +
                        "\n--------------------------------------------------\n\n";

                    else if (userInterest.Equals("safe browsing")) askQuestion1 = askQuestion1 +
                            "\nAs someone interested in Safe Browsing, i recommend you ask about Safe Browsing security" +
                        "\n--------------------------------------------------\n\n";

                        ChatBotReply.Content = askQuestion1;

                    break;

                case 6:
                    questionDelegate = question.ContinueQuestion;

                    ChatBotReply.Content = questionDelegate(answer2);
                    askQuestionCount--;
                    saveQuestionCount--;
                break;

                case 7:

                    askQuestion1 = "Do you wish to leave?";

                    ChatBotReply.Content = askQuestion1;

                    if (userInput.Text.ToLower().Equals("yes")) askQuestionCount = 0;
                        
                    else if(userInput.Text.ToLower().Equals("no")) askQuestionCount = 5;
                        

                    break;

                default:
                    break;
            }
        }

        private void saveQuestion() 
        {

            string userName = question.getName();

            switch (saveQuestionCount)
            {

                case 1:
                        
                    userName = userInput.Text;

                    question.setName(userName);

                    askQuestionCount = 1;

                    saveQuestionCount++;

                    break;

                case 2:

                        string userDay = userInput.Text;

                        question.setDay(userDay);

                        ChatBotReply.Content = "...";

                        askQuestionCount++;

                        saveQuestionCount++;

                        break;

                case 3:

                        string userFavourite = userInput.Text;

                        string userInterest = "";

                        List<string> recognizedKeywordsInterest = RecognizeKeywords(userFavourite.ToLower(), interestedKeywords);

                        foreach (string keyword in recognizedKeywordsInterest)
                        {
                            userInterest = keyword;
                        }


                        List<string> topicArray = question.getFavouriteTopic();

                        topicArray.Add(userInterest);

                        question.setFavouriteTopic(topicArray);

                        ChatBotReply.Content = "...";

                        Thread.Sleep(3000); //wait for 3 seconds
                        
                        MessageBox.Show("Great, i will remember that you are interest interested in " + userFavourite, "Great", MessageBoxButton.OK);

                        askQuestionCount++;

                        saveQuestionCount++;                        

                    break;

                case 4:
                        
                    string otherQuestions = userInput.Text;

                    ChatBotReply.Content = "...";

                    Thread.Sleep(3000); //wait for 3 seconds

                    if (otherQuestions.ToLower().Equals("no"))
                    {
                        askQuestionCount = askQuestionCount + 2;
                        saveQuestionCount = saveQuestionCount + 2;
                    }

                    else if (otherQuestions.ToLower().Equals("yes"))
                    {
                        askQuestionCount++;
                        saveQuestionCount++;
                    }
                    else ChatBotReply.Content = "\nSorry, I didn't understand that. Could you rephrase\n";

                        break;

                case 5:

                    //================== Searching Keywords for question ==================

                    List<string> recognizedKeywords = RecognizeKeywords(askQuestion1.ToLower(), otherKeywords);

                    foreach (string keyword in recognizedKeywords)
                    {
                        answer2 = keyword;
                    }

                    //================== Searching Keywords for emotion ==================

                    List<string> recognizedEmotionKeywords = RecognizeKeywords(askQuestion1.ToLower(), emotionKeywords);

                    emotion = "";

                    foreach (string keyword in recognizedEmotionKeywords)
                    {
                        emotion = keyword;
                    }

                    if (!answer2.Equals(null))
                    {
                        ChatBotReply.Content = question.otherQuestions(answer2, emotion);
                        askQuestionCount = 3;
                        saveQuestionCount--;
                        Thread.Sleep(10000);
                    }

                    else if (answer2.Equals("no")) break;

                    else MessageBox.Show("\nSorry, I didn't understand that. Could you rephrase\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);

                    break;

                case 6:

                        recognizedKeywords = RecognizeKeywords(askQuestion1.ToLower(), keywords);

                        foreach (string keyword in recognizedKeywords)
                        {
                            answer2 = keyword;
                        }

                        //================== Searching Keywords for emotion ==================

                        recognizedEmotionKeywords = RecognizeKeywords(askQuestion1.ToLower(), emotionKeywords);

                        emotion = "";

                        foreach (string keyword in recognizedEmotionKeywords)
                        {
                            emotion = keyword;
                        }

                    if (answer2.Equals("no"))
                    {
                        askQuestionCount = 7;
                    }

                    //================== Password Question ==================

                    else if (answer2.Equals("password") || answer2.Equals("passwords"))
                    {
                        questionDelegate = question.Password;

                        ChatBotReply.Content =  questionDelegate(emotion);

                    }
                    
                    //================== Phishing Question ==================

                    else if (answer2.Equals("phishing"))
                    {
                        questionDelegate = question.Phishing;

                        ChatBotReply.Content = questionDelegate(emotion);

                    }

                    //================== SAfe Browsing Question ==================

                    else if (answer2.Equals("safe browsing"))
                    {
                        questionDelegate = question.SafeBrowsing;

                        ChatBotReply.Content = questionDelegate(emotion);

                    }
                    
                    else ChatBotReply.Content = "\nSorry, I didn't understand that. Could you rephrase\n";
                       
                    askQuestionCount++;

                        break;
                                       
                    default:
                        break;
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
