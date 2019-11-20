﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BookCataloguing
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader Dr1;

        public Form3()
        {
            InitializeComponent();
        }
        public void bkld(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("auth1_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@authname", label1.Text);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("<<<INVALID SQL OPERATION>>> \n" + ex);

                }
                con.Close();

                dataGridView1.DataSource = DS.Tables[0];
                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
               




            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
            

          //  String b = label3.Text;
           // string syntax = "SELECT authimgurl FROM authors WHERE bid=" + b; 
           // cmd = new SqlCommand(syntax, con);


           // Dr1 = cmd.ExecuteReader();
          //  Dr1.Read();


           
           // label2.Text = Dr1[0].ToString();
           
            
            pictureBox1.ImageLocation = label2.Text;

        }




        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.authors' table. You can move, or remove it, as needed.
            this.authorsTableAdapter1.Fill(this.database1DataSet1.authors);
            // TODO: This line of code loads data into the 'database1DataSet.authors' table. You can move, or remove it, as needed.
            this.authorsTableAdapter.Fill(this.database1DataSet.authors);

        }

        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            string a = label2.Text;
            pictureBox1.ImageLocation = a;
            try
            {
                cmd = new SqlCommand("auth1_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@authname", label1.Text);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("<<<INVALID SQL OPERATION>>> \n" + ex);

                }
                con.Close();

                dataGridView1.DataSource = DS.Tables[0];
                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

               



            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }

        }
    }
}
