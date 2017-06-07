using CyberSecurity.Data;
using CyberSecurity.StorageClient;
using System.Collections.Generic;
using System.Linq;

namespace CyberSecurity.Persistence
{
    public class PasswordPersistence
    {
        //this class talks to the db/client/storage layer, and interacts with the database without exposing important data (i.e. file names)
        SaveLoadArchive saveLoad;

        public PasswordPersistence()
        {
            saveLoad = new SaveLoadArchive();
        }

        public PasswordArchive GetUser(string user)
        {
            return saveLoad.LoadUser(user);
        }

        public List<PasswordArchive> GetAll()
        {
            return saveLoad.LoadUsers().ToList();
        }

        public void Put(PasswordArchive passArchive)
        {
            saveLoad.Store(passArchive);
        }

        //because we're actually working with files and not a real db, in order to update
        //we must first get all the data in the file and store it, we then search for the object we want to change
        //and update it appropriately, clear the file and store all the data including the updated object
        public void UpdatePasswords(string username, string password)
        {
            var pass = saveLoad.LoadUsers();

            foreach(var passA in pass)
            {
                if(passA.Username == username) //match the usernames
                {
                    if(passA.Passwords == null)
                    {
                        passA.Passwords = new List<string>();
                    }

                    passA.Passwords.Add(password); //store the new password in the archives 
                }
            }

            ClearFile();

            foreach(var passA in pass)
            {
                saveLoad.Store(passA);
            }
        }

        public void ClearFile()
        {
            saveLoad.ClearFile();
        }

        //decode the password in order to compare it to strings, method is private
        private string DecodeFromBase64(string data)
        {
            var encodeDataAsBytes = System.Convert.FromBase64String(data);
            return System.Text.ASCIIEncoding.ASCII.GetString(encodeDataAsBytes);
        }

        public string ReadPassword(string pass)
        {
            return DecodeFromBase64(pass);
        }
    }
}