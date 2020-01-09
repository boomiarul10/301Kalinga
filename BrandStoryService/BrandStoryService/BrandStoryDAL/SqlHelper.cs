using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BrandStoryDAL
{
    public interface ISqlHelper
    {
        object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters);
        DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters);       
    }
    public class SqlHelper:ISqlHelper
    {
        #region PrivateMembers

        private static string strConnectionString = "";
        private static SqlConnection objSqlconnection;
        private static SqlTransaction objSqlTransaction;

        #endregion //private members

        #region Properties

        public static string ConnectionString
        {
            set { strConnectionString = value; }
        }

        #endregion //Properties

        #region Public Methods
        //public static void InitializeTransaction(string connectionString)
        //{
        //    objSqlconnection = new SqlConnection(connectionString);
        //    objSqlconnection.Open();
        //    objSqlTransaction = objSqlconnection.BeginTransaction();
        //    SqlHelperParameterCache
        //}

        public object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return ExecuteScalar(con, commandType, commandText, commandParameters);
            }
        }
        public DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return ExecuteDataset(con, commandType, commandText, commandParameters);
            }
        }
        #endregion  //Public Methods

        #region Private Methods

        private DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //create a command to prepare it for execution
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, commandType, commandText, commandParameters);

            //Create the DataAdapter and DataSet
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            //fill the dataset using default values for datatable names, etc..
            da.Fill(ds);

            //detach the sqlparameters from command object, so they can be used again.
            cmd.Parameters.Clear();

            return ds;
        }

        private object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, commandType, commandText, commandParameters);

            object retVal = cmd.ExecuteScalar();
            
            //detach the sqlparameters from command object, so they can be used again.
            cmd.Parameters.Clear();

            return retVal;

        }
        private void PrepareCommand(SqlCommand command, SqlConnection connection, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            //if the provided connection is not open then we will oipen it
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            //associate the connection with the command
            command.Connection = connection;

            //set the command text (stored procedure name or SQL statement)
            command.CommandText = commandText;

            ////if we provided a transaction, assign it.
            //if (transaction != null)
            //{
            //    command.Transaction = transaction;
            //}

            //set the command type
            command.CommandType = commandType;

            //attach the command parameters if they are provided
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }

            return;
        }

        private void AttachParameters(SqlCommand command, SqlParameter[] commandParameter)
        {
            foreach (SqlParameter p in commandParameter)
            {
                //check for derived output value with no value assigned
                if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                {
                    p.Value = DBNull.Value;
                }
                command.Parameters.Add(p);
            }
        }

        #endregion

    }
}
