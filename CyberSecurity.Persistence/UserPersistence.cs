using System.Collections.Generic;
using System.Linq;

namespace CyberSecurity.Data
{
    public class UserPersistence
    {
        private SaveLoadUsers saveLoad;

        public UserPersistence()
        {
            saveLoad = new SaveLoadUsers();
        }

        //update the user in the same way we update the passwords
        public void UpdateUser(User user)
        {
            var users = saveLoad.GetAll().ToList();

            saveLoad.Clear();

            foreach(var u in users)
            {
                if(u.Id == user.Id)
                {
                    u.Details = user.Details;
                    u.Username = user.Username;
                    u.Password = user.Password;
                    u.PasswordUses = user.PasswordUses;
                    u.GuineaPigData = user.GuineaPigData;
                }
            }
            foreach (var u in users)
            {
                saveLoad.Put(u);
            }
        }

        public void AddUser(string username, string password)
        {
            var id = GenterateUserId();

            var newUser = new User
            {
                Id = id,
                Username = username,
                Password = password,

            };

            saveLoad.Put(newUser);
        }

        public void RemoveUser(User user)
        {
            var users = saveLoad.GetAll().ToList();

            saveLoad.Clear();

            users.Remove(user);
            foreach(var u in users)
            {
                saveLoad.Put(u);
            }
        }

        public User GetUser(long id)
        {
            var users = saveLoad.GetAll();
            foreach(var u in users)
            {
                if (u.Id == id)
                {
                    return u;
                }
            }

            return null;
        }

        public List<User> GetUsers()
        {
            return saveLoad.GetAll().ToList();
        }

        public User FindUser(string username, string password)
        {
            return saveLoad.Search(username, password);
        }

        public long GenterateUserId()
        {
            var users = saveLoad.GetAll();

            var maxId = 0;

            foreach (var u in users)
            {
                if (maxId == 0)
                {
                    maxId = (int)u.Id;
                }

                if (u.Id > maxId)
                {
                    maxId = (int)u.Id;
                }
            }

            return maxId + 1;
        }

        public bool CheckUsername(string username)
        {
            var users = saveLoad.GetAll();

            foreach (var u in users)
            {
                if (u.Username == username)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckUsersExist()
        {
            return saveLoad.UsersExist();
        }

        public void ClearFile()
        {
            saveLoad.Clear();
        }
    }
}
