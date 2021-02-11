using CommonLibrary1.Models;
using Dapper;
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
                dbConnection.Open();
                return dbConnection.Query<Employee>($"SELECT * FROM {tableName}");
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
                dbConnection.Execute($"INSERT INTO {tableName} (FirstName, LastName, BirthDay, Phone, Email, EmpId) " +
                    $"VALUES (@FirstName, @LastName, @BirthDay, @Phone, @Email, @EmpId)", employee);
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
                dbConnection.Query($"UPDATE {tableName} SET (FirstName, LastName, BirthDay, Phone, Email, EmpId)" +
                    $"=(@FirstName, @LastName, @BirthDay, @Phone, @Email, @EmpId) WHERE Id = {employee.Id}", employee);
                dbConnection.Close();
            }
        }
    }
}
