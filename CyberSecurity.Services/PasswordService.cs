using CyberSecurity.Data;
using CyberSecurity.Persistence;
using System.Collections.Generic;

namespace CyberSecurity.Services
{
    public class PasswordService
    {
        PasswordPersistence passPersistence;

        public PasswordService() { passPersistence = new PasswordPersistence(); }

        public PasswordArchive GetUser(string username)
        {
            return passPersistence.GetUser(username);
        }

        public List<PasswordArchive> GetUsers()
        {
            return passPersistence.GetAll();
        }

        public void Put(PasswordArchive passArchive)
        {
            passPersistence.Put(passArchive);
        }

        public void Update(string username, string password)
        {
            passPersistence.UpdatePasswords(username,password);
        }

        public bool CheckPasswords(string username, string newPassword)
        {
            var password = passPersistence.GetUser(username);
            if(password != null)
            {
                foreach(var p in password.Passwords) //check our password archive to see if our new password hasnt been used before
                {
                    if(newPassword == passPersistence.ReadPassword(p))
                    {
                        return true;
                    }
                }
            }
            else
            {
                return true;
            }

            return false;
        }

        public void ClearFile()
        {
            passPersistence.ClearFile();
        }

        public string ReadPassword(string pass)
        {
            return passPersistence.ReadPassword(pass);
        }
    }
}
