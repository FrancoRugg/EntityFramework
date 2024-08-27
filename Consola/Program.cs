using EntityFramework.Models;
using EntityFramework.Repositories;
using EntityFramework.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<AppDbContext>(options => options.UseSqlite("Data source=Database/SistemaMetricas.db"))
            .AddScoped<LoginRepository,LoginService>()
            .BuildServiceProvider();

        var LoginService = serviceProvider.GetService<LoginRepository>();
        if(LoginService == null)
        {
            Console.WriteLine("No se pudo obtener el servicio solicitado: LoginService.");
            return;
        }

        //Obtener la Lista de Usuarios
        ActionResult<List<Login>> lista = await LoginService.GetUserList();

        foreach (var user in lista.Value)
        {
            Console.WriteLine($"Id: {user.Id}, Usuario: {user.Usuario}, Estado: {user.Estado}");
        }

        //Crear Usuario Nuevo
        //var newUser = new Login
        //{
        //    Usuario = "UserConET",
        //    Clave = "OtraClave",
        //    Nombre = "Sulma",
        //    Apellido = "Lobato",
        //    Email = "asfdaef@afdasfda.com.ar",
        //    Dni = "000000000",
        //    Area = "Desarrollo",
        //    FechaAlta = DateTime.Now.ToString(),
        //    Rol = 1,
        //    Estado = "V"
        //};

        //var res = await LoginService.PostUser(newUser);
        //if (res)
        //{
        //    Console.WriteLine("Usuario agregado correctamente " + DateTime.Now.ToString());
        //}
        //else
        //{
        //    Console.WriteLine("Hubo un problema al ingresar el usuario " + DateTime.Now.ToString());
        //}

        //Delete 
        //int idToDelete = 6;
        //var delRes = await LoginService.DelUser(idToDelete);
        //if (delRes)
        //{
        //    Console.WriteLine("Usuario Eliminado correctamente " + DateTime.Now.ToString());
        //}
        //else
        //{
        //    Console.WriteLine("Hubo un problema al Eliminar el usuario " + DateTime.Now.ToString());
        //}

        Console.ReadKey();

    }
}