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
    public partial class FormClientMain : Form
    {
        List<Service> services;
        List<MasterSevice> masterSevices;
        List<User> masters;

        /// <summary>
        /// заполнение таблицы моих записей к мастерам
        /// </summary>
        private void FillDataGridViewRecords()
        {
            Global.SqlCommand.CommandText = $@"SELECT r.id, u.name  AS master, u.phone, s.name     AS service, s.price, r.dt
                    FROM `records` AS r
                    JOIN `users` AS u ON r.id_master=u.id
                    JOIN `services` AS s ON r.id_service=s.id
                    WHERE `id_client`={Global.User.Id}";
            MySqlDataReader dataReader = Global.SqlCommand.ExecuteReader();

            dataGridViewRecords.Rows.Clear();
            
            while(dataReader.Read())
            {
                int id = dataReader.GetInt32("id");
                string master = dataReader.GetString("master");
                string phone = dataReader.GetString("phone");
                string service = dataReader.GetString("service");
                decimal price = dataReader.GetDecimal("price");
                DateTime dt = dataReader.GetDateTime("dt");

                dataGridViewRecords.Rows.Add(id, master, phone, service, price, dt);
            }

            dataReader.Close();
        }

        /// <summary>
        /// Загрузка услуг
        /// </summary>
        private void LoadServices()
        {
            Global.SqlCommand.CommandText = "SELECT * FROM `services`";
            MySqlDataReader dataReader = Global.SqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                int id = dataReader.GetInt32("id");
                string name = dataReader.GetString("name");
                decimal price = dataReader.GetDecimal("price");

                services.Add(new Service()
                {
                    Id = id,
                    Name = name,
                    Price = price
                });
            }

            dataReader.Close();
        }

        /// <summary>
        /// Загрузка мастеров из базы данныъ
        /// </summary>
        private void LoadMasters()
        {
            Global.SqlCommand.CommandText = "SELECT * FROM `users` WHERE `id_role`=2";
            MySqlDataReader dataReader = Global.SqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                int id = dataReader.GetInt32("id");
                string login = dataReader.GetString("login");
                string password = dataReader.GetString("password");
                string name = dataReader.GetString("name");
                string phone = dataReader.GetString("phone");
                int idRole = dataReader.GetInt32("id_role");

                masters.Add(new User()
                {
                    Id = id,
                    Login = login,
                    Password = password,
                    Name = name,
                    Phone = phone,
                    IdRole = idRole
                });
            }

            dataReader.Close();
        }

        /// <summary>
        /// Загрузка услуг мастера
        /// </summary>
        private void LoadMasterSevices(int idSelectedMaster)
        {
            Global.SqlCommand.CommandText = $"SELECT * FROM `masters_services` WHERE `id_master`={idSelectedMaster}";
            MySqlDataReader dataReader = Global.SqlCommand.ExecuteReader();

            masterSevices = new List<MasterSevice>();

            while (dataReader.Read())
            {
                int id = dataReader.GetInt32("id");
                int idMaster = dataReader.GetInt32("id_master");
                int idService = dataReader.GetInt32("id_service");

                masterSevices.Add(new MasterSevice()
                {
                    Id = id,
                    IdMaster = idMaster,
                    IdService = idService
                });
            }

            dataReader.Close();
        }

        public FormClientMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// обработчик загрузки формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormClientMain_Load(object sender, EventArgs e)
        {
            labelUserName.Text = Global.User.Name;
            maskedTextBoxUserPhone.Text = Global.User.Phone;

            services = new List<Service>();
            masters = new List<User>();

            try
            {
                LoadServices();
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки услуг");
                return;
            }

            try
            {
                LoadMasters();

                comboBoxMasters.DataSource = masters;
                comboBoxMasters.DisplayMember = "Name";
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки мастеров");
                return;
            }

            comboBoxTimes.SelectedIndex = 0;

            try
            {
                FillDataGridViewRecords();
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки записей");
            }
        }
        
        /// <summary>
        /// Обработчки кнопки обновления телефона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdateUserPhone_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxUserPhone.Text == String.Empty)
            {
                MessageBox.Show("Заполните телефон");
                return;
            }

            try
            {
                string phone = maskedTextBoxUserPhone.Text;

                Global.SqlCommand.CommandText = $"UPDATE `users` SET `phone`='{phone}' WHERE `id`={Global.User.Id}";

                Global.SqlCommand.ExecuteNonQuery();

                MessageBox.Show("Телефон успешно обновлён");

                Global.User.Phone = phone;
            }
            catch
            {
                MessageBox.Show("Ошибка обновления телефона");
            }
        }

        /// <summary>
        /// обработчик выбора нового мастера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxMasters_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSelectedMaster = ((User)(comboBoxMasters.SelectedItem)).Id;

            try
            {
                LoadMasterSevices(idSelectedMaster);
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки услуг мастера");
                return;
            }

            List<Service> mServices = new List<Service>();

            for (int i = 0; i < services.Count; i++)
            {
                for (int j = 0; j < masterSevices.Count; j++)
                {
                    if (services[i].Id == masterSevices[j].IdService)
                    {
                        mServices.Add(services[i]);
                    }
                }
            }
            comboBoxMastesServices.DataSource = null;
            comboBoxMastesServices.DataSource = mServices;
            comboBoxMastesServices.DisplayMember = "Name";
        }

        /// <summary>
        /// обработчки выбора услуги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxMastesServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMastesServices.SelectedItem == null) { return; }

            decimal price = ((Service)comboBoxMastesServices.SelectedItem).Price;
            textBoxPrice.Text = price.ToString();
        }

        /// <summary>
        /// обработчик добавления записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddRecord_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = dateTimePickerDate.Value;
                string time = (string)comboBoxTimes.SelectedItem;
                //10:00->["10","0"]
                int hour = int.Parse(time.Split(':')[0]);
                DateTime dateTimeRecord = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);

                int idMaster = ((User)(comboBoxMasters.SelectedItem)).Id;
                int idService = ((Service)comboBoxMastesServices.SelectedItem).Id;
                int idClient = Global.User.Id;
                string dt = dateTimeRecord.ToString("yyyy-MM-dd H:mm:ss");

                Global.SqlCommand.CommandText = $"SELECT * FROM `records` WHERE `id_master`={idMaster} AND `dt`='{dt}'";

                MySqlDataReader dataReader = Global.SqlCommand.ExecuteReader();
                bool exist = dataReader.HasRows;
                dataReader.Close();

                if(exist)
                {
                    MessageBox.Show("Ошибка На это время у мастера уже есть запись");
                    return;
                }


                Global.SqlCommand.CommandText = $"INSERT INTO `records`(`id_master`,`id_client`,`id_service`,`dt`) VALUES({idMaster},{idClient},{idService},'{dt}')";
                Global.SqlCommand.ExecuteNonQuery();

                MessageBox.Show("Вы успешно записаны на услугу!");
            }
            catch
            {
                MessageBox.Show("Ошибка записи на услугу!");
                return;
            }

            try
            {
                FillDataGridViewRecords();
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки записей");
            }
        }
        /// <summary>
        /// обработчки отмены записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewRecords.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Ошибка!Выберите запись для отмены");
                    return;
                }
                int idRecord = int.Parse(dataGridViewRecords.SelectedRows[0].Cells[0].Value.ToString());

                Global.SqlCommand.CommandText = $"DELETE FROM `records` WHERE `id`={idRecord}";
                Global.SqlCommand.ExecuteNonQuery();

                MessageBox.Show("Запись успешно удалена");
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении записи");
                return;
            }

            try
            {
                FillDataGridViewRecords();
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки записей");
            }
        }

        /// <summary>
        /// обработчки кнопки выхода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExitProfile_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
