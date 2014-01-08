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
            List<Member> members = new List<Member>();

            do
            {
                switch (GetMenuChoice())
                {
                    case 0:
                        exit = true;
                        continue;

                    case 1:
                        RegisterRepository rr = new RegisterRepository("register.txt");
                        rr.Load(members);
                        break;

                    case 2:
                        RegisterRepository rrs = new RegisterRepository("register.txt");
                        rrs.Save(members);
                        break;

                    case 3:
                        AddMember(members);
                        break;

                    case 4:
                        EditMember(members);
                        break;

                    case 5:
                        DeleteMember(members);
                        break;

                    case 6:
                        MemberView(members, true);
                        break;

                    case 7:
                        MemberView(members, false);
                        break;

                }

                ContinueOnKeyPressed();
            } while (!exit);
        }

        private static void AddMember(List<Member> members)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔═══════════════════════════════════╗ ");
            Console.WriteLine(" ║         Lägg till medlem          ║ ");
            Console.WriteLine(" ╚═══════════════════════════════════╝ ");
            Console.BackgroundColor = ConsoleColor.Black;

            string firstName;
            string lastName;
            string phoneNumber;

            Console.Write("\n Skriv in förnamn: ");
            firstName = Console.ReadLine();
            Console.Write(" Skriv in efternamn: ");
            lastName = Console.ReadLine();
            Console.Write(" Skriv in telefon nummer: ");
            phoneNumber = Console.ReadLine();

            Member member = new Member(firstName, lastName, phoneNumber);

            members.Add(member);

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

        private static void DeleteMember(List<Member> members)
        {
            do
            {
                if (members.Count == 0)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(" ╔══════════════════════════════════════╗ ");
                    Console.WriteLine(" ║ Det finns inga medelmmar att ta bort ║ ");
                    Console.WriteLine(" ╚══════════════════════════════════════╝ ");
                    Console.ResetColor();
                    break;
                }

                string header = "TA BORT MEDLEM!";
                Member chosenMember = GetMember(header, members);

                if (chosenMember == null)
                {
                    break;
                }

                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("\n  Vill du verkligen ta bort '{0}' [J/N]: ", chosenMember.FirstName + " " + chosenMember.LastName + " från registret");
                Console.ResetColor();
                ConsoleKeyInfo info = Console.ReadKey();
                if (info.KeyChar == 'j')
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\n ╔═══════════════════════════════════╗ ");
                    Console.WriteLine(" ║   Medlemmen har tagits bort       ║ ");
                    Console.WriteLine(" ╚═══════════════════════════════════╝ ");
                    Console.ResetColor();
                    members.Remove(chosenMember);
                    ContinueOnKeyPressed();
                }
                else if (info.KeyChar == 'n')
                {
                    ContinueOnKeyPressed();
                }

            } while (true);
        }

        private static void EditMember(List<Member> members)
        {
                if (members.Count == 0)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(" ╔══════════════════════════════════════╗ ");
                    Console.WriteLine(" ║  Det finns inga medelmmar att ändra  ║ ");
                    Console.WriteLine(" ╚══════════════════════════════════════╝ ");
                    Console.ResetColor();
                }

                string header = "ÄNDRA MEDLEM!";
                Member chosenMember = GetMember(header, members);

               ViewMember viewMember = new ViewMember();
               viewMember.Render(chosenMember);
                
                

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

        private static Member GetMember(string header, List<Member> members)
        {
            int index = 0;
            Member chosenMember;

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n------------------------------");
            Console.WriteLine(header);
            Console.WriteLine("------------------------------");
            Console.ResetColor();
            Console.WriteLine("\n Arkiv -----------------------------------\n");
            Console.WriteLine(" 0. Avsluta.");
            Console.WriteLine("\n Medlemmar --------------------------------\n");

            for (int i = 0; i < members.Count; i++)
            {
                index++;
                string name = members[i].FirstName + " " + members[i].LastName;
                Console.WriteLine(" {0}. {1}", index, name);
            }

            do
            {
                Console.Write("\n Välj Medlem [1-{0}]: ", members.Count);
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= members.Count)
                {
                    if (index == 0)
                    {
                        chosenMember = null;
                        return chosenMember;
                    }
                    else
                    {
                        chosenMember = members[index - 1];
                        return chosenMember;
                    }

                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" FEL! välj nått av meny alternativen");
                    Console.ResetColor();
                }
            } while (true);

        }

        private static void MemberView(List<Member> members, bool viewAll = false)
        {
            ViewMember viewMember = new ViewMember();
            Member chosenMember;
            string header = "Välj Medlem Att Visa";

            if (viewAll == true)
            {
                viewMember.Render(members);
            }
            else 
            {
                chosenMember = GetMember(header, members);
                if (chosenMember != null)
                {
                    viewMember.Render(chosenMember);
                }
            }
        }

    }
}
