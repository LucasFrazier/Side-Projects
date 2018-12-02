using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SportClips.DAL
{
    public class SportClipsDAL : ISportClipsDAL
    {
        private string connectionString;

        public SportClipsDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Store> GetAllStores()
        {
            List<Store> Stores = new List<Store>();

            string query = @"SELECT storeNumber, storeName FROM store";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Stores.Add(MapRowToStore(reader));
                }
            }

            return Stores;
        }

        private Store MapRowToStore(SqlDataReader reader)
        {
            return new Store()
            {
                StoreNumber = Convert.ToInt32(reader["storeNumber"]),
                StoreName = Convert.ToString(reader["storeName"])
            };
        }

        public int AddRequestOffToDb(RequestOff request)
        {
            int numRowsAffected = 0;

            string query = @"INSERT INTO requestOff (firstName, lastName, storeNumber, dateTimeOfRequest, dateFrom, dateTo, reason) VALUES (@firstName, @lastName, @storeNumber, @dateTimeOfRequest, @dateFrom, @dateTo, @reason)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@firstName", request.FirstName);
                cmd.Parameters.AddWithValue("@lastName", request.LastName);
                cmd.Parameters.AddWithValue("@storeNumber", request.StoreNumber);
                cmd.Parameters.AddWithValue("@dateTimeOfRequest", request.DateTimeOfRequest);
                cmd.Parameters.AddWithValue("@dateFrom", request.DateFrom);
                cmd.Parameters.AddWithValue("@dateTo", request.DateTo);
                cmd.Parameters.AddWithValue("@reason", request.Reason);
                numRowsAffected = (int)cmd.ExecuteNonQuery();
            }

            return numRowsAffected;
        }
    }
}