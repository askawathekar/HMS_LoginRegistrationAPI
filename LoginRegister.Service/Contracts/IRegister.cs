using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRegister.Service.Contracts
{
    public interface IRegister<TEntity> where TEntity : class
    {
        bool ChcekUserExist(string nurseId);
        bool Register(TEntity model);
    }
}
