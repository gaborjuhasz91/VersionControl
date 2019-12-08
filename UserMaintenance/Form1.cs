using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();
            lblFullName.Text = Resource1.FullName; // label1
            btnAdd.Text = Resource1.Add; // button1
            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
            btnCsv.Text = Resource1.SaveFile;
            btnDel.Text = Resource1.DeleteName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtFullName.Text,
               
            };
            users.Add(u);
        }

        private void BtnCsv_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*";
            saveFileDialog1.Filter = filter;
            const string header = "Id,FullName";
            StreamWriter writer = null;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filter = saveFileDialog1.FileName;
                writer = new StreamWriter(filter);

                writer.WriteLine(header);
                foreach (User user in users)
                {
                    writer.WriteLine(user.ID +";"+user.FullName);
                }
                writer.Close();
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            users.RemoveAt(listUsers.SelectedIndex);
        }
    }
}
