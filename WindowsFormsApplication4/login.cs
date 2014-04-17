﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // checking if the inboxs are empty
            if (txbUserName.Text != "" & txbPassWord.Text != "") {
                //sql query
                string queryText = "SELECT Count(*) FROM Users " +
                                   "WHERE username = @Username AND password = @Password";
                // starting the sql connection - SqlConnection needs to be written
                using (SqlConnection cn = new SqlConnection("your_connection_string"))
                // passing the sql query - SqlCommand needs to be written
                using (SqlCommand cmd = new SqlCommand(queryText, cn)) {
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Username", txbUserName.Text); 
                    cmd.Parameters.AddWithValue("@Password", txbPassWord.Text);
                    int result = (int)cmd.ExecuteScalar();
                    // checking how many results are returned
                    if (result > 0)
                        MessageBox.Show("Loggen In!");
                    else
                        MessageBox.Show("User Not Found!");
                }
            } 



        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
