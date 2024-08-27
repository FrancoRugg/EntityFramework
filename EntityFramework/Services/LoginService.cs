using EntityFramework.Models;
using EntityFramework.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Services
{
    public class LoginService : LoginRepository //Acá se implementa la interfáz a utilizar.
    {
        private readonly AppDbContext context;

        public LoginService(AppDbContext context)//Constructor que recibe el AppDbContext.
        {
            this.context = context;
        }

        public async Task<bool> DelUser(int id)
        {
            //throw new NotImplementedException();
            var user = await context.Login.FindAsync(id);
            if (user != null) 
            { 
                context.Login.Remove(user);
                await context.SaveChangesAsync();
                return true;
            }
            else 
            {
                return false; 
            }
        }

        public async Task<ActionResult<List<Login>>> GetUserList()
        {
            //throw new NotImplementedException();
            return await context.Login.ToListAsync(); //retorna un select de todos los usuarios
        }

        public async Task<bool> PostUser(Login user)
        {
            //throw new NotImplementedException();
            try
            {
                context.Login.Add(user);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
