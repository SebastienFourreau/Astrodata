using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DatabaseNamespace;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Database singleton = Database.getInstance();
        public MySqlConnection dao;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Astro Data 0.1";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addSheet.Visible = false;
            dao = singleton.db;
        }

        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show( "Voulez vous vraiment quitter ? " , "Attention" , MessageBoxButtons .YesNo, MessageBoxIcon .Question);

            if(res == DialogResult.Yes)
                this.Close();
        }

        private void ajouterUneFicheToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Object sky_object = new Object();
            List<string> all_type = sky_object.getAllType();

            foreach (string type in all_type)
            {
                comboBox1.Items.Add(type);
            }

            comboBox1.SelectedIndex = 0;
            addSheet.Visible = true;
        }

        private void editerUneFicheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM test", dao);

            try
            {
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    string thisrow = "";
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                            thisrow += reader.GetValue(i).ToString() + "  |  ";
                    }

                    // Test get infos
                    MessageBox.Show(thisrow);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }       
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Work in progress."); 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void addSheet_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
