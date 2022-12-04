using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lotto
{
  
        internal class Program
        {
            //global variable
            static int UserMenuNr, createdRandomNr;

            //global Array
            static int[] lottoNrs = new int[6] { -1, -1, -1, -1, -1, -1 };
            static Random rnd = new Random();

            static void Main()
            {
                Menu();
            }

            static void Menu()
            {                                                                                                                                                      
                int maxRepeats = 1;

                Console.Clear();
                Console.WriteLine("         QUICK PICK LOTTO PROGRAM    ");
                Console.WriteLine("         ------------------------    ");
                Console.WriteLine();
                Console.WriteLine(" 1. Create one Quick Pick            ");
                Console.WriteLine(" 2. Create a multiple Quick Pick     ");
                Console.WriteLine(" 3. Exit Program.                    ");
                Console.WriteLine();

                Console.WriteLine("Please enter 1, 2 or 3 to access a menu item.");
                UserMenuNr = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine();

                while (UserMenuNr < 1 || UserMenuNr > 3 && maxRepeats < 3)
                {
                    Console.WriteLine("An invalid Menu number has been entered. Please try again... ");
                    Console.WriteLine("Please enter 1, 2 or 3 to access a menu item.");
                    UserMenuNr = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine();
                    maxRepeats++;
                }

                if (maxRepeats == 3)
                {
                    UserMenuNr = 3;
                }

                switch (UserMenuNr)
                {
                    case 1:
                        QuickPickHeader();
                        QuickPick();
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to the Main Menu...");
                        Console.ReadKey();
                        Main();
                        break;

                    case 2:
                        QuickPickMultiple();
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to the Main Menu...");
                        Console.ReadKey();
                        Main();
                        break;

                    case 3:
                        ExitProgram();
                        break;

                    default:
                        break;
                }
            }

            static void QuickPickHeader()
            {
                //Print Quick Pick
                Console.Clear();
                Console.WriteLine("         QUICK PICK LOTTO NUMBERS    ");
                Console.WriteLine("         ------------------------    ");
                Console.WriteLine();
                Console.WriteLine("Your Quick Pick Numbers are: ");

            }


            static void QuickPick()         //Menu Nr 1
            {
                for (int counter = 0; counter < lottoNrs.Length; counter++)
                {
                    GenerateRandomNumber();
                    CheckDuplicate();
                    lottoNrs[counter] = createdRandomNr;
                }

                //sort Array
                Array.Sort(lottoNrs);

                for (int counter2 = 0; counter2 < 6; counter2++)
                {
                    Console.Write("{0}\t|\t", lottoNrs[counter2]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            static void GenerateRandomNumber()
            {
                createdRandomNr = rnd.Next(0, 36);
            }

            static void CheckDuplicate()
            {
                while (lottoNrs[0] == createdRandomNr || lottoNrs[1] == createdRandomNr || lottoNrs[2] == createdRandomNr || lottoNrs[3] == createdRandomNr || lottoNrs[4] == createdRandomNr || lottoNrs[5] == createdRandomNr)
                {
                    GenerateRandomNumber();
                }
            }

            static void QuickPickMultiple() //Menu Nr 2
            {
                int quickPickRepeats = 0, repeatCounter = 0;

                try
                {
                    Console.WriteLine("Please enter how many QUICK PICK LOTTO Numbers you want?");
                    quickPickRepeats = Convert.ToInt16(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("You have entered a INVALID input. Try again:");
                    Console.WriteLine("Please enter how many QUICK PICK LOTTO Numbers you want?");
                    quickPickRepeats = Convert.ToInt16(Console.ReadLine());
                }

                QuickPickHeader();

                while (repeatCounter < quickPickRepeats)
                {
                    QuickPick();
                    repeatCounter++;
                }
            }

            static void ExitProgram()       //Menu Nr3
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("         GOOD BYE!!!    ");
                Console.WriteLine("         -----------    ");
                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    
}
