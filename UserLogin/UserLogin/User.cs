using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class User
    {
        private string name;
        private string password;
        private string facNumber;
        private UserRole role;
        private DateTime created;
        private DateTime validUntil;

        public User(string name, string password, string facNumber, UserRole role)
        {
            this.name = name;
            this.password = password;
            this.facNumber = facNumber;
            this.role = role;
            this.created = DateTime.UtcNow;
            this.validUntil = DateTime.MinValue;
        }

        public User(string name, string password, string facNumber, UserRole role, DateTime validUntil)
        {
            this.name = name;
            this.password = password;
            this.facNumber = facNumber;
            this.role = role;
            this.created = DateTime.UtcNow;
            this.validUntil = validUntil;
        }

        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string FacNumber { get => facNumber; set => facNumber = value; }
        public UserRole Role { get => role; set => role = value; }
        public DateTime ValidUntil{get => validUntil; set => validUntil = value; }

        private String getValidUntil() {
            return this.validUntil.Equals(DateTime.MinValue) ? 
                    "forever" :  this.validUntil.ToString();
        }

        public override string ToString()
        {
            return "User name: " + this.name + "\n"
                + "User faculty number: " + this.facNumber + "\n"
                + "User role: " + this.role + "\n"
                + "User created: " + this.created + "\n"
                + "User account valid until: " + getValidUntil();
        }
    }
}
