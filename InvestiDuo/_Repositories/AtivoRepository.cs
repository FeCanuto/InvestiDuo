using InvestiDuo.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace InvestiDuo._Repositories
{
    public class AtivoRepository : BaseRepository, IAtivoRepository
    {
        public AtivoRepository(string sqlConnectionString)
        {
            connectionString = sqlConnectionString;
        }

        public void Add(AtivoModel ativoModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Insert into Ativos values (@name, @ticket, @quantity, @value, @total, @data)";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = ativoModel.Name;
                command.Parameters.Add("@ticket", SqlDbType.NVarChar).Value = ativoModel.Ticket;
                command.Parameters.Add("@quantity", SqlDbType.Int).Value = ativoModel.Name;
                command.Parameters.Add("@value", SqlDbType.Decimal).Value = ativoModel.Value;
                command.Parameters.Add("@total", SqlDbType.Decimal).Value = ativoModel.Total;
                command.Parameters.Add("@data", SqlDbType.DateTime).Value = ativoModel.Date;
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from Ativo where Ativo_Id = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(AtivoModel ativoModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update Ativo set Ativo_Name = @name, Ativo_Ticket = @ticket, Ativo_Quantity, Ativo_Value, Ativo_Date, Ativo_Total
                    where Ativo_Id = @id";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = ativoModel.Name;
                command.Parameters.Add("@ticket", SqlDbType.NVarChar).Value = ativoModel.Ticket;
                command.Parameters.Add("@quantity", SqlDbType.Int).Value = ativoModel.Name;
                command.Parameters.Add("@value", SqlDbType.Decimal).Value = ativoModel.Value;
                command.Parameters.Add("@total", SqlDbType.Decimal).Value = ativoModel.Total;
                command.Parameters.Add("@data", SqlDbType.DateTime).Value = ativoModel.Date;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<AtivoModel> GetAll()
        {
            var assetList = new List<AtivoModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from Ativos order by Ativo_Id desc";
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
                command.CommandText = "Select * from Ativos " +
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
