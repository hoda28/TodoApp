using log4net;
using log4net.Repository.Hierarchy;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using TodoApp.DataInputDataSetTableAdapters;

namespace TodoApp.Service
{
    public class EditFormService : IEditFormService
    {
        #region InsertTasks
        /// <summary>
        ///InsertTasks
        /// </summary>
        /// <param name="dataTable">table</param>
        public int InsertTasks(DataInputDataSet.tasksRow row)
        {
            ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            logger.Debug("Strat");
            //TodoApp.DataInputDataSetTableAdapters.tasksTableAdapter adt = new TodoApp.DataInputDataSetTableAdapters.tasksTableAdapter();
            //adt.Insert(row.discription, row.category, row.startdate, row.enddate);

            string server = "localhost";
            string port = "5432";
            string username = "postgres";
            string password = "checkups";
            string database = "postgres";

            //接続文字列の作成
            string connectionText = $"Server={server};Port={port};Username={username};Password={password};Database={database}";
            var connection = new NpgsqlConnection(connectionText);
            
                connection.Open();

            var cmd = new NpgsqlCommand("Insert Into tasks (discription, category, startdate, enddate) Values (@discription, @category, @startdate, @enddate)", connection);
            cmd.Parameters.AddWithValue("@discription", row.discription);
            cmd.Parameters.AddWithValue("@category", row.category);
            cmd.Parameters.AddWithValue("@startdate", row.startdate);
            cmd.Parameters.AddWithValue("@enddate", row.enddate);

            int result = cmd.ExecuteNonQuery();

            logger.Debug("End");

            return result;
        }
        #endregion
    }
}
