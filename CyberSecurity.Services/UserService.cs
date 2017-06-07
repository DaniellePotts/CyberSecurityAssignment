
using System.Collections.Generic;

namespace CyberSecurity.Data
{
    public class UserService
    {

        UserPersistence persistence;

        public UserService()
        {
            persistence = new UserPersistence();
        }

        public void AddUser(User u)
        {
            u.Id = persistence.GenterateUserId();
            persistence.AddUser(u.Username, u.Password);
        }

        public void UpdateUser(User u)
        {
            persistence.UpdateUser(u);
        }

        public void DeleteUser(User u)
        {
            persistence.RemoveUser(u);
        }

        public User GetUser(long id)
        {
            return persistence.GetUser(id);
        }

        public List<User> GetAllUsers()
        {
            return persistence.GetUsers();
        }

        public User FindUser(string username, string password)
        {
            return persistence.FindUser(username,password);
        }

        public bool CheckUsersExist()
        {
            return persistence.CheckUsersExist();
        }

        public void ClearFile()
        {
            persistence.ClearFile();
        }

        public bool CheckUsernameIsUnique(string username)
        {
            var users = persistence.GetUsers();

            foreach(var user in users)
            {
                if(user.Username == username)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
