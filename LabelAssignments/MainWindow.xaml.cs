using System;
using System.Windows;
using System.Data.SqlClient;

namespace LabelAssignments
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        string DBServerName = "BUSHMASTER";
        string DatabaseName = "ProductionManualLabels";
        string DatabaseUserID = "prodmanuser";
        string DatabasePW = "71m30u7";

        LabelCodeData MyData = new LabelCodeData();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = MyData;

            partNumberTB.Text = "MCAZGBRA";
            versionTB.Text = "0.02";            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AssignLabelTypesFromDataBase();
            GetSpecialLabelTypesFromDataBase();
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

                string sSql = "select * from label_Data where Part_Number = '" + partNumberTB.Text + "' and Part_Version = '" + versionTB.Text + "'";

                SqlCommand myCommand = new SqlCommand(sSql, TheConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    string sLocation = myReader["Location_Name"].ToString();
                    string sType = myReader["Label_Type_Name"].ToString();

//                     LabelTypes type = (LabelTypes)Enum.Parse(typeof(LabelTypes), sType);
//                     PrinterArea area = (PrinterArea)Enum.Parse(typeof(PrinterArea), sLocation);
// 
//                     if (area == ePrinterArea)
//                     {
//                         AssignedLabels.Add((int)type);
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

        private void GetSpecialLabelTypesFromDataBase()
        {
            string ConnectionString = GetConnectionString();

            SqlDataReader myReader = null;
            SqlConnection TheConnection = null;

            try
            {
                TheConnection = new SqlConnection(ConnectionString);

                TheConnection.Open();

                SqlCommand myCommand = new SqlCommand("select Condition_Name, Attribute_Value from part_flags where Part_Number = '" + partNumberTB.Text + "' and Part_Version = '" + versionTB.Text + "'", TheConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    string sCondition = myReader["Condition_Name"].ToString();
                    string sAttribute = myReader["Attribute_Value"].ToString();

                    // TODO: ja - store these in config?
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
    }
}
