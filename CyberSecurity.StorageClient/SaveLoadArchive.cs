using CyberSecurity.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace CyberSecurity.StorageClient
{
    public class SaveLoadArchive
    {
        /*This class mimics the actions of a database by using a serialized file. This particular file stores archived passwords. the purpose of such is to ensure that users create unqiue passwords
         each time they change their password*/

        private const string FILE_NAME = "ARCHIVE.csr"; //store the password in a .csr file

        public void Store(PasswordArchive user) //store the user
        {
            var bf = new BinaryFormatter();
            var outfile = new FileStream(FILE_NAME, FileMode.Append, FileAccess.Write);
            for (var i = 0; i < user.Passwords.Count; i++)
            {
                user.Passwords[i] = EncodeToBase64(user.Passwords[i]);
            }

            if (!File.Exists(FILE_NAME))
            {
                outfile = new FileStream(FILE_NAME, FileMode.Create, FileAccess.Write);
            }


            bf.Serialize(outfile, user);

            outfile.Close();

            System.Console.WriteLine("Successfully wrote user to file.");
        }

        public IEnumerable<PasswordArchive> LoadUsers() //load all users
        {
            var users = new List<PasswordArchive>();

            var bf = new BinaryFormatter();
            var infile = new FileStream(FILE_NAME, FileMode.OpenOrCreate, FileAccess.Read);

            if (!File.Exists(FILE_NAME))
            {
                return null;
            }
            else
            {
                while (infile.Position < infile.Length)
                {
                    users.Add((PasswordArchive)bf.Deserialize(infile));
                }

                for (var i = 0; i < users.Count; i++)
                {
                    for (var j = 0; j < users[i].Passwords.Count; j++)
                    {
                        users[i].Passwords[j] = DecodeFromBase64(users[i].Passwords[j]);
                    }
                }
            }

            infile.Close();

            return users.AsEnumerable();
        }

        public PasswordArchive LoadUser(string userName) //load a single user
        {
            var user = new PasswordArchive();
            var users = new List<PasswordArchive>();
            var bf = new BinaryFormatter();
            var infile = new FileStream(FILE_NAME, FileMode.OpenOrCreate, FileAccess.Read);

            if (!File.Exists(FILE_NAME))
            {
                return null;
            }
            else
            {
                while (infile.Position < infile.Length)
                {
                    users.Add((PasswordArchive)bf.Deserialize(infile));
                }

                foreach (var u in users)
                {
                    if (u.Username == userName)
                    {
                        user = u;
                        break;
                    }
                }

                if (System.String.IsNullOrEmpty(user.Username)) //so we can check for a null instance.
                {
                    user = null;
                }
            }

            infile.Close();

            return user;
        }

        private string EncodeToBase64(string toEncode) //encode every password we store to a byte
        {
            var toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            var result = System.Convert.ToBase64String(toEncodeAsBytes);
            return result;
        }

        private string DecodeFromBase64(string data) //decode passwords for when we need to match passwords
        {
            var encodeDataAsBytes = System.Convert.FromBase64String(data);
            return System.Text.ASCIIEncoding.ASCII.GetString(encodeDataAsBytes);
        }

        public void ClearFile()
        {
            File.WriteAllText(FILE_NAME, string.Empty);
        }
    }
}

