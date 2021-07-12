using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRegister.Service.Contracts
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity Authenticate(string username, string password);
        string GetJWTToken(string username);
       
    }
}
