using CommonLibrary1.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GymClientServer.Sources
{
    public class ClubesRepository : IRepository<Gym>
    {
        private string tableName = "clubes";
        private string connectionString;
        public ClubesRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }
        internal IDbConnection DbConnection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }
        public IEnumerable<Gym> FindAll()
        {
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                return connection.Query<Gym>($"SELECT * FROM {tableName}");
            }
        }
        public Gym FindById(int id)
        {
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                return connection.Query<Gym>($"SELECT * FROM {tableName} WHERE Id = {id}").FirstOrDefault();
            }
        }
        public void Add(Gym gym)
        {
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                connection.Execute($"INSERT INTO {tableName} (Adress, Email, Phone) VALUES(@Adress, @Email, @Phone)", gym);
                connection.Close();
            }
        }
        public void Remove(int id)
        {
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                connection.Execute($"DELETE FROM {tableName} WHERE Id = {id}");
                connection.Close();
            }
        }
        public void Update(Gym gym)
        {
            using (IDbConnection dbConnection = DbConnection)
            {
                dbConnection.Open();
                dbConnection.Query($"UPDATE {tableName} SET Adress = @Adress, Email = @Email, Phone = @Phone WHERE Id = {gym.Id}", gym);
                dbConnection.Close();
            }
        }
    }
}
