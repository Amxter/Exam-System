using System.Data;
namespace DataES.Interfaces
{
    public interface IGenericRepositroy<TDto>
    {

        TDto GetById(int Id);
        
        DataTable GetAll();
        
        /// <returns>returns the added entity id , returns -1 if not added</returns>
        int Add(TDto dto);
        
        bool Update(TDto dto);
        
        bool Delete(int Id);

        bool IsExist(int Id);
    }
}

