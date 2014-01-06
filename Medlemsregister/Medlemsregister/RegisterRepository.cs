using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medlemsregister
{

    enum RegisterReadStatus { Indefinite, Name, PhoneNumber };

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

        public List<Member> Load()
        {

            RegisterReadStatus status = RegisterReadStatus.Indefinite;

            List<Member> register = new List<Member>();

            using (StreamReader reader = new StreamReader(Path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {

                    if (line.Length == 0)
                    {
                        continue;
                    }
                    if (line == "[Name]")
                    {
                        status = RegisterReadStatus.Name;
                    }
                    else
                    {

                        switch (status)
                        {

                            case RegisterReadStatus.Name:
                                string[] text = line.Split(';');
                                if (text.Length != 3)
                                {
                                    throw new ArgumentException();
                                }
                                else
                                {
                                    Member member = new Member(text[0], text[1], text[2]);
                                    register.Add(member);
                                }
                                break;

                            case RegisterReadStatus.Indefinite:
                                throw new NotImplementedException();
                        }

                    }

                }
            }

            return register;

        }

        public RegisterRepository(string path)
        {
            Path = path;
        }
    }
}
