﻿using System;
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
                int index = register.IndexOf(member);
                Render(member, index);
            }
        }

        public void Render(Member member, int index)
        {
            Console.WriteLine("\n Medlemsnummer {0}", index);
            Console.WriteLine(" Namn: {0}", member.FirstName + " " + member.LastName + " ");
            Console.WriteLine(" Telefon nummer: {0}", member.PhoneNumber);
        }
    }
}
