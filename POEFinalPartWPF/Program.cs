
namespace POEFinalPartWPF
{
    using System.Windows;
    using System;
   
    using System.IO;
    using System.Threading;
    using System.Collections.Generic;
    using System.Linq;

    //================== IClassd is the interface for printing out messages ==================

    internal class Program
    {
        static void main()
        {
          


            //================== Formatting text colour ==================
            Console.ForegroundColor = ConsoleColor.Blue;

            //================== Error Handling the whole program ==================
            try
            {

                //================== Calling Class ==================
                Question question = new Question();

                Program message = new Program();

                //================== Asking for name ==================
                message.OutPut("--------------------------------------------------\n\n- Hello user, what is your name?-  \n\n--------------------------------------------------");
                string userName = Console.ReadLine();

                message.OutPut("...");
                Thread.Sleep(3000); //wait for 3 seconds

                question.setName(userName);

                //================== Asking how was the day so far ==================
                message.OutPut("--------------------------------------------------\n\n- How was your day so far, " + userName + "?  -\n\n--------------------------------------------------");

                string userDay = Console.ReadLine();

                message.OutPut("...");
                Thread.Sleep(3000); //wait for 3 seconds

                question.setDay(userDay);

                //================== Asking for favourite topics from the user ==================
                message.OutPut("--------------------------------------------------\n\n- What are you interest in, " + userName + "?, mainly in cyberSecurity  -\n\n--------------------------------------------------");

                string userFavourite = Console.ReadLine();

                message.OutPut("...");
                Thread.Sleep(3000); //wait for 3 seconds

                message.OutPut("Great, i will remember that you are interest interested in " + userFavourite);

                List<string> topicArray = question.getFavouriteTopic();

                topicArray.Add(userFavourite);
                
                question.setFavouriteTopic(topicArray);

                message.OutPut("...");
                Thread.Sleep(3000); //wait for 3 seconds

                string otherQuestions = "";

                //================== Keyword List collections ==================

                List<string> otherKeywords = new List<string> { "car", "cars", "trucks", "truck", "bike", "bikes", "no" };

                List<string> keywords = new List<string> {"passwords", "password", "phishing", "safe browsing", "no" };

                List<string> emotionKeywords = new List<string> { "worried", "curious", "frustrated" };

                List<string> interestedKeywords = new List<string> { "passwords", "password", "phishing", "safe browsing", };

                //================== Calling Delegate ==================

                //QuestionDelegate questionDelegate;

                //================== Checking user Interest for keywords ==================

                string userInterest = "";

                List<string> recognizedKeywordsInterest = RecognizeKeywords(userFavourite.ToLower(), interestedKeywords);

                foreach (string keyword in recognizedKeywordsInterest)
                {
                    userInterest = keyword;
                }

                //================== Using loop to go back if user makes a mistake ==================
                while (true)
                {

                    while (true)
                    {

                        message.OutPut("--------------------------------------------------\n\n- Any Questions before we continue to cyberSecurity, " + userName + "?, 'Yes', or 'No'  -\n\n--------------------------------------------------");

                        otherQuestions = Console.ReadLine();

                        message.OutPut("...");
                        Thread.Sleep(3000); //wait for 3 seconds

                        if (otherQuestions.ToLower().Equals("no")) break;

                        else if (otherQuestions.ToLower().Equals("yes"))
                        {

                            //================== Using loop to go back if user makes a mistake ==================

                            message.OutPut("--------------------------------------------------\n\n-  What type of question would you like to ask, " + userName + "?  -\n\n--------------------------------------------------");

                            string questionAsked = Console.ReadLine();

                            message.OutPut("...");
                            Thread.Sleep(3000); //wait for 3 seconds

                            //================== Searching Keywords for question ==================

                            string answer1 = "";

                            List<string> recognizedKeywords = RecognizeKeywords(questionAsked.ToLower(), otherKeywords);

                            foreach (string keyword in recognizedKeywords)
                            {
                                answer1 = keyword;
                            }

                            //================== Searching Keywords for emotion ==================

                            List<string> recognizedEmotionKeywords = RecognizeKeywords(questionAsked.ToLower(), emotionKeywords);

                            string emotion = "";

                            foreach (string keyword in recognizedEmotionKeywords)
                            {
                                emotion = keyword;
                            }

                            //================== Check if user asked these questions ==================

                            if (answer1.Equals("cars") || answer1.Equals("car") || answer1.Equals("bike")
                                || answer1.Equals("bikes") || answer1.Equals("trucks") || answer1.Equals("truck"))
                                 question.otherQuestions(answer1, emotion);

                            else if (answer1.Equals("no")) break;

                            else message.OutPut("\nSorry, I didn't understand that. Could you rephrase\n");
                        }

                        else message.OutPut("\nSorry, I didn't understand that. Could you rephrase\n");
                    }
                    
                    //================== Using loop to go back if user makes a mistake ==================
                    while (true)
                    {

                        message.OutPut("\n--------------------------------------------------\n\n-  " +
                            "\nWhat Question do you wish to ask about cyber security, " + userName + "?, Enter 'No' for exit\n\n--------------------------------------------------\n\n");


                        if (userInterest.Equals("password") || userInterest.Equals("passwords")) message.OutPut("As someone interested in Passwords, i recommend you ask about Password security" +
                            "\n--------------------------------------------------\n\n");

                        else if (userInterest.Equals("phishing")) message.OutPut("As someone interested in Phishing, i recommend you ask about Phishing security" +
                            "\n--------------------------------------------------\n\n");

                        else if (userInterest.Equals("safe browsing")) message.OutPut("As someone interested in Safe Browsing, i recommend you ask about Safe Browsing security" +
                            "\n--------------------------------------------------\n\n");

                        string questionAsked1 = Console.ReadLine();

                        //================== Searching for Keywords for Question ==================

                        List<string> recognizedKeywords = RecognizeKeywords(questionAsked1.ToLower(), keywords);

                        string answer1 = "";

                        foreach (string keyword in recognizedKeywords)
                        {
                            answer1 = keyword;
                        }

                        //================== Searching for keywords for emotion ==================

                        List<string> recognizedEmotionKeywords = RecognizeKeywords(questionAsked1.ToLower(), emotionKeywords);

                        string emotion = "";

                        foreach (string keyword in recognizedEmotionKeywords)
                        {
                            emotion = keyword;
                        }

                        Console.WriteLine("...");
                        Thread.Sleep(3000); //wait for 3 seconds

                        //================== check users response ==================

                        if (answer1.Equals("no"))
                        {
                            break;
                        }
                        
                        //================== Password Question ==================

                        else if (answer1.Equals("password") || answer1.Equals("passwords"))
                        {
                            //questionDelegate = question.Password;

                            //questionDelegate(emotion);

                            message.OutPut("...");
                            Thread.Sleep(3000); //wait for 3 seconds

                            while (true)
                            {
                                message.OutPut("May i continue?");

                                string questionanswer = Console.ReadLine();

                                message.OutPut("...");
                                Thread.Sleep(3000); //wait for 3 seconds

                                if (questionanswer.ToLower().Equals("yes"))
                                {
                                    message.OutPut("\nYou can always download a software that will keep all of your passwords secure." +
                                        "\nyou can also have another software that auto generates passwords that gets sent to your secure password holder" +
                                        "\nthat only you can access. This way you don't ever have to worry about resetting passwords and them getting stolen.");
                                    break;
                                }

                                else if (questionanswer.ToLower().Equals("no")) break;

                                else message.OutPut("Sorry, i didn't understand. Could you pleased rephrase");
                            }

                            message.OutPut("...");
                            Thread.Sleep(3000); //wait for 3 seconds

                            //================== Changing Text Colour ==================

                            Console.ForegroundColor = ConsoleColor.Blue;
                        }

                        //================== Phishing Question ==================

                        else if (answer1.Equals("phishing"))
                        {
                            //questionDelegate = question.Phishing;

                            //questionDelegate(emotion);

                            message.OutPut("...");
                            Thread.Sleep(3000); //wait for 3 seconds

                            while (true)
                            {
                                message.OutPut("May i continue?");

                                string questionanswer = Console.ReadLine();

                                message.OutPut("...");
                                Thread.Sleep(3000); //wait for 3 seconds

                                if (questionanswer.ToLower().Equals("yes"))
                                {
                                    message.OutPut("\nHaving to download some software that can help detect phishing attacks will help you alot." +
                                        "\nYou can also have this software block any phishing attack so that you don't ever get them and put at rish of openning them." +
                                        "\nThis might be the easiest if you are looking for the best solution.");
                                    break;
                                }

                                else if (questionanswer.ToLower().Equals("no")) break;

                                else message.OutPut("Sorry, i didn't understand");
                            }

                            message.OutPut("...");
                            Thread.Sleep(3000); //wait for 3 seconds

                            //================== Changing Text Colour ==================

                            Console.ForegroundColor = ConsoleColor.Blue;
                        }

                        //================== SAfe Browsing Question ==================

                        else if (answer1.Equals("safe browsing"))
                        {
                            //questionDelegate = question.SafeBrowsing;

                            //questionDelegate(emotion);

                            message.OutPut("...");
                            Thread.Sleep(3000); //wait for 3 seconds

                            while (true)
                            {
                                message.OutPut("May i continue?");

                                string questionanswer = Console.ReadLine();

                                message.OutPut("...");
                                Thread.Sleep(3000); //wait for 3 seconds

                                if (questionanswer.ToLower().Equals("yes"))
                                {
                                    message.OutPut("\nThere are many ways to protect your self while you safe browse but end of the day." +
                                        "\nA human such as yourself will make a mistake and end up downloading malware accidentally." +
                                        "\nThats why its good to have software that checks for malware and removes it.");
                                    break;
                                }

                                else if (questionanswer.ToLower().Equals("no")) break;

                                else message.OutPut("Sorry, i didn't understand");
                            }

                            message.OutPut("...");
                            Thread.Sleep(3000); //wait for 3 seconds

                            //================== Changing Text Colour ==================

                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else message.OutPut("\nSorry, I didn't understand that. Could you rephrase\n");
                    }

                    message.OutPut("Do you wish to leave?");

                    string answer = Console.ReadLine();

                    message.OutPut("...");
                    Thread.Sleep(3000); //wait for 3 seconds

                    if (answer.ToLower().Equals("no")) { }

                    else
                    {
                        message.OutPut(question.ToString() + "\n\nEnjoy your day");
                         break;
                    }
                }
            }

            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //================== Processes keyword and returns the found keyword ==================

        public void OutPut(string message) 
        {

            Console.WriteLine(message);
        }

        static List<string> RecognizeKeywords(string text, List<string> keywords)
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
