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
    public partial class FormMasterMain : Form
    {
        List<Service> services;
        List<MasterSevice> masterSevices;
        
        /// <summary>
        /// загзузка и отображение списка записей
        /// </summary>
        private void FillDataGridViewRecords()
        {
            Global.SqlCommand.CommandText = $@"SELECT r.id, u.name AS client, u.phone, s.name AS service, s.price, r.dt
                FROM `records` AS r
                JOIN `users` AS u ON r.id_client=u.id
                JOIN `services` AS s ON r.id_service=s.id
                WHERE `id_master`={Global.User.Id}";
            MySqlDataReader dataReader = Global.SqlCommand.ExecuteReader();

            dataGridViewRecords.Rows.Clear();

            while (dataReader.Read())
            {
                int id = dataReader.GetInt32("id");
                string client = dataReader.GetString("client");
                string phone = dataReader.GetString("phone");
                string service = dataReader.GetString("service");
                decimal price = dataReader.GetDecimal("price");
                DateTime dt = dataReader.GetDateTime("dt");

                dataGridViewRecords.Rows.Add(id, client, phone, service, price, dt);
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
        /// загрузка услуг мастера
        /// </summary>
        /// 
        private void LoadMasterServices()
        {
            Global.SqlCommand.CommandText = $"SELECT * FROM `masters_services` WHERE `id_master`={Global.User.Id}";
            MySqlDataReader dataReader = Global.SqlCommand.ExecuteReader();

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


        public FormMasterMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// обработчик загрузки формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMasterMain_Load(object sender, EventArgs e)
        {
            labelUserName.Text = Global.User.Name;
            maskedTextBoxUserPhone.Text = Global.User.Phone;

            services = new List<Service>();
            masterSevices = new List<MasterSevice>();

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
                LoadMasterServices();
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки услуг мастера");
                return;
            }

            for (int i=0;i<services.Count;i++)
            {
                bool exist = false;
                for (int j = 0; j < masterSevices.Count; j++)
                {
                    if(services[i].Id==masterSevices[j].IdService)
                    {
                        exist = true;
                        break;
                    }
                }
                checkedListBoxMasterServices.Items.Add(services[i],exist);
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
        /// Обработчик обновления телефона пользователя
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
        /// обработчки обновления услуг мастера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdateMasterServices_Click(object sender, EventArgs e)
        {
            if(checkedListBoxMasterServices.CheckedItems.Count==0)
            {
                MessageBox.Show("Ошибка! Выберите услуги мастера!");
                return;
            }

            try
            {
                Global.SqlCommand.CommandText = $"DELETE FROM `masters_services` WHERE `id_master`={Global.User.Id}";
                Global.SqlCommand.ExecuteNonQuery();

                for (int i = 0; i < checkedListBoxMasterServices.CheckedItems.Count; i++)
                {
                    int idMaster = Global.User.Id;
                    int idService = ((Service)checkedListBoxMasterServices.CheckedItems[i]).Id;

                    Global.SqlCommand.CommandText = $"INSERT INTO `masters_services`(`id_master`,`id_service`) VALUES({idMaster},{idService})";
                    Global.SqlCommand.ExecuteNonQuery();
                }


                MessageBox.Show("Услуги успешно обновлены!");
            }
            catch
            {
                MessageBox.Show("Ошибка обновления услуг");
            }
        }

        /// <summary>
        /// обработчик кнопки выхода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExitProfile_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
