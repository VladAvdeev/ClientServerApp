using CommonLibrary.Models;
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
    public class TimingRepository : IRepository<TimeSport>
    {
        private string tableName = "TimeSport";
        private string connectionString;
        public TimingRepository(IConfiguration configuration)
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
        public IEnumerable<TimeSport> FindAll()
        {
            using(IDbConnection connection = DbConnection)
            {
                connection.Open();
                return connection.Query<TimeSport>($"SELECT * FROM {tableName}");
            }
        }
        public TimeSport FindById(int id)
        {
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                return connection.Query<TimeSport>($"SELECT * FROM {tableName} WHERE Id = {id}").FirstOrDefault();
            }
        }
        public void Add(TimeSport time)
        {
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                connection.Execute($"INSERT INTO {tableName} (FromTo, TimeForClub)  VALUES(@FromTo, @TimeForClub)", time);
                connection.Close();
            }
        }
        public void Update(TimeSport time)
        {
            using (IDbConnection connection = DbConnection)
            {
                connection.Open();
                connection.Execute($"UPDATE {tableName} SET FromTo = @FromTo, TimeForClub = @TimeForClub WHERE Id = {time.Id}", time);
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
    }
}
