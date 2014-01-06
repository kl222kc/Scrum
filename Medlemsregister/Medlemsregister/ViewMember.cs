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
            Console.WriteLine(member.FirstName);
            Console.WriteLine(member.LastName);
            Console.WriteLine(member.PhoneNumber);
        }
    }
}
