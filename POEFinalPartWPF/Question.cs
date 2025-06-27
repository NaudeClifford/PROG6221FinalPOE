using System;
using System.Collections.Generic;
using System.IO;
using System.Media;

namespace POEFinalPartWPF
{
    internal class Question : AbstractClassd
    {
        //================== Delegate for user emotions in the question ==================

        public delegate string QuestionDelegate(string emotion);

        public Question() :base()
        {}

        public Question(string name, string day, List<string> favouriteTopic) : base(name, day, favouriteTopic)
        {}

        //================== Logo for application ==================

        public string logo() 
        {

            return "                ++++++++++++++++                 \r" +
                "\n             ++++++++++++++++++++++++             \r" +
                "\n           ++++++++++++++++++++++++++++           \r" +
                "\n         ++++++++++++++++++++++++++++++++         \r" +
                "\n       ++++++++++++++++++++++++++++++++++++       \r" +
                "\n     ++++++++++++++++=-::::-=++++++++++++++++     \r" +
                "\n    +++++++++++++++=...:--:...=+++++++++++++++    \r" +
                "\n   +++++++++++++++:..=******=..:+++++++++++++++   \r" +
                "\n   ++++++++++++++=..+********+..=++++++++++++++   \r" +
                "\n  +++++++++++++++- :**********: -**+++++++++++++  \r" +
                "\n  +++++++++++++++- :**********: -****+++++++++++  \r" +
                "\n ++++++++++++++==: .==========. :=+****++++++++++ \r" +
                "\n +++++++++++++-... ............ ...-*****++++++++ \r" +
                "\n +++++++++++++-                    -******+++++++ \r" +
                "\n +++++++++++++-       .:==:.       -********+++++ \r" +
                "\n  ++++++++++++-       :****:       -**********++  \r" +
                "\n  ++++++++++++-       .-**-.       -***********+  \r" +
                "\n   +++++++++++-       ..**.        -***********   \r" +
                "\n   +++++++++++-        ....        -***********   \r" +
                "\n    ++++++++++-                    -*********+    \r" +
                "\n     +++++++++=--------------------=********+     \r" +
                "\n       ++++++++++**************************       \r" +
                "\n         ++++++++++**********************         \r" +
                "\n           ++++++++++*****************+           \r" +
                "\n              ++++++++************+*              \r" +
                "\n                 +++++++********* ";
        }

        //================== welcome Message for application ==================

        public string welcomeMessage() 
        {

            return
            
                    "\n:__        __   _                            _           ____ _           _   ____        _   :\r" +
                    "\n:\\ \\      / /__| | ___ ___  _ __ ___   ___  | |_ ___    / ___| |__   __ _| |_| __ )  ___ | |_ :\r" +
                    "\n: \\ \\ /\\ / / _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\ | __/ _ \\  | |   | '_ \\ / _` | __|  _ \\ / _ \\| __|:\r" +
                    "\n:  \\ V  V /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |___| | | | (_| | |_| |_) | (_) | |_ :\r" +
                    "\n:   \\_/\\_/ \\___|_|\\___\\___/|_| |_| |_|\\___|  \\__\\___/   \\____|_| |_|\\__,_|\\__|____/ \\___/ \\__|:\r" +
                    "\n:  __                         _                                        _ _                    :\r" +
                    "\n: / _| ___  _ __    ___ _   _| |__   ___ _ __ ___  ___  ___ _   _ _ __(_) |_ _   _            :\r" +
                    "\n:| |_ / _ \\| '__|  / __| | | | '_ \\ / _ \\ '__/ __|/ _ \\/ __| | | | '__| | __| | | |           :\r" +
                    "\n:|  _| (_) | |    | (__| |_| | |_) |  __/ |  \\__ \\  __/ (__| |_| | |  | | |_| |_| |           :\r" +
                    "\n:|_|  \\___/|_|     \\___|\\__, |_.__/ \\___|_|  |___/\\___|\\___|\\__,_|_|  |_|\\__|\\__, |           :\r" +
                    "\n:                       |___/                                                |___/            :\r";
        }

        //================== Emotion response ==================

        private List<string> worriedResponse = new List<string>(3) { "I understand why you are worried",
                "You must be worried in the fast change world that is today",
                "It is understanable, i would also wory if i could"};

        private List<string> frustratedResponse = new List<string>(3) { "In your position, its right to be frustrated",
                "It makes sense that you are frustrated, i would to if i can feel",
                "There is nothing wrong with being frustrated, i understand" };

        private List<string> curiousResponse = new List<string>(3) { "We can all get curious sometimes, there is nothing wrong with that",
                "We must be curious now and then, otherwise what will be the joy in learn new things",
                "Its right to be curious, it means you are human"};

        private int logCount = 1;

        //================== For random generated numbers ==================

        private Random random = new Random();

        private int randomNumber;

        private int randomNumberEmotions;

        //================== Other questions that the user would ask thats not related to cybersecurity ==================

        public string otherQuestions(string question, string emotion) 
        {
            //================== Array that stores the reply to the users questions ==================

            List<string> responseArray = new List<string>(3);
            
            //================== For random generated numbers ==================

            randomNumberEmotions = random.Next(0, 2);

            if (question.Equals("cars") || question.Equals("car"))
            {
                if (emotion.Equals(""))
                {

                    responseArray.Add("I get that cars can be a problem for the environment, this is why we must always push to reduce emisions or" +
                        "\njust go full eletric. its better for us and the world we live in.");

                    responseArray.Add("Cars can be dangerous for everyone on the road, thats why there are so many deaths on the road. i think that if" +
                        "\neveryone follows the rules or break them safely, then the roads will be safer given that they are maintained\n");

                    responseArray.Add("Cars are fun to drive and customise, they have been part of our society for a really long time" +
                        "\nand i think with more improvements. these vehicles will be a bleasing for humanitie\n");

                }


                else if (emotion.Equals("worried"))
                {

                    responseArray.Add(worriedResponse[randomNumberEmotions] + "\nI get that cars can be a problem for the environment, this is why we must always push to reduce emisions or" +
                        "\njust go full eletric. its better for us and the world we live in.");

                    responseArray.Add(worriedResponse[randomNumberEmotions] + "\nCars can be dangerous for everyone on the road, thats why there are so many deaths on the road. i think that if" +
                        "\neveryone follows the rules or break them safely, then the roads will be safer given that they are maintained\n");

                    responseArray.Add(worriedResponse[randomNumberEmotions] + "\nCars are fun to drive and customise, they have been part of our society for a really long time" +
                        "\nand i think with more improvements. these vehicles will be a bleasing for humanitie\n");
                }

                else if (emotion.Equals("curious"))
                {

                    responseArray.Add(curiousResponse[randomNumberEmotions] + "\nI get that cars can be a problem for the environment, this is why we must always push to reduce emisions or" +
                        "\njust go full eletric. its better for us and the world we live in.");

                    responseArray.Add(curiousResponse[randomNumberEmotions] + "\nCars can be dangerous for everyone on the road, thats why there are so many deaths on the road. i think that if" +
                        "\neveryone follows the rules or break them safely, then the roads will be safer given that they are maintained\n");

                    responseArray.Add(curiousResponse[randomNumberEmotions] + "\nCars are fun to drive and customise, they have been part of our society for a really long time" +
                        "\nand i think with more improvements. these vehicles will be a bleasing for humanitie\n");
                }

                else if (emotion.Equals("frustrated"))
                {

                    responseArray.Add(frustratedResponse[randomNumberEmotions] + "\nI get that cars can be a problem for the environment, this is why we must always push to reduce emisions or" +
                        "\njust go full eletric. its better for us and the world we live in.");

                    responseArray.Add(frustratedResponse[randomNumberEmotions] + "\nCars can be dangerous for everyone on the road, thats why there are so many deaths on the road. i think that if" +
                        "\neveryone follows the rules or break them safely, then the roads will be safer given that they are maintained\n");

                    responseArray.Add(frustratedResponse[randomNumberEmotions] + "\nCars are fun to drive and customise, they have been part of our society for a really long time" +
                        "\nand i think with more improvements. these vehicles will be a bleasing for humanitie\n");
                }
            }

            if (emotion.Equals("bikes") || question.Equals("bike"))
            {
                if (emotion.Equals(""))
                {

                    responseArray.Add("Bikes are very useful for getting us to places and are very fuel efficient. " +
                        "\nThis is a big advantage in now a days shrinking world where fuel is becoming more expensive");

                    responseArray.Add("Bikes now a days are becoming to loud and are becoming a danger to humans since people ain't respecting bikers" +
                        "\non the road no more because certain bikers are rude and don't respect the cars.\n");

                    responseArray.Add("Bikes can be a bleasing on the road but at the same time they can be a nightmere on road users. " +
                        "\nIt all depends on the bike and who uses the bike.\n");

                }


                else if (emotion.Equals("worried"))
                {

                    responseArray.Add(worriedResponse[randomNumberEmotions] + "\nBikes are very useful for getting us to places and are very fuel efficient. " +
                        "\nThis is a big advantage in now a days shrinking world where fuel is becoming more expensive");

                    responseArray.Add(worriedResponse[randomNumberEmotions] + "\nBikes now a days are becoming to loud and are becoming a danger to humans since people ain't respecting bikers" +
                        "\non the road no more because certain bikers are rude and don't respect the cars.\n");

                    responseArray.Add(worriedResponse[randomNumberEmotions] + "\nBikes can be a bleasing on the road but at the same time they can be a nightmere on road users. " +
                        "\nIt all depends on the bike and who uses the bike.\n");

                }

                else if (emotion.Equals("curious"))
                {

                    responseArray.Add(curiousResponse[randomNumberEmotions] + "\nBikes are very useful for getting us to places and are very fuel efficient. " +
                         "\nThis is a big advantage in now a days shrinking world where fuel is becoming more expensive");

                    responseArray.Add(curiousResponse[randomNumberEmotions] + "\nBikes now a days are becoming to loud and are becoming a danger to humans since people ain't respecting bikers" +
                        "\non the road no more because certain bikers are rude and don't respect the cars.\n");

                    responseArray.Add(curiousResponse[randomNumberEmotions] + "\nBikes can be a bleasing on the road but at the same time they can be a nightmere on road users. " +
                        "\nIt all depends on the bike and who uses the bike.\n");
                }

                else if (emotion.Equals("frustrated"))
                {

                    responseArray.Add(frustratedResponse[randomNumberEmotions] + "\nBikes are very useful for getting us to places and are very fuel efficient. " +
                        "\nThis is a big advantage in now a days shrinking world where fuel is becoming more expensive");

                    responseArray.Add(frustratedResponse[randomNumberEmotions] + "\nBikes now a days are becoming to loud and are becoming a danger to humans since people ain't respecting bikers" +
                        "\non the road no more because certain bikers are rude and don't respect the cars.\n");

                    responseArray.Add(frustratedResponse[randomNumberEmotions] + "\nBikes can be a bleasing on the road but at the same time they can be a nightmere on road users. " +
                        "\nIt all depends on the bike and who uses the bike.\n");
                }
            }

            if (emotion.Equals("trucks") || question.Equals("truck"))
            {
                if (emotion.Equals(""))
                {

                    responseArray.Add("Trucks are important in our society since they deliver large quantities of supples and goods to everywhere in the country");

                    responseArray.Add("Trucks can be a danger on the road since they are so difficult to stop and if it is a bad driver, well thats bad for everyone.\n");

                    responseArray.Add("Trucks might be unnessary at such a scale if the trains would deliver large quantities between citys.\n");

                }


                else if (emotion.Equals("worried"))
                {

                    responseArray.Add(worriedResponse[randomNumberEmotions] + "\nTrucks are important in our society since they deliver large quantities of supples and goods to everywhere in the country");

                    responseArray.Add(worriedResponse[randomNumberEmotions] + "\nTrucks can be a danger on the road since they are so difficult to stop and if it is a bad driver, well thats bad for everyone.\n");

                    responseArray.Add(worriedResponse[randomNumberEmotions] + "\nTrucks might be unnessary at such a scale if the trains would deliver large quantities between citys.\n");
                }

                else if (emotion.Equals("curious"))
                {

                    responseArray.Add(curiousResponse[randomNumberEmotions] + "\nTrucks are important in our society since they deliver large quantities of supples and goods to everywhere in the country");

                    responseArray.Add(curiousResponse[randomNumberEmotions] + "\nTrucks can be a danger on the road since they are so difficult to stop and if it is a bad driver, well thats bad for everyone.\n");

                    responseArray.Add(curiousResponse[randomNumberEmotions] + "\nTrucks might be unnessary at such a scale if the trains would deliver large quantities between citys.\n");
                }

                else if (emotion.Equals("frustrated"))
                {

                    responseArray.Add(frustratedResponse[randomNumberEmotions] + "\nTrucks are important in our society since they deliver large quantities of supples and goods to everywhere in the country");

                    responseArray.Add(frustratedResponse[randomNumberEmotions] + "\nTrucks can be a danger on the road since they are so difficult to stop and if it is a bad driver, well thats bad for everyone.\n");

                    responseArray.Add(frustratedResponse[randomNumberEmotions] + "\nTrucks might be unnessary at such a scale if the trains would deliver large quantities between citys.\n");
                }
            }

            randomNumber = random.Next(0, 2);

            return responseArray[randomNumber];
        }

        //answer to password question
        public string Password(string emotion)
        {

            List<string> responseArray = new List<string>();

            randomNumberEmotions = random.Next(0, 3);

            if (emotion.Equals("")) {

                responseArray.Add("You must not use real words in your password and ensure the numbers " +
                    "\nare random to make it harder for the hackers to guess your password.");

                responseArray.Add("Do not use one password for everything, if you do, then once someone gains access" +
                "\nto this password, they can use it to access all of your information.");

                responseArray.Add("It might bbe safest to use a randomly generated password since the pattern will" +
                "\nbe difficult for anyone to figure out");

            }

            else if (emotion.Equals("worried")) {

                responseArray.Add(worriedResponse[randomNumberEmotions] + "\njust follow these tips and your password will be safe.\n" +
                    "\nYou must not use real words in your password and ensure the numbers \n" +
                        "are random to make it harder for the hackers to guess your password.");

                responseArray.Add(worriedResponse[randomNumberEmotions] + "\nBy doing this, your password will be safe." +
                    "\nDo not use one password for everything, if you do, then once someone gains access" +
                "to this password, they can use it to access all of your information.");

                responseArray.Add(worriedResponse[randomNumberEmotions] + "\nlistening to me will take your worries away." +
                    "\nIt might be safest to use a randomly generated password since the pattern will" +
                "\nbe difficult for anyone to figure out\n");
            }

            else if (emotion.Equals("curious")) {

                responseArray.Add(curiousResponse[randomNumberEmotions] +
                    "\nIts because you must not use real words in your password and ensure the numbers " +
                    "\nare random to make it harder for the hackers to guess your password.");

                responseArray.Add(curiousResponse[randomNumberEmotions] +
                    "\nStart be not using one password for everything, if you do, then once someone gains access" +
                "\nto this password, they can use it to access all of your information.");

                responseArray.Add(curiousResponse[randomNumberEmotions] +
                    "\nIt might bbe safest to use a randomly generated password since the pattern will" +
                "\nbe difficult for anyone to figure out\n");
            }

            else if (emotion.Equals("frustrated")) {

                responseArray.Add(frustratedResponse[randomNumberEmotions] + "i can explain passwords for you." +
                    "\nYou must not use real words in your password and ensure the numbers " +
                        "\nare random to make it harder for the hackers to guess your password.");

                responseArray.Add(frustratedResponse[randomNumberEmotions] +
                    "\nDo not use one password for everything, if you do, then once someone gains access" +
                "\nto this password, they can use it to access all of your information.");

                responseArray.Add(frustratedResponse[randomNumberEmotions] +
                    "\nIt might bbe safest to use a randomly generated password since the pattern will" +
                "\nbe difficult for anyone to figure out\n");
            }

            randomNumber = random.Next(0,3);

            return responseArray[randomNumber];
        }

        //answer to phishing question

        public string Phishing(string emotion)
        {

            List<string> responseArray = new List<string>();

            randomNumberEmotions = random.Next(0, 3);

            if (emotion.Equals(""))
            {

                responseArray.Add("To prevent phishing, you must first understand phishing and on what an phishing attack looks like.");

                responseArray.Add("You can download free anti-phishing software or go for security awareness traing to be able to " +
                "\nidentify phishing.");

                responseArray.Add("Be aware of dangerous emails and never click on the links that will most likely be an phishing attack.\n");

            }

            else if (emotion.Equals("worried")) {

                responseArray.Add(worriedResponse[randomNumberEmotions] +
                    "\nTo prevent phishing, you must first understand phishing and on what an phishing attack looks like.");

                responseArray.Add(worriedResponse[randomNumberEmotions] +
                    "\nYou can download free anti-phishing software or go for security awareness traing to be able to " +
                    "\nidentify phishing.");

                responseArray.Add(worriedResponse[randomNumberEmotions] +
                    "\nBeing aware of dangerous emails and never click on the links that will most likely be an phishing attack.\n");
            }

            else if (emotion.Equals("curious")) {

                responseArray.Add(curiousResponse[randomNumberEmotions] +
                    "\nTo prevent phishing, you must first understand phishing and on what an phishing attack looks like.");

                responseArray.Add(curiousResponse[randomNumberEmotions] +
                    "\nYou can download free anti-phishing software or go for security awareness traing to be able to " +
                "\nidentify phishing.");

                responseArray.Add(curiousResponse[randomNumberEmotions] +
                    "\nBe aware of dangerous emails and never click on the links that will most likely be" +"an phishing attack.\n");
            }

            else if (emotion.Equals("frustrated")) {

                responseArray.Add(frustratedResponse[randomNumberEmotions] + "\nThe hackers to becoming more bold now a days." +
                    "\nTo prevent phishing, you must first understand phishing and on what an phishing attack looks like.");

                responseArray.Add(frustratedResponse[randomNumberEmotions] + "We all need to keep of aaccounts safe." +
                    "\nYou can download free anti-phishing software or go for security awareness traing to be able to " +
                "\nidentify phishing.");

                responseArray.Add(frustratedResponse[randomNumberEmotions] + "\nThis is the correct reaction to someone trying to steal your account information." +
                    "\nBe aware of dangerous emails and never click on the links that will most likely be an phishing attack.\n");
            }

            randomNumber = random.Next(0,3);

            return responseArray[randomNumber];
           
        }

        //answer to safe browsing question

        public string SafeBrowsing(string emotion)
        {
            List<string> responseArray = new List<string>();

            randomNumberEmotions = random.Next(0, 3);

            if (emotion.Equals(""))
            {

                responseArray.Add("When browsing the internet, you need to keep your browser up to date to ensure that there isn't any vulnerabilities with the browser..");

                responseArray.Add("Use secure and trusted internet connection by not using public Wi-Fi networks and using a VPN.");

                responseArray.Add("Install reliable antivirus and firewall software that will protect you from malware, viruses and cyber threats.");

                responseArray.Add("Avoid downloading from untrusted sources to prevent the chance of downloading malware or viruses.");
            }

            else if (emotion.Equals("worried")) {

                responseArray.Add(worriedResponse[randomNumberEmotions] +  "\nWe must be safe when to browse the internet." +
                    "\nWhen browsing the internet, you need to keep your browser up to date to ensure that there isn't any vulnerabilities with the browser..");

                responseArray.Add(worriedResponse[randomNumberEmotions] + "\nWe will understand on how to stay safe." +
                    "\nUse secure and trusted internet connection by not using public Wi-Fi networks and using a VPN.");

                responseArray.Add(worriedResponse[randomNumberEmotions] + "\nAlways try to ensure your internet security." +
                    "\nInstall reliable antivirus and firewall software that will protect you from malware, viruses and cyber threats.");

                responseArray.Add(worriedResponse[randomNumberEmotions] + "\nIf your browser is unsafe, you will get hacked." +
                    "\nAvoid downloading from untrusted sources to prevent the chance of downloading malware or viruses.");
            }

            else if (emotion.Equals("curious")) {

                responseArray.Add(curiousResponse[randomNumberEmotions] +
                    "\nWhen browsing the internet, you need to keep your browser up to date to ensure that there isn't any vulnerabilities with the browser..");

                responseArray.Add(curiousResponse[randomNumberEmotions] + "\nThere is nothing wrong we wanting to learn." +
                    "\nUse secure and trusted internet connection by not using public Wi-Fi networks and using a VPN.");

                responseArray.Add(curiousResponse[randomNumberEmotions] +
                    "\nInstall reliable antivirus and firewall software that will protect you from malware, viruses and cyber threats.");

                responseArray.Add(curiousResponse[randomNumberEmotions] +
                    "\nAvoid downloading from untrusted sources to prevent the chance of downloading malware or viruses.");
            }

            else if (emotion.Equals("frustrated")) {

                responseArray.Add(frustratedResponse[randomNumberEmotions] + "\nA safe browser is very important for protecting of information." +
                    "\nWhen browsing the internet, you need to keep your browser up to date to ensure that there isn't any vulnerabilities with the browser..");

                responseArray.Add(frustratedResponse[randomNumberEmotions] + "\nThe hackers in our world are becoming more difficult to counter." +
                    "\nUse secure and trusted internet connection by not using public Wi-Fi networks and using a VPN.");

                responseArray.Add(frustratedResponse[randomNumberEmotions] +
                    "\nInstall reliable antivirus and firewall software that will protect you from malware, viruses and cyber threats.");

                responseArray.Add(frustratedResponse[randomNumberEmotions] +
                    "\nAvoid downloading from untrusted sources to prevent the chance of downloading malware or viruses.");
            }

            randomNumber = random.Next(0,4);

            return responseArray[randomNumber];
        }

        public string ContinueQuestion(string question)
        {
            string answer = "";
            
            switch (question)
            {

                case "password":
                    
                        answer = "You can always download a software that will keep all of your passwords secure." +
                            "\nyou can also have another software that auto generates passwords that gets sent to your secure password holder" +
                            "\nthat only you can access. This way you don't ever have to worry about resetting passwords and them getting stolen.";
                    
                    break;

                case "phishing":
                    
                    answer = "Having to download some software that can help detect phishing attacks will help you alot." +
                               "\nYou can also have this software block any phishing attack so that you don't ever get them and put at rish of openning them." +
                               "\nThis might be the easiest if you are looking for the best solution.";
                    break;

                case "safe browsing":
                    
                    answer = "There are many ways to protect your self while you safe browse but end of the day." +
                                        "\nA human such as yourself will make a mistake and end up downloading malware accidentally." +
                                        "\nThats why its good to have software that checks for malware and removes it.";
                    break;

                default:
                    break;

            }
            return answer;
        }

        public void LogQuestions(string question)
        {

            StreamWriter writer = new StreamWriter("C:\\Users\\lab_services_student\\Documents\\GitHub\\PROG6221FinalPOE\\POEFinalPartWPF\\Log.txt", true);

            writer.WriteLine(logCount + ": " + question);

            logCount++;

            writer.Close();
        }

        public string ReadLogQuestions()
        {

            StreamReader reader = new StreamReader("C:\\Users\\lab_services_student\\Documents\\GitHub\\PROG6221FinalPOE\\POEFinalPartWPF\\Log.txt");
                
            string log = "";
            
            string[] lines = File.ReadAllLines("C:\\Users\\lab_services_student\\Documents\\GitHub\\PROG6221FinalPOE\\POEFinalPartWPF\\Log.txt"); // Read all lines
            
            for (int i = lines.Length-1; i > lines.Length-6; i--)
            {
                log = log + "\n" + lines[i];
            }
            reader.Close();
            
            return log;
        }
    }
}
