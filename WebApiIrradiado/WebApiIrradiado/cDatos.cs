using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApiIrradiado
{
    public class cDatos
    {

        public SqlConnection Connection;
        public SqlTransaction Transaction;

        public string MsgError { get; set; }
        public bool BolExito { get; set; }


        public DataSet EjecutaConsultaSqlServer(string strQuery) 
        {
            MsgError = string.Empty;
            BolExito = true;
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            try
            {
                this.Connection = new SqlConnection();
                DataSet dstDatos = new DataSet();
                System.Data.SqlClient.SqlDataAdapter dapDatos = new System.Data.SqlClient.SqlDataAdapter();
                var cadena = config["ConnectionStrings:DefaultConnection"];
                byte[] bytetemp = Convert.FromBase64String(cadena);
                this.Connection.ConnectionString = System.Text.Encoding.Unicode.GetString(bytetemp);
                this.Connection.Open();

                IsolationLevel isolation = IsolationLevel.ReadCommitted;
                Transaction = Connection.BeginTransaction(isolation);

                System.Data.Common.DbCommand cmd = Transaction.Connection.CreateCommand();
                cmd.Transaction = Transaction;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                //cmd.ExecuteNonQuery();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    dt.Load(reader);
                    ds.Tables.Add(dt);
                    dstDatos = ds;
                }

                Transaction.Commit();


                return dstDatos;
            }
            catch (System.ApplicationException err)
            {
                if (Transaction.Connection.State == ConnectionState.Open && Transaction != null)
                    Transaction.Rollback();
                System.Exception inner = err.InnerException ?? err;
                BolExito = false;
                throw inner;
            }

            catch (System.Exception ex)
            {
                if (Transaction.Connection.State == ConnectionState.Open && Transaction != null)
                    Transaction.Rollback();
                BolExito = false;
                MsgError = ex.Message;
                throw;
            }

            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }


        }

    }
}
