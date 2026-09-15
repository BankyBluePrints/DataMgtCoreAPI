using Dapper;
using DataManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Data.CommandType;
using DataManagement.Repository.Interfaces;
using System.Data;

namespace DataManagement.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public bool AddUser(User user)
        {
            try
            {
                if (user == null)
                    throw new ArgumentNullException(nameof(user));

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", user.UserName);
                parameters.Add("@UserMobile", user.UserMobile);
                parameters.Add("@UserEmail", user.UserEmail);
                parameters.Add("@FaceBookUrl", user.FaceBookUrl);
                parameters.Add("@LinkedInUrl", user.LinkedInUrl);
                parameters.Add("@TwitterUrl", user.TwitterUrl);
                parameters.Add("@PersonalWebUrl", user.PersonalWebUrl);

                SqlMapper.Execute(Connection, "AddUser", param: parameters, commandType: StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                // Log the actual exception details in a real application
                throw new Exception("Failed to add user", ex);
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                if (userId <= 0)
                    throw new ArgumentException("User ID must be greater than 0", nameof(userId));

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", userId);
                SqlMapper.Execute(Connection, "DeleteUser", param: parameters, commandType: StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                // Log the actual exception details in a real application
                throw new Exception("Failed to delete user", ex);
            }
        }

        public IList<User> GetAllUser() => SqlMapper.Query<User>(Connection, "GetAllUsers", commandType: StoredProcedure).ToList();
        public User GetUserById(int userId)
        {
            try
            {
                if (userId <= 0)
                    throw new ArgumentException("User ID must be greater than 0", nameof(userId));

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", userId);
                return SqlMapper.Query<User>(Connection, "GetUserById", parameters, commandType: StoredProcedure).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Log the actual exception details in a real application
                throw new Exception("Failed to get user by ID", ex);
            }
        }


        public bool UpdateUser(User user)
        {
            try
            {
                if (user == null)
                    throw new ArgumentNullException(nameof(user));

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", user.UserId);
                parameters.Add("@UserName", user.UserName);
                parameters.Add("@UserMobile", user.UserMobile);
                parameters.Add("@UserEmail", user.UserEmail);
                parameters.Add("@FaceBookUrl", user.FaceBookUrl);
                parameters.Add("@LinkedInUrl", user.LinkedInUrl);
                parameters.Add("@TwitterUrl", user.TwitterUrl);
                parameters.Add("@PersonalWebUrl", user.PersonalWebUrl);

                SqlMapper.Execute(Connection, "UpdateUser", param: parameters, commandType: StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                // Log the actual exception details in a real application
                throw new Exception("Failed to update user", ex);
            }
        }


    }
}
