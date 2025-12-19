using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataES.Dtos
{
    
    public class PersonDto
    {
        public int Id { get; set; }

        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public string FirstName { get; set; }
        
        public string SecondName { get; set; } // nullable
        
        public string LastName { get; set; }
        
        public string Email { get; set; } // nullable
        
        public DateTime DateOfBirth { get; set; }
        
        public enum enRole { Instructor = 1, Student = 2};
        
        public enRole Role { get; set; }


    }
}
