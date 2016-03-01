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

namespace BookStoreDatabase
{
    public partial class MainWindow : Form
    {
        DataSet ds = new DataSet();
        SqlConnection cs = new SqlConnection("Data Source = DESKTOP-3JU4JU4; Initial Catalog = BookStore; Integrated Security = TRUE");
        SqlDataAdapter da = new SqlDataAdapter();

        BindingSource tblBooksBS = new BindingSource();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addRecordButton_Click(object sender, EventArgs e)
        {
            
            da.InsertCommand = new SqlCommand("INSERT INTO Books VALUES (@book_title, @pub_date, @pud_id, @language)", cs);
            da.InsertCommand.Parameters.Add("@book_title", SqlDbType.VarChar).Value = bookTitleBox.Text;
            da.InsertCommand.Parameters.Add("@pub_date", SqlDbType.Date).Value = pubDateBox.Text;
            da.InsertCommand.Parameters.Add("@pud_id", SqlDbType.Int).Value = publisherIDBox.Text;
            da.InsertCommand.Parameters.Add("@language", SqlDbType.VarChar).Value = languageBox.Text;

            cs.Open();
            da.InsertCommand.ExecuteNonQuery();
            cs.Close();
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new SqlCommand("SELECT * FROM Books", cs);
            da.Fill(ds);
            dg.DataSource = ds.Tables[0];

            tblBooksBS.DataSource = ds.Tables["Books"];
            bookTitleBox.DataBindings.Add(new Binding("Text", tblBooksBS, "book_title"));
            publisherIDBox.DataBindings.Add(new Binding("Text", tblBooksBS, "book_title"));
            bookTitleBox.DataBindings.Add(new Binding("Text", tblBooksBS, "book_title"));
            bookTitleBox.DataBindings.Add(new Binding("Text", tblBooksBS, "book_title"));
        }

   
    }
}