using FinchAPI;
using System;

namespace Finch_Starter
{
    class Program
    {
        // *************************************************************
        // Application:     Finch Control

        // Author:          Hailey McGuire
        // Description:     Finch Starter - Data Recorder
        // Application Type: Console
        // Date Created:    02/09/2021
        // Date Revised:    02/28/2021
        // *************************************************************

        static void Main(string[] args)
        {
            //
            // create a new Finch object
            //
            Finch myFinch;
            myFinch = new Finch();

            //
            // call the connect method
            //
            myFinch.connect();

            //
            // begin your code
            //

            MainAppTheme();

            DisplayWelcomeScreen();

            MainMenu();

            DisplayClosingScreen();

            //
            // call the disconnect method
            //
            myFinch.disConnect();
        }

        static void MainAppTheme()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
        }

        static void SecondaryAppTheme()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
        }

        static void DisplayContinuePrompt()
        {
            Console.WriteLine("\tPress any key to continue: ");
            Console.ReadKey();
        }

        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t" + headerText);
            Console.WriteLine();
        }

        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            SecondaryAppTheme();

            Console.WriteLine();
            Console.WriteLine("\tWelcome to your new Finch Robot!");
            Console.WriteLine();
            Console.WriteLine("\tThis app will show you all the things your Finch can do.");
            Console.WriteLine();
            DisplayContinuePrompt();
        }

        static void DisplayClosingScreen()
        {
            Console.Clear();
            SecondaryAppTheme();
            DisplayScreenHeader("\tClosing Screen");

            Console.WriteLine();
            Console.WriteLine("\tThank you for using the Finch app!");
            Console.WriteLine();
            DisplayContinuePrompt();
        }

        static void MainMenu()
        {

            bool quit = false;
            string userInput;

            Console.Clear();
            MainAppTheme();

            Finch myFinch = new Finch();

            do
            {
                DisplayScreenHeader("\tMain Finch Menu");
                Console.WriteLine();
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tg) Feedback Menu");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t Enter your selection: ");
                userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "a":
                        DisplayConnectFinchRobot(myFinch);
                        break;

                    case "b":

                        TalentShowDisplayMenu(myFinch);
                        break;

                    case "c":

                        DataRecorderDisplayMenuScreen(myFinch);
                        break;

                    case "d":

                        AlarmSystemDisplayMenuScreen(myFinch);
                        break;

                    case "e":

                        UserProgrammingDisplayMenuScreen(myFinch);
                        break;

                    case "f":

                        DisplayDisconnectFinchRobot(myFinch);
                        break;

                    case "g":

                        FeedbackMenu();
                        break;

                    case "q":
                        DisplayClosingScreen();
                        quit = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease select a letter from the menu");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quit);
        }

        #region TALENT SHOW

        static void TalentShowDisplayMenu(Finch myFinch)
        {
            string userInput;
            bool quitTalentShowMenu = false;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                Console.WriteLine();
                Console.WriteLine("\tMake a Selection:");
                Console.WriteLine("\ta. Light and Sound");
                Console.WriteLine("\tb. Dance");
                Console.WriteLine("\tc. Mixing it Up");
                Console.WriteLine("\td. Return to Main Menu");
                Console.WriteLine();
                Console.Write("\tEnter your Selection: ");
                userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(myFinch);
                        break;

                    case "b":
                        TalentShowDisplayDance(myFinch);
                        break;

                    case "c":
                        TalentShowDisplayMixingItUp(myFinch);
                        break;

                    case "d":
                        MainMenu();
                        break;
                }

            } while (!quitTalentShowMenu);


        }

        static void TalentShowDisplayMixingItUp(Finch myFinch)
        {
            Console.Clear();
            Console.WriteLine();
            DisplayScreenHeader("Mixing it Up");
            Console.WriteLine();
            Console.WriteLine("\tHere are all of your Finch's talents all together!");

            for (int ledValue = 100; ledValue < 255; ledValue++)
            {
                myFinch.setLED(ledValue, ledValue, ledValue);
            }

            for (int ledValue = 255; ledValue > 100; ledValue--)
            {
                myFinch.setLED(ledValue, ledValue, ledValue);
            }

            myFinch.setLED(0, 255, 255);
            myFinch.noteOn(523);
            myFinch.wait(200);
            myFinch.noteOn(698);
            myFinch.wait(400);
            myFinch.noteOn(698);
            myFinch.wait(400);
            myFinch.noteOn(880);
            myFinch.wait(600);
            myFinch.noteOff();
            //myFinch.wait(100);
            myFinch.noteOn(523);
            myFinch.wait(200);
            myFinch.noteOn(698);
            myFinch.wait(400);
            myFinch.noteOn(698);
            myFinch.wait(400);
            myFinch.noteOn(880);
            myFinch.wait(200);
            myFinch.noteOff();

            myFinch.setLED(255, 255, 0);
            myFinch.setMotors(80, 80);
            myFinch.wait(200);
            myFinch.setLED(0, 255, 255);
            myFinch.setMotors(-80, -80);
            myFinch.wait(200);
            myFinch.setLED(255, 255, 0);
            myFinch.setMotors(80, 80);
            myFinch.wait(200);
            myFinch.setLED(0, 255, 255);
            myFinch.setMotors(-80, -80);
            myFinch.wait(200);
            myFinch.setMotors(0, 0);

            myFinch.setLED(255, 255, 0);
            myFinch.noteOn(1047);
            myFinch.wait(200);
            myFinch.noteOff();
            myFinch.noteOn(1047);
            myFinch.wait(200);
            myFinch.noteOff();
            myFinch.noteOn(880);
            myFinch.wait(200);
            myFinch.noteOn(1047);
            myFinch.wait(400);
            myFinch.noteOn(1174);
            myFinch.wait(200);
            myFinch.noteOn(880);
            myFinch.wait(200);
            myFinch.noteOn(784);
            myFinch.wait(600);

            myFinch.noteOn(523);
            myFinch.wait(200);
            myFinch.noteOn(659);
            myFinch.wait(400);
            myFinch.noteOn(659);
            myFinch.wait(400);
            myFinch.noteOn(784);
            myFinch.wait(600);
            myFinch.noteOff();
            myFinch.noteOn(523);
            myFinch.wait(200);
            myFinch.noteOn(659);
            myFinch.wait(400);
            myFinch.noteOn(659);
            myFinch.wait(400);
            myFinch.noteOn(784);
            myFinch.wait(200);
            myFinch.noteOff();

            myFinch.setLED(255, 255, 0);
            myFinch.setMotors(80, 80);
            myFinch.wait(200);
            myFinch.setLED(0, 255, 255);
            myFinch.setMotors(-80, -80);
            myFinch.wait(200);
            myFinch.setLED(255, 255, 0);
            myFinch.setMotors(80, 80);
            myFinch.wait(200);
            myFinch.setLED(0, 255, 255);
            myFinch.setMotors(-80, -80);
            myFinch.wait(200);
            myFinch.setMotors(0, 0);

            myFinch.setLED(255, 255, 0);
            myFinch.noteOn(1047);
            myFinch.wait(200);
            myFinch.noteOff();
            myFinch.noteOn(1047);
            myFinch.wait(200);
            myFinch.noteOff();
            myFinch.noteOn(880);
            myFinch.wait(200);
            myFinch.noteOn(1047);
            myFinch.wait(400);
            myFinch.noteOn(1174);
            myFinch.wait(200);
            myFinch.noteOn(880);
            myFinch.wait(200);
            myFinch.noteOn(784);
            myFinch.wait(600);

            myFinch.noteOff();
            myFinch.setLED(0, 0, 0);

            DisplayContinuePrompt();
        }

        static void TalentShowDisplayLightAndSound(Finch myFinch)
        {
            DisplayScreenHeader("Light and Sound");
            Console.WriteLine("\tHere is a light show and a song from your Finch!");

            myFinch.setLED(255, 0, 255);
            myFinch.noteOn(784);
            myFinch.wait(200);
            myFinch.noteOn(880);
            myFinch.wait(200);
            myFinch.noteOn(988);
            myFinch.wait(400);
            myFinch.noteOn(587);
            myFinch.wait(400);
            myFinch.noteOn(587);
            myFinch.wait(400);

            myFinch.setLED(255, 0, 0);
            myFinch.noteOn(659);
            myFinch.wait(400);
            myFinch.setLED(255, 0, 255);
            myFinch.noteOn(784);
            myFinch.wait(400);
            myFinch.setLED(0, 0, 255);
            myFinch.noteOn(587);
            myFinch.wait(400);

            myFinch.setLED(255, 0, 0);
            myFinch.noteOn(659);
            myFinch.wait(400);
            myFinch.setLED(255, 0, 255);
            myFinch.noteOn(784);
            myFinch.wait(400);
            myFinch.setLED(0, 0, 255);
            myFinch.noteOn(587);
            myFinch.wait(400);

            myFinch.setLED(255, 0, 255);
            myFinch.noteOn(659);
            myFinch.wait(400);
            myFinch.noteOn(784);
            myFinch.wait(400);
            myFinch.noteOn(784);
            myFinch.wait(200);
            myFinch.noteOn(880);
            myFinch.wait(200);

            myFinch.noteOn(988);
            myFinch.wait(400);
            myFinch.noteOn(587);
            myFinch.wait(400);
            myFinch.noteOn(587);
            myFinch.wait(400);

            myFinch.setLED(255, 0, 0);
            myFinch.noteOn(659);
            myFinch.wait(400);
            myFinch.setLED(255, 0, 255);
            myFinch.noteOn(784);
            myFinch.wait(400);
            myFinch.setLED(0, 0, 255);
            myFinch.noteOn(587);
            myFinch.wait(400);
            myFinch.setLED(255, 0, 0);
            myFinch.noteOn(659);

            myFinch.wait(400);
            myFinch.noteOn(659);
            myFinch.setLED(255, 0, 255);
            myFinch.wait(400);
            myFinch.noteOn(784);
            myFinch.setLED(0, 0, 255);
            myFinch.wait(400);
            myFinch.noteOn(880);
            myFinch.setLED(255, 0, 0);
            myFinch.wait(400);
            myFinch.noteOn(784);
            myFinch.setLED(255, 0, 255);
            myFinch.wait(800);

            myFinch.setLED(0, 0, 0);
            myFinch.noteOff();

            DisplayContinuePrompt();

        }

        static void TalentShowDisplayDance(Finch myFinch)
        {
            Console.Clear();
            Console.WriteLine();
            DisplayScreenHeader("Dance");
            Console.WriteLine();
            Console.WriteLine("\tYour finch will now do a dance!");

            myFinch.setMotors(-80, 80);
            myFinch.wait(2000);
            myFinch.setMotors(80, -80);
            myFinch.wait(2000);
            myFinch.setMotors(100, 100);
            myFinch.wait(1000);
            myFinch.setMotors(-100, -100);
            myFinch.wait(1000);
            myFinch.setMotors(-100, 100);
            myFinch.wait(3000);

            myFinch.setMotors(80, -80);
            myFinch.wait(2000);
            myFinch.setMotors(-80, 80);
            myFinch.wait(2000);
            myFinch.setMotors(-100, -100);
            myFinch.wait(1000);
            myFinch.setMotors(100, 100);
            myFinch.wait(1000);
            myFinch.setMotors(100, -100);
            myFinch.wait(3000);

            myFinch.setMotors(300, 300);

            myFinch.setMotors(0, 0);

            DisplayContinuePrompt();
        }

        #endregion

        static bool DisplayConnectFinchRobot(Finch myfinch)
        {

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tConnecting the Finch robot now. Please be sure the USB cable is connected to the robot and computer.");
            Console.WriteLine();
            DisplayContinuePrompt();

            robotConnected = myfinch.connect();

            myfinch.setLED(0, 0, 0);
            myfinch.noteOff();

            return robotConnected;

        }

        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tDisconnecting from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine();
            Console.WriteLine("\tThe Finch robot is now disconnected.");
            DisplayContinuePrompt();

            MainMenu();
        }

        static void AlarmSystemDisplayMenuScreen(Finch myFinch)
        {
            DisplayScreenHeader("Alarm System");

            Console.WriteLine();
            Console.WriteLine("\tThis app is under construction.");
            Console.WriteLine();
            DisplayContinuePrompt();
        }

        static void UserProgrammingDisplayMenuScreen(Finch myFinch)
        {
            DisplayScreenHeader("User Programming");

            Console.WriteLine();
            Console.WriteLine("\tThis app is under construction.");
            Console.WriteLine();
            DisplayContinuePrompt();
        }

        static void FeedbackMenu()
        {
            int userFeedback;
            string userResponse;
            bool validResponse;

            DisplayScreenHeader("Feedback Menu");

            do
            {
                Console.WriteLine();
                Console.WriteLine("\tThank you for using your Finch robot.");
                Console.WriteLine("\tPlease rate your experience from 1-5.");
                Console.WriteLine("\t1 is the worst, 5 is the best.");
                Console.WriteLine();
                Console.Write("\tYour rating: ");
                userResponse = Console.ReadLine();

                validResponse = int.TryParse(userResponse, out userFeedback);

                if (validResponse)
                {

                    if (userFeedback >= 3)
                    {
                        validResponse = true;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("\tThank you for your feedback! We are glad you enjoy your Finch robot.");
                        DisplayContinuePrompt();
                    }

                    else if (userFeedback < 3)
                    {
                        validResponse = true;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("\tWe are sorry that you are not enjoying your Finch robot.");
                        DisplayContinuePrompt();

                    }
                }

                else if (!validResponse)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter an integer from 1 to 5.");
                }
            } while (!validResponse);
        }

        #region DATA RECORDER

        static void DataRecorderDisplayMenuScreen(Finch myFinch)
        {
            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;

            bool quitMenu = false;
            string userInput;

            Console.Clear();
            MainAppTheme();

            //Finch myFinch = new Finch();

            do
            {
                DisplayScreenHeader("\tData Recorder Menu");
                Console.WriteLine();
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\te) Light Sensor");
                Console.WriteLine("\tq) Return to Main Menu");
                Console.Write("\t Enter your selection: ");
                userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "a":
                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();
                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, myFinch);
                        break;

                    case "d":
                        DataRecorderDisplayData(temperatures);
                        break;

                    case "e":
                        LightSensorMenu(myFinch);
                        break;

                    case "q":
                        MainMenu();
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease select a letter from the menu");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }

        static void DataRecorderDisplayData(double[] temperatures)
        {
            DisplayScreenHeader("Display Data");

            DataRecorderDisplayTable(temperatures);

            DisplayContinuePrompt();
        }

        static void DataRecorderDisplayTable(double[] temperatures)
        {
            //
            // Table Headers
            //

            Console.WriteLine(
                "Recording Number".PadLeft(15) +
                "Temperature".PadLeft(15)
                );
            Console.WriteLine(
                "----------------".PadLeft(15) +
                "------------".PadLeft(15)
                );

            //
            // Display Table Data
            //
            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                    (index + 1).ToString().PadLeft(15) +
                    temperatures[index].ToString("n2").PadLeft(15)
                );
            }

            Console.WriteLine();

        }

        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch myFinch)
        {
            double[] temperatures = new double[numberOfDataPoints];

            DisplayScreenHeader("Get Data");

            Console.WriteLine("\tNumber of data points:{0}", numberOfDataPoints);
            Console.WriteLine("\tFrequency of data points:{0}", dataPointFrequency);
            Console.WriteLine();
            Console.WriteLine("\tThe Finch robot is ready to begin recording the temperature data.");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temperatures[index] = myFinch.getTemperature();
                Console.WriteLine("\tReading {0}: {1}", index + 1, temperatures[index].ToString("n2"));
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                myFinch.wait(waitInSeconds);
            }

            DisplayContinuePrompt();
            DisplayScreenHeader("Get Data");

            Console.WriteLine();
            Console.WriteLine("\tTable of Data");
            Console.WriteLine();
            DataRecorderDisplayTable(temperatures);

            DisplayContinuePrompt();
            return temperatures;
        }

        //
        // Get and store frequency of data points
        //
        static double DataRecorderDisplayGetDataPointFrequency()
        {
            double dataPointFrequency;
            string userResponse;
            bool validResponse;

            DisplayScreenHeader("Data Point Frequency");

            do
            {
                Console.Write("\tEnter the frequency of data points: ");
                userResponse = Console.ReadLine();
                validResponse = double.TryParse(userResponse, out dataPointFrequency);

                if (validResponse)
                {

                }

                else if (!validResponse)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter an integer.");
                }

            } while (!validResponse);


            DisplayContinuePrompt();

            return dataPointFrequency;
        }

        //
        //Get and store number of data points
        //
        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;
            string userResponse;
            bool validResponse;

            DisplayScreenHeader("Number of Data Points");

            do
            { 
                Console.Write("\tEnter number of data points: ");
                userResponse = Console.ReadLine();
                validResponse = int.TryParse(userResponse, out numberOfDataPoints);

                if (validResponse)
                {

                }

                else if (!validResponse)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter an integer.");
                }

            } while (!validResponse);


            DisplayContinuePrompt();

            return numberOfDataPoints;

        }

        static void LightSensorMenu(Finch myFinch)
        {
            int[] lightReading = null;
            bool quitMenu = false;
            string userInput;

            Console.Clear();
            MainAppTheme();

            do
            {
                DisplayScreenHeader("\tLight Reading Menu");
                Console.WriteLine();
                Console.WriteLine("\ta) Get Data");
                Console.WriteLine("\tb) Display Data");
                Console.WriteLine("\tq) Return to Main Menu");
                Console.Write("\t Enter your selection: ");
                userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "a":
                        lightReading = LightSensorGetData(myFinch);
                        break;

                    case "b":
                        LightSensorDisplayData(lightReading);
                        break;

                    case "q":
                        MainMenu();
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease select a letter from the menu");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }

        static int[] LightSensorGetData(Finch myFinch)
        {
            int[] lightReading = new int[5];

            Console.Clear();
            DisplayScreenHeader("Light Reading");
            Console.WriteLine("\tThe Finch robot is ready to begin recording the light data.");
            DisplayContinuePrompt();

            for (int index = 0; index < 5; index++)
            {
                lightReading[index] = myFinch.getRightLightSensor();
                Console.WriteLine("\tReading {0}: {1}", index + 1, lightReading[index]);
                myFinch.wait(1000);
            }

            DisplayContinuePrompt();
            return lightReading;

        }

        static void LightSensorDisplayData(int[] lightReading)
        {
            //
            // Table Headers
            //
            DisplayScreenHeader("Light Data Display");

            Console.Clear();
            Console.WriteLine(
                "Recording Number".PadLeft(15) +
                "Light Reading".PadLeft(15)
                );
            Console.WriteLine(
                "----------------".PadLeft(15) +
                "------------".PadLeft(15)
                );

            //
            // Display Table Data
            //
            for (int index = 0; index < lightReading.Length; index++)
            {
                Console.WriteLine(
                    (index + 1).ToString().PadLeft(15) +
                    lightReading[index].ToString("n2").PadLeft(15)
                );
            }

            int i = 0;
            int sum = 0;
            float average = 0.0F;

            for (i = 0; i < lightReading.Length; i++)
            {
                sum += lightReading[i];
            }

            average = (float)sum / lightReading.Length;

            Console.WriteLine("The average of the light reading is {0}", average);


            Console.WriteLine();
            DisplayContinuePrompt();
        }


        #endregion
    }
}
