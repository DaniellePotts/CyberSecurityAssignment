using System.Collections.Generic;

namespace CyberSecurity.Data
{
    [System.Serializable]
    public class PasswordArchive
    {
        public long ID { get; set; }
        public string Username { get; set; }
        public List<string> Passwords { get; set; }
    }
}
