#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Documents;
using Sepehr.Settings.Documents.Properties;
#endregion

namespace Sepehr.Settings.Documents
{
    /// <summary>
    /// فرم مدیریت متن های مدارك
    /// </summary>
    public partial class frmDocTexts : Form
    {

        #region Fields

        #region List<DocText> _TemplatesCollection
        /// <summary>
        /// لیست متن های افزوده شده به سیستم
        /// </summary>
        private List<DocText> _TemplatesCollection;
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
        public frmDocTexts()
        {
            InitializeComponent();
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
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

        #region btnAddNewRootText_Click
        private void btnAddNewRootText_Click(object sender, EventArgs e)
        {
            AddNewText(null);
        }
        #endregion

        #region btnNewGroup_Click
        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            AddNewGroup(TreeViewText.SelectedNode);
        }
        #endregion

        #region btnNewText_Click
        private void btnNewText_Click(object sender, EventArgs e)
        {
            AddNewText(TreeViewText.SelectedNode);
        }
        #endregion

        #region TreeViewTexts_NodeMouseClick
        private void TreeViewTexts_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // كلیك بر قالب ها
            if (e.Button == MouseButtons.Right && !e.Node.Checked)
            {
                TreeViewText.SelectedNode = e.Node;
                btnNewGroup.Visible = false;
                btnNewText.Visible = false;
                btnColapse.Visible = false;
                btnExpand.Visible = false;
                btnEdit.Visible = true;
                btnRemove.Visible = true;
                cmsACLManage.Popup(MousePosition);
            }
            // كلیك بر گروه ها
            else if (e.Button == MouseButtons.Right && e.Node.Checked)
            {
                TreeViewText.SelectedNode = e.Node;
                btnNewGroup.Visible = true;
                btnNewText.Visible = true;
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
                btnRemove.Visible = true;
                cmsACLManage.Popup(MousePosition);
            }
        }
        #endregion

        #region TreeViewTexts_NodeMouseDoubleClick
        private void TreeViewTexts_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // كلیك بر قالب ها
            if (e.Button == MouseButtons.Left && !e.Node.Checked)
            {
                TreeViewText.SelectedNode = e.Node;
                btnEdit_Click(null, null);
            }
        }
        #endregion

        #region btnEdit_Click
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Int16 NodeID = Convert.ToInt16(TreeViewText.SelectedNode.Tag);

            #region (For Groups) TreeViewTexts.SelectedNode.Checked
            if (TreeViewText.SelectedNode.Checked)
            {
                frmDocTextsGroupManage MyForm = new frmDocTextsGroupManage(NodeID);
                if (MyForm.DialogResult != DialogResult.OK) return;
                try
                {
                    DocText Temp = DBLayerIMS.Manager.DBML.DocTexts.Where(Data => Data.ID == NodeID).ToList().First();
                    Temp.Name = MyForm.txtName.Text.Trim().Normalize();
                    Temp.Description = MyForm.txtDescription.Text.Trim().Normalize();
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
                TreeViewText.SelectedNode.Text = MyForm.txtName.Text.Trim().Normalize();
                TreeViewText.SelectedNode.ToolTipText = MyForm.txtDescription.Text.Trim().Normalize();
            }
            #endregion

            #region (For Texts) TreeViewTexts.SelectedNode.Checked == false
            else
            {
                frmDocTextsManage MyForm = new frmDocTextsManage(NodeID);
                if (MyForm.DialogResult == DialogResult.OK)
                {
                    Int16? TextCode = null;
                    if (MyForm.txtTextCode.ValueObject != null) TextCode = Convert.ToInt16(MyForm.txtTextCode.Value);
                    try
                    {
                        DocText Temp = DBLayerIMS.Manager.DBML.DocTexts.Where(Data => Data.ID == NodeID).ToList().First();
                        Temp.Name = MyForm.txtName.Text.Trim();
                        Temp.Description = MyForm.txtDescription.Text.Trim();
                        Temp.Code = TextCode;
                        Temp.TextsData = MyForm.txtText.Text;
                        DBLayerIMS.Manager.DBML.SubmitChanges();
                    }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage =
                            "امكان ویرایش گره متن مدرك انتخاب شده در بانك اطلاعات ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return;
                    }
                    #endregion
                    TreeViewText.SelectedNode.Text = MyForm.txtName.Text.Trim();
                    TreeViewText.SelectedNode.ToolTipText = MyForm.txtDescription.Text.Trim();
                }
                BringToFront();
                Focus();
            }
            #endregion
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Dr = PMBox.Show("آیا مایلید این قالب را حذف نمایید؟\nبا حذف این قالب ،" +
                " تمام قالب های زیر مجموعه آن حذف خواهد شد و امكان بازگشت آن وجود ندارد.",
                "هشدار!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (Dr == DialogResult.No) return;
            DeleteNode(TreeViewText.SelectedNode);
        }
        #endregion

        #region btnExpand_Click
        private void btnExpand_Click(object sender, EventArgs e)
        {
            if (((ButtonItem)sender).Name == "btnExpand")
                TreeViewText.SelectedNode.ExpandAll();
            else TreeViewText.SelectedNode.Collapse();
        }
        #endregion

        #region btnCopy_Click
        /// <summary>
        /// تابعی برای ذخیره كلید كپی برداری قالب مدرك
        /// </summary>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            _TempIDForCopy = Convert.ToInt32(TreeViewText.SelectedNode.Tag);
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
            if (!TreeViewText.SelectedNode.Checked) // چسباندن بر روی قالب ممكن نیست
            {
                PMBox.Show("چسباندن آیتم های كپی شده ، زیر یك قالب ممكن نیست!\n" +
                    "تنها آیتم های كپی شده را بر روی گروه ها بچسبانید.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Int16? ReturnValue = CopyTemplate(Convert.ToInt16(_TempIDForCopy),
                Convert.ToInt16(TreeViewText.SelectedNode.Tag));
            if (ReturnValue != null)
            {
                Int32 CurrentSelectedNodeIndex = TreeViewText.SelectedNode.Index;
                TreeViewText.Nodes.Clear();
                FillFormData();
                TreeViewText.Nodes[CurrentSelectedNodeIndex].Expand();
                TreeViewText.Nodes[CurrentSelectedNodeIndex].EnsureVisible();
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
                Int32 CurrentSelectedNodeIndex = TreeViewText.SelectedNode.Index;
                TreeViewText.Nodes.Clear();
                FillFormData();
                TreeViewText.Nodes[CurrentSelectedNodeIndex].Expand();
                TreeViewText.Nodes[CurrentSelectedNodeIndex].EnsureVisible();
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
            if (!TreeViewText.SelectedNode.Checked) // چسباندن بر روی قالب ممكن نیست
            {
                PMBox.Show("چسباندن آیتم های كپی شده ، زیر یك قالب ممكن نیست!\n" +
                    "تنها آیتم های كپی شده را بر روی گروه ها بچسبانید.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Int16? ReturnValue = CopyTemplate(Convert.ToInt16(_TempIDForCopy),
                Convert.ToInt16(TreeViewText.SelectedNode.Tag));
            if (ReturnValue != null)
            {
                CopyTemplateWithChilds(Convert.ToInt16(_TempIDForCopy), ReturnValue);
                Int32 CurrentSelectedNodeIndex = TreeViewText.SelectedNode.Index;
                TreeViewText.Nodes.Clear();
                FillFormData();
                TreeViewText.Nodes[CurrentSelectedNodeIndex].Expand();
                TreeViewText.Nodes[CurrentSelectedNodeIndex].EnsureVisible();
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
                Int32 CurrentSelectedNodeIndex = TreeViewText.SelectedNode.Index;
                TreeViewText.Nodes.Clear();
                FillFormData();
                TreeViewText.Nodes[CurrentSelectedNodeIndex].Expand();
                TreeViewText.Nodes[CurrentSelectedNodeIndex].EnsureVisible();
            }
        }
        #endregion

        #region btnHelp_Click
        /// <summary>
        /// روال نمایش راهنمایی برای فرم
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            // ToDo: نمایش راهنما تكمیل شود
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            GC.Collect();
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
            FormToolTip.SetSuperTooltip(btnAddNewRootText, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
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
            try
            {
                Table<DocText> TempData = DBLayerIMS.Manager.DBML.DocTexts;
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                _TemplatesCollection = TempData.ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در خواندن اطلاعات قالب مدارك تصویربرداری از بانك اطلاعات!\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            foreach (DocText DocData in _TemplatesCollection)
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
                    TreeViewText.Nodes.Add(node);
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
            foreach (DocText Data in _TemplatesCollection)
            {
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
        }
        #endregion

        #region void AddNewGroup(TreeNode ParentNode)
        /// <summary>
        /// روالی برای افزودن یك گروه متن به لیست
        /// </summary>
        /// <param name="ParentNode">گروه پدر یا تهی برای گروه ریشه</param>
        private void AddNewGroup(TreeNode ParentNode)
        {
            frmDocTextsGroupManage MyForm = new frmDocTextsGroupManage();
            if (MyForm.DialogResult != DialogResult.OK) return;
            DocText NewItem = new DocText();
            NewItem.IsGroup = true;
            if (ParentNode != null) NewItem.ParentIX = Convert.ToInt16(ParentNode.Tag);
            NewItem.Name = MyForm.txtName.Text.Trim().Normalize();
            NewItem.Description = MyForm.txtDescription.Text.Trim().Normalize();
            DBLayerIMS.Manager.DBML.DocTexts.InsertOnSubmit(NewItem);
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان اضافه كردن گروه متن مدرك به بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            TreeNode node = new TreeNode();
            node.Tag = NewItem.ID;
            node.Text = NewItem.Name;
            node.ToolTipText = NewItem.Description;
            node.Checked = true;
            if (ParentNode == null) TreeViewText.Nodes.Add(node);
            else ParentNode.Nodes.Add(node);
            MyForm.Dispose();
        }
        #endregion

        #region void AddNewText(TreeNode ParentNode)
        /// <summary>
        /// روالی برای افزودن یك متن به لیست
        /// </summary>
        /// <param name="ParentNode">متن پدر یا تهی برای متن ریشه</param>
        private void AddNewText(TreeNode ParentNode)
        {
            frmDocTextsManage MyForm = new frmDocTextsManage(null);
            if (MyForm.DialogResult != DialogResult.OK) return;
            DocText NewItem = new DocText();
            NewItem.IsGroup = false;
            NewItem.Name = MyForm.txtName.Text.Trim().Normalize();
            NewItem.Description = MyForm.txtDescription.Text.Trim().Normalize();
            if (ParentNode != null) NewItem.ParentIX = Convert.ToInt16(ParentNode.Tag);
            Int16? TemplateCode = null;
            if (MyForm.txtTextCode.ValueObject != null)
                TemplateCode = Convert.ToInt16(MyForm.txtTextCode.Value);
            NewItem.Code = TemplateCode;
            NewItem.TextsData = MyForm.txtText.Text;
            DBLayerIMS.Manager.DBML.DocTexts.InsertOnSubmit(NewItem);
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان اضافه كردن متن مدرك به بانك اطلاعات ممكن نیست.\n" +
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
            if (ParentNode == null) TreeViewText.Nodes.Add(node);
            else ParentNode.Nodes.Add(node);
            MyForm.Dispose();
            BringToFront();
            Focus();
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
            DocText Temp = DBLayerIMS.Manager.DBML.DocTexts.
                Where(Data => Data.ID == Convert.ToInt16(node.Tag)).ToList().First();
            DBLayerIMS.Manager.DBML.DocTexts.DeleteOnSubmit(Temp);
            if (!DBLayerIMS.Manager.Submit())
            {
                const String ErrorMessage = "امكان حذف متن مدرك از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TreeViewText.Nodes.Remove(node);
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
                DocText BaseItem = DBLayerIMS.Manager.DBML.DocTexts.
                    Where(Data => Data.ID == BaseItemID).First();
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, BaseItem);
                DocText NewItem = new DocText();
                NewItem.ParentIX = TargetParentID;
                NewItem.Code = null;
                NewItem.IsGroup = BaseItem.IsGroup;
                NewItem.Name = BaseItem.Name;
                NewItem.TextsData = BaseItem.TextsData;
                NewItem.Description = BaseItem.Description;
                DBLayerIMS.Manager.DBML.DocTexts.InsertOnSubmit(NewItem);
                DBLayerIMS.Manager.DBML.SubmitChanges();
                return NewItem.ID;
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در كپی برداری آیتم انتخاب شده!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + 
                    Ex.StackTrace, EventLogEntryType.Error);
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
                IQueryable<DocText> Childs = DBLayerIMS.Manager.DBML.DocTexts.
                    Where(Data => Data.ParentIX == BaseItemID);
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, Childs);
                foreach (DocText child in Childs)
                {
                    DocText NewItem = new DocText();
                    NewItem.ParentIX = TargetParentID;
                    NewItem.Code = null;
                    NewItem.IsGroup = child.IsGroup;
                    NewItem.Name = child.Name;
                    NewItem.TextsData = child.TextsData;
                    NewItem.Description = child.Description;
                    DBLayerIMS.Manager.DBML.DocTexts.InsertOnSubmit(NewItem);
                    DBLayerIMS.Manager.DBML.SubmitChanges();
                    CopyTemplateWithChilds(child.ID, NewItem.ID);
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در كپی برداری آیتم انتخاب شده!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Settings", Ex.Message + "\n" + 
                    Ex.StackTrace, EventLogEntryType.Error);
                DBLayerIMS.Manager.DBML = null;
            }
            #endregion
        }
        #endregion

        #endregion

    }
}