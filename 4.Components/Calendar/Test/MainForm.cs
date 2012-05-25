using System;
using System.Windows.Forms;

namespace TestCal
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ColDate1.ShowTime = false;
            ColDate2.ShowTime = true;
            dataGridView1.Rows.Add(DateTime.Now, DateTime.Now.AddYears(1).AddDays(10));
        }

        private void persianMonthView1_SelectedDateTimeChanged(object sender, EventArgs e)
        {
            if (persianMonthView1.SelectedDateTime == null) label3.Text = "تهی";
            else label3.Text = persianMonthView1.SelectedDateTime.Value.ToString();
        }

        private void persianMonthView2_SelectedDateTimeChanged(object sender, EventArgs e)
        {
            if (persianMonthView2.SelectedDateTime == null) label4.Text = "تهی";
            else label4.Text = persianMonthView2.SelectedDateTime.Value.ToString();
        }

        private void persianMonthView3_SelectedDateTimeChanged(object sender, EventArgs e)
        {
            if (persianMonthView3.SelectedDateTime == null) label5.Text = "تهی";
            else label5.Text = persianMonthView3.SelectedDateTime.Value.ToString();
        }

        private void persianDatePicker1_SelectedDateTimeChanged(object sender, EventArgs e)
        {
            if (persianDatePicker1.SelectedDateTime == null) label6.Text = "تهی";
            else label6.Text = persianDatePicker1.SelectedDateTime.Value.ToString();
        }

        private void persianDatePicker4_SelectedDateTimeChanged(object sender, EventArgs e)
        {
            if (persianDatePicker4.SelectedDateTime == null) label9.Text = "تهی";
            else label9.Text = persianDatePicker4.SelectedDateTime.Value.ToString();
        }

        private void persianDatePicker2_SelectedDateTimeChanged_1(object sender, EventArgs e)
        {
            if (persianDatePicker2.SelectedDateTime == null) label7.Text = "تهی";
            else label7.Text = persianDatePicker2.SelectedDateTime.Value.ToString();
        }

        private void persianDatePicker3_SelectedDateTimeChanged(object sender, EventArgs e)
        {
            if (persianDatePicker3.SelectedDateTime == null) label8.Text = "تهی";
            else label8.Text = persianDatePicker3.SelectedDateTime.Value.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObjects = new object[] { ColDate1 };
            //MessageBox.Show(Negar.PersianCalendar.Utilities.
            //    PersianDateConverter.ToPersianDate(DateTime.Now).ToWritten());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ColDate2.ShowTime = !ColDate2.ShowTime;
            dataGridView1.Invalidate();
        }

    }
}
