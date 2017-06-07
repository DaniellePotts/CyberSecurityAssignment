using System;

namespace CyberSecurity.Data
{
    [Serializable]
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PasswordUses { get; set; }
        public DateTime DaysSincePasswordCreated { get; set; }

        public UserDetails Details { get; set; }
        public GuineaPigData GuineaPigData { get; set; }

        public override string ToString()
        {
            return Id + ": " + Username;
        }
    }
}
