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
            RegisterRepository rr = new RegisterRepository("register.txt");
            rr.Load(members);

            do
            {
                switch (GetMenuChoice())
                {
                    case 0:
                        exit = true;
                        continue;

                    case 1:
                        AddMember(members);
                        rr.Save(members);
                        break;

                    case 2:
                        EditMember(members);
                        rr.Save(members);
                        break;

                    case 3:
                        DeleteMember(members);
                        rr.Save(members);
                        break;

                    case 4:
                        MemberView(members, true);
                        break;

                    case 5:
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

            int id = 0;
            int maxId = members.Max(element => element.Id) + 2;

            for (int i = 0; i < maxId; i++)
            {
                if (!members.Exists(element => element.Id == i) && i != 0)
                {
                    id = i;
                    break;
                }
 
            }

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\n  Vill du lägga till denna medlem i registret [J/N]");
            Console.ResetColor();
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.KeyChar == 'j')
            {
            Member member = new Member(id, firstName, lastName, phoneNumber);
            members.Add(member);
            }
            else 
            {
                ContinueOnKeyPressed();
            }

            

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

                if (chosenMember != null)
                {
                    ViewMember viewMember = new ViewMember();

                    viewMember.Render(chosenMember);

                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("\n  Vill du verkligen ändra '{0}' [J/N]: ", chosenMember.FirstName + " " + chosenMember.LastName);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.White;
                    ConsoleKeyInfo info = Console.ReadKey();
                    Console.WriteLine("");
                    if (info.KeyChar == 'j')
                    {
                        Console.Write("\n Förnamn: ");
                        string firstName = Console.ReadLine();
                        Console.Write(" Efternamn: ");
                        string lastName = Console.ReadLine();
                        Console.Write(" Telefon nummer: ");
                        string phoneNumber = Console.ReadLine();

                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\n  Vill du spara ändringarna? [J/N]");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;
                        ConsoleKeyInfo info2 = Console.ReadKey();
                        Console.WriteLine("");
                        if (info2.KeyChar == 'j')
                        {
                            chosenMember.FirstName = firstName;
                            chosenMember.LastName = lastName;
                            chosenMember.PhoneNumber = phoneNumber;
                        }
                        else if (info.KeyChar == 'n')
                        {
                            ContinueOnKeyPressed();
                        } 
                    }

                }

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
                Console.WriteLine("\n - Redigera --------------------------------\n");
                Console.WriteLine(" 1. Lägg till medlem.");
                Console.WriteLine(" 2. Ändra medlem.");
                Console.WriteLine(" 3. Ta bort medlem.");
                Console.WriteLine("\n - Visa ------------------------------------\n");
                Console.WriteLine(" 4. Visa alla medlemmar.");
                Console.WriteLine(" 5. Visa specifik medlem.");
                Console.WriteLine("\n ═══════════════════════════════════════════\n");
                Console.Write(" Ange menyval [0-5]: ");
                Console.ResetColor();

                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 5)
                {
                    return index;
                }

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n FEL! Ange ett nummer mellan 0 och 5.\n");
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
            Console.ForegroundColor = ConsoleColor.White;
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
                    Console.WriteLine("\n FEL! välj nått av meny alternativen");
                    Console.BackgroundColor = ConsoleColor.Black;
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
