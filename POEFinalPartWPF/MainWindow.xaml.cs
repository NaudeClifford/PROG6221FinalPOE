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
        private Question question = new Question();

        public MainWindow()
        {
            InitializeComponent();

            welcomeMessageLabel.Content = question.welcomeMessage();

            mediaElement.Play();
        }

        private List<string> otherKeywords = new List<string> { "car", "cars", "trucks", "truck", "bike", "bikes", "no"};

        private List<string> keywords = new List<string> { "passwords", "password", "phishing", "safe browsing", "no"};

        private List<string> emotionKeywords = new List<string> { "worried", "curious", "frustrated" };

        private List<string> interestedKeywords = new List<string> { "passwords", "password", "phishing", "safe browsing"};

        //================== Calling Delegate ==================

        private QuestionDelegate questionDelegate;

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
                //how was your day question, savecount 2
                case 1:
                    //================== Asking how was the day so far ==================

                    ChatBotReply.FontSize = 30;

                    askQuestion1 = "--------------------------------------------------\n\n- How was your day so far, " + userName + "?  -\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    saveQuestionCount = 2;
                        
                    break;
                //save count 3, asking for favourite topic
                case 2:

                    //================== Asking for favourite topics from the user ==================
                    ChatBotReply.FontSize = 30;

                    askQuestion1 = "--------------------------------------------------\n\n- What are you interested in, " + userName + "?, mainly in cyberSecurity  -\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    saveQuestionCount = 3;

                    break;
                //save count 4, asking to continue to cyber security
                case 3:

                    ChatBotReply.FontSize = 20;

                    askQuestion1 = "--------------------------------------------------\n\n- Any Questions before we continue to cyberSecurity, " + userName + "?, 'Yes', or 'No'  -\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    saveQuestionCount = 4;

                    break;
                //save count 5, asking what type of questions to ask
                case 4:

                    ChatBotReply.FontSize = 20;

                    askQuestion1 = "--------------------------------------------------\n\n-  What type of question would you like to ask, " + userName + "?  -\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    saveQuestionCount = 5;

                    break;
                //otherquestions, save count 6
                case 5:
                    //================== Searching Keywords for question ==================
                    askQuestion1 = userInput.Text;

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

                    ChatBotReply.Text = question.otherQuestions(answer2, emotion);

                    saveQuestionCount = 6;
                    
                    userInput.Text = "";

                    break;
                //save count 7, asking what question in cyber security should i answer
                case 6:

                    ChatBotReply.FontSize = 15;

                    string userInterest = question.getFavouriteTopic()[0];

                    askQuestion1 = "\n----------------------------------------------------------------------------------------------------\n  " +
                                "\n-What Question do you wish to ask about cyber security, " + userName + "?-" +
                                "\n----------------------------------------------------------------------------------------------------\n\n";

                    if (userInterest.Equals("password") || userInterest.Equals("passwords")) askQuestion1 = askQuestion1 +
                            "\nAs someone interested in Passwords, i recommend you ask about Password security" +
                        "\n--------------------------------------------------\n\n";

                    else if (userInterest.Equals("phishing")) askQuestion1 = askQuestion1 +
                            "\nAs someone interested in Phishing, i recommend you ask about Phishing security" +
                        "\n--------------------------------------------------\n\n";

                    else if (userInterest.Equals("safe browsing")) askQuestion1 = askQuestion1 +
                            "\nAs someone interested in Safe Browsing, i recommend you ask about Safe Browsing security" +
                        "\n--------------------------------------------------\n\n";

                    ChatBotReply.Text = askQuestion1;

                    saveQuestionCount = 7;

                    userInput.Text = "";

                    break;
                //save count 8, ask to continue question's answer
                case 7:
                    ChatBotReply.FontSize = 20;

                    askQuestion1 = userInput.Text;

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

                    //================== Password Question ==================

                    if (answer2.Equals("password") || answer2.Equals("passwords"))
                    {
                        questionDelegate = question.Password;

                        ChatBotReply.Text = questionDelegate(emotion) + ". May i continue?";

                        saveQuestionCount = 8;

                    }

                    //================== Phishing Question ==================

                    else if (answer2.Equals("phishing"))
                    {
                        questionDelegate = question.Phishing;

                        ChatBotReply.Text = questionDelegate(emotion) + ". May i continue?";

                        saveQuestionCount = 8;
                    }

                    //================== SAfe Browsing Question ==================

                    else if (answer2.Equals("safe browsing"))
                    {
                        questionDelegate = question.SafeBrowsing;

                        ChatBotReply.Text = questionDelegate(emotion) + ". May i continue?";

                        saveQuestionCount = 8;
                    }

                    else ChatBotReply.Text = "\nSorry, I didn't understand that. Could you rephrase\n";

                    userInput.Text = "";

                    break;
                //savecount = 9, continue with question answer
                case 8:

                    questionDelegate = question.ContinueQuestion;

                    ChatBotReply.Text = questionDelegate(answer2);

                    saveQuestionCount = 9;

                    userInput.Text = "";

                    break;
                //savecount = 10, ask if user wants to leave
                case 9:

                    askQuestion1 = "Do you wish to leave?";

                    ChatBotReply.Text = askQuestion1;

                    saveQuestionCount = 10;

                    userInput.Text = "";

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
                //question count = 1, save user name
                case 1:
                        
                    userName = userInput.Text;

                    question.setName(userName);

                    askQuestionCount = 1;

                    userInput.Text = "";

                    break;
                //question count = 2, save user day
                case 2:

                    string userDay = userInput.Text;

                    question.setDay(userDay);

                    ChatBotReply.Text = "...";

                    askQuestionCount = 2;

                    userInput.Text = "";

                    break;
                //question count = 3, save user favourite topic
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
                        
                    MessageBox.Show("Great, i will remember that you are interested in " + userFavourite, "Great", MessageBoxButton.OK);

                    askQuestionCount = 3;

                    userInput.Text = "";

                    break;
                //question count = 4, 6, save other questions
                case 4:
                        
                    string otherQuestions = userInput.Text;

                    if (otherQuestions.ToLower().Equals("no")) askQuestionCount = 6;
                    

                    else if (otherQuestions.ToLower().Equals("yes")) askQuestionCount = 4;
                    
                    userInput.Text = "";

                    break;
                //question count = 5, other questions asked
                case 5:

                    askQuestionCount = 5;

                    break;
                //question count = 6, cybersecurity questions
                case 6:

                    askQuestionCount = 6;

                    break;
                //question count = 7 
                case 7:

                    askQuestionCount = 7;
                    break;
                //question count = 8, yes or no, 9 
                case 8:

                    ChatBotReply.FontSize = 20;

                    string user = userInput.Text;

                    if (user.ToLower().Equals("yes"))
                    {

                        askQuestionCount = 8;
                    }

                    else
                    {

                        askQuestionCount = 9;
                    }
                    break;
                //question count = 9 
                case 9:
                    askQuestionCount = 9;
                    break;
                //question count = 0, 6, yes or no 
                case 10:

                    if (userInput.Text.ToLower().Equals("yes")) askQuestionCount = 0;
                    
                    else if (userInput.Text.ToLower().Equals("no")) askQuestionCount = 6;
                    
                    break;

                default:
                        
                    userInput.Text = "";

                    break;
                }
        }
        
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !userInput.Text.Equals(null))
            {
                try
                {
                    
                    saveQuestion();

                    askQuestion();

                    if (askQuestionCount == 0) this.Close();

                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("\nSorry, I didn't understand that. Could you rephrase\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                catch (FormatException)
                {
                    MessageBox.Show("\nSorry, I didn't understand that. Could you rephrase\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                catch (FileNotFoundException)
                {
                    MessageBox.Show("\nSorry, I didn't understand that. Could you rephrase\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                catch (ArgumentException) 
                {
                    MessageBox.Show("\nSorry, I didn't understand that. Could you rephrase\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                catch (StackOverflowException)
                {
                    MessageBox.Show("\nSorry, I didn't understand that. Could you rephrase\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                catch (Exception)
                {
                    MessageBox.Show("\nSorry, I didn't understand that. Could you rephrase\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Respond_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                saveQuestion();

                askQuestion();

                if (askQuestionCount == 0) this.Close();
            
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("\nSorry, I didn't understand that. Could you rephrase\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            catch (FormatException)
            {
                MessageBox.Show("\nSorry, I didn't understand that. Could you rephrase\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            catch (FileNotFoundException)
            {
                MessageBox.Show("\nSorry, I didn't understand that. Could you rephrase\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            catch (ArgumentException)
            {
                MessageBox.Show("\nSorry, I didn't understand that. Could you rephrase\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            catch (StackOverflowException)
            {
                MessageBox.Show("\nSorry, I didn't understand that. Could you rephrase\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            catch (Exception)
            {
                MessageBox.Show("\nSorry, I didn't understand that. Could you rephrase\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            userInput.Text = null;
        }

        private void MiniGame_Click(object sender, RoutedEventArgs e)
        {
            MiniGame miniGame = new MiniGame();
            
            miniGame.Show();
            
            this.Hide();
        }

        private void TaskAssistant_Click(object sender, RoutedEventArgs e)
        {
            TaskAssistant taskAssistant = new TaskAssistant();
            
            taskAssistant.Show();
            
            this.Hide();     
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
