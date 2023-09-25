using InvestiDuo.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace InvestiDuo._Repositories
{
    public class AtivoRepository : BaseRepository, IAtivoRepository
    {
        private string sqlConnectionString;

        public AtivoRepository(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AtivoModel> GetAll()
        {
            var assetList = new List<AtivoModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from Ativo order by Ativo_Id desc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var assetModel = new AtivoModel();
                        assetModel.Id = (int) reader[0];
                        assetModel.Name = reader[1].ToString();
                        assetModel.Ticket = reader[2].ToString();
                        assetModel.Quantity = (int) reader[3];
                        assetModel.Value = (decimal)reader[4];
                        assetModel.Date = (DateTime)reader[5];
                        assetModel.Total = (decimal)reader[6];

                        assetList.Add(assetModel);
                    }
                }
            }
            return assetList;
        }

        public IEnumerable<AtivoModel> GetByValue(string value)
        {
            var assetList = new List<AtivoModel>();
            int assetId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string assetName = value;
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from Ativo " +
                    "where Ativo_Id = @id or Ativo_Name like @name+'%' order by Ativo_Id desc";
                command.Parameters.Add("@id", SqlDbType.Int).Value = assetId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = assetName;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var assetModel = new AtivoModel();
                        assetModel.Id = (int)reader[0];
                        assetModel.Name = reader[1].ToString();
                        assetModel.Ticket = reader[2].ToString();
                        assetModel.Quantity = (int)reader[3];
                        assetModel.Value = (decimal)reader[4];
                        assetModel.Date = (DateTime)reader[5];
                        assetModel.Total = (decimal)reader[6];

                        assetList.Add(assetModel);
                    }
                }
            }
            return assetList;
        }
    }
}
