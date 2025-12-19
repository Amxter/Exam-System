using System;
using System.Data;
using DataES.Dtos;
using DataES.Interfaces;
using DataES.Repositries;

namespace BusinessEM.Entities
{
    public class clsPerson : clsEntity<PersonDto>
    {
        
        private static IPersonRepository _repo = new PersonRepository();

        // properities

        public int Id { get; set; } = -1;

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string SecondName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; } 
        
        public enum enRole {Instructor = 1 , Student = 2};
        public enRole Role { get; set; } 

        // Constructor for new entities
        public clsPerson() {

            _Mode = enMode.Add;
        }

        // Contructor for existing (loaded) entities
        private clsPerson (PersonDto dto)
        {
            _LoadFromDto(dto);
            _Mode = enMode.Update;
        } 

        // methods
        
        protected override void _LoadFromDto (PersonDto dto)
        {
            Id = dto.Id;
            FirstName = dto.FirstName;
            SecondName = dto.SecondName;
            LastName = dto.LastName;
            Username = dto.Username;
            Password = dto.Password;
            Email = dto.Email;
            DateOfBirth = dto.DateOfBirth;
            Role = (enRole)dto.Role;
        }
        protected override PersonDto _ToDto ( )
        {

            var dto = new PersonDto();

            dto.Id = Id;
            dto.FirstName = FirstName;
            dto.SecondName = SecondName;
            dto.LastName = LastName;

            dto.Username = Username;
            dto.Password = Password;

            dto.Email = Email;
            dto.DateOfBirth = DateOfBirth;

            dto.Role = (PersonDto.enRole)Role;

            return dto;

        }
        
        protected override bool _Add()
        {
            var dto = _ToDto();
            this.Id = _repo.Add(dto);

            if ( Id != -1)
            {
                _Mode = enMode.Update;
                return true;
            }

            return false;
        }
        protected override bool _Update() => _repo.Update(_ToDto());

        public static clsPerson GetById(int Id)
        {
            var dto = _repo.GetById(Id);
            
            if ( dto == null ) return null;
            
            return new clsPerson(dto);
                
        }
        public static DataTable GetAll() => _repo.GetAll();
        public static bool Delete(int Id) => _repo.Delete(Id);

        
        
    }
}
