using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repositories
{
    public interface LoginRepository
    {
        public Task<ActionResult<List<Login>>> GetUserList();
        public Task<bool> PostUser(Login user);
        public Task<bool> DelUser(int id);



    }
}
