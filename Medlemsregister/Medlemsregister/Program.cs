using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medlemsregister
{
    class Program
    {
        static void Main(string[] args)
        {

            bool exit = false;
            List<Member> member = new List<Member>();

            do
            {
                switch (GetMenuChoice())
                {
                    case 0:
                        exit = true;
                        continue;

                    case 1:
                        //Console.WriteLine("Not Yet Implemented");
                        //Member test = new Member();
                        //test.FirstName = "Kim";
                        //test.LastName = "Larsson";
                        //test.PhoneNumber = "07091212";

                        //member.Add(test);

                        //Console.WriteLine(member[0]);
                        //Console.WriteLine(member[0].FirstName);
                        //Console.WriteLine(member[0].LastName);
                        //Console.WriteLine(member[0].PhoneNumber);

                        RegisterRepository rr = new RegisterRepository("register.txt");
                        rr.Load();
                        //Console.WriteLine(rr);
                        //Console.WriteLine(rr.Path);
                        break;

                    case 2:
                        Console.WriteLine("Not Yet Implemented");
                        break;

                    case 3:
                        Console.WriteLine("Not Yet Implemented");
                        break;

                    case 4:
                        Console.WriteLine("Not Yet Implemented");
                        break;

                    case 5:
                        Console.WriteLine("Not Yet Implemented");
                        break;

                    case 6:
                        Console.WriteLine("Not Yet Implemented");
                        break;

                    case 7:
                        Console.WriteLine("Not Yet Implemented");
                        break;

                }

                ContinueOnKeyPressed();
            } while (!exit);
        }

        private static void ContinueOnKeyPressed()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("\n   Tryck tangent för att fortsätta   ");
            Console.ResetColor();
            Console.ReadKey(true);
            Console.Clear();
        }

        private static int GetMenuChoice()
        {
            int index;

            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ╔═══════════════════════════════════╗ ");
                Console.WriteLine(" ║          Medlemsregister          ║ ");
                Console.WriteLine(" ╚═══════════════════════════════════╝ ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("\n - Arkiv -----------------------------------\n");
                Console.WriteLine(" 0. Avsluta.");
                Console.WriteLine(" 1. Ladda medlemsregister.");
                Console.WriteLine(" 2. Spara medlemsregister.");
                Console.WriteLine("\n - Redigera --------------------------------\n");
                Console.WriteLine(" 3. Lägg till medlem.");
                Console.WriteLine(" 4. Ändra medlem.");
                Console.WriteLine(" 5. Ta bort medlem.");
                Console.WriteLine("\n - Visa ------------------------------------\n");
                Console.WriteLine(" 6. Visa alla medlemmar.");
                Console.WriteLine(" 7. Visa specifik medlem.");
                Console.WriteLine("\n ═══════════════════════════════════════════\n");
                Console.Write(" Ange menyval [0-7]: ");
                Console.ResetColor();

                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 7)
                {
                    return index;
                }

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n FEL! Ange ett nummer mellan 0 och 7.\n");
                ContinueOnKeyPressed();

            } while (true);
        }

    }
}
