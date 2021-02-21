using CommonLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using Npgsql;
using Dapper;

namespace GymClientServer.Sources
{
    public class PostsRepository : IRepository<CareerPost>
    {
        private string tableName = "Post";
        private string connectionString;
        public PostsRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }
        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }
        public IEnumerable<CareerPost> FindAll()
        {
            using(IDbConnection connection = Connection)
            {
                connection.Open();
                return connection.Query<CareerPost>($"SELECT * FROM {tableName}");
            }
        }
        public CareerPost FindById(int id)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                return connection.Query<CareerPost>($"SELECT * FROM {tableName}").FirstOrDefault();
            }
        }
        public void Add(CareerPost careerPost)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                connection.Execute($"INSERT INTO {tableName} (PostName) VALUES (@PostName)", careerPost);
            }
        }
        public void Remove(int id)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                connection.Execute($"DELETE FROM {tableName} WHERE Id = {id}");
                connection.Close();
            }
        }
        public void Update(CareerPost careerPost)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                connection.Query<CareerPost>($"UPDATE {tableName} SET PostName = @PostName WHERE Id = {careerPost.Id}" , careerPost);
                connection.Close();
            }
        }
    }
}
