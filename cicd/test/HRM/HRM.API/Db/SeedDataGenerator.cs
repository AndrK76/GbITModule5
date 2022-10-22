using HRM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.API.Db
{
    public class SeedDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HRMContext(
                serviceProvider.GetRequiredService<DbContextOptions<HRMContext>>()))
            {
                if (context.Employees!.Any())
                {
                    return; 
                }

                context.Employees!.AddRange(
                    new Employee
                    {
                        Name = "г.н Анжынер",
                        Designation = "Глава департамента It",
                        FathersName = "Иван Иванов",
                        MothersName = "Петр петров",
                        DateOfBirth = new DateTime(1984, 12, 19, 00, 00, 00)
                    },

                    new Employee
                    {
                        Name = "富山県～金輪県",
                        Designation = "도야마-카나와",
                        FathersName = "ტოიამა ტო კანავა",
                        MothersName = "Тояма То Канава",
                        DateOfBirth = new DateTime(1990, 10, 29, 00, 00, 00)
                    },

                    new Employee
                    {
                        Name = "Tahiya Hasan Arisha",
                        Designation = "Jr. Software Engineer",
                        FathersName = "Md. Mahedee Hasan",
                        MothersName = "Khaleda Islam",
                        DateOfBirth = new DateTime(2017, 09, 17, 00, 00, 00)
                    },

                    new Employee
                    {
                        Name = "Humaira Hasan",
                        Designation = "Jr. Software Engineer",
                        FathersName = "Md. Mahedee Hasan",
                        MothersName = "Khaleda Islam",
                        DateOfBirth = new DateTime(2021, 03, 17, 00, 00, 00)
                    }
                );
                context.SaveChanges();

            }
        }
    }
}