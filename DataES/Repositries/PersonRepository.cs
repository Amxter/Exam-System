using System;
using System.Data;
using System.Data.SqlClient;
using DataES.Dtos;
using DataES.Interfaces;

namespace DataES.Repositries
{
    public class PersonRepository : IPersonRepository
    {

        public int Add(PersonDto dto)
        {
            
            if (dto == null) return -1;

            int GeneratedId = -1;

            string Query = @"
                    INSERT INTO People (
                        Username, Password, FirstName, SecondName, LastName, 
                        Email, DateOfBirth, Role
                    ) 
                    VALUES (
                        @Username, @Password, @FirstName, @SecondName, @LastName,
                        @Email, @DateOfBirth, @Role
                    );
                    SELECT SCOPE_IDENTITY();
                ";

            var Connection = new SqlConnection(clsDataSettings.ConnectionString);

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Id", dto.Id);
            Command.Parameters.AddWithValue("@Username", dto.Username);
            Command.Parameters.AddWithValue("@Password", dto.Password);
            Command.Parameters.AddWithValue("@FirstName", dto.FirstName);
            Command.Parameters.AddWithValue("@LastName", dto.LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", dto.DateOfBirth);
            Command.Parameters.AddWithValue("@Role", dto.Role);

            if (dto.Email == null || string.IsNullOrEmpty(dto.Email))
                Command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Email", dto.Email);

            if (dto.SecondName == null || string.IsNullOrEmpty(dto.SecondName))
                Command.Parameters.AddWithValue("@SecondName", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@SecondName", dto.SecondName);


            try
            {
                Connection.Open();

                var result = Command.ExecuteScalar();

                if (result != null) GeneratedId = (int)result;

            }

            catch (Exception ex) { GeneratedId = -1; }

            finally { Connection.Close(); }

            return GeneratedId;

        }

        public bool Delete(int Id)
        {
            int AffectedRowsNumber = 0;

            string Query = "Delete From People Where PersonId = @Id";

            var Connection = new SqlConnection(clsDataSettings.ConnectionString);

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@id", Id);

            try
            {
                Connection.Open();

                AffectedRowsNumber = Command.ExecuteNonQuery();

            }
            catch (Exception ex) { return false; }

            finally { Connection.Close(); }

            return AffectedRowsNumber > 0;

        }

        public DataTable GetAll()
        {
            string Query = "Select * From People";

            var Connection = new SqlConnection(clsDataSettings.ConnectionString);

            var Command = new SqlCommand(Query, Connection);

            DataTable dt = new DataTable();

            try
            {
                Connection.Open();

                var Reader = Command.ExecuteReader();

                dt.Load(Reader);

                Reader.Close();
            }
            catch (Exception ex) { }
            finally { Connection.Close(); }

            return dt;

        }

        public PersonDto GetById(int Id)
        {
            string Query = "Select * From People Where PersonId = @Id";

            var Connection = new SqlConnection(clsDataSettings.ConnectionString);

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Id", Id);

            PersonDto dto = null;

            try
            {
                Connection.Open();

                var Reader = Command.ExecuteReader();

                if (Reader.Read()) {

                    dto = new PersonDto();

                    dto.Id = (int)Reader["PersonId"];
                    dto.Username = Reader["Username"].ToString();
                    dto.Password = Reader["Password"].ToString();
                    dto.FirstName = Reader["FirstName"].ToString();
                    dto.SecondName = Reader["SecondName"].ToString();
                    dto.LastName = Reader["LastName"].ToString();
                    dto.Email = Reader["Email"].ToString();
                    dto.DateOfBirth = DateTime.Parse(Reader["DateOfBirth"].ToString());
                    dto.Role = (PersonDto.enRole)Reader["Role"];
                }

                Reader.Close();
            }
            catch (Exception ex) { }
            finally { Connection.Close(); }

            return dto;
        }

        public bool IsExist(int Id)
        {
            bool IsFound = false;

            string Query = "Select 1 From People Where PersonId = @Id";

            var Connection = new SqlConnection(clsDataSettings.ConnectionString);

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Id", Id);

            try
            {
                Connection.Open();
                var result = Command.ExecuteScalar();

                if (result != null) IsFound = true;

            }
            catch { IsFound = false; }
            finally { Connection.Close(); }

            return IsFound;
        }

        public bool Update(PersonDto dto)
        {
            
            if ( dto  == null ) return false;   

            int AffectedRowsNumber = 0;

            string Query =
                @"Update People
                 Set
                      Username =    @Username,
                      Password =    @Password,
                      FirstName =   @FirstName,
                      SecondName =  @SecondName,
                      LastName =    @LastName,
                      Email =       @Email,
                      DateOfBirth = @DateOfBirth,
                      Role = @Role
                Where 
                     PersonId = @Id
            ";

            var Connection = new SqlConnection(clsDataSettings.ConnectionString);

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Id", dto.Id);
            Command.Parameters.AddWithValue("@Username", dto.Username);
            Command.Parameters.AddWithValue("@Password", dto.Password);
            Command.Parameters.AddWithValue("@FirstName", dto.FirstName);
            Command.Parameters.AddWithValue("@LastName", dto.LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", dto.DateOfBirth);
            Command.Parameters.AddWithValue("@Role", dto.Role);

            if (dto.Email == null || string.IsNullOrEmpty(dto.Email))
                Command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Email", dto.Email);

            if (dto.SecondName == null || string.IsNullOrEmpty(dto.SecondName))
                Command.Parameters.AddWithValue("@SecondName", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@SecondName", dto.SecondName);


            try
            {

                Connection.Open();

                AffectedRowsNumber = Command.ExecuteNonQuery();

            }
            catch (Exception ex) { return false; }
            finally { Connection.Close(); }

            return AffectedRowsNumber > 0;
        }

    }
}
