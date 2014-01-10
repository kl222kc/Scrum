using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medlemsregister
{

    enum RegisterReadStatus { Indefinite, New };

    class RegisterRepository
    {
        private string _path;

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Felaktivgt värde för path");
                }
                _path = value;
            }

        }

        public List<Member> Load(List<Member> register)
        {

            RegisterReadStatus status = RegisterReadStatus.Indefinite;

            using (StreamReader reader = new StreamReader(Path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {

                    if (line.Length == 0)
                    {
                        continue;
                    }
                    if (line == "[Member]")
                    {
                        status = RegisterReadStatus.New;
                    }
                    else
                    {

                        switch (status)
                        {

                            case RegisterReadStatus.New:
                                string[] text = line.Split(';');
                                if (text.Length != 4)
                                {
                                    throw new ArgumentException();
                                }
                                else
                                {
                                    int id = Int32.Parse(text[0]);
                                    Member member = new Member(id, text[1], text[2], text[3]);
                                    register.Add(member);
                                }
                                break;

                            case RegisterReadStatus.Indefinite:
                                throw new NotImplementedException();
                        }

                    }

                }
            }

            register.Sort();
            return register;

        }

        public void Save(List<Member> register)
        {

            register.Sort();

            using (StreamWriter writer = new StreamWriter(Path))
            {
                foreach (Member member in register)
                {
                    writer.WriteLine("[Member]");
                    writer.WriteLine(member.Id + ";" + member.FirstName + ";" + member.LastName + ";" + member.PhoneNumber);
                }
            }
        }

        public RegisterRepository(string path)
        {
            Path = path;
        }
    }
}
