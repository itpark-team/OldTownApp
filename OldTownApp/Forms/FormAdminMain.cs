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
    public partial class FormAdminMain : Form
    {
        /// <summary>
        /// Загрузка и отображение клиентов в таблицу
        /// </summary>
        private void FillDataGridViewClients()
        {
            try
            {
                Global.SqlCommand.CommandText = "SELECT * FROM `users` WHERE `id_role`=3";
                MySqlDataReader dataReader = Global.SqlCommand.ExecuteReader();

                dataGridViewClients.Rows.Clear();

                while(dataReader.Read())
                {
                    string login = dataReader.GetString("login");
                    string password = dataReader.GetString("password");
                    string name = dataReader.GetString("name");
                    string phone = dataReader.GetString("phone");

                    dataGridViewClients.Rows.Add(login, password, name, phone);
                }

                dataReader.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки клиентов");
            }
        }

        /// <summary>
        /// Загрузка и отображение мастеров в таблицу
        /// </summary>
        private void FillDataGridViewMasters()
        {
            try
            {
                Global.SqlCommand.CommandText = "SELECT * FROM `users` WHERE `id_role`=2";
                MySqlDataReader dataReader = Global.SqlCommand.ExecuteReader();

                dataGridViewMasters.Rows.Clear();

                while (dataReader.Read())
                {
                    string login = dataReader.GetString("login");
                    string password = dataReader.GetString("password");
                    string name = dataReader.GetString("name");
                    string phone = dataReader.GetString("phone");

                    dataGridViewMasters.Rows.Add(login, password, name, phone);
                }
                dataReader.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки мастеров");
            }
        }

        /// <summary>
        /// Загрузка и отображение записей в таблицу
        /// </summary>
        private void FillDataGridViewRecords()
        {
            try
            {
                Global.SqlCommand.CommandText = @"SELECT uM.name AS master, uM.phone AS master_phone,
                    uC.name AS client, uC.phone AS client_phone,
                    s.name AS service, s.price, r.dt
                    FROM `records` AS r
                    JOIN `users` AS uM ON r.id_master = uM.id
                    JOIN `users` AS uC ON r.id_client = uC.id
                    JOIN `services` AS s ON r.id_service = s.id";

                MySqlDataReader dataReader = Global.SqlCommand.ExecuteReader();

                dataGridViewRecords.Rows.Clear();

                while (dataReader.Read())
                {
                    string master = dataReader.GetString("master");
                    string masterPhone = dataReader.GetString("master_phone");
                    string client = dataReader.GetString("client");
                    string clientPhone = dataReader.GetString("client_phone");
                    string service = dataReader.GetString("service");
                    string price = dataReader.GetString("price");
                    string dt = dataReader.GetString("dt");

                    dataGridViewRecords.Rows.Add(master, masterPhone, client, clientPhone, service, price, dt);
                }
                dataReader.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки записей");
            }
        }


        /// <summary>
        /// Загрузка и отображение услуг в таблицу
        /// </summary>
        private void FillDataGridViewServices()
        {
            try
            {
                Global.SqlCommand.CommandText = "SELECT * FROM `services`";
                MySqlDataReader dataReader = Global.SqlCommand.ExecuteReader();

                dataGridViewServices.Rows.Clear();

                while (dataReader.Read())
                {
                    int id = dataReader.GetInt32("id");
                    string name = dataReader.GetString("name");
                    decimal price = dataReader.GetDecimal("price");

                    dataGridViewServices.Rows.Add(id, name, price);
                }

                dataReader.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки услуг");
            }
        }

        public FormAdminMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик загрузки формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAdminMain_Load(object sender, EventArgs e)
        {
            FillDataGridViewClients();
            FillDataGridViewMasters();
            FillDataGridViewRecords();
            FillDataGridViewServices();
        }

        /// <summary>
        /// Обработчик кнопки добавления новой услуги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddService_Click(object sender, EventArgs e)
        {
            if(textBoxServiceName.Text==String.Empty)
            {
                MessageBox.Show("Ошибка заполните все поля");
                return;
            }

            string name = textBoxServiceName.Text;
            decimal price = numericUpDownServicePrice.Value;

            try
            {
                Global.SqlCommand.CommandText = $"INSERT INTO `services`(`name`,`price`) VALUES('{name}',{price})";
                Global.SqlCommand.ExecuteNonQuery();

                textBoxServiceName.Clear();
                numericUpDownServicePrice.Value = numericUpDownServicePrice.Minimum;
                textBoxServiceId.Clear();

                FillDataGridViewServices();
            }
            catch
            {
                MessageBox.Show("Ошибка добавления услуги");
            }
        }

        /// <summary>
        /// Обработчик кнопки удаления услуги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteService_Click(object sender, EventArgs e)
        {
            if(textBoxServiceId.Text == String.Empty)
            {
                MessageBox.Show("Ошибка, выберите услугу для удаления");
                return;
            }

            int id = int.Parse(textBoxServiceId.Text);

            try
            {
                Global.SqlCommand.CommandText = $"DELETE FROM `services` WHERE `id`={id}";
                Global.SqlCommand.ExecuteNonQuery();

                textBoxServiceId.Clear();
                textBoxServiceName.Clear();
                numericUpDownServicePrice.Value = numericUpDownServicePrice.Minimum;


                FillDataGridViewServices();
            }
            catch
            {
                MessageBox.Show("Ошибка удаления услуги");
            }
        }

        /// <summary>
        /// Обработчик выделения услуги в таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridViewServices.SelectedRows.Count!=0)
            {
                textBoxServiceId.Text = dataGridViewServices.SelectedRows[0].Cells[0].Value.ToString();

                textBoxServiceName.Text = dataGridViewServices.SelectedRows[0].Cells[1].Value.ToString();

                numericUpDownServicePrice.Value =decimal.Parse(dataGridViewServices.SelectedRows[0].Cells[2].Value.ToString());
            }
        }
        /// <summary>
        /// Обработчик кнопки обновления  услуги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdateService_Click(object sender, EventArgs e)
        {
            if (textBoxServiceId.Text == String.Empty)
            {
                MessageBox.Show("Ошибка, выберите услугу для обновления");
                return;
            }

            if (textBoxServiceName.Text == String.Empty)
            {
                MessageBox.Show("Ошибка заполните все поля");
                return;
            }

            int id = int.Parse(textBoxServiceId.Text);
            string name = textBoxServiceName.Text;
            decimal price = numericUpDownServicePrice.Value;

            string correctPrice = price.ToString().Replace(',', '.');

            try
            {
                Global.SqlCommand.CommandText = $"UPDATE `services` SET `name`='{name}',`price`={correctPrice} WHERE `id`={id}";
                Global.SqlCommand.ExecuteNonQuery();

                textBoxServiceId.Clear();
                textBoxServiceName.Clear();
                numericUpDownServicePrice.Value = numericUpDownServicePrice.Minimum;
                
                FillDataGridViewServices();
            }
            catch
            {
                MessageBox.Show("Ошибка обновления услуги");
            }
        }
    }
}
