using JWTDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTDemo.Services
{
    public interface IAuthentiCateServices
    {
        User Authentication(string userName, string password);
    }
}
