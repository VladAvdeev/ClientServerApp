﻿using CommonLibrary.Models;
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
    public class ClientRepository : IRepository<Client>
    {
        private string tableName = "Clients";
        private string connectionString;
        public ClientRepository(IConfiguration configuration)
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
        public IEnumerable<Client> FindAll()
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Client>($"SELECT * FROM {tableName}");
            }
        }
        public Client FindById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Client>($"SELECT * FROM {tableName} WHERE Id = {id}", new { Id = id }).FirstOrDefault();
            }
        }
        public void Add(Client client)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute($"INSERT INTO {tableName}(FirstName, LastName, BirthDay, Phone, Email, ClientId, GymTicketId, ClubClientId " +
                    $"TicketName, TicketUseful) " +
                    $"VALUES(@FirstName, @LastName, @BirthDay, @Phone, @Email, @ClientId, @GymTicketId, @ClubClientId" , client);
                dbConnection.Close();
            }
        }
        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute($"DELETE FROM {tableName} WHERE Id = {id}");
                dbConnection.Close();
            }
        }
        public void Update(Client client)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query($"UPDATE {tableName} SET FirstName = @FirstName, LastName = @LastName, BirthDay = @BirthDay, Phone = @Phone, " +
                    $"Email = @Email, ClientId = @ClientId, GymTicketId = @GymTicketId, ClubClientId = @ClubClientId" +
                    $"WHERE Id = {client.Id}", client);
                dbConnection.Close();
            }
        }
    }
}
