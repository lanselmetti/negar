using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AftabCalendar.Utilities;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private readonly DbMLDataContext _DbML;
        private DbIS _DbMLIS;

        public Form1()
        {
            InitializeComponent();
            _DbML = new DbMLDataContext(@"Data Source=.\Sqldeveloper;Initial Catalog=PatientsSystem;Persist Security Info=True;User ID=sa;Password=sudnhdvhk");
            _DbMLIS = new DbIS(@"Data Source=.\Sqldeveloper;Initial Catalog=ImagingSystem;Persist Security Info=True;User ID=sa;Password=sudnhdvhk");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<NamesBank> NameList = _DbML.NamesBanks.ToList();
            List<NamesBank> FNames = NameList.Where(Data => Data.IsFirstName).ToList();
            List<NamesBank> LNames = NameList.Where(Data => !Data.IsFirstName).ToList();
            PersianDate PPatIDDate = PersianDateConverter.ToPersianDate(DateTime.Now.AddYears(-5));
            Int32 j = 1;
            for (Int32 i = 1; i <= 50000; i++)
            {
                Random TheRand = new Random();
                PatList NewPat = new PatList();
                NewPat.PatientID = PPatIDDate.Year.ToString() + PPatIDDate.Month.ToString() +
                    PPatIDDate.Day.ToString() + (j).ToString();
                NewPat.IsEditing = false;
                NewPat.FirstName = FNames[TheRand.Next(0, FNames.Count - 1)].LocaleName;
                if (NewPat.FirstName.Length > 20) NewPat.FirstName = NewPat.FirstName.Substring(0, 19);
                NewPat.LastName = LNames[TheRand.Next(0, LNames.Count - 1)].LocaleName;
                if (NewPat.FirstName.Length > 30) NewPat.FirstName = NewPat.FirstName.Substring(0, 29);
                NewPat.IsMale = Convert.ToBoolean(TheRand.Next(-1, 1));
                NewPat.BirthDate = new DateTime(TheRand.Next(1920, 2009), TheRand.Next(1, 12), TheRand.Next(1, 28));
                Detail PatDetail = new Detail();
                PatDetail.IsMaried = Convert.ToBoolean(TheRand.Next(-1, 1));
                PatDetail.TelNo1 = "88637522";
                PatDetail.TelNo1 = "09124389435";
                PatDetail.Address = "آدرس آزمایشی بیمار - " + i;
                NewPat.Detail = PatDetail;
                _DbML.PatLists.InsertOnSubmit(NewPat);
                _DbML.SubmitChanges();
                j++;
                if (j == 100)
                {
                    PPatIDDate = PersianDateConverter.ToPersianDate(PersianDateConverter.ToGregorianDateTime(PPatIDDate).AddDays(1));
                    j = 1;
                }
            }
            //dataGridView1.DataSource = InsertList;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> InsertList = _DbML.PatLists.Select(Data => Data.ID).ToList();
            List<ServiceList> ServiceList = _DbMLIS.ServiceLists.ToList();
            DateTime PPatIDDate = DateTime.Now.AddYears(-5);
            Int32 j = 1;
            foreach (Int32 PatientListID in InsertList)
            {
                Random I = new Random();
                for (int i = 0; i <= I.Next(1, 3); i++)
                {
                    Random TheRand = new Random();
                    RefList NewRef = new RefList();
                    NewRef.PatientIX = PatientListID;
                    NewRef.IsEditing = false;
                    PPatIDDate = PPatIDDate.AddMinutes(10);
                    NewRef.RegisterDate = PPatIDDate.AddMinutes(10);
                    NewRef.PrescriptionDate = PPatIDDate.AddDays(TheRand.Next(-10, -1));
                    NewRef.Weight = (Byte)TheRand.Next(50, 120);
                    NewRef.AdmitterIX = (Int16)TheRand.Next(1, 3);
                    NewRef.ReferPhysicianIX = (Int16)TheRand.Next(1, 1544);
                    NewRef.Ins1IX = (Int16)TheRand.Next(1, 6);
                    NewRef.Ins1Validation = NewRef.RegisterDate.AddDays(TheRand.Next(30, 90));
                    NewRef.Ins1Num1 = TheRand.Next(1, 100000).ToString();

                    _DbMLIS.RefLists.InsertOnSubmit(NewRef);
                    _DbMLIS.SubmitChanges();

                    #region Insert Services
                    Random J = new Random();
                    Int32 Limit1 = J.Next(1, 4);
                    for (Int32 k = 0; k < Limit1; k++)
                    {
                        RefService NewRefService = new RefService();
                        NewRefService.ServiceIX = ServiceList[J.Next(1, ServiceList.Count)].ID;
                        NewRefService.IsActive = true;
                        NewRefService.ReferralIX = NewRef.ID;
                        NewRefService.Quantity = (Byte)J.Next(1, 2);
                        NewRefService.IsIns1Cover = Convert.ToBoolean(J.Next(-1, 1));
                        if (NewRefService.IsIns1Cover.Value)
                        {
                            NewRefService.Ins1Price = J.Next(10000, 1000000);
                            NewRefService.Ins1PartPrice = NewRefService.Ins1Price * 70 / 100;
                            NewRefService.PatientPayablePrice = Math.Abs(NewRefService.Ins1Price.Value - NewRefService.Ins1PartPrice.Value);
                        }
                        else
                        {
                            NewRefService.Ins1Price = 0;
                            NewRefService.Ins1PartPrice = 0;
                            NewRefService.PatientPayablePrice = J.Next(10000, 1000000);
                        }
                        NewRefService.IsIns2Cover = false;
                        NewRefService.Ins2Price = 0;
                        NewRefService.Ins2PartPrice = 0;
                        NewRef.RefServices.Add(NewRefService);
                    }
                    #endregion

                    #region Insert Document
                    RefDocument NewRefDoc = new RefDocument();
                    NewRefDoc.Date = NewRef.RegisterDate;
                    NewRefDoc.Title = "تیتر آزمایشی " + NewRefDoc.Date.ToShortDateString();
                    NewRefDoc.RefIX = NewRef.ID;
                    NewRefDoc.DocData = File.ReadAllBytes("TestDoc.Zip");

                    NewRef.RefDocuments.Add(NewRefDoc);
                    #endregion

                    j++;
                    if (j == 100)
                    {
                        PPatIDDate = PPatIDDate.AddDays(1);
                        j = 1;
                    }
                    _DbMLIS.SubmitChanges();
                }
            }
        }
    }
}
