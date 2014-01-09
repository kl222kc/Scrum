using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medlemsregister
{
    class ViewMember
    {
        public void Render(List<Member> register)
        {
            foreach (Member member in register)
            {
                Render(member);
            }
        }

        public void Render(Member member)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n Medlemsnummer {0}",member.Id );
            Console.WriteLine(" Namn: {0}", member.FirstName + " " + member.LastName + " ");
            Console.WriteLine(" Telefon nummer: {0}", member.PhoneNumber);
        }
    }
}
