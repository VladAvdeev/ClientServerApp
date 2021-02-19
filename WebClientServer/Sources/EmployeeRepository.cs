using CommonLibrary1.Models;
using Dapper;
using GymClientServer.ViewDB;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GymClientServer.Sources
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private string tableName = "Employee"; // Строка для инициализации таблицы
        private string connectionString; // Строка подключения к базе
        public EmployeeRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }
        internal IDbConnection ConnectionDb
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }
        public IEnumerable<Employee> FindAll()
        {
            using (IDbConnection dbConnection = ConnectionDb)
            {
                List<Employee> employeesList = new List<Employee>();
                List<EmployeeView> employeeViews;
                dbConnection.Open();
                employeeViews = dbConnection.Query<EmployeeView>("SELECT * FROM EmployeePost").ToList();
                foreach(var emp in employeeViews)
                {
                    Employee employee = new Employee()
                    {
                        Id = emp.Id,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        Birthday = emp.Birthday,
                        Phone = emp.Phone,
                        Email = emp.Email,
                        CareerPost = new CareerPost() { PostName = emp.PostName },
                        GymAcces = new Gym() { Adress = emp.Adress },
                    };
                    employeesList.Add(employee);
                }
                //dbConnection.Query<Employee>($"SELECT * FROM {tableName}");
                return employeesList;
            }
        }
        public Employee FindById(int id)
        {
            using (IDbConnection dbConnection = ConnectionDb)
            {
                dbConnection.Open();
                return dbConnection.Query<Employee>($"SELECT * FROM {tableName} WHERE Id = {id}", new { Id = id }).FirstOrDefault();
            }
        }
        public void Add(Employee employee)
        {
            using (IDbConnection dbConnection = ConnectionDb)
            {
                dbConnection.Open();
                dbConnection.Execute($"INSERT INTO {tableName} (FirstName, LastName, BirthDay, Phone, Email, EmpId, clubId, ScheduleId) " +
                    $"VALUES (@FirstName, @LastName, @BirthDay, @Phone, @Email, @EmpId, @ClubId, @ScheduleId)", employee);
            }
        }
        public void Remove(int id)
        {
            using(IDbConnection dbConnection = ConnectionDb)
            {
                dbConnection.Open();
                dbConnection.Execute($"DELETE FROM {tableName} WHERE Id = {id}");
                dbConnection.Close();
            }
        }
        public void Update(Employee employee)
        {
            using (IDbConnection dbConnection = ConnectionDb)
            {
                dbConnection.Open();
                dbConnection.Query($"UPDATE {tableName} SET FirstName = @FirstName, LastName = @LastName, BirthDay = @BirthDay, Phone = @Phone, EmpId = @EmpId, ClubId = @ClubId, ScheduleId = @ScheduleId " +
                    $"WHERE Id = {employee.Id}", employee);
                dbConnection.Close();
            }
        }
    }
}
