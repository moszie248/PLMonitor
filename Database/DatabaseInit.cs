using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pallet.Database;
using Pallet.Models;

namespace Pallet.Database
{
    public class DatabaseInit
    {
        public static void INIT(IServiceProvider serviceProvider)
        {
            // var context = new DatabaseContext(serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>());

            // If database does not exist then the database and all its schema are created
            // context.Database.EnsureCreated();

            //CheckDatabase about InsertData
            // insertData(context);
        }

        private static void insertData(DatabaseContext context)
        {
          
            // if (context.Employees.Any())
            // {
            //     return;
            // }

            // context.Employees.AddRange(dummyEmployee());
            // context.SaveChanges();
        }

        // private static IEnumerable<Employee> dummyEmployee()
        // {
        //     return new List<Employee>{
        //        new Employee
        //         {
        //             Eusername = "",
        //             Epassword = "",
        //             Ename = "",
        //             Esurname = "",
        //             Eemail = "",
        //             Etel = "",
        //             Evisible = true,
        //         }
        //    };
        // }
    }
}