#region using
using System;
using System.Drawing;
using System.Windows.Forms;
using Negar.BarcodeManager;
#endregion

namespace BarcodeLibTest
{
    /// <summary>
    /// This form is a test form to show what all you can do with the Barcode Library.
    /// Only one call is actually needed to do the encoding and return the image of the 
    /// barcode but the rest is just flare and user interface ... stuff.
    /// </summary>
    public partial class TestApp : Form
    {
        #region Fields
        Barcode Barcode = new Barcode();
        #endregion

        #region Ctor
        public TestApp()
        {
            InitializeComponent();
        }
        #endregion

        #region EventHandlers

        #region TestApp_Load
        private void TestApp_Load(object sender, EventArgs e)
        {
            Bitmap temp = new Bitmap(1, 1);
            temp.SetPixel(0, 0, BackColor);
            barcode.Image = temp;
            cbEncodeType.SelectedIndex = 0;
            cbBarcodeAlign.SelectedIndex = 0;
            cbLabelLocation.SelectedIndex = 0;

            cbRotateFlip.DataSource = Enum.GetNames(typeof(RotateFlipType));

            int i = 0;
            foreach (object o in cbRotateFlip.Items)
            {
                if (o.ToString().Trim().ToLower() == "rotatenoneflipnone")
                    break;
                i++;
            }//foreach
            cbRotateFlip.SelectedIndex = i;

            //Show library version
            tslblLibraryVersion.Text = "Barcode Library Version: " + Barcode.Version;

            btnBackColor.BackColor = Barcode.BackColor;
            btnForeColor.BackColor = Barcode.ForeColor;
        }//Form1_Load

        #endregion

        #region btnEncode_Click
        private void btnEncode_Click(Object sender, EventArgs e)
        {
            errorProvider1.Clear();
            Int32 W = Convert.ToInt32(txtWidth.Text.Trim());
            Int32 H = Convert.ToInt32(txtHeight.Text.Trim());
            AlignmentPositions Align = AlignmentPositions.CENTER;

            //Barcode alignment
            switch (cbBarcodeAlign.SelectedItem.ToString().Trim().ToLower())
            {
                case "left": Align = AlignmentPositions.LEFT; break;
                case "right": Align = AlignmentPositions.RIGHT; break;
                default: Align = AlignmentPositions.CENTER; break;
            }//switch

            TYPE Type = TYPE.UNSPECIFIED;
            #region Set Type
            switch (cbEncodeType.SelectedItem.ToString().Trim())
            {
                case "UPC-A": Type = TYPE.UPCA; break;
                case "UPC-E": Type = TYPE.UPCE; break;
                case "UPC 2 Digit Ext.": Type = TYPE.UPC_SUPPLEMENTAL_2DIGIT; break;
                case "UPC 5 Digit Ext.": Type = TYPE.UPC_SUPPLEMENTAL_5DIGIT; break;
                case "EAN-13": Type = TYPE.EAN13; break;
                case "JAN-13": Type = TYPE.JAN13; break;
                case "EAN-8": Type = TYPE.EAN8; break;
                case "ITF-14": Type = TYPE.ITF14; break;
                case "Codabar": Type = TYPE.Codabar; break;
                case "PostNet": Type = TYPE.PostNet; break;
                case "Bookland/ISBN": Type = TYPE.BOOKLAND; break;
                case "Code 11": Type = TYPE.CODE11; break;
                case "Code 39": Type = TYPE.CODE39; break;
                case "Code 39 Extended": Type = TYPE.CODE39Extended; break;
                case "Code 93": Type = TYPE.CODE93; break;
                case "LOGMARS": Type = TYPE.LOGMARS; break;
                case "MSI": Type = TYPE.MSI_Mod10; break;
                case "Interleaved 2 of 5": Type = TYPE.Interleaved2of5; break;
                case "Standard 2 of 5": Type = TYPE.Standard2of5; break;
                case "Code 128": Type = TYPE.CODE128; break;
                case "Code 128-A": Type = TYPE.CODE128A; break;
                case "Code 128-B": Type = TYPE.CODE128B; break;
                case "Code 128-C": Type = TYPE.CODE128C; break;
                case "Telepen": Type = TYPE.TELEPEN; break;
                case "FIM": Type = TYPE.FIM; break;
                default: MessageBox.Show("Please specify the encoding type."); break;
            }//switch
            #endregion

            try
            {
                if (Type != TYPE.UNSPECIFIED)
                {
                    Barcode.IncludeLabel = chkGenerateLabel.Checked;

                    Barcode.Alignment = Align;
                    Barcode.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType),
                        cbRotateFlip.SelectedItem.ToString(), true);

                    //label alignment and position
                    switch (cbLabelLocation.SelectedItem.ToString().Trim().ToUpper())
                    {
                        case "BOTTOMLEFT": Barcode.LabelPosition = LabelPositions.BOTTOMLEFT; break;
                        case "BOTTOMRIGHT": Barcode.LabelPosition = LabelPositions.BOTTOMRIGHT; break;
                        case "TOPCENTER": Barcode.LabelPosition = LabelPositions.TOPCENTER; break;
                        case "TOPLEFT": Barcode.LabelPosition = LabelPositions.TOPLEFT; break;
                        case "TOPRIGHT": Barcode.LabelPosition = LabelPositions.TOPRIGHT; break;
                        default: Barcode.LabelPosition = LabelPositions.BOTTOMCENTER; break;
                    }//switch

                    //===== Encoding performed here =====
                    barcode.Image = Barcode.Encode(Type, txtData.Text.Trim(), btnForeColor.BackColor, btnBackColor.BackColor, W, H);
                    //===================================

                    //show the encoding time
                    lblEncodingTime.Text = "(" + Math.Round(Barcode.EncodingTime, 0, MidpointRounding.AwayFromZero) + "ms)";

                    txtEncoded.Text = Barcode.EncodedValue;

                    tsslEncodedType.Text = "Encoding Type: " + Barcode.EncodedType;
                }//if

                barcode.Width = barcode.Image.Width;
                barcode.Height = barcode.Image.Height;

                //reposition the barcode image to the middle
                barcode.Location = new Point((groupBox2.Location.X + groupBox2.Width / 2) - barcode.Width / 2,
                    (groupBox2.Location.Y +groupBox2.Height / 2) - barcode.Height / 2);
            }//try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//catch
        }//btnEncode_Click
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif";
            sfd.FilterIndex = 2;
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveTypes savetype = SaveTypes.UNSPECIFIED;
                switch (sfd.FilterIndex)
                {
                    case 1: /* BMP */  savetype = SaveTypes.BMP; break;
                    case 2: /* GIF */  savetype = SaveTypes.GIF; break;
                    case 3: /* JPG */  savetype = SaveTypes.JPG; break;
                    case 4: /* PNG */  savetype = SaveTypes.PNG; break;
                    case 5: /* TIFF */ savetype = SaveTypes.TIFF; break;
                    default: break;
                }//switch
                Barcode.SaveImage(sfd.FileName, savetype);
            }//if
        }//btnSave_Click
        #endregion

        #region splitContainer1_SplitterMoved
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            barcode.Location = new Point((this.groupBox2.Location.X + this.groupBox2.Width / 2) - barcode.Width / 2, (this.groupBox2.Location.Y + this.groupBox2.Height / 2) - barcode.Height / 2);
        }//splitContainer1_SplitterMoved
        #endregion

        #region btnForeColor_Click
        private void btnForeColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog cdialog = new ColorDialog())
            {
                cdialog.AnyColor = true;
                if (cdialog.ShowDialog() == DialogResult.OK)
                {
                    this.Barcode.ForeColor = cdialog.Color;
                    this.btnForeColor.BackColor = cdialog.Color;
                }//if
            }//using
        }//btnForeColor_Click
        #endregion

        #region btnBackColor_Click
        private void btnBackColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog cdialog = new ColorDialog())
            {
                cdialog.AnyColor = true;
                if (cdialog.ShowDialog() == DialogResult.OK)
                {
                    this.Barcode.BackColor = cdialog.Color;
                    this.btnBackColor.BackColor = cdialog.Color;
                }//if
            }//using
        }//btnBackColor_Click
        #endregion

        #region btnSaveXML_Click
        private void btnSaveXML_Click(object sender, EventArgs e)
        {
            btnEncode_Click(sender, e);

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "XML Files|*.xml";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName))
                    {
                        sw.Write(Barcode.XML);
                    }//using
                }//if
            }//using
        }//btnGetXML_Click
        #endregion

        #region btnLoadXML_Click
        private void btnLoadXML_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (BarcodeXML XML = new BarcodeXML())
                    {
                        XML.ReadXml(ofd.FileName);

                        //load image from xml
                        this.barcode.Width = XML.Barcode[0].ImageWidth;
                        this.barcode.Height = XML.Barcode[0].ImageHeight;
                        this.barcode.Image = Barcode.GetImageFromXML(XML);

                        //populate the screen
                        this.txtData.Text = XML.Barcode[0].RawData;
                        this.chkGenerateLabel.Checked = XML.Barcode[0].IncludeLabel;

                        switch (XML.Barcode[0].Type)
                        {
                            case "UCC12":
                            case "UPCA":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("UPC-A");
                                break;
                            case "UCC13":
                            case "EAN13":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("EAN-13");
                                break;
                            case "Interleaved2of5":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Interleaved 2 of 5");
                                break;
                            case "Industrial2of5":
                            case "Standard2of5":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Standard 2 of 5");
                                break;
                            case "LOGMARS":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("LOGMARS");
                                break;
                            case "CODE39":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Code 39");
                                break;
                            case "CODE39Extended":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Code 39 Extended");
                                break;
                            case "Codabar":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Codabar");
                                break;
                            case "PostNet":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("PostNet");
                                break;
                            case "ISBN":
                            case "BOOKLAND":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Bookland/ISBN");
                                break;
                            case "JAN13":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("JAN-13");
                                break;
                            case "UPC_SUPPLEMENTAL_2DIGIT":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("UPC 2 Digit Ext.");
                                break;
                            case "MSI_Mod10":
                            case "MSI_2Mod10":
                            case "MSI_Mod11":
                            case "MSI_Mod11_Mod10":
                            case "Modified_Plessey":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("MSI");
                                break;
                            case "UPC_SUPPLEMENTAL_5DIGIT":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("UPC 5 Digit Ext.");
                                break;
                            case "UPCE":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("UPC-E");
                                break;
                            case "EAN8":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("EAN-8");
                                break;
                            case "USD8":
                            case "CODE11":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Code 11");
                                break;
                            case "CODE128":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Code 128");
                                break;
                            case "CODE128A":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Code 128-A");
                                break;
                            case "CODE128B":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Code 128-B");
                                break;
                            case "CODE128C":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Code 128-C");
                                break;
                            case "ITF14":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("ITF-14");
                                break;
                            case "CODE93":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Code 93");
                                break;
                            case "FIM":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("FIM");
                                break;
                            default: throw new Exception("ELOADXML-1: Unsupported encoding type in XML.");
                        }//switch

                        this.txtEncoded.Text = XML.Barcode[0].EncodedValue;
                        this.btnForeColor.BackColor = ColorTranslator.FromHtml(XML.Barcode[0].Forecolor);
                        this.btnBackColor.BackColor = ColorTranslator.FromHtml(XML.Barcode[0].Backcolor); ;
                        this.txtWidth.Text = XML.Barcode[0].ImageWidth.ToString();
                        this.txtHeight.Text = XML.Barcode[0].ImageHeight.ToString();

                        //populate the local object
                        btnEncode_Click(sender, e);

                        //reposition the barcode image to the middle
                        barcode.Location = new Point((this.groupBox2.Location.X + this.groupBox2.Width / 2) - barcode.Width / 2, (this.groupBox2.Location.Y + this.groupBox2.Height / 2) - barcode.Height / 2);
                    }//using
                }//if
            }//using
        }
        #endregion

        #endregion

    }//class
}//namespace