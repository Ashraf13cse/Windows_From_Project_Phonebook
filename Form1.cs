using Microsoft.Data.SqlClient;
using Phnbk3.Entities;
using System.Data;
using System.Globalization;

namespace Phnbk3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            ContactContext cntContext = new ContactContext();
            Contact cnt = new Contact() { Name = txtName.Text, Mobile = txtMobile.Text, Address = this.txtAddress.Text }; //Age = int.Parse(TextBox3.Text)
            cntContext.Contacts.Add(cnt);
            cntContext.SaveChanges();
            string message = "Data Inserted Successfully";
            MessageBox.Show(message); 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtMobile.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
       
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private Button reloadButton = new Button();
        private Button submitButton = new Button();
        private void GetData(string selectCommand)
        {
            try
            {
                // Specify a connection string.
                // Replace <SQL Server> with the SQL Server for your Northwind sample database.
                // Replace "Integrated Security=True" with user login information if necessary.
                String connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=ContactDB;";

                ContactContext contactContext = new ContactContext();
                // Create a new data adapter based on the specified query.
               // dataAdapter = new SqlDataAdapter(selectCommand, contactContext);
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("server = MUNESH;Database=datastore;UID=sa;Password=123;");
            dataGridView1.DataSource = bindingSource1;
            GetData("select * from Contacts");
        }

       
    }

}
    
