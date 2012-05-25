// Copyright 2006 Herre Kuijpers - <herre@xs4all.nl>
//
// This source file(s) may be redistributed, altered and customized
// by any means PROVIDING the authors name and all copyright
// notices remain intact.
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED. USE IT AT YOUR OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//-----------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OutlookStyleControls;
using System.IO;

namespace OutlookGridApp
{
    public partial class Form1 : Form
    {
        #region private members
        // example of a bound object list
        private ArrayList ContactList;

        // specifies the current data view (bound/unbound, dataset)
        private string View;

        // remember the column index that was last sorted on
        private int prevColIndex = -1;

        // remember the direction the rows were last sorted on (ascending/descending)
        private ListSortDirection prevSortDirection = ListSortDirection.Ascending;
        #endregion private members

        #region Form setup
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // invoke the outlook style
            menuSkinOutlook_Click(sender, e);

            // setup our example list of business objects
            // in this case a list of contacts
            ContactList = new ArrayList();
            ContactList.Add(new ContactInfo(1, "Mark", DateTime.Now.Subtract(TimeSpan.FromDays(2)), "as the world turns", 0.54));
            ContactList.Add(new ContactInfo(2, "Mark", DateTime.Now.Subtract(TimeSpan.FromDays(8)), "GTST", 0.54));
            ContactList.Add(new ContactInfo(3, "Piet", DateTime.Now.Subtract(TimeSpan.FromDays(1)), "Day after", 0.35));
            ContactList.Add(new ContactInfo(4, "Herre", DateTime.Now.Subtract(TimeSpan.FromDays(17)), "Wodka lime", 0.9567));
            ContactList.Add(new ContactInfo(5, "Ronald", DateTime.Now.Subtract(TimeSpan.FromDays(42)), "I need some coffee", 0.54));
            ContactList.Add(new ContactInfo(6, "Piet", DateTime.Now.Subtract(TimeSpan.FromDays(167)), "Mr Bean", 0.653));

            // invoke inital filling, in this case unbound data
            menuUnboundContactList_Click(sender, e);

        }
        #endregion Form setup

        #region Grouping & Sorting!! - handle column clicks
        // this event is called when the user clicks on a cell
        // in this particular case we check to see if one of the column headers
        // was clicked. If so, the grid will be sorted based on the clicked column.
        // Note: this handler is not implemented optimally. It is merely used for demonstration purposes
        private void outlookGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 && e.ColumnIndex >= 0)
            {
                ListSortDirection direction = ListSortDirection.Ascending;
                if (e.ColumnIndex == prevColIndex) // reverse sort order
                    direction = prevSortDirection == ListSortDirection.Descending ? ListSortDirection.Ascending : ListSortDirection.Descending;

                // remember the column that was clicked and in which direction is ordered
                prevColIndex = e.ColumnIndex;
                prevSortDirection = direction;

                // set the column to be grouped
                outlookGrid1.GroupTemplate.Column = outlookGrid1.Columns[e.ColumnIndex];

                //sort the grid (based on the selected view)
                switch (View)
                {
                    case "BoundContactInfo":
                        outlookGrid1.Sort(new ContactInfoComparer(e.ColumnIndex, direction));
                        break;
                    case "BoundCategory":
                        outlookGrid1.Sort(new DataRowComparer(e.ColumnIndex, direction));
                        break;
                    case "BoundInvoices":
                        outlookGrid1.Sort(new DataRowComparer(e.ColumnIndex, direction));
                        break;
                    case "BoundQuarterly":
                        // this is an example of overriding the default behaviour of the
                        // Group object. Instead of using the DefaultGroup behavious, we
                        // use the AlphabeticGroup, so items are grouped together based on
                        // their first character:
                        // all items starting with A or a will be put in the same group.
                        IOutlookGridGroup prevGroup = outlookGrid1.GroupTemplate;

                        if (e.ColumnIndex == 0) // execption when user pressed the customer name column
                        {
                            // simply override the GroupTemplate to use before sorting
                            outlookGrid1.GroupTemplate = new OutlookGridAlphabeticGroup();
                            outlookGrid1.GroupTemplate.Collapsed = prevGroup.Collapsed;
                        }

                        // set the column to be grouped
                        // this must always be done before sorting
                        outlookGrid1.GroupTemplate.Column = outlookGrid1.Columns[e.ColumnIndex];

                        // execute the sort, arrange and group function
                        outlookGrid1.Sort(new DataRowComparer(e.ColumnIndex, direction));
                         
                        //after sorting, reset the GroupTemplate back to its default (if it was changed)
                        // this is needed just for this demo. We do not want the other
                        // columns to be grouped alphabetically.
                         outlookGrid1.GroupTemplate = prevGroup;
                         break;
                    default: //UnboundContactInfo
                        outlookGrid1.Sort(outlookGrid1.Columns[e.ColumnIndex], direction);
                        break;
                }
            }
        }
        #endregion Grouping & Sorting!! - handle column clicks

        #region menu handlers
        private void menuBoundContactList_Click(object sender, EventArgs e)
        {
            // basic example of object binding
            // not that the List to bind must inherit from IList.
            outlookGrid1.BindData(ContactList, null); 
            View = "BoundContactInfo";
        }

        private void menuUnboundContactList_Click(object sender, EventArgs e)
        {
            // this is an example of adding unbound data into the grid
            // while the grouping mechanism keeps functioning

            // first clear any previous bindings
            outlookGrid1.BindData(null, null); 

            // setup the column headers
            outlookGrid1.Columns.Add("column1", "Id");
            outlookGrid1.Columns.Add("column2", "First name");
            outlookGrid1.Columns.Add("column3", "Date");
            outlookGrid1.Columns.Add("column4", "Title");
            outlookGrid1.Columns.Add("column5", "Value");

            // example of unbound items
            foreach (ContactInfo obj in ContactList)
            {
                // notice that the outlookgrid only works with OutlookGridRow objects
                OutlookGridRow row = new OutlookGridRow();
                row.CreateCells(outlookGrid1, obj.Id, obj.Name, obj.Date, obj.Subject, obj.Concentration);
                outlookGrid1.Rows.Add(row);
            }

            //set our view for sorting
            View = "UnboundContactInfo";

        }

        private void menuBoundDatasetQuarterly_Click(object sender, EventArgs e)
        {
            // this is an example of binding a dataset to the OutlookGrid control.
            // in this case we load the dataset from an xml file for demo purposes
            // alternatively it can be created from a query on a database.
            try
            {
                DataSet set = new DataSet();
                set.ReadXml(Application.StartupPath + @"\Quarterly_orders.xml");
                outlookGrid1.BindData(set, "category");

                //example of overriding the databound column header texts
                outlookGrid1.Columns[0].HeaderText = "Customer name";
                outlookGrid1.Columns[1].HeaderText = "Company name";

                // example of hiding columns
                outlookGrid1.Columns[5].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            View = "BoundQuarterly";
 
        }

        private void menuBoundDatasetSales_Click(object sender, EventArgs e)
        {
            // another example of binding a dataset to the OutlookGrid control.
            // in this case we load the dataset from an xml file for demo purposes
            // alternatively it can be created from a query on a database.

            try
            {
                DataSet set = new DataSet();
                set.ReadXml(@"sales_by_category.xml");
                outlookGrid1.BindData(set, "category");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            View = "BoundCategory";

        }

        private void menuBoundDatasetInvoices_Click(object sender, EventArgs e)
        {
            // another example of binding a dataset to the OutlookGrid control.
            // in this case we load the dataset from an xml file for demo purposes
            // alternatively it can be created from a query on a database.

            try
            {
                DataSet set = new DataSet();
                
                set.ReadXml(@"invoices.xml");
                outlookGrid1.BindData(set, "invoice");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            View = "BoundInvoices";

        }

        private void menuCollapseAllGroups_Click(object sender, EventArgs e)
        {
            outlookGrid1.CollapseAll();
        }

        private void menuExpandAllGroups_Click(object sender, EventArgs e)
        {
            outlookGrid1.ExpandAll();
        }

        private void menuClearAllGroups_Click(object sender, EventArgs e)
        {
            outlookGrid1.ClearGroups();
        }

        private void menuSkinDefault_Click(object sender, EventArgs e)
        {
            this.outlookGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.outlookGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.outlookGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;

            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.outlookGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;

            this.outlookGrid1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.outlookGrid1.RowTemplate.Height = 23;
            this.outlookGrid1.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.outlookGrid1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.outlookGrid1.RowHeadersVisible = true;
            this.outlookGrid1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.outlookGrid1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            this.outlookGrid1.AllowUserToAddRows = true;
            this.outlookGrid1.AllowUserToDeleteRows = true;
            this.outlookGrid1.AllowUserToResizeRows = true;
            this.outlookGrid1.EditMode = DataGridViewEditMode.EditOnF2;
            this.outlookGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


        }

        private void menuSkinOutlook_Click(object sender, EventArgs e)
        {
            this.outlookGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.outlookGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.outlookGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;

            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.outlookGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;

            this.outlookGrid1.GridColor = System.Drawing.SystemColors.Control;
            this.outlookGrid1.RowTemplate.Height = 19;            
            this.outlookGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.outlookGrid1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.outlookGrid1.RowHeadersVisible = false;
            this.outlookGrid1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.outlookGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.outlookGrid1.AllowUserToAddRows = false;
            this.outlookGrid1.AllowUserToDeleteRows = false;
            this.outlookGrid1.AllowUserToResizeRows = false;
            this.outlookGrid1.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.outlookGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.outlookGrid1.ClearGroups(); // reset

        }
        #endregion menu handlers

        #region conversion helper function
        private void ConverCSVToXml()
        {
            TextReader file = File.OpenText(@"D:\Projects\cs2005\OutlookGridApp\Data\invoices.txt");
            DataTable table = new DataTable("invoice");

            string line = file.ReadLine();
            foreach (string s in line.Split('\t'))
                table.Columns.Add(s);

            line = file.ReadLine();
            while (line != null)
            {
                table.Rows.Add(line.Split('\t'));
                line = file.ReadLine();
            }

            file.Close();
            table.WriteXml(@"D:\Projects\cs2005\OutlookGridApp\Data\invoices.xml");
        }
        #endregion
    }

    #region Comparers - used to sort CustomerInfo objects and DataRows of a DataTable

    /// <summary>
    /// reusable custom DataRow comparer implementation, can be used to sort DataTables
    /// </summary>
    public class DataRowComparer : IComparer
    {
        ListSortDirection direction;
        int columnIndex;

        public DataRowComparer(int columnIndex, ListSortDirection direction)
        {
            this.columnIndex = columnIndex;
            this.direction = direction;
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {

            DataRow obj1 = (DataRow)x;
            DataRow obj2 = (DataRow)y;
            return string.Compare(obj1[columnIndex].ToString(), obj2[columnIndex].ToString()) * (direction == ListSortDirection.Ascending ? 1 : -1);
        }
        #endregion
    }

    // custom object comparer implementation
    public class ContactInfoComparer : IComparer
    {
        private int propertyIndex;
        ListSortDirection direction;

        public ContactInfoComparer(int propertyIndex, ListSortDirection direction)
        {
            this.propertyIndex = propertyIndex;
            this.direction = direction;
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {
            ContactInfo obj1 = (ContactInfo)x;
            ContactInfo obj2 = (ContactInfo)y;

            switch (propertyIndex)
            {
                case 1:
                    return CompareStrings(obj1.Name, obj2.Name);
                case 2:
                    return CompareDates(obj1.Date, obj2.Date);
                case 3:
                    return CompareStrings(obj1.Subject, obj2.Subject);
                case 4:
                    return CompareNumbers(obj1.Concentration, obj2.Concentration);
                default:
                    return CompareNumbers((double)obj1.Id, (double)obj2.Id);
            }
        }
        #endregion

        private int CompareStrings(string val1, string val2)
        {
            return string.Compare(val1, val2) * (direction == ListSortDirection.Ascending ? 1 : -1);
        }

        private int CompareDates(DateTime val1, DateTime val2)
        {
            if (val1 > val2) return (direction == ListSortDirection.Ascending ? 1 : -1);
            if (val1 < val2) return (direction == ListSortDirection.Ascending ? -1 : 1);
            return 0;
        }

        private int CompareNumbers(double val1, double val2)
        {
            if (val1 > val2) return (direction == ListSortDirection.Ascending ? 1 : -1);
            if (val1 < val2) return (direction == ListSortDirection.Ascending ? -1 : 1);
            return 0;
        }
    }
    #endregion Comparers

    #region ContactInfo - example business object implementation
    public class ContactInfo
    {
        public ContactInfo()
        {
        }
        public ContactInfo(int id, string name, DateTime date, string subject, double con)
        {
            this.id = id;
            this.name = name;
            this.date = date;
            this.subject = subject;
            this.concentration = con;
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        private double concentration;

        public double Concentration
        {
            get { return concentration; }
            set { concentration = value; }
        }

    }

    #endregion  
}