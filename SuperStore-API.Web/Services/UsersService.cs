
using SuperStore_API.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace SuperStore_API.Web.Services
{
    public class UsersService : IUsersService
    {
        // this is a private field that can be accessed by any other code inside this class:
        string connectionString = ConfigurationManager.ConnectionStrings["SuperStoreConnection"].ConnectionString;

        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "User_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }
        public void Update(UsersUpdateRequest req)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "User_Update_ById";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", req.Id);
                cmd.Parameters.AddWithValue("@FirstName", req.FirstName);
                cmd.Parameters.AddWithValue("@LastName", req.LastName);
                cmd.Parameters.AddWithValue("@UserId", req.UserId);

                cmd.ExecuteNonQuery();
            }
        }
        public int Create(UsersCreateRequest request)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "User_Create";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", request.FirstName);
                cmd.Parameters.AddWithValue("@LastName", request.LastName);
                cmd.Parameters.AddWithValue("@UserId", request.UserId);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                return (int)cmd.Parameters["@Id"].Value;
            }
        }
        public List<User> GetAll()
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "User_SelectAll";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<User> users = new List<User>();

                    while (reader.Read())
                    {

                        // this loop will happen once per row of the result set  

                        User user = new User();
                        user.Id = (int)reader["Id"];
                        user.FirstName = (string)reader["FirstName"];
                        user.LastName = (string)reader["LastName"];
                        user.UserId = (string)reader["UserId"];
                        user.DateModified = (DateTime)reader["DateModified"];
                        user.DateCreated = (DateTime)reader["DateCreated"];

                        users.Add(user);
                    }

                    // after the loop is done, return the results
                    return users;
                }

            }
        }
        public User GetById(int id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "User_Select_ById";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    if (!reader.Read())
                    {
                        return null;
                    }

                    User user = new User();
                    user.Id = (int)reader["Id"];
                    user.FirstName = (string)reader["FirstName"];
                    user.LastName = (string)reader["LastName"];
                    user.UserId = (string)reader["UserId"];
                    user.DateModified = (DateTime)reader["DateModified"];
                    user.DateCreated = (DateTime)reader["DateCreated"];

                    return user;

                }

            }
        }
    }
}