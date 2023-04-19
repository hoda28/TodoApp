using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace TodoApp
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string server = "localhost";
            string port = "5432";
            string username = "postgres";
            string password = "checkups";
            string database = "postgres";

            //接続文字列の作成
            string connectionText = $"Server={server};Port={port};Username={username};Password={password};Database={database}";
            using (var connection = new NpgsqlConnection(connectionText))
            {
                connection.Open();
            }

            Application.Run(new MainForm());


        }
    }


}
