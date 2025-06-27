using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
using static System.Net.Mime.MediaTypeNames;
using static POEFinalPartWPF.Question;

namespace POEFinalPartWPF
{
    /// <summary>
    /// Interaction logic for TaskAssistant.xaml
    /// </summary>
   
    public partial class TaskAssistant : Window
    { 
    
        private Question question = new Question();

        private List<string> keywords = new List<string> { "add", "add task", "remove task", "show tasks", "review tasks", "view tasks", 
            "show task", "review task", "view task", "yes", "no", "ok", "remove", "show log activity", "what have you done for me?", "mark task"};

        private List<string> reminderKeywords = new List<string> { "remind me", "add reminder" };

        private string askQuestion1 = "";

        private int askQuestionCount = 11;

        private int saveQuestionCount = 1;

        //For storage
        private List<string> task = new List<string>();

        private List<string> description = new List<string>();

        private List<string> reminder = new List<string>();

        private string taskName = "";

        private string taskName1 = "";
        private string taskDescription1 = "";
        private string taskDate1 = "";

        private string userUnedited = "";
        private string user = "";

        private int numberOfTask = 0;

        private int removeTaskCount = 0;

        public TaskAssistant()
        {
            InitializeComponent();
        }

        private void askQuestion()
        {

            string userName = question.getName();

            switch (askQuestionCount)
            {
                //saveQuestion count 2, task added
                case 1:
                    //ask task name
                    ChatBotReply.FontSize = 20;

                    askQuestion1 = "--------------------------------------------------\n\n-Added Task Named: " + taskName1 + "\nWith Description: " + taskDescription1 + "\nWith reminder: " + taskDate1
                        + "\nPress Ok to continue-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;
                    break;
                //saveQuestion count 4, task added without reminder
                case 2:

                    //================== ask description ==================
                    askQuestion1 = "--------------------------------------------------\n\n-Added Task Named: " + taskName1 +"\nWith Description: " + taskDescription1
                        +"\nWould you like a reminder?-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;
                    saveQuestionCount = 4;
                    break;
                //saveQuestion count 5, enter reminder date
                case 3:
                    //ask reminder
                    askQuestion1 = "--------------------------------------------------\n\nEnter reminder date\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;
                    saveQuestionCount = 5;

                    break;
                //Added task reminder
                case 4:

                    askQuestion1 = "--------------------------------------------------\n\nTask reminder added: " + taskDate1 + "say Ok to continue-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;
                    
                    break;
                //saveQuestionCount = 6, are you sure you want to delete?
                case 5:
                    //ask to confirm
                    askQuestion1 = "--------------------------------------------------\n\nAre you sure you want to remove task? : " + taskName1 + "-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    saveQuestionCount = 6;

                    break;
                //task been removed
                case 6:

                    askQuestion1 = "--------------------------------------------------\n\n-Task has been removed: " + taskName1 + ", Say Ok to continue-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;
                                        
                    break;
                //saveQuestion count 7, what task do you wish to view
                case 7:

                    askQuestion1 = "--------------------------------------------------\n\n-What task do you wish to view?-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    saveQuestionCount = 7;

                    userInput.Text = "";

                    break;
                //show one task
                case 8:
                    
                    int check = 0;

                    for(int i = 0; i < task.Count(); i++)
                    {
                        if (taskName1.Equals(task[i]))
                        {
                            check = 1;
                            taskDescription1 = description[i];
                            taskDate1 = reminder[i];

                            break;
                        }
                        else{ }
                        
                    }

                    if (check == 1) {
                        askQuestion1 = "--------------------------------------------------\n\n-Task Name: " + taskName1 + "\nTask Description: " + taskDescription1 + "\nTask Reminder: " + taskDate1
                            + "\nSay Ok to continue-\n\n--------------------------------------------------";

                        question.LogQuestions("Task viewed: " + taskName1 + ", User asked to view this task.");

                        ChatBotReply.Text = askQuestion1;
                    }
                    else
                    {
                        MessageBox.Show("\nSorry, I didn't understand that. Could you rephrase\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                        askQuestionCount = 7;
                        saveQuestionCount = 1;

                    }

                    break;
                //show all task
                case 9:

                    string task1 = "";
                                        
                    for (int i2 = 0; i2 < task.Count; i2++) task1 = task1 + "\n\nTask Name: " + task[i2] + "\nTask Description: " + description[i2] + "\nTask Reminder: " + reminder[i2];
                        
                    askQuestion1 = "--------------------------------------------------\n\n-" + task1 + "\n Say Ok to continue-\n\n--------------------------------------------------";

                    question.LogQuestions("All task reviewed, user ask to view all the task.");

                    ChatBotReply.Text = askQuestion1;

                    break;
                //Asking what task to remove, save count 8
                case 10:
                    //ask to confirm
                    askQuestion1 = "--------------------------------------------------\n\nWhat task do you want to remove?-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    saveQuestionCount = 8;

                    userInput.Text = "";

                    break;
                //starting question
                case 11:
                    ChatBotReply.Text = "Welcome user, review, add, mark task or remove a task? Can also view Log Activity";
                    
                    break;
                //asking if user wants to view the log
                case 12:
                    askQuestion1 = "--------------------------------------------------\n\nDo you wish to view the Log activity?-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    saveQuestionCount = 9;
                    break;
                //viewing log
                case 13:

                    string log = question.ReadLogQuestions();

                    Console.WriteLine(log);

                    ChatBotReply.Text = log + "\nSay Ok to continue";
                    break;
                //ask what task needs to be marked as completed.
                case 14:
                    askQuestion1 = "--------------------------------------------------\n\n-What task do you mark as completed?-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    saveQuestionCount = 10;

                    userInput.Text = "";

                    break;
                //show task i completed
                case 15:
                    askQuestion1 = "--------------------------------------------------\n\n-Task has been completed - "+ taskName1 + "\nEnter ok to continue-\n\n--------------------------------------------------";

                    ChatBotReply.Text = askQuestion1;

                    break;
                default:
                    break;
            }
        }
            
        //saves questions responses from the user
        private void saveQuestion()
        {
            string taskDate = "";

            userUnedited = userInput.Text;
            user = userInput.Text.ToLower();
            
            //recognize the keywords
            List<string> recognizedKeywordsInterest1 = RecognizeKeywords(user, keywords);

            foreach (string keyword in recognizedKeywordsInterest1) taskName = keyword;
                        
            List<string> recognizedKeywordsInterest3 = RecognizeKeywords(user, reminderKeywords);

            foreach (string reminderKeywords in recognizedKeywordsInterest3) taskDate = reminderKeywords;

            //Add task
            if ((taskName.Equals("add") || taskName.Equals("add task")))
            {
                //if includes reminder
                if (taskDate.Equals("remind me") || taskDate.Equals("add reminder"))
                {
                    askQuestionCount = 1;
                    saveQuestionCount = 2;

                }
                //doesn't include reminder
                else
                {
                    askQuestionCount = 2;
                    saveQuestionCount = 3;

                }
            }
            //remove task
            else if (taskName.Equals("remove task") || taskName.Equals("remove"))
            {

                askQuestionCount = 10;

            }
            //show task
            else if (taskName.Equals("show task") || taskName.Equals("review task") || taskName.Equals("view task"))
            {

                askQuestionCount = 7;

            }
            //show all tasks
            else if (taskName.Equals("show tasks") || taskName.Equals("review tasks") || taskName.Equals("view tasks"))
            {

                askQuestionCount = 9;

            }
            //show activitie log
            else if (taskName.Equals("show log activity") || taskName.Equals("what have you done for me?"))
            {
                askQuestionCount = 12;

                userInput.Text = "";
            }
            //mark task as completed
            else if (taskName.Equals("mark task")) {

                askQuestionCount = 14;

            }
            //go back to starting question
            else if (taskName.Equals("ok"))
            {

                askQuestionCount = 11;
                saveQuestionCount = 1;

                userInput.Text = "";
            }

            questions();
        }

        private void questions() 
        {

            switch (saveQuestionCount)
            {
                //save task
                case 2:

                    ChatBotReply.FontSize = 20;

                    userUnedited = userInput.Text;

                    user = userUnedited.ToLower();

                    taskName1 = "";
                    taskDescription1 = "";
                    taskDate1 = "";

                    SplitWords();

                    if (taskName1.Equals(""))
                    {
                        askQuestionCount = 11;
                        MessageBox.Show("\nSorry, You have to give a task name\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                        
                    }
                    else if (taskDescription1.Equals(""))
                    {
                        askQuestionCount = 11;
                        MessageBox.Show("\nSorry, You have to give a task description\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                        
                    }

                    else
                    {
                        task.Add(taskName1);
                        description.Add(taskDescription1);
                        reminder.Add(taskDate1);

                        question.LogQuestions("Task saved: "+ taskName1 + ", A task has been created and saved for later use.");

                        numberOfTask++;
                    }
                    userInput.Text = "";

                    break;
                //save task without reminder
                case 3:

                    ChatBotReply.FontSize = 20;

                    userUnedited = userInput.Text;

                    user = userUnedited.ToLower();

                    taskName1 = "";
                    taskDescription1 = "";
                    taskDate1 = "";

                    SplitWords();

                    if (taskName1.Equals(""))
                    {
                        askQuestionCount = 11;
                        MessageBox.Show("\nSorry, You have to give a task name\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                        
                    }
                    else if (taskDescription1.Equals(""))
                    {
                        askQuestionCount = 11;
                        MessageBox.Show("\nSorry, You have to give a task description\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                        
                    }

                    else
                    {

                        task.Add(taskName1);
                        description.Add(taskDescription1);
                        reminder.Add("");

                        question.LogQuestions("Task saved without reminder: "+ taskName1 + ", A task has been created and saved for later use.");

                        numberOfTask++;
                    }
                    userInput.Text = "";

                    break;
                //question count 3, 13, yes or no
                case 4:

                    if (taskName.Equals("yes")) askQuestionCount = 3;

                    else if (taskName.Equals("no")) askQuestionCount = 1;

                    userInput.Text = "";

                    break;
                //save reminder
                case 5:
                    //check for task by name
                    reminder[numberOfTask - 1] = userInput.Text;

                    askQuestionCount = 4;

                    question.LogQuestions("Reminder added to Task: " + userInput.Text + ", A reminder has been add to a task after asking the user.");

                    userInput.Text = "";

                    break;
                //question count 6, confirm to remove task
                case 6:
                    //removes task from the array
                    if (user.Equals("yes"))
                    {
                        question.LogQuestions("Task removed: " + task[removeTaskCount] + ", A task has been remove from the application.");

                        task.RemoveAt(removeTaskCount);

                        ChatBotReply.Text = "Task Removed, Say Ok to continue";

                        askQuestionCount = 6;

                        saveQuestionCount = 1;

                        userInput.Text = "";
                    }

                    else if (user.Equals("no")) askQuestionCount = 11;

                    break;
                //question count 8, show one task
                case 7:
                    //show one task
                    askQuestionCount = 8;

                    taskName1 = " " + userInput.Text;

                    userInput.Text = "";

                    break;
                //what task to remove?
                case 8:

                        user = " " + userInput.Text;

                        int check = 0;

                        for (removeTaskCount = 0; removeTaskCount < task.Count(); removeTaskCount++)
                        {
                            if (user.Equals(task[removeTaskCount]))
                            {

                                taskName1 = user;
                                check = 1;
                                break;
                            }

                        }

                        if (check == 1)
                        {
                            askQuestionCount = 5;
                        }
                        else
                        {
                            MessageBox.Show("\nSorry, task not found\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                            askQuestionCount = 11;
                            saveQuestionCount = 1;
                        }

                    userInput.Text = "";

                    break;
                //yes or no for reviewing log
                case 9:
                    user = userInput.Text.ToLower();

                    if (user.Equals("yes")) askQuestionCount = 13;

                    else askQuestionCount = 11;

                    userInput.Text = "";
                    break;
                //complete task
                case 10:
                    userUnedited = " " + userUnedited;

                    check = 0;

                    for (int i = 0; i < task.Count(); i++)
                    {
                        if (userUnedited.Equals(task[i]))
                        {
                            reminder[i] = "completed";
                            taskName1 = userUnedited;
                            check = 1;

                        }
                        else { }

                    }

                    if (check == 1) askQuestionCount = 15;

                        else
                        {

                            MessageBox.Show("\nSorry, I didn't understand that. Could you rephrase\n", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                            askQuestionCount = 14;
                        }
                    
                    userInput.Text = "";

                    break;
                default:
                    break;
            }
        }

        private void SplitWords() 
        {

            char[] delimiters = { '-' };
            char[] delimiters1 = { ' ' };

                string[] sentences = userUnedited.Split(delimiters, 3, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < sentences.Length; i++)//split into 3 sentences
                {

                    string[] words = sentences[i].Split(delimiters1, StringSplitOptions.RemoveEmptyEntries); //split sentence into words
                    
                    //taskname
                    if (i == 0)for (int i2 = 1; i2 < words.Length; i2++) taskName1 = taskName1 + " " + words[i2];

                    //taskDescription
                    else if (i == 1) for (int i2 = 0; i2 < words.Length; i2++) taskDescription1 = taskDescription1 + " " + words[i2];
                        
                    //taskDate
                    else if (i == 2) for (int i2 = 0; i2 < words.Length; i2++) taskDate1 = taskDate1 + " " + words[i2];
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

        private void MiniGame_Click(object sender, RoutedEventArgs e)
        {
            MiniGame miniGame = new MiniGame();

            miniGame.Show();

            this.Hide();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();

            home.Show();
            
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
