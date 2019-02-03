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
    public partial class FormRegister : Form
    {
        List<Role> roles;

        /// <summary>
        /// Загрузка ролей из базы данных
        /// </summary>
        private void LoadRoles()
        {
            roles = new List<Role>();

            Global.SqlCommand.CommandText = "SELECT * FROM roles";

            MySqlDataReader dataReader = Global.SqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                int id = dataReader.GetInt32("id");
                string name = dataReader.GetString("name");

                roles.Add(new Role()
                {
                    Id = id,
                    Name = name
                });
            }

            dataReader.Close();
            roles.RemoveAt(0);

            
        }

        /// <summary>
        /// Регистрация пользователя в БД
        /// </summary>
        /// <returns></returns>
        private bool RegisterUser()
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            string name = textBoxName.Text;
            string phone = maskedTextBoxPhone.Text;
            int idRole = ((Role)comboBoxRole.SelectedItem).Id;

            Global.SqlCommand.CommandText = $@"SELECT * FROM `users` WHERE
                  `login`='{login}' AND `password`='{password}'";

            MySqlDataReader dataReader = Global.SqlCommand.ExecuteReader();
            bool isUserExist = dataReader.HasRows;
            dataReader.Close();

            if (isUserExist == true)
            {
                MessageBox.Show("Ошибка. Такого пользователь в системе уже зарегистрирован! Измените логин и пароль");
                return false;
            }


            Global.SqlCommand.CommandText = $@"INSERT INTO `users`              (`login`,`password`,`name`,`phone`,`id_role`)
            VALUES ('{login}','{password}','{name}','{phone}',{idRole})";
            Global.SqlCommand.ExecuteNonQuery();

            MessageBox.Show("Вы успешно зарегистрированы! Вернитесь назад и войдите");

            return true;
        }


        public FormRegister()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработчик кнопки отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ОБработчик загрузки формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRegister_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRoles();

                comboBoxRole.DataSource = roles;
                comboBoxRole.DisplayMember = "Name";
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки ролей");
            }
        }

        /// <summary>
        /// ОБработчик кнопки регистрация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == String.Empty ||
                textBoxPassword.Text == String.Empty ||
                textBoxName.Text == String.Empty ||
                maskedTextBoxPhone.Text == String.Empty)
            {
                MessageBox.Show("Ошибка. Заполните все поля!");
                return;
            }
            try
            {
                if (RegisterUser())
                {
                    textBoxLogin.Clear();
                    textBoxPassword.Clear();
                    textBoxName.Clear();
                    maskedTextBoxPhone.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка регистрации пользователя");
            }
        }
    }
}
