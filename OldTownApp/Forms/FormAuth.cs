using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using MySql.Data.MySqlClient;

namespace OldTownApp
{
    public partial class FormAuth : Form
    {
        public FormAuth()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработка нажатия на кнопку авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            try
            {
                string login = textBoxLogin.Text;
                string password = textBoxPassword.Text;

                Global.SqlCommand.CommandText = $@"SELECT * FROM `users` WHERE
                  `login`='{login}' AND `password`='{password}'";

                MySqlDataReader dataReader = Global.SqlCommand.ExecuteReader();

                if (dataReader.HasRows == false)
                {
                    MessageBox.Show("Ошибка. Такого пользователя в системе нет!");
                    dataReader.Close();
                }
                else
                {
                    dataReader.Read();
                    Global.User = new User()
                    {
                        Id = dataReader.GetInt32("id"),
                        Login = dataReader.GetString("login"),
                        Password = dataReader.GetString("password"),
                        Name = dataReader.GetString("name"),
                        Phone = dataReader.GetString("phone"),
                        IdRole = dataReader.GetInt32("id_role")
                    };

                    dataReader.Close();

                    this.Hide();
                    textBoxLogin.Clear();
                    textBoxPassword.Clear();

                    if (Global.User.IdRole == 1)
                    {
                        new FormAdminMain().ShowDialog();
                    }
                    else if (Global.User.IdRole == 2)
                    {
                        new FormMasterMain().ShowDialog();
                    }
                    else if (Global.User.IdRole == 3)
                    {
                        new FormClientMain().ShowDialog();
                    }

                    this.Show();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка авторизации");
            }
        }
        /// <summary>
        /// Обработчик загрузки формы, установка соединения с базой данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAuth_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=127.0.0.1;Port=3306;Database=oldtown;User=root;Password=1234";
                Global.SqlConnection = new MySqlConnection(connectionString);
                Global.SqlConnection.Open();

                Global.SqlCommand = new MySqlCommand();
                Global.SqlCommand.Connection = Global.SqlConnection;
            }
            catch
            {
                MessageBox.Show("Ошибка соединения с БД");
            }
        }
        /// <summary>
        /// Обработчик нопки регистрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            new FormRegister().ShowDialog();
        }

        /// <summary>
        /// Обработчик кнопки выхода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
