using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LabelAssignmentsWf
{
    // TODO: ja - share this across code base
    public enum LabelTypes
    {
        none = 0,
        small = 1,
        large = 2,
        both = 3,
        cable = 4,
        philips_small = 10,
        philips_large = 20,
        philips_packing = 50
    }

    public enum PrinterArea
    {
        smt = 20,
        in_process = 40,
        baseplate = 50,
        final = 100
    }

    public partial class LabelAssignment : Form
    {
        private int indexOfItemUnderMouseToDrag;
        private Rectangle dragBoxFromMouseDown;
        private Point screenOffset;

        private string ConnectionString = "Data Source=BUSHMASTER;Initial Catalog=ProductionManualLabels;Integrated Security=True";

        //private ImageList il;

        public LabelAssignment()
        {
            InitializeComponent();
        }
        
        private void GetLabelImages()
        {
            ImageList il = new ImageList();
            int count = 0;

            string sPath = @"\\nightadder\btwFiles\assignLabelImages";
            int nSubLen = sPath.Length;

            try
            {

                string[] fileEntries = Directory.GetFiles(sPath, "*.png");
                foreach (string fileName in fileEntries)
                {
                    il.Images.Add(Bitmap.FromFile(fileName));

                    string sLabelName = fileName.Substring(nSubLen + 1, (fileName.Length - 5) - nSubLen);

                    ListViewItem listViewItm = new ListViewItem();
                    listViewItm.Text = sLabelName;
                    listViewItm.ImageIndex = count++;
                    allLabelsListView.Items.Add(listViewItm);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            il.ImageSize = new Size(64, 64);

            allLabelsListView.LargeImageList = il;
            smtListView.LargeImageList = il;
            inProcessListView.LargeImageList = il;
            basePlateListView.LargeImageList = il;            
            finalListView.LargeImageList = il;
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetLabelImages();

            // TODO: ja - 1 > Read Labels from DB
           

            //       ja - 2 > Assign SMT

            //       ja - 3 > Assign In Process

            //       ja - 4 > Asingn BasePlate (Logic for 2 labels)

            //       ja - 5 > Assign Final

            //       ja - 6 > Fix number of labels mechiniszm 

            //       ja - 7 > Disable DD from non Final

            //       ja - 8 > Save to Database


        }




        private void foo()
        {
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
                    string sQty = myReader["Print_Qty"].ToString();

                    LabelTypes type = (LabelTypes)Enum.Parse(typeof(LabelTypes), sType);
                    PrinterArea area = (PrinterArea)Enum.Parse(typeof(PrinterArea), sLocation);

                    if (area == PrinterArea.smt)
                    {
                        smtListView.Items.Add(allLabelsListView.Items[0]);
                    }
                   
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


        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {

                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    // Create custom cursors for the drag-and-drop operation.
//                     try
//                     {
//                         MyNormalCursor = new Cursor("3dwarro.cur");
//                         MyNoDropCursor = new Cursor("3dwno.cur");
// 
//                     }
//                     catch
//                     {
//                         // An error occurred while attempting to load the cursors, so use
//                         // standard cursors.
//                         UseCustomCursorsCheck.Checked = false;
//                     }
//                     finally
//                     {

                        // The screenOffset is used to account for any desktop bands 
                        // that may be at the top or left side of the screen when 
                        // determining when to cancel the drag drop operation.
                        screenOffset = SystemInformation.WorkingArea.Location;

                        // Proceed with the drag-and-drop, passing in the list item.                    
                        DragDropEffects dropEffect = allLabelsListView.DoDragDrop(allLabelsListView.Items[indexOfItemUnderMouseToDrag], /*DragDropEffects.All |*/ DragDropEffects.Move);

                    // If the drag operation was a move then remove the item.
                     if (dropEffect == DragDropEffects.Move)
                     {
                         allLabelsListView.Items.RemoveAt(indexOfItemUnderMouseToDrag);
// 
//                         // Selects the previous item in the list as long as the list has an item.
//                         if (indexOfItemUnderMouseToDrag > 0)
//                            allLabelsListView.SelectedIndex = indexOfItemUnderMouseToDrag - 1;
// 
//                         else if (listView1.Items.Count > 0)
//                         // Selects the first item.
//                         listView1.SelectedIndex = 0;
                     }

//                         Dispose of the cursors since they are no longer needed.
//                                                     if (MyNormalCursor != null)
//                                                         MyNormalCursor.Dispose();
//                             
//                                                     if (MyNoDropCursor != null)
//                                                         MyNoDropCursor.Dispose();
                    //}
                }
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            Point p = allLabelsListView.PointToClient(new Point(e.X, e.Y));
            int index = allLabelsListView.GetItemAt(e.X, e.Y).Index;

            indexOfItemUnderMouseToDrag = index;// listView1.IndexFromPoint(e.X, e.Y);

            if (indexOfItemUnderMouseToDrag != ListBox.NoMatches)
            {

                // Remember the point where the mouse down occurred. The DragSize indicates
                // the size that the mouse can move before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)), dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;

        }

        private void listView2_DragDrop(object sender, DragEventArgs e)
        {
            AssignListItem(e, finalListView);
          
        }

        private void listView2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void smtListView_DragDrop(object sender, DragEventArgs e)
        {
            AssignListItem(e, smtListView);
        }

        private void smtListView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void InProcessListView_DragDrop(object sender, DragEventArgs e)
        {
            AssignListItem(e, inProcessListView);
        }

        private void InProcessListView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void AssignListItem(DragEventArgs e, ListView lView)
        {
            ListViewItem lvItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

            ListViewItem clonedLvItem = (ListViewItem)lvItem.Clone();

            lView.Items.Add(clonedLvItem);
        }

        private void basePlateListView_DragDrop(object sender, DragEventArgs e)
        {
            AssignListItem(e, basePlateListView);
        }

        private void basePlateListView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void basePlateListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point p = allLabelsListView.PointToClient(new Point(e.X, e.Y));
            int index = allLabelsListView.GetItemAt(e.X, e.Y).Index;

            basePlateListView.Items[index].Text = basePlateListView.Items[index].Text + " (1)";
        }

        private void goBtn_Click(object sender, EventArgs e)
        {
            foo();
        }
    }
}
