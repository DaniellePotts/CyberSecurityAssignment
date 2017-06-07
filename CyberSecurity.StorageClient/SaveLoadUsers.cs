using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace CyberSecurity.Data
{
    public class SaveLoadUsers
    {
        /*This class mimics the actions of a database by using a serialized file. This file in particular stores the users. each user has a unique username and ID. This data acts like the primary key*/

        private const string FILE_NAME = "USER_FILE.csr"; //store data in a .csr file
        private void SaveUser(User user) //store a user
        {
            var bf = new BinaryFormatter();
            var outfile = new FileStream(FILE_NAME, FileMode.Append, FileAccess.Write);
            user.Password = EncodeToBase64(user.Password); //encode password
            if (!File.Exists(FILE_NAME))
            {
                outfile = new FileStream(FILE_NAME, FileMode.Create, FileAccess.Write);
            }

            bf.Serialize(outfile, user);
            outfile.Close();

            System.Console.WriteLine("Successfully wrote user to file.");
        }

        private IEnumerable<User> LoadUsers()//load all users
        {
            var users = new List<User>();

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
                    users.Add((User)bf.Deserialize(infile));
                }

                foreach(var u in users)
                {
                    u.Password = DecodeFromBase64(u.Password);
                }
            }

            infile.Close();

            return users.AsEnumerable();
        } 

        private User LoadUser(string userName, string password) //load a single user
        {
            var user = new User();
            var users = new List<User>();
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
                    users.Add((User)bf.Deserialize(infile));
                }

                foreach(var u in users)
                {
                    if(DecodeFromBase64(u.Password) == password && u.Username == userName)
                    {
                        user = u;
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

        private string EncodeToBase64(string toEncode)
        {
            var toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            var result = System.Convert.ToBase64String(toEncodeAsBytes);
            return result;
        }

        private string DecodeFromBase64(string data)
        {
            var encodeDataAsBytes = System.Convert.FromBase64String(data);
            return System.Text.ASCIIEncoding.ASCII.GetString(encodeDataAsBytes);
        }

        private User FindUser(string username, string password)
        {
            var users = LoadUsers();

            foreach (var u in users)
            {
                if (u.Username == username && u.Password == password)
                {
                    return u;
                }
            }

            return null;
        }
        public long GenterateUserId()
        {
            var users = LoadUsers();

            long maxId = 0;

           foreach(var u in users)
            {
                if(maxId == 0)
                {
                    maxId = u.Id;
                }

                if(u.Id > maxId)
                {
                    maxId = u.Id;
                }
            }

            return maxId + 1;
        }

        public bool CheckUsername(string username) 
        {
            var users = LoadUsers();

            foreach(var u in users)
            {
                if(u.Username == username)
                {
                    return true;
                }
            }

            return false;
        }

        private void ClearFile()
        {
           File.WriteAllText(FILE_NAME, string.Empty);
        }

        public bool UsersExist()
        {
            var users = LoadUsers();

            if(users == null || users.Count() == 0)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<User> GetAll()
        {
            return LoadUsers();
        }

        public User GetUser(string username, string password)
        {
            return LoadUser(username, password);
        }

        public void Put(User user)
        {
            SaveUser(user);
        }

        public void Clear()
        {
            ClearFile();
        }

        public User Search(string username, string password)
        {
            return FindUser(username, password);
        }
    }
}
