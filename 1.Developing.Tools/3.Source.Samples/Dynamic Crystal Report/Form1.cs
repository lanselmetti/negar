using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace app5
{
    public partial class Form1 : Form
    {
        private CrystalReport1 _CurrentReport;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _CurrentReport = new CrystalReport1();

            const string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\db1.mdb";

            //Get Select query Strring and add parameters to the 
            //Crystal report.
            string query = CreateSelectQueryAndParameters();

            //if there is no item select,then exit from the method.
            if (!query.Contains("Column"))
            {
                MessageBox.Show("No selection to display!");
                return;
            }

            try
            {
                var adepter = new OleDbDataAdapter(query, connString);
                var Ds = new DataSet1();

                adepter.Fill(Ds, "Customer");
                _CurrentReport.SetDataSource(Ds);
                crystalReportViewer1.ReportSource = _CurrentReport;
            }
            catch (OleDbException oleEx)
            {
                MessageBox.Show(oleEx.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        /// <summary>
        /// This method is used to 
        /// 1. creat SELECT query according to the selcted column names and 
        /// 2. create parameters and assign values for that parameter that correspond to 
        ///    the crystal report.
        /// NOTE: This parameter is used to display Coulumn names of the Crystal Report
        /// according to the user selecteion.
        /// </summary>
        /// <returns></returns>
        private string CreateSelectQueryAndParameters()
        {
            ParameterFields paramFields;
            ParameterField paramField;
            ParameterDiscreteValue paramDiscreteValue;
            paramFields = new ParameterFields();
            String query = "SELECT ";
            int columnNo = 0;

            if (chbCode.Checked)
            {
                columnNo++;
                query = query.Insert(query.Length, "Code as Column" + columnNo);
                paramField = new ParameterField();
                paramField.Name = "col" + columnNo;
                paramDiscreteValue = new ParameterDiscreteValue();
                paramDiscreteValue.Value = "” Ê‰ 1";
                paramField.CurrentValues.Add(paramDiscreteValue);
                //Add the paramField to paramFields
                paramFields.Add(paramField);
            }
            if (chbFirstName.Checked)
            {
                columnNo++;
                if (query.Contains("Column"))
                {
                    query = query.Insert(query.Length, ", ");
                }
                query = query.Insert(query.Length, "FirstName as Column" + columnNo);


                paramField = new ParameterField();
                paramField.Name = "col" + columnNo;
                paramDiscreteValue = new ParameterDiscreteValue();
                paramDiscreteValue.Value = "First Name";
                paramField.CurrentValues.Add(paramDiscreteValue);
                //Add the paramField to paramFields
                paramFields.Add(paramField);
            }
            if (chbLastName.Checked)
            {
                columnNo++;
                if (query.Contains("Column"))
                {
                    query = query.Insert(query.Length, ", ");
                }
                query = query.Insert(query.Length, "LastName as Column" + columnNo);


                paramField = new ParameterField();
                paramField.Name = "col" + columnNo;
                paramDiscreteValue = new ParameterDiscreteValue();
                paramDiscreteValue.Value = "Last Name";
                paramField.CurrentValues.Add(paramDiscreteValue);
                //Add the paramField to paramFields
                paramFields.Add(paramField);
            }
            if (chbAddress.Checked)
            {
                columnNo++;
                if (query.Contains("Column"))
                {
                    query = query.Insert(query.Length, ", ");
                }
                query = query.Insert(query.Length, "Address as Column" + columnNo);


                paramField = new ParameterField();
                paramField.Name = "col" + columnNo;
                paramDiscreteValue = new ParameterDiscreteValue();
                paramDiscreteValue.Value = "Address";
                paramField.CurrentValues.Add(paramDiscreteValue);
                //Add the paramField to paramFields
                paramFields.Add(paramField);
            }
            if (chbPhone.Checked)
            {
                columnNo++;
                if (query.Contains("Column"))
                {
                    query = query.Insert(query.Length, ", ");
                }
                query = query.Insert(query.Length, "Phone as Column" + columnNo);


                paramField = new ParameterField();
                paramField.Name = "col" + columnNo;
                paramDiscreteValue = new ParameterDiscreteValue();
                paramDiscreteValue.Value = "Phone";
                paramField.CurrentValues.Add(paramDiscreteValue);
                //Add the paramField to paramFields
                paramFields.Add(paramField);
            }

            //if there is any remaining parameter, assign empty value for that 
            //parameter.
            for (int i = columnNo; i < 5; i++)
            {
                columnNo++;
                paramField = new ParameterField();
                paramField.Name = "col" + columnNo;
                paramDiscreteValue = new ParameterDiscreteValue();
                paramDiscreteValue.Value = "";
                paramField.CurrentValues.Add(paramDiscreteValue);
                //Add the paramField to paramFields
                paramFields.Add(paramField);
            }

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            query += " FROM Customer";
            return query;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var x = (FieldObject) _CurrentReport.Section3.ReportObjects[0];
            x.ApplyFont(new Font("Tahoma", 12, FontStyle.Bold));
            x.Width = 2000;
            crystalReportViewer1.ReportSource = _CurrentReport;
        }
    }
}