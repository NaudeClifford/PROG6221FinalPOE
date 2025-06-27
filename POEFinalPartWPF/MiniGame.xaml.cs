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

        private Question question = new Question();

        private int askQuestionCount = 15;

        private int saveQuestionCount = 1;

        private string askQuestion1 = "";

        private List<string> correctAnswersArray = new List<string>(10) { "", "", "", "", "", "", "", "", "", ""};

        private int quizResult = 0;
        
        public MiniGame()
        {
            InitializeComponent();
        }

        private List<string> keywords = new List<string> { "" };

        private void askQuestion()
        {

            switch (askQuestionCount)
            {

                case 1:

                    askQuestion1 = "--------------------------------------------------\n\n-When it is time to change passwords, whats the easier way to choose one?-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;
                    break;

                case 2:

                    askQuestion1 = "--------------------------------------------------\n\n-What are the normal characters used in a password?-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    break;

                case 3:

                    askQuestion1 = "--------------------------------------------------\n\n-_____ is a internet scam done by cyber criminals where user is convinced to provide information.-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    break;

                case 4:

                    askQuestion1 = "--------------------------------------------------\n\n-Phishers often develop ______ websites for tricking users and filling their personal data-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    break;

                case 5:

                    askQuestion1 = "--------------------------------------------------\n\n-What is internet safety?-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    break;

                case 6:

                    askQuestion1 = "--------------------------------------------------\n\n-What is a common risk with sharing personal information on the internet?-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    break;

                case 7:

                    askQuestion1 = "--------------------------------------------------\n\n-What risk are accociated with social engineering attacks-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    break;

                case 8:

                    askQuestion1 = "--------------------------------------------------\n\n-What challenges have you faced with social engineering attacks? no wrong answers-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    break;

                case 9:

                    askQuestion1 = "--------------------------------------------------\n\n-I have a really strong password, should i use it for many years? True/False-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    break;

                case 10:

                    askQuestion1 = "--------------------------------------------------\n\n-What is the purpose of privacy settings on social media?\na) To restrict internet access" +
                        "\nb) To protect personal information and control who view it\nc) To share personal information\nd) To block all incoming messages" +
                        "n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    break;
                //Result
                case 11:

                    if (quizResult >= 8) askQuestion1 = "Results: " + quizResult + "\nGreat job, You are a cyber security pro!";

                    else if (quizResult < 8 && quizResult >= 5) askQuestion1 = "Results: " + quizResult + "\nNot bad";

                    else askQuestion1 = "Results: " + quizResult + "\nKeep learning to be safe online";

                    ChatBotReply.Text = askQuestion1;
                    break;

                default:
                    break;
            }
        }

        private void saveQuestion()
        {            

            switch (saveQuestionCount)
                {
                //asking to start
                case 1:

                    ChatBotReply.FontSize = 20;

                    if (userInput.Text.ToLower().Equals("yes"))
                    {
                        askQuestionCount = 1;

                        saveQuestionCount++;
                    }

                    userInput.Text = "";

                        break;
                //Question 1
                case 2:
                        //Answer: choose something you can remember but make it complex to strengthen the password
                    askQuestion1 = userInput.Text.ToLower();

                    string user1 = "";

                    string user2 = "";

                    List<string> correctAnswers = new List<string>(2) { "something that you can remember", "something that i can remember"};
                        
                    List<string> correctAnswers2 = new List<string>(2) { "make it complex", "make it complicated" };

                            //recognize the keywords
                    List<string> recognizedKeywordsInterest = RecognizeKeywords(askQuestion1, correctAnswers);

                    foreach (string keyword in recognizedKeywordsInterest) user1 = keyword;

                    ///recognize the keywords
                    List<string> recognizedKeywordsInterest1 = RecognizeKeywords(askQuestion1, correctAnswers2);

                    foreach (string keyword in recognizedKeywordsInterest1) user2 = keyword;

                    if ((user1.Equals("something that you can remember") || user1.Equals("something that i can remember")) && (user2.Equals("make it complex") || user2.Equals("make it complicated")))
                        {
                            MessageBox.Show("\nCorrect, You must always pick something that you can remember\nand it must be complex enough to be safe"
                                , "Feedback", MessageBoxButton.OK, MessageBoxImage.Information);
                            quizResult++;
                            correctAnswersArray[0] = userInput.Text;
                        }

                    else MessageBox.Show("\nSorry, Wrong Answer. You must always pick something that you can remember\nand it must be complex enough to be safe"
                        , "Invalid", MessageBoxButton.OK, MessageBoxImage.Information);

                    askQuestionCount++;

                    saveQuestionCount++;

                    userInput.Text = "";

                    break;
                //Question 2
                case 3:
                        //Answer: choose something you can remember but make it complex to strengthen the password
                    askQuestion1 = userInput.Text.ToLower();

                    user1 = "";

                    correctAnswers = new List<string>(7) { "letters", "letter", "number", "numbers", "mixed case", "mixed cases", "special characters"};
                        
                    //recognize the keywords
                    recognizedKeywordsInterest = RecognizeKeywords(askQuestion1, correctAnswers);

                    foreach (string keyword in recognizedKeywordsInterest) user1 = keyword;
                   
                    if (user1.Equals("letters") || user1.Equals("letter") || user1.Equals("number") || user1.Equals("numbers") || user1.Equals("mixed case") || user1.Equals("mixed cases") ||
                            user1.Equals("special characters"))
                        {
                            MessageBox.Show("\nCorrect, A password can consist of lots of different characters.\n As long as that are not predictable", "Feedback", MessageBoxButton.OK, MessageBoxImage.Information);
                            quizResult++;
                            correctAnswersArray[1] = userInput.Text;
                        }

                    else MessageBox.Show("\nSorry, Wrong Answer.  A password must consist of lots of different characters", "Invalid", MessageBoxButton.OK, MessageBoxImage.Information);

                    askQuestionCount++;

                    saveQuestionCount++;

                    userInput.Text = "";

                        break;
                //Question 3
                case 4:
                    //Answer: choose something you can remember but make it complex to strengthen the password
                    askQuestion1 = userInput.Text.ToLower();

                    user1 = "";


                    correctAnswers = new List<string>(1) { "phishing" };

                    //recognize the keywords
                    recognizedKeywordsInterest = RecognizeKeywords(askQuestion1, correctAnswers);

                    foreach (string keyword in recognizedKeywordsInterest) user1 = keyword;
                    
                    if (user1.Equals("phishing"))
                    {
                        MessageBox.Show("\nCorrect, Phishing is a internet scam", "Feedback", MessageBoxButton.OK, MessageBoxImage.Information);
                        quizResult++;
                        correctAnswersArray[2] = userInput.Text;
                    }

                    else MessageBox.Show("\nSorry, Wrong Answer. Phishing is a internet scam, \nnot: " + user1, "Invalid", MessageBoxButton.OK, MessageBoxImage.Information);

                    askQuestionCount++;

                    saveQuestionCount++;

                    userInput.Text = "";

                    break;
                //Question 4
                case 5:
                    //Answer: choose something you can remember but make it complex to strengthen the password
                    askQuestion1 = userInput.Text.ToLower();

                    user1 = "";

                    correctAnswers = new List<string>(1) { "illegitimate" };

                    //recognize the keywords
                    recognizedKeywordsInterest = RecognizeKeywords(askQuestion1, correctAnswers);

                    foreach (string keyword in recognizedKeywordsInterest) user1 = keyword;
                    
                    if (user1.Equals("illegitimate"))
                    {
                        MessageBox.Show("\nCorrect, Phishers make illegitimate websites", "Feedback", MessageBoxButton.OK, MessageBoxImage.Information);
                        quizResult++;
                        correctAnswersArray[3] = userInput.Text;
                    }

                    else MessageBox.Show("\nSorry, Wrong Answer. Phishers make illegitimate websites", "Invalid", MessageBoxButton.OK, MessageBoxImage.Information);

                    askQuestionCount++;

                    saveQuestionCount++;

                    userInput.Text = "";
                    break;
                //Question 5
                case 6:
                    //Answer: choose something you can remember but make it complex to strengthen the password
                    askQuestion1 = userInput.Text.ToLower();

                    user1 = "";

                    correctAnswers = new List<string>(2) { "protecting individuels and information" };

                    //recognize the keywords
                    recognizedKeywordsInterest = RecognizeKeywords(askQuestion1, correctAnswers);

                    foreach (string keyword in recognizedKeywordsInterest) user1 = keyword;
                    
                    if (user1.Equals("protecting individuels and information"))
                    {
                        MessageBox.Show("\nCorrect, Internet safety is for protecting individuels and information. \nIt is important to know next time you fill a form.",
                            "Feedback", MessageBoxButton.OK, MessageBoxImage.Information);
                        quizResult++;
                        correctAnswersArray[4] = userInput.Text;
                    }

                    else MessageBox.Show("\nSorry, Internet safety is for protecting individuels and information. \nIt is important to know next time you fill a form.",
                        "Invalid", MessageBoxButton.OK, MessageBoxImage.Information);

                    askQuestionCount++;

                    saveQuestionCount++;

                    userInput.Text = "";

                    break;
                //Question 6
                case 7:
                    //Answer: choose something you can remember but make it complex to strengthen the password
                    askQuestion1 = userInput.Text.ToLower();

                    user1 = "";

                    correctAnswers = new List<string>(1) { "identity theft" };

                    //recognize the keywords
                    recognizedKeywordsInterest = RecognizeKeywords(askQuestion1, correctAnswers);

                    foreach (string keyword in recognizedKeywordsInterest) user1 = keyword;
                    
                    if (user1.Equals("identity theft"))
                    {
                        MessageBox.Show("\nCorrect, Be careful sharing information on the internet as it can result in identity theft", "Feedback", MessageBoxButton.OK, MessageBoxImage.Information);
                        quizResult++;
                        correctAnswersArray[5] = userInput.Text;
                    }

                    else MessageBox.Show("\nSorry, Wrong Answer. answer is identity theft since othre people have your information, \nthey can act as you",
                        "Invalid", MessageBoxButton.OK, MessageBoxImage.Information);

                    askQuestionCount++;

                    saveQuestionCount++;

                    userInput.Text = "";

                    break;
                //Question 7
                case 8:
                    //Answer: choose something you can remember but make it complex to strengthen the password
                    askQuestion1 = userInput.Text.ToLower();

                    user1 = "";

                    correctAnswers = new List<string>(2) { "financial loss", "reputation damage", "data breaches", "compliance violations" };

                    //recognize the keywords
                    recognizedKeywordsInterest = RecognizeKeywords(askQuestion1, correctAnswers);

                    foreach (string keyword in recognizedKeywordsInterest) user1 = keyword;
                   
                    if (user1.Equals("financial loss") || user1.Equals("reputation damage") || user1.Equals("data breaches") || user1.Equals("compliance violations"))
                    {
                        MessageBox.Show("\nCorrect, they are many risk to social engineering, that is why you must learn more on the topic", "Feedback", MessageBoxButton.OK, MessageBoxImage.Information);
                        quizResult++;
                        correctAnswersArray[6] = userInput.Text;
                    }

                    else MessageBox.Show("\nSorry, Wrong Answer. answer is any of these: financial loss, reputation damage, data breaches, compliance violations", "Invalid",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    askQuestionCount++;

                    saveQuestionCount++;

                    userInput.Text = "";
                    break;
                //Question 8
                case 9:
                    //Answer: choose something you can remember but make it complex to strengthen the password
                    askQuestion1 = userInput.Text.ToLower();

                    MessageBox.Show("\nCorrect, No wrong answers", "Valid", MessageBoxButton.OK, MessageBoxImage.Information);
                    quizResult++;
                    correctAnswersArray[7] = userInput.Text;
                   
                    askQuestionCount++;

                    saveQuestionCount++;

                    userInput.Text = "";
                    break;
                //Question 9
                case 10:
                    //Answer: choose something you can remember but make it complex to strengthen the password
                    askQuestion1 = userInput.Text.ToLower();

                    user1 = "";

                    correctAnswers = new List<string>(2) { "true", "false" };

                    //recognize the keywords
                    recognizedKeywordsInterest = RecognizeKeywords(askQuestion1, correctAnswers);

                    foreach (string keyword in recognizedKeywordsInterest) user1 = keyword;
                    
                    if (user1.Equals("true") || user1.Equals("false"))
                    {
                        MessageBox.Show("\nCorrect, You should always change passwords every year as a good practice", "Feedback", MessageBoxButton.OK, MessageBoxImage.Information);
                        quizResult++;
                        correctAnswersArray[0] = userInput.Text;
                    }

                    else MessageBox.Show("\nSorry, Wrong Answer, you should always change passwords every year as a safe practice", "Invalid", MessageBoxButton.OK, MessageBoxImage.Information);

                    askQuestionCount++;

                    saveQuestionCount++;

                    userInput.Text = "";

                    break;
                //Question 10
                case 11:
                    //Answer: choose something you can remember but make it complex to strengthen the password
                    askQuestion1 = userInput.Text.ToLower();

                    if (askQuestion1.Equals("b"))
                    {
                        MessageBox.Show("\nCorrect, To protect personal information, this is important to prevent identity theft attacks, Enter Ok to finish", "Feedback",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        quizResult++;
                        correctAnswersArray[0] = userInput.Text;
                    }

                    else MessageBox.Show("\nSorry, Wrong Answer. answer is (b) to protect personal information, Enter Ok to finish", "Invalid", MessageBoxButton.OK, MessageBoxImage.Information);

                    askQuestionCount++;

                    saveQuestionCount++;

                    userInput.Text = "";
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

            catch (Exception)
            {
                MessageBox.Show("\nSorry, I didn't understand that. Could you rephrase\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            userInput.Text = null;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            
            home.Show();
            
            this.Hide();

            if (askQuestionCount != 11) question.LogQuestions("Quiz started: " + askQuestionCount + " questions completed, Score: " + quizResult);

            else question.LogQuestions("Quiz started: " + askQuestionCount + " questions completed, Score: " + quizResult);
        }

        private void TaskAssistant_Click(object sender, RoutedEventArgs e)
        {
            TaskAssistant taskAssistant = new TaskAssistant();

            taskAssistant.Show();
            
            this.Hide();

            if (askQuestionCount != 11) question.LogQuestions("Quiz started: " + askQuestionCount + " questions completed, Score: " + quizResult);

            else question.LogQuestions("Quiz started: " + askQuestionCount + " questions completed, Score: " + quizResult);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            var result = MessageBox.Show("Are You Sure?",
                                         "Question",
                                         MessageBoxButton.YesNo);

            // User doesn't want to close, cancel closure
            if (result == MessageBoxResult.No)
                e.Cancel = true;

            else {
                if (askQuestionCount != 11) question.LogQuestions("Quiz started: " + askQuestionCount + " questions completed, Score: " + quizResult);
                
                else question.LogQuestions("Quiz started: " + askQuestionCount + " questions completed, Score: " + quizResult);
            }
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
