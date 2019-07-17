using APIDeEekhoorn.Logic.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace APIDeEekhoorn.Logic.Models
{
    public class User : Entity<int>
    {
        public virtual string Username { get; set; }

        public virtual string Password { get; set; }

        public virtual string ApiKey { get; set; }

        public User()
        {

        }
    }
}
