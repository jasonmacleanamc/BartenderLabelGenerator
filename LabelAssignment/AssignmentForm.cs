using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabelAssignment
{
    public enum PrinterArea
    {
        smt = 20,
        in_process = 40,
        baseplate = 50,
        final = 100
    }

    public enum LabelTypes
    {
        none = 0,
        small = 1,
        large = 2,
        both = 3,
        cable = 4,
        type_a = 5,
        aspinv = 6,
        philips_small = 10,
        philips_large = 20,
        philips_packing = 50
    }
;
    public partial class AssignmentForm : Form
    {
        string DBServerName = "BUSHMASTER";
        string DatabaseName = "ProductionManualLabels";
        string DatabaseUserID = "prodmanuser";
        string DatabasePW = "71m30u7";

        public AssignmentForm()
        {
            InitializeComponent();

            partNumberTB.Text = "4598-001-96621C";
            versionUD.Text = "0.02";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillLocations();
            FillLabelTypes();
        }

        public void FillLocations()
        {
            using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand("select location_name from label_Location", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    locationCB.Items.Add(sqlReader["location_name"].ToString());
                }

                sqlReader.Close();
            }
        }

        private void FillLabelTypes()
        {
            using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand sqlCmd = new SqlCommand("select label_type_name from label_type", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    labelTypeCB.Items.Add(sqlReader["label_type_name"].ToString());
                }

                sqlReader.Close();
            }
        }

        public string GetConnectionString()
        {
            string ConnectionString = "user id=" + DatabaseUserID + ";password=" + DatabasePW + ";Data Source=" + DBServerName + ";Initial Catalog=" + DatabaseName + ";Integrated Security=True";

            return ConnectionString;
        }

        private void AssignLabelTypesFromDataBase()
        {
            string ConnectionString = GetConnectionString();

            SqlDataReader myReader = null;
            SqlConnection TheConnection = null;

            try
            {
                TheConnection = new SqlConnection(ConnectionString);

                TheConnection.Open();

                // ja - get the label information from the database view
                SqlCommand myCommand = new SqlCommand("select * from label_Data where Part_Number = '" + partNumberTB.Text + "' and Part_Version = '" + versionUD.Text + "'", TheConnection);
                myReader = myCommand.ExecuteReader();

                // ja - loop through all of the assigned label types
                while (myReader.Read())
                {
                    // ja - get the information from the database
                    string sLocation = myReader["Location_Name"].ToString();
                    string sType = myReader["Label_Type_Name"].ToString();
                    string sQty = myReader["Print_Qty"].ToString();
                    string sCustomerName = myReader["Customer_Name"].ToString();

                    LabelTypes type = (LabelTypes)Enum.Parse(typeof(LabelTypes), sType);
                    PrinterArea area = (PrinterArea)Enum.Parse(typeof(PrinterArea), sLocation);

                    // ja - if the printer area matches the passed in area (Physical Printer) add to queue
//                     if (area == ePrinterArea)
//                     {
//                      
//                     }
                }

                myReader.Close();
                TheConnection.Close();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                myReader.Close();
                TheConnection.Close();
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            string ConnectionString = GetConnectionString();
            string select = "select * from label_Data where Part_Number = '" + partNumberTB.Text + "' and Part_Version = '" + versionUD.Text + "'";
            
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, ConnectionString); 

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            string _sPartNumber = "This is my string12345!";

            string n = _sPartNumber.TrimEnd(_sPartNumber[_sPartNumber.Length - 1]);

            int y = 0;
        }
    }
}
