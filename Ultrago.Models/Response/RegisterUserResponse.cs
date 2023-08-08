using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultrago.Models.Response
{
    public class RegisterUserResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Message { get; set; } = "User registered successfully";
    }
}
