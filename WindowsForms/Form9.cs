﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;

namespace WindowsForms
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
            //takes to memeber dashboard
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
            this.Hide();
            //takes to events screen
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();  
            form11.Show();
            this.Hide();
            //takes to feedback screen 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Group Joinied!");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Group Joinied!");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Group Joinied!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Group Joinied!");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Group Joinied!");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Group Joinied!");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
