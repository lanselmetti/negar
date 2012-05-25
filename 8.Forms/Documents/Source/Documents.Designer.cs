namespace Sepehr.Forms.Documents
{
    partial class frmDocuments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocuments));
            this.ribbonBarOrders = new DevComponents.DotNetBar.Bar();
            this.btnClose = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrevPatient = new DevComponents.DotNetBar.ButtonItem();
            this.iContainerPatientData = new DevComponents.DotNetBar.ItemContainer();
            this.lblPatientID = new DevComponents.DotNetBar.LabelItem();
            this.lblRefID = new DevComponents.DotNetBar.LabelItem();
            this.lblPatientFullName = new DevComponents.DotNetBar.LabelItem();
            this.lblRefDate = new DevComponents.DotNetBar.LabelItem();
            this.btnNextPatient = new DevComponents.DotNetBar.ButtonItem();
            this.iContainerRefManager = new DevComponents.DotNetBar.ItemContainer();
            this.btnNextReferral = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrevReferral = new DevComponents.DotNetBar.ButtonItem();
            this.btnNewDoc = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrintDefaultDoc = new DevComponents.DotNetBar.ButtonItem();
            this.iContainerCaptureManager = new DevComponents.DotNetBar.ItemContainer();
            this.btnClipAndGrab = new DevComponents.DotNetBar.ButtonItem();
            this.iContainerCapture = new DevComponents.DotNetBar.ItemContainer();
            this.btnGrabber = new DevComponents.DotNetBar.ButtonItem();
            this.btnClip = new DevComponents.DotNetBar.ButtonItem();
            this.iContainerDataFile = new DevComponents.DotNetBar.ItemContainer();
            this.btnShowFiles = new DevComponents.DotNetBar.ButtonItem();
            this.btnBurnCD = new DevComponents.DotNetBar.ButtonItem();
            this.cmsDocManagment = new DevComponents.DotNetBar.ContextMenuBar();
            this.cmsdgvDocuments = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditDoc = new DevComponents.DotNetBar.ButtonItem();
            this.btnRemove = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditInWord = new DevComponents.DotNetBar.ButtonItem();
            this.btnPreView = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrintDoc = new DevComponents.DotNetBar.ButtonItem();
            this.dgvDocuments = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColRowNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDocTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTypist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormToolTip = new DevComponents.DotNetBar.SuperTooltip();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvRefServices = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExpert = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColPhysician = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonBarOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmsDocManagment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefServices)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonBarOrders
            // 
            this.ribbonBarOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonBarOrders.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonBarOrders.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnClose,
            this.btnPrevPatient,
            this.iContainerPatientData,
            this.btnNextPatient,
            this.iContainerRefManager,
            this.btnNewDoc,
            this.btnPrintDefaultDoc,
            this.iContainerCaptureManager});
            this.ribbonBarOrders.Location = new System.Drawing.Point(0, 0);
            this.ribbonBarOrders.Name = "ribbonBarOrders";
            this.ribbonBarOrders.Size = new System.Drawing.Size(792, 81);
            this.ribbonBarOrders.Stretch = true;
            this.ribbonBarOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBarOrders.TabIndex = 1;
            this.ribbonBarOrders.TabStop = false;
            this.ribbonBarOrders.Text = "نوار دسترسی";
            // 
            // btnClose
            // 
            this.btnClose.BeginGroup = true;
            this.btnClose.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnClose.Image = global::Sepehr.Forms.Documents.Properties.Resources.Cancel;
            this.btnClose.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnClose.ImagePaddingHorizontal = 12;
            this.btnClose.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnClose.Name = "btnClose";
            this.btnClose.RibbonWordWrap = false;
            this.btnClose.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.AltF4);
            this.btnClose.SubItemsExpandWidth = 20;
            this.btnClose.Text = "خروج\r\n(Esc)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrevPatient
            // 
            this.btnPrevPatient.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrevPatient.FontBold = true;
            this.btnPrevPatient.ForeColor = System.Drawing.Color.Green;
            this.btnPrevPatient.Image = global::Sepehr.Forms.Documents.Properties.Resources.RightLarge;
            this.btnPrevPatient.ImagePaddingHorizontal = 8;
            this.btnPrevPatient.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPrevPatient.Name = "btnPrevPatient";
            this.btnPrevPatient.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F11);
            this.btnPrevPatient.SubItemsExpandWidth = 14;
            this.btnPrevPatient.Text = "بیمار\r\nقبلی";
            this.btnPrevPatient.Click += new System.EventHandler(this.btnPrevPatient_Click);
            // 
            // iContainerPatientData
            // 
            this.iContainerPatientData.ItemSpacing = 0;
            this.iContainerPatientData.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerPatientData.MinimumSize = new System.Drawing.Size(180, 0);
            this.iContainerPatientData.Name = "iContainerPatientData";
            this.iContainerPatientData.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblPatientID,
            this.lblRefID,
            this.lblPatientFullName,
            this.lblRefDate});
            this.iContainerPatientData.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // lblPatientID
            // 
            this.lblPatientID.BackColor = System.Drawing.Color.White;
            this.lblPatientID.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.lblPatientID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.PaddingBottom = 1;
            this.lblPatientID.PaddingTop = 1;
            this.lblPatientID.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblRefID
            // 
            this.lblRefID.BackColor = System.Drawing.Color.White;
            this.lblRefID.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.lblRefID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefID.Name = "lblRefID";
            this.lblRefID.PaddingBottom = 1;
            this.lblRefID.PaddingTop = 1;
            this.lblRefID.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblPatientFullName
            // 
            this.lblPatientFullName.BackColor = System.Drawing.Color.White;
            this.lblPatientFullName.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.lblPatientFullName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientFullName.Name = "lblPatientFullName";
            this.lblPatientFullName.PaddingBottom = 1;
            this.lblPatientFullName.PaddingTop = 1;
            this.lblPatientFullName.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lblPatientFullName.Width = 160;
            // 
            // lblRefDate
            // 
            this.lblRefDate.BackColor = System.Drawing.Color.White;
            this.lblRefDate.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.lblRefDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefDate.Name = "lblRefDate";
            this.lblRefDate.PaddingBottom = 1;
            this.lblRefDate.PaddingTop = 1;
            this.lblRefDate.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnNextPatient
            // 
            this.btnNextPatient.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNextPatient.FontBold = true;
            this.btnNextPatient.ForeColor = System.Drawing.Color.Green;
            this.btnNextPatient.Image = global::Sepehr.Forms.Documents.Properties.Resources.LeftLarge;
            this.btnNextPatient.ImagePaddingHorizontal = 8;
            this.btnNextPatient.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNextPatient.Name = "btnNextPatient";
            this.btnNextPatient.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.btnNextPatient.SubItemsExpandWidth = 14;
            this.btnNextPatient.Text = "بیمار\r\nبعدی";
            this.btnNextPatient.Click += new System.EventHandler(this.btnNextPatient_Click);
            // 
            // iContainerRefManager
            // 
            this.iContainerRefManager.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.iContainerRefManager.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerRefManager.Name = "iContainerRefManager";
            this.iContainerRefManager.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNextReferral,
            this.btnPrevReferral});
            this.iContainerRefManager.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // btnNextReferral
            // 
            this.btnNextReferral.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNextReferral.FontBold = true;
            this.btnNextReferral.Image = global::Sepehr.Forms.Documents.Properties.Resources.UpLarge;
            this.btnNextReferral.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnNextReferral.ImagePaddingHorizontal = 15;
            this.btnNextReferral.ImagePaddingVertical = 10;
            this.btnNextReferral.Name = "btnNextReferral";
            this.btnNextReferral.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F10);
            this.btnNextReferral.SubItemsExpandWidth = 14;
            this.btnNextReferral.Text = "مراجعه\r\nبعدی";
            this.btnNextReferral.Click += new System.EventHandler(this.btnNextRef_Click);
            // 
            // btnPrevReferral
            // 
            this.btnPrevReferral.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrevReferral.FontBold = true;
            this.btnPrevReferral.Image = global::Sepehr.Forms.Documents.Properties.Resources.DownLarge;
            this.btnPrevReferral.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnPrevReferral.ImagePaddingHorizontal = 15;
            this.btnPrevReferral.ImagePaddingVertical = 10;
            this.btnPrevReferral.Name = "btnPrevReferral";
            this.btnPrevReferral.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F9);
            this.btnPrevReferral.SubItemsExpandWidth = 14;
            this.btnPrevReferral.Text = "مراجعه\r\nقبلی";
            this.btnPrevReferral.Click += new System.EventHandler(this.btnPrevRef_Click);
            // 
            // btnNewDoc
            // 
            this.btnNewDoc.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNewDoc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNewDoc.FontBold = true;
            this.btnNewDoc.Image = global::Sepehr.Forms.Documents.Properties.Resources.DocumentAdd;
            this.btnNewDoc.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.btnNewDoc.ImagePaddingHorizontal = 8;
            this.btnNewDoc.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNewDoc.Name = "btnNewDoc";
            this.btnNewDoc.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnNewDoc.Text = "مدرك جدید\r\n(F4)";
            this.btnNewDoc.Click += new System.EventHandler(this.btnNewDoc_Click);
            // 
            // btnPrintDefaultDoc
            // 
            this.btnPrintDefaultDoc.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrintDefaultDoc.FontBold = true;
            this.btnPrintDefaultDoc.Image = global::Sepehr.Forms.Documents.Properties.Resources.PrintGrid;
            this.btnPrintDefaultDoc.ImagePaddingHorizontal = 6;
            this.btnPrintDefaultDoc.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPrintDefaultDoc.Name = "btnPrintDefaultDoc";
            this.btnPrintDefaultDoc.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.btnPrintDefaultDoc.Text = "چاپ مدرك\r\nپیشفرض";
            this.btnPrintDefaultDoc.Click += new System.EventHandler(this.btnPrintDefaultDoc_Click);
            // 
            // iContainerCaptureManager
            // 
            this.iContainerCaptureManager.BeginGroup = true;
            this.iContainerCaptureManager.Name = "iContainerCaptureManager";
            this.iContainerCaptureManager.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnClipAndGrab,
            this.iContainerCapture,
            this.iContainerDataFile});
            // 
            // btnClipAndGrab
            // 
            this.btnClipAndGrab.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnClipAndGrab.FontBold = true;
            this.btnClipAndGrab.Image = global::Sepehr.Forms.Documents.Properties.Resources.PatRef;
            this.btnClipAndGrab.ImagePaddingHorizontal = 12;
            this.btnClipAndGrab.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnClipAndGrab.Name = "btnClipAndGrab";
            this.btnClipAndGrab.Text = "دریافت\r\nویدئو و\r\nعكس";
            this.btnClipAndGrab.Click += new System.EventHandler(this.btnClipAndGrab_Click);
            // 
            // iContainerCapture
            // 
            this.iContainerCapture.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerCapture.Name = "iContainerCapture";
            this.iContainerCapture.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnGrabber,
            this.btnClip});
            // 
            // btnGrabber
            // 
            this.btnGrabber.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnGrabber.FontBold = true;
            this.btnGrabber.Image = global::Sepehr.Forms.Documents.Properties.Resources.PrintPreview;
            this.btnGrabber.ImagePaddingHorizontal = 8;
            this.btnGrabber.Name = "btnGrabber";
            this.btnGrabber.Text = "ضبط تصویر";
            this.btnGrabber.Click += new System.EventHandler(this.btnGrabber_Click);
            // 
            // btnClip
            // 
            this.btnClip.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnClip.FontBold = true;
            this.btnClip.Image = global::Sepehr.Forms.Documents.Properties.Resources.Movie;
            this.btnClip.ImagePaddingHorizontal = 8;
            this.btnClip.Name = "btnClip";
            this.btnClip.Text = "ضبط  ویدئو";
            this.btnClip.Click += new System.EventHandler(this.btnClip_Click);
            // 
            // iContainerDataFile
            // 
            this.iContainerDataFile.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.iContainerDataFile.Name = "iContainerDataFile";
            this.iContainerDataFile.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnShowFiles,
            this.btnBurnCD});
            // 
            // btnShowFiles
            // 
            this.btnShowFiles.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnShowFiles.FontBold = true;
            this.btnShowFiles.Image = global::Sepehr.Forms.Documents.Properties.Resources.FreeLockedRow;
            this.btnShowFiles.ImagePaddingHorizontal = 8;
            this.btnShowFiles.Name = "btnShowFiles";
            this.btnShowFiles.Text = "فایلها";
            this.btnShowFiles.Click += new System.EventHandler(this.btnShowFiles_Click);
            // 
            // btnBurnCD
            // 
            this.btnBurnCD.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnBurnCD.FontBold = true;
            this.btnBurnCD.Image = global::Sepehr.Forms.Documents.Properties.Resources.CDBurnerStart;
            this.btnBurnCD.ImagePaddingHorizontal = 8;
            this.btnBurnCD.Name = "btnBurnCD";
            this.btnBurnCD.Text = "رایت";
            this.btnBurnCD.Click += new System.EventHandler(this.btnBurnCD_Click);
            // 
            // cmsDocManagment
            // 
            this.cmsDocManagment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmsDocManagment.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmsdgvDocuments});
            this.cmsDocManagment.Location = new System.Drawing.Point(646, 140);
            this.cmsDocManagment.Name = "cmsDocManagment";
            this.cmsDocManagment.Size = new System.Drawing.Size(117, 25);
            this.cmsDocManagment.Stretch = true;
            this.cmsDocManagment.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.cmsDocManagment.TabIndex = 6653;
            this.cmsDocManagment.TabStop = false;
            // 
            // cmsdgvDocuments
            // 
            this.cmsdgvDocuments.AutoExpandOnClick = true;
            this.cmsdgvDocuments.ImagePaddingHorizontal = 8;
            this.cmsdgvDocuments.Name = "cmsdgvDocuments";
            this.cmsdgvDocuments.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnEditDoc,
            this.btnRemove,
            this.btnEditInWord,
            this.btnPreView,
            this.btnPrintDoc});
            this.cmsdgvDocuments.Text = "منوی جدول مدارك";
            // 
            // btnEditDoc
            // 
            this.btnEditDoc.Image = global::Sepehr.Forms.Documents.Properties.Resources.DocumentEdit;
            this.btnEditDoc.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnEditDoc.ImagePaddingHorizontal = 8;
            this.btnEditDoc.Name = "btnEditDoc";
            this.btnEditDoc.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.btnEditDoc.Text = "<b>ویرایش جواب</b>\r\n<div></div>\r\n<font color=\"#000000\">ویرایش متن گزارش بیمار.</f" +
                "ont>";
            this.btnEditDoc.Click += new System.EventHandler(this.btnEditDoc_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.Image = global::Sepehr.Forms.Documents.Properties.Resources.DeleteMed;
            this.btnRemove.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnRemove.ImagePaddingHorizontal = 8;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.btnRemove.Text = "<b>حذف مدرك</b>\r\n<div></div>\r\n<font color=\"#000000\">حذف مدرك از پرونده.</font>";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEditInWord
            // 
            this.btnEditInWord.BeginGroup = true;
            this.btnEditInWord.Image = global::Sepehr.Forms.Documents.Properties.Resources.Word;
            this.btnEditInWord.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnEditInWord.ImagePaddingHorizontal = 8;
            this.btnEditInWord.Name = "btnEditInWord";
            this.btnEditInWord.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnEditInWord.Text = "<b>تولید خروجی و نمایش</b>\r\n<div></div>\r\n<font color=\"#000000\">نمایش جواب در Word" +
                ".</font>";
            this.btnEditInWord.Click += new System.EventHandler(this.btnEditInWord_Click);
            // 
            // btnPreView
            // 
            this.btnPreView.Image = global::Sepehr.Forms.Documents.Properties.Resources.PrintPreview;
            this.btnPreView.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnPreView.ImagePaddingHorizontal = 8;
            this.btnPreView.Name = "btnPreView";
            this.btnPreView.Text = "<b>پیش نمایش چاپ</b>\r\n<div></div>\r\n<font color=\"#000000\">پیش نمایش مدرك برای چاپ." +
                "</font>";
            this.btnPreView.Click += new System.EventHandler(this.btnDocumentPreview_Click);
            // 
            // btnPrintDoc
            // 
            this.btnPrintDoc.ForeColor = System.Drawing.Color.Green;
            this.btnPrintDoc.Image = global::Sepehr.Forms.Documents.Properties.Resources.PrintGrid;
            this.btnPrintDoc.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnPrintDoc.ImagePaddingHorizontal = 8;
            this.btnPrintDoc.Name = "btnPrintDoc";
            this.btnPrintDoc.Text = "<b>چاپ مدرك</b>\r\n<div></div>\r\n<font color=\"#000000\">چاپ مستقیم مدرك.</font>";
            this.btnPrintDoc.Click += new System.EventHandler(this.btnPrintDoc_Click);
            // 
            // dgvDocuments
            // 
            this.dgvDocuments.AllowUserToAddRows = false;
            this.dgvDocuments.AllowUserToDeleteRows = false;
            this.dgvDocuments.AllowUserToOrderColumns = true;
            this.dgvDocuments.AllowUserToResizeRows = false;
            this.dgvDocuments.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvDocuments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocuments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDocuments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColRowNum,
            this.ColDocTypeName,
            this.ColDate,
            this.ColTitle,
            this.ColTypist});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocuments.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocuments.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDocuments.Location = new System.Drawing.Point(0, 223);
            this.dgvDocuments.MultiSelect = false;
            this.dgvDocuments.Name = "dgvDocuments";
            this.dgvDocuments.ReadOnly = true;
            this.dgvDocuments.RowHeadersVisible = false;
            this.dgvDocuments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDocuments.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dgvDocuments.RowTemplate.Height = 27;
            this.dgvDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocuments.Size = new System.Drawing.Size(792, 350);
            this.dgvDocuments.TabIndex = 0;
            this.dgvDocuments.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDocuments_CellMouseClick);
            this.dgvDocuments.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvDocuments_PreviewKeyDown);
            this.dgvDocuments.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocuments_CellFormatting);
            this.dgvDocuments.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDocuments_CellMouseDoubleClick);
            // 
            // ColRowNum
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ColRowNum.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColRowNum.HeaderText = "ردیف";
            this.ColRowNum.Name = "ColRowNum";
            this.ColRowNum.ReadOnly = true;
            this.ColRowNum.Width = 35;
            // 
            // ColDocTypeName
            // 
            this.ColDocTypeName.DataPropertyName = "TypeOf";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ColDocTypeName.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColDocTypeName.HeaderText = "نوع مدرك";
            this.ColDocTypeName.Name = "ColDocTypeName";
            this.ColDocTypeName.ReadOnly = true;
            this.ColDocTypeName.Width = 210;
            // 
            // ColDate
            // 
            this.ColDate.DataPropertyName = "FaDateOf";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColDate.HeaderText = "زمان ثبت";
            this.ColDate.Name = "ColDate";
            this.ColDate.ReadOnly = true;
            this.ColDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDate.Width = 140;
            // 
            // ColTitle
            // 
            this.ColTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColTitle.DataPropertyName = "TitleOf";
            this.ColTitle.HeaderText = "عنوان";
            this.ColTitle.Name = "ColTitle";
            this.ColTitle.ReadOnly = true;
            // 
            // ColTypist
            // 
            this.ColTypist.DataPropertyName = "TypistName";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColTypist.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColTypist.HeaderText = "كاربر ثبت كننده";
            this.ColTypist.Name = "ColTypist";
            this.ColTypist.ReadOnly = true;
            this.ColTypist.Width = 150;
            // 
            // FormToolTip
            // 
            this.FormToolTip.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(0, -50);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvRefServices
            // 
            this.dgvRefServices.AllowUserToAddRows = false;
            this.dgvRefServices.AllowUserToDeleteRows = false;
            this.dgvRefServices.AllowUserToResizeRows = false;
            this.dgvRefServices.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvRefServices.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvRefServices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRefServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvRefServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColServiceName,
            this.ColQuantity,
            this.ColExpert,
            this.ColPhysician});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRefServices.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvRefServices.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvRefServices.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvRefServices.Location = new System.Drawing.Point(0, 81);
            this.dgvRefServices.MultiSelect = false;
            this.dgvRefServices.Name = "dgvRefServices";
            this.dgvRefServices.ReadOnly = true;
            this.dgvRefServices.RowHeadersVisible = false;
            this.dgvRefServices.Size = new System.Drawing.Size(792, 142);
            this.dgvRefServices.StandardTab = true;
            this.dgvRefServices.TabIndex = 6654;
            this.dgvRefServices.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRefServices_CellFormatting);
            // 
            // ColServiceName
            // 
            this.ColServiceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColServiceName.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColServiceName.HeaderText = "نام خدمت بیمار";
            this.ColServiceName.Name = "ColServiceName";
            this.ColServiceName.ReadOnly = true;
            this.ColServiceName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColServiceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ColQuantity
            // 
            this.ColQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColQuantity.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColQuantity.HeaderText = "تعداد";
            this.ColQuantity.MaxInputLength = 3;
            this.ColQuantity.Name = "ColQuantity";
            this.ColQuantity.ReadOnly = true;
            this.ColQuantity.Width = 40;
            // 
            // ColExpert
            // 
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Purple;
            this.ColExpert.DefaultCellStyle = dataGridViewCellStyle10;
            this.ColExpert.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColExpert.DisplayStyleForCurrentCellOnly = true;
            this.ColExpert.HeaderText = "كارشناس";
            this.ColExpert.Name = "ColExpert";
            this.ColExpert.ReadOnly = true;
            this.ColExpert.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColExpert.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColExpert.Width = 150;
            // 
            // ColPhysician
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Purple;
            this.ColPhysician.DefaultCellStyle = dataGridViewCellStyle11;
            this.ColPhysician.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColPhysician.DisplayStyleForCurrentCellOnly = true;
            this.ColPhysician.HeaderText = "پزشك";
            this.ColPhysician.Name = "ColPhysician";
            this.ColPhysician.ReadOnly = true;
            this.ColPhysician.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColPhysician.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColPhysician.Width = 150;
            // 
            // frmDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cmsDocManagment);
            this.Controls.Add(this.dgvDocuments);
            this.Controls.Add(this.dgvRefServices);
            this.Controls.Add(this.ribbonBarOrders);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmDocuments";
            this.Opacity = 0.01;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بیماران - مدارك - مدیریت مدارك بیمار";
            this.Shown += new System.EventHandler(this.Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonBarOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmsDocManagment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefServices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar ribbonBarOrders;
        private DevComponents.DotNetBar.ButtonItem btnPrevPatient;
        private DevComponents.DotNetBar.ItemContainer iContainerPatientData;
        private DevComponents.DotNetBar.ButtonItem btnNextPatient;
        private DevComponents.DotNetBar.ButtonItem btnNewDoc;
        private DevComponents.DotNetBar.ContextMenuBar cmsDocManagment;
        private DevComponents.DotNetBar.ButtonItem cmsdgvDocuments;
        private DevComponents.DotNetBar.ButtonItem btnEditDoc;
        private DevComponents.DotNetBar.ButtonItem btnRemove;
        private DevComponents.DotNetBar.ButtonItem btnPreView;
        private DevComponents.DotNetBar.ButtonItem btnPrintDoc;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvDocuments;
        private DevComponents.DotNetBar.SuperTooltip FormToolTip;
        private DevComponents.DotNetBar.LabelItem lblPatientID;
        private DevComponents.DotNetBar.LabelItem lblPatientFullName;
        private DevComponents.DotNetBar.LabelItem lblRefDate;
        private DevComponents.DotNetBar.ItemContainer iContainerRefManager;
        private DevComponents.DotNetBar.ButtonItem btnNextReferral;
        private DevComponents.DotNetBar.ButtonItem btnPrevReferral;
        private DevComponents.DotNetBar.ButtonItem btnClose;
        private System.Windows.Forms.Button btnExit;
        private DevComponents.DotNetBar.ButtonItem btnEditInWord;
        private DevComponents.DotNetBar.ButtonItem btnPrintDefaultDoc;
        private DevComponents.DotNetBar.ItemContainer iContainerCapture;
        private DevComponents.DotNetBar.ButtonItem btnGrabber;
        private DevComponents.DotNetBar.ButtonItem btnClip;
        private DevComponents.DotNetBar.ItemContainer iContainerDataFile;
        private DevComponents.DotNetBar.ButtonItem btnShowFiles;
        private DevComponents.DotNetBar.ButtonItem btnBurnCD;
        private DevComponents.DotNetBar.ItemContainer iContainerCaptureManager;
        private DevComponents.DotNetBar.ButtonItem btnClipAndGrab;
        private DevComponents.DotNetBar.LabelItem lblRefID;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvRefServices;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQuantity;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColExpert;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColPhysician;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRowNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDocTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTypist;
    }
}