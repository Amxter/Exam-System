using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEM.Entities
{
    public abstract class clsEntity<TDto>
    {
        protected enum enMode { Add , Update};
        protected enMode _Mode; 

        public bool Save()
        {
            if (_Mode == enMode.Add) {
                if (_Add())
                {
                    _Mode = enMode.Update;
                    return true;
                }
                return false;
            }

            return _Update();

        }

        protected abstract bool _Add();
        protected abstract bool _Update();

        protected abstract TDto _ToDto();
        protected abstract void _LoadFromDto(TDto dto);

    }
}
