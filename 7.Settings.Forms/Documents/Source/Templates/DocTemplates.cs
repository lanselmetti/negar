#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Chilkat;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Documents;
using Sepehr.Settings.Documents.Properties;
#endregion

namespace Sepehr.Settings.Documents
{
    /// <summary>
    /// فرم مدیریت قالب های مدارك
    /// </summary>
    public partial class frmDocTemplates : Form
    {

        #region Fields

        #region List<SP_SelectTemplatesResult> _TemplatesCollection
        /// <summary>
        /// لیست قالب های افزوده شده به سیستم
        /// </summary>
        private List<SP_SelectTemplatesResult> _TemplatesCollection;
        #endregion

        #region Int32? _TempIDForCopy
        /// <summary>
        /// این فیلد نگهدارنده شناسه گروه یا قالبیست كه قرار است به صورت موردی كپی شود
        /// </summary>
        private Int32? _TempIDForCopy;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmDocTemplates()
        {
            InitializeComponent();
            if (!FillFormData()) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
        }
        #endregion

        #region btnAddNewRootGroup_Click
        private void btnAddNewRootGroup_Click(object sender, EventArgs e)
        {
            AddNewGroup(null);
        }
        #endregion

        #region btnAddNewRootTemplate_Click
        private void btnAddNewRootTemplate_Click(object sender, EventArgs e)
        {
            AddNewTemplate(null);
        }
        #endregion

        #region btnNewGroup_Click
        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            AddNewGroup(TreeViewTemplates.SelectedNode);
        }
        #endregion

        #region btnNewTemplate_Click
        private void btnNewTemplate_Click(object sender, EventArgs e)
        {
            AddNewTemplate(TreeViewTemplates.SelectedNode);
        }
        #endregion

        #region TreeViewTemp_NodeMouseClick
        private void TreeViewTemp_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // كلیك بر قالب ها
            if (e.Button == MouseButtons.Right && !e.Node.Checked)
            {
                TreeViewTemplates.SelectedNode = e.Node;
                btnNewGroup.Visible = false;
                btnNewTemplate.Visible = false;
                btnColapse.Visible = false;
                btnExpand.Visible = false;
                btnEdit.Visible = true;
                btnExport.Visible = true;
                btnRemove.Visible = true;
                cmsACLManage.Popup(MousePosition);
            }
            // كلیك بر گروه ها
            else if (e.Button == MouseButtons.Right && e.Node.Checked)
            {
                TreeViewTemplates.SelectedNode = e.Node;
                btnNewGroup.Visible = true;
                btnNewTemplate.Visible = true;
                // اگر گروه زیر شاخه نداشته باشد
                if (e.Node.Nodes.Count == 0)
                {
                    btnColapse.Visible = false;
                    btnExpand.Visible = false;
                }
                // اگر گروه زیر شاخه داشته باشد
                else
                {
                    btnColapse.Visible = true;
                    btnExpand.Visible = true;
                }
                btnEdit.Visible = true;
                btnExport.Visible = false;
                btnRemove.Visible = true;
                cmsACLManage.Popup(MousePosition);
            }
        }
        #endregion

        #region TreeViewTemplates_NodeMouseDoubleClick
        private void TreeViewTemplates_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // كلیك بر قالب ها
            if (e.Button == MouseButtons.Left && !e.Node.Checked)
            {
                TreeViewTemplates.SelectedNode = e.Node;
                btnEdit_Click(null, null);
            }
        }
        #endregion

        #region btnEdit_Click
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Int16 NodeID = Convert.ToInt16(TreeViewTemplates.SelectedNode.Tag);
            #region (For Groups) TreeViewTemplates.SelectedNode.Checked
            if (TreeViewTemplates.SelectedNode.Checked)
            {
                frmDocTemplatesGroupManage MyForm = new frmDocTemplatesGroupManage(Convert.ToInt16(NodeID));
                if (MyForm.DialogResult != DialogResult.OK) return;
                try
                {
                    DocTemplate DataToEdit = DBLayerIMS.Manager.DBML.DocTemplates.
                        Where(Data => Data.ID == Convert.ToInt16(NodeID)).First();
                    DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, DataToEdit);
                    DataToEdit.Name = MyForm.txtName.Text.Trim().Normalize();
                    DataToEdit.Description = MyForm.txtDescription.Text.Trim().Normalize();
                    DBLayerIMS.Manager.DBML.SubmitChanges();
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان ویرایش گره قالب مدرك انتخاب شده در بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                    return;
                }
                #endregion
                TreeViewTemplates.SelectedNode.Text = MyForm.txtName.Text.Trim();
                TreeViewTemplates.SelectedNode.ToolTipText = MyForm.txtDescription.Text.Trim();
            }
            #endregion

            #region (For Templates) TreeViewTemplates.SelectedNode.Checked == false
            else
            {
                frmDocTemplatesManage MyForm = new frmDocTemplatesManage(Convert.ToInt16(NodeID));
                if (MyForm.DialogResult != DialogResult.OK) return;
                try
                {
                    DocTemplate Field = DBLayerIMS.Manager.DBML.DocTemplates.
                        Where(Data => Data.ID == Convert.ToInt16(NodeID)).First();
                    DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, Field);
                    Field.Name = MyForm.txtName.Text.Trim().Normalize();
                    if (MyForm.cBoxIsDefault.Checked)
                    {
                        IQueryable<DocTemplate> DefaultData = DBLayerIMS.Manager.DBML.DocTemplates.
                            Where(Data => Data.ID != Field.ID);
                        foreach (DocTemplate Data in DefaultData) Data.IsDefault = false;
                    }
                    Field.IsDefault = MyForm.cBoxIsDefault.Checked;
                    Field.Description = MyForm.txtDescription.Text.Trim().Normalize();
                    Int16? TemplateCode = null;
                    if (MyForm.txtTemplateCode.ValueObject != null)
                        TemplateCode = Convert.ToInt16(MyForm.txtTemplateCode.Value);
                    Field.Code = TemplateCode;
                    Field.TemplateData = File.ReadAllBytes(MyForm.FormFilePath + "Zip");
                    DBLayerIMS.Manager.DBML.SubmitChanges();
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان ویرایش گره قالب مدرك انتخاب شده در بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error); return;
                }
                #endregion
                TreeViewTemplates.SelectedNode.Text = MyForm.txtName.Text.Trim().Normalize();
                TreeViewTemplates.SelectedNode.ToolTipText = MyForm.txtDescription.Text.Trim().Normalize();

                if (File.Exists(MyForm.FormFilePath + "Doc"))
                    try { File.Delete(MyForm.FormFilePath + "Doc"); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage =
                            "امكان ویرایش گره قالب مدرك انتخاب شده در بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return;
                    }
                    #endregion
                if (File.Exists(MyForm.FormFilePath + "Zip"))
                    try { File.Delete(MyForm.FormFilePath + "Zip"); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage =
                            "امكان ویرایش گره قالب مدرك انتخاب شده در بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return;
                    }
                    #endregion
                BringToFront();
                Focus();
            }
            #endregion
        }
        #endregion

        #region btnExport_Click
        private void btnExport_Click(object sender, EventArgs e)
        {
            Int16 NodeID = Convert.ToInt16(TreeViewTemplates.SelectedNode.Tag);
            FormSaveFileDialog.Filter = "فایل ورد (*.doc)|*.doc";
            FormSaveFileDialog.FileName = "TemplateFile.Doc";
            if (FormSaveFileDialog.ShowDialog() != DialogResult.OK) return;
            if (!ExportTemplateToFile(NodeID, FormSaveFileDialog.FileName)) { Close(); return; }
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Dr = PMBox.Show("آیا مایلید این قالب را حذف نمایید؟\nبا حذف این قالب ،" +
                " تمام قالب های زیر مجموعه آن حذف خواهد شد و امكان بازگشت آن وجود ندارد.",
                "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (Dr == DialogResult.No) return;
            DeleteNode(TreeViewTemplates.SelectedNode);
        }
        #endregion

        #region btnExpand_Click
        private void btnExpand_Click(object sender, EventArgs e)
        {
            if (((ButtonItem)sender).Name == "btnExpand")
                TreeViewTemplates.SelectedNode.ExpandAll();
            else TreeViewTemplates.SelectedNode.Collapse();
        }
        #endregion

        #region btnHelp_Click
        /// <summary>
        /// روال نمایش راهنمایی برای فرم
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            // نمایش راهنما تكمیل شود
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            GC.Collect();
        }
        #endregion

        #region btnCopy_Click
        /// <summary>
        /// تابعی برای ذخیره كلید كپی برداری قالب مدرك
        /// </summary>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            _TempIDForCopy = Convert.ToInt32(TreeViewTemplates.SelectedNode.Tag);
        }
        #endregion

        #region btnPaste_Click
        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (_TempIDForCopy == null) // بررسی اینكه آیا قالبی برای كپی برداری انتخاب شده است
            {
                PMBox.Show("آیتمی كپی نشده تا بتوان از آن رونوشت گرفت!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!TreeViewTemplates.SelectedNode.Checked) // چسباندن بر روی قالب ممكن نیست
            {
                PMBox.Show("چسباندن آیتم های كپی شده ، زیر یك قالب ممكن نیست!\n" +
                    "تنها آیتم های كپی شده را بر روی گروه ها بچسبانید.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Int16? ReturnValue = CopyTemplate(Convert.ToInt16(_TempIDForCopy),
                Convert.ToInt16(TreeViewTemplates.SelectedNode.Tag));
            if (ReturnValue != null)
            {
                Int32 CurrentSelectedNodeIndex = TreeViewTemplates.SelectedNode.Index;
                TreeViewTemplates.Nodes.Clear();
                FillFormData();
                TreeViewTemplates.Nodes[CurrentSelectedNodeIndex].Expand();
                TreeViewTemplates.Nodes[CurrentSelectedNodeIndex].EnsureVisible();
            }
        }
        #endregion

        #region btnPasteRoot_Click
        private void btnPasteRoot_Click(object sender, EventArgs e)
        {
            if (_TempIDForCopy == null) // بررسی اینكه آیا قالبی برای كپی برداری انتخاب شده است
            {
                PMBox.Show("آیتمی كپی نشده تا بتوان از آن رونوشت گرفت!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Int16? ReturnValue = CopyTemplate(Convert.ToInt16(_TempIDForCopy), null);
            if (ReturnValue != null)
            {
                Int32 CurrentSelectedNodeIndex = TreeViewTemplates.SelectedNode.Index;
                TreeViewTemplates.Nodes.Clear();
                FillFormData();
                TreeViewTemplates.Nodes[CurrentSelectedNodeIndex].Expand();
                TreeViewTemplates.Nodes[CurrentSelectedNodeIndex].EnsureVisible();
            }
        }
        #endregion

        #region btnPasteAll_Click
        private void btnPasteAll_Click(object sender, EventArgs e)
        {
            if (_TempIDForCopy == null) // بررسی اینكه آیا قالبی برای كپی برداری انتخاب شده است
            {
                PMBox.Show("آیتمی كپی نشده تا بتوان از آن رونوشت گرفت!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!TreeViewTemplates.SelectedNode.Checked) // چسباندن بر روی قالب ممكن نیست
            {
                PMBox.Show("چسباندن آیتم های كپی شده ، زیر یك قالب ممكن نیست!\n" +
                    "تنها آیتم های كپی شده را بر روی گروه ها بچسبانید.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Int16? ReturnValue = CopyTemplate(Convert.ToInt16(_TempIDForCopy),
                Convert.ToInt16(TreeViewTemplates.SelectedNode.Tag));
            if (ReturnValue != null)
            {
                CopyTemplateWithChilds(Convert.ToInt16(_TempIDForCopy), ReturnValue);
                Int32 CurrentSelectedNodeIndex = TreeViewTemplates.SelectedNode.Index;
                TreeViewTemplates.Nodes.Clear();
                FillFormData();
                TreeViewTemplates.Nodes[CurrentSelectedNodeIndex].Expand();
                TreeViewTemplates.Nodes[CurrentSelectedNodeIndex].EnsureVisible();
            }
        }
        #endregion

        #region btnPasteRootAll_Click
        private void btnPasteRootAll_Click(object sender, EventArgs e)
        {
            if (_TempIDForCopy == null) // بررسی اینكه آیا قالبی برای كپی برداری انتخاب شده است
            {
                PMBox.Show("آیتمی كپی نشده تا بتوان از آن رونوشت گرفت!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Int16? ReturnValue = CopyTemplate(Convert.ToInt16(_TempIDForCopy), null);
            if (ReturnValue != null)
            {
                CopyTemplateWithChilds(Convert.ToInt16(_TempIDForCopy), ReturnValue);
                Int32 CurrentSelectedNodeIndex = TreeViewTemplates.SelectedNode.Index;
                TreeViewTemplates.Nodes.Clear();
                FillFormData();
                TreeViewTemplates.Nodes[CurrentSelectedNodeIndex].Expand();
                TreeViewTemplates.Nodes[CurrentSelectedNodeIndex].EnsureVisible();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region void SetControlsToolTipTexts()
        /// <summary>
        /// تابع تنظیم متن راهنمای كنترل ها
        /// </summary>
        private void SetControlsToolTipTexts()
        {
            const String TooltipHeader = "راهنماي تنظيمات سيستم";
            const String TooltipFooter = "سيستم مديريت تصويربرداري سپهر";

            #region btnHelp
            String TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAddNewRootGroup
            TooltipText = ToolTipManager.GetText("btnAddDocumentRootGroup", "IMS");
            FormToolTip.SetSuperTooltip(btnAddNewRootGroup, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAddNewRootTemplate
            TooltipText = ToolTipManager.GetText("btnAddDocumentRootTemplate", "IMS");
            FormToolTip.SetSuperTooltip(btnAddNewRootTemplate, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnClose
            TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnClose, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region Boolean FillFormData()
        /// <summary>
        /// تابع خواندن اطلاعات قالب هاب مدارك
        /// </summary>
        /// <returns></returns>
        private Boolean FillFormData()
        {
            DBLayerIMS.Document.DocTemplatesList = null;
            _TemplatesCollection = DBLayerIMS.Document.DocTemplatesList;
            if (_TemplatesCollection == null) return false;
            foreach (SP_SelectTemplatesResult DocData in _TemplatesCollection)
            {
                if (DocData.ParentIX == null)
                {
                    TreeNode node = new TreeNode();
                    node.Tag = DocData.ID;
                    node.Text = DocData.Name;
                    node.ToolTipText = DocData.Description;
                    // برای گروه های قالب
                    if (DocData.IsGroup) node.Checked = true;
                    // برای متن قالب ها
                    else
                    {
                        node.Checked = false;
                        node.ForeColor = Color.Green;
                    }
                    FillTreeChildNodes(node);
                    TreeViewTemplates.Nodes.Add(node);
                }
            }
            return true;
        }
        #endregion

        #region void FillTreeChildNodes(TreeNode ParentNode)
        /// <summary>
        /// تابع بازگشتی افزودن قالب های فرزند
        /// </summary>
        /// <param name="ParentNode">گره پدر</param>
        private void FillTreeChildNodes(TreeNode ParentNode)
        {
            foreach (SP_SelectTemplatesResult Data in _TemplatesCollection)
                if (Data.ParentIX == Convert.ToInt16(ParentNode.Tag))
                {
                    TreeNode node = new TreeNode();
                    node.Tag = Data.ID;
                    node.Text = Data.Name;
                    node.ToolTipText = Data.Description;
                    // برای گروه های قالب
                    if (Data.IsGroup) node.Checked = true;
                    // برای متن قالب ها
                    else
                    {
                        node.Checked = false;
                        node.ForeColor = Color.Green;
                    }
                    FillTreeChildNodes(node);
                    ParentNode.Nodes.Add(node);
                }
        }
        #endregion

        #region void AddNewGroup(TreeNode ParentNode)
        /// <summary>
        /// روالی برای افزودن یك گروه قالب به لیست
        /// </summary>
        /// <param name="ParentNode">گروه پدر یا تهی برای گروه ریشه</param>
        private void AddNewGroup(TreeNode ParentNode)
        {
            frmDocTemplatesGroupManage MyForm = new frmDocTemplatesGroupManage();
            if (MyForm.DialogResult != DialogResult.OK) return;
            DocTemplate NewItem = new DocTemplate();
            NewItem.IsGroup = true;
            if (ParentNode != null) NewItem.ParentIX = Convert.ToInt16(ParentNode.Tag);
            NewItem.Name = MyForm.txtName.Text.Trim().Normalize();
            NewItem.Description = MyForm.txtDescription.Text.Trim().Normalize();
            DBLayerIMS.Manager.DBML.DocTemplates.InsertOnSubmit(NewItem);
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان اضافه كردن گروه قالب مدرك به بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            TreeNode node = new TreeNode();
            node.Tag = NewItem.ID;
            node.Text = NewItem.Name;
            node.ToolTipText = NewItem.Description;
            node.Checked = true;
            if (ParentNode == null) TreeViewTemplates.Nodes.Add(node);
            else ParentNode.Nodes.Add(node);
            MyForm.Dispose();
            TopMost = true;
            Select();
            Activate();
            BringToFront();
            Focus();
            TopMost = false;
        }
        #endregion

        #region void AddNewTemplate(TreeNode ParentNode)
        /// <summary>
        /// روالی برای افزودن یك قالب به لیست
        /// </summary>
        /// <param name="ParentNode">قالب پدر یا تهی برای قالب ریشه</param>
        private void AddNewTemplate(TreeNode ParentNode)
        {
            frmDocTemplatesManage MyForm = new frmDocTemplatesManage(null);
            if (MyForm.DialogResult != DialogResult.OK) return;
            DocTemplate NewItem = new DocTemplate();
            NewItem.IsGroup = false;
            NewItem.Name = MyForm.txtName.Text.Trim().Normalize();
            if (MyForm.cBoxIsDefault.Checked)
            {
                Table<DocTemplate> DefaultData = DBLayerIMS.Manager.DBML.DocTemplates;
                foreach (DocTemplate Data in DefaultData) Data.IsDefault = false;
            }
            NewItem.IsDefault = MyForm.cBoxIsDefault.Checked;
            NewItem.Description = MyForm.txtDescription.Text.Trim().Normalize();
            if (ParentNode != null) NewItem.ParentIX = Convert.ToInt16(ParentNode.Tag);
            Int16? TemplateCode = null;
            if (MyForm.txtTemplateCode.ValueObject != null)
                TemplateCode = Convert.ToInt16(MyForm.txtTemplateCode.Value);
            NewItem.Code = TemplateCode;
            NewItem.TemplateData = File.ReadAllBytes(MyForm.FormFilePath + "Zip");
            DBLayerIMS.Manager.DBML.DocTemplates.InsertOnSubmit(NewItem);
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان اضافه كردن قالب مدرك به بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            TreeNode node = new TreeNode();
            node.Tag = NewItem.ID;
            node.Text = MyForm.txtName.Text.Trim();
            node.ToolTipText = MyForm.txtDescription.Text.Trim();
            node.Checked = false;
            node.ForeColor = Color.Green;
            if (ParentNode == null) TreeViewTemplates.Nodes.Add(node);
            else ParentNode.Nodes.Add(node);
            try
            {
                if (File.Exists(MyForm.FormFilePath + "Zip")) File.Delete(MyForm.FormFilePath + "Zip");
                if (File.Exists(MyForm.FormFilePath + "Doc")) File.Delete(MyForm.FormFilePath + "Doc");
            }
            #region Catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
            MyForm.Dispose();
            TopMost = true;
            Select();
            Activate();
            BringToFront();
            Focus();
            TopMost = false;
        }
        #endregion

        #region void DeleteNode(TreeNode node)
        /// <summary>
        /// تابع حذف گره قالب مدرك
        /// </summary>
        /// <param name="node">گرع مورد نظر</param>
        private void DeleteNode(TreeNode node)
        {
            for (Int32 i = node.Nodes.Count - 1; i >= 0; i--) DeleteNode(node.Nodes[i]);
            DBLayerIMS.Manager.DBML.DocTemplates.DeleteAllOnSubmit(
                DBLayerIMS.Manager.DBML.DocTemplates.Where(Data => Data.ID == Convert.ToInt16(node.Tag)));
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان حذف قالب مدرك از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            TreeViewTemplates.Nodes.Remove(node);
        }
        #endregion

        #region Boolean ExportTemplateToFile(Int16 TemplateID, String TemplatePath)
        /// <summary>
        /// تابع ایجاد خروجی فایل از یك قالب مدرك
        /// </summary>
        private static Boolean ExportTemplateToFile(Int16 TemplateID, String TargetFilePath)
        {
            String TempPath = TargetFilePath.Substring(0, TargetFilePath.Count() - 3);
            String TemplateDirectory = TargetFilePath;
            // بدست آوردن آدرس دایركتوری انتخاب شده از آدرس كامل ارسال شده
            for (Int32 i = TargetFilePath.Count() - 1; i >= 0; i--)
            {
                Char Temp = TemplateDirectory[i];
                TemplateDirectory = TemplateDirectory.Substring(0, TemplateDirectory.Count() - 1);
                if (Temp == Convert.ToChar("\\")) break;
            }
            try
            {
                DocTemplate DocTemplateData = DBLayerIMS.Manager.DBML.
                    DocTemplates.Where(Data => Data.ID == TemplateID).ToList().First();
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, DocTemplateData);
                // خواندن فایل باینری فشرده شده ی قالب
                Binary TempData = DocTemplateData.TemplateData;
                // حذف فایل های مقصدی كه فرم بر اساس زمان سیستم تولید كرده در صورت وجود
                if (File.Exists(TempPath + "Doc")) File.Delete(TempPath + "Doc");
                if (File.Exists(TempPath + "Zip")) File.Delete(TempPath + "Zip");
                // ایجاد فایل زیپ قالب مورد نظر به صورت خالی
                File.Create(TempPath + "Zip").Close();
                // ریختن اطلاعات باینری فایل فشرده شده ی قالب
                if (TempData != null) File.WriteAllBytes(TempPath + "Zip", TempData.ToArray());
                #region Unzip Document
                Zip ZipHelper = new Zip();
                ZipHelper.UnlockComponent("ZIP-TEAMBEAN_4F46F322914X");
                Boolean IsOpenedZipFile = ZipHelper.OpenZip(TempPath + "Zip");
                if (!IsOpenedZipFile) throw new Exception(ZipHelper.LastErrorText);
                Int32 FilesCount = ZipHelper.Unzip(TemplateDirectory);
                if (FilesCount == -1) throw new Exception(ZipHelper.LastErrorText);
                ZipHelper.CloseZip();
                ZipHelper.Dispose();
                if (File.Exists(TempPath + "Zip")) File.Delete(TempPath + "Zip");
                if (File.Exists(TemplateDirectory + "\\RefDocTemplate.Doc"))
                    File.Copy(TemplateDirectory + "\\RefDocTemplate.Doc", TempPath + "Doc");
                if (File.Exists(TemplateDirectory + "\\RefDocTemplate.Doc"))
                    File.Delete(TemplateDirectory + "\\RefDocTemplate.Doc");
                #endregion
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات قالب مدرك انتخاب شده از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟\n" +
                    "2. آیا ترم افزار ورد مایكروسافت نصب می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Int16? CopyTemplate(Int16 BaseItemID, Int16? TargetParentID)
        /// <summary>
        /// تابعی برای كپی برداری یك آیتم و جانشینی آن به عنوان آیتمی جدید
        /// </summary>
        /// <returns>كلید آیتم جدید ساخته شده یا تهی برای خطا</returns>
        private static Int16? CopyTemplate(Int16 BaseItemID, Int16? TargetParentID)
        {
            try
            {
                DocTemplate BaseItem = DBLayerIMS.Manager.DBML.DocTemplates.
                    Where(Data => Data.ID == BaseItemID).First();
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, BaseItem);
                DocTemplate NewItem = new DocTemplate();
                NewItem.ParentIX = TargetParentID;
                NewItem.Code = null;
                NewItem.IsDefault = false;
                NewItem.IsGroup = BaseItem.IsGroup;
                NewItem.Name = BaseItem.Name;
                NewItem.TemplateData = BaseItem.TemplateData;
                NewItem.Description = BaseItem.Description;
                DBLayerIMS.Manager.DBML.DocTemplates.InsertOnSubmit(NewItem);
                DBLayerIMS.Manager.DBML.SubmitChanges();
                return NewItem.ID;
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در كپی برداری آیتم انتخاب شده!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                DBLayerIMS.Manager.DBML = null;
                return null;
            }
            #endregion
        }
        #endregion

        #region void CopyTemplateWithChilds(Int16 BaseItemID, Int16? TargetParentID)
        /// <summary>
        /// تابعی برای كپی برداری یك آیتم و جانشینی آن به عنوان آیتمی جدید
        /// </summary>
        /// <returns>كلید آیتم جدید ساخته شده یا تهی برای خطا</returns>
        private static void CopyTemplateWithChilds(Int16 BaseItemID, Int16? TargetParentID)
        {
            try
            {
                IQueryable<DocTemplate> Childs = DBLayerIMS.Manager.DBML.DocTemplates.
                    Where(Data => Data.ParentIX == BaseItemID);
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, Childs);
                foreach (DocTemplate child in Childs)
                {
                    DocTemplate NewItem = new DocTemplate();
                    NewItem.ParentIX = TargetParentID;
                    NewItem.Code = null;
                    NewItem.IsDefault = false;
                    NewItem.IsGroup = child.IsGroup;
                    NewItem.Name = child.Name;
                    NewItem.TemplateData = child.TemplateData;
                    NewItem.Description = child.Description;
                    DBLayerIMS.Manager.DBML.DocTemplates.InsertOnSubmit(NewItem);
                    DBLayerIMS.Manager.DBML.SubmitChanges();
                    CopyTemplateWithChilds(child.ID, NewItem.ID);
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در كپی برداری آیتم انتخاب شده!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                DBLayerIMS.Manager.DBML = null;
            }
            #endregion
        }
        #endregion

        #endregion

    }
}