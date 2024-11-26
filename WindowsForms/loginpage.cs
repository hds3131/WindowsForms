using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsForms.Form2;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();//hi amy
        }


        
        


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void lin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form2 signUpForm = new Form2();
            signUpForm.Show();
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            {
            string username = textBox3.Text;
            string password = textBox4.Text;

            
            if (username == "admin" && password == "password")
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //hi
        }
    }
    }

    


    

