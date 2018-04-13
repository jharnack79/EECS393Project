using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using GetThiqqq.Constants;
using GetThiqqq.Services;

namespace GetThiqqq.Repository
{
    public interface ITrackRepository
    {
        List<Progression> GetAllProgressionsByUserId(int id);
    }
    public class TrackRepository : ITrackRepository
    {
        public List<Progression> GetAllProgressionsByUserId(int id)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select * from ";
            return null;
        }
    }
}
