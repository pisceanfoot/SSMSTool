using BrightIdeasSoftware;
namespace SSMSTool.CodeSnippet
{
    partial class CodeSnippetEditorFrm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtBoxCode = new System.Windows.Forms.RichTextBox();
            this.ButtonEnable = new System.Windows.Forms.RadioButton();
            this.ButtonDisable = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnRemvoe = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 414);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.olvColumn1);
            this.listView.AllColumns.Add(this.olvColumn2);
            this.listView.AllColumns.Add(this.olvColumn3);
            this.listView.AllowColumnReorder = true;
            this.listView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.listView.CellEditEnterChangesRows = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(3, 16);
            this.listView.Name = "listView";
            this.listView.OwnerDraw = true;
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(186, 395);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_ItemSelectionChanged);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Shortcut";
            this.olvColumn1.Text = "Shortcut";
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Content";
            this.olvColumn2.IsEditable = false;
            this.olvColumn2.Text = "Code";
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Active";
            this.olvColumn3.CheckBoxes = true;
            this.olvColumn3.HeaderCheckBox = true;
            this.olvColumn3.Text = "A";
            this.olvColumn3.ToolTipText = "Active";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtBoxCode);
            this.groupBox2.Location = new System.Drawing.Point(210, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(544, 344);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // TxtBoxCode
            // 
            this.TxtBoxCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBoxCode.Location = new System.Drawing.Point(3, 16);
            this.TxtBoxCode.Name = "TxtBoxCode";
            this.TxtBoxCode.Size = new System.Drawing.Size(538, 325);
            this.TxtBoxCode.TabIndex = 0;
            this.TxtBoxCode.Text = "";
            this.TxtBoxCode.TextChanged += new System.EventHandler(this.TxtBoxCode_TextChanged);
            // 
            // ButtonEnable
            // 
            this.ButtonEnable.AutoSize = true;
            this.ButtonEnable.Location = new System.Drawing.Point(31, 23);
            this.ButtonEnable.Name = "ButtonEnable";
            this.ButtonEnable.Size = new System.Drawing.Size(58, 17);
            this.ButtonEnable.TabIndex = 2;
            this.ButtonEnable.TabStop = true;
            this.ButtonEnable.Text = "Enable";
            this.ButtonEnable.UseVisualStyleBackColor = true;
            // 
            // ButtonDisable
            // 
            this.ButtonDisable.AutoSize = true;
            this.ButtonDisable.Location = new System.Drawing.Point(106, 23);
            this.ButtonDisable.Name = "ButtonDisable";
            this.ButtonDisable.Size = new System.Drawing.Size(60, 17);
            this.ButtonDisable.TabIndex = 2;
            this.ButtonDisable.TabStop = true;
            this.ButtonDisable.Text = "Disable";
            this.ButtonDisable.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ButtonDisable);
            this.groupBox3.Controls.Add(this.ButtonEnable);
            this.groupBox3.Location = new System.Drawing.Point(213, 372);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(544, 54);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Enable feature";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(554, 451);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(656, 451);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 3;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(15, 430);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(29, 23);
            this.BtnAdd.TabIndex = 4;
            this.BtnAdd.Text = "+";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnRemvoe
            // 
            this.BtnRemvoe.Location = new System.Drawing.Point(50, 430);
            this.BtnRemvoe.Name = "BtnRemvoe";
            this.BtnRemvoe.Size = new System.Drawing.Size(31, 23);
            this.BtnRemvoe.TabIndex = 4;
            this.BtnRemvoe.Text = "-";
            this.BtnRemvoe.UseVisualStyleBackColor = true;
            this.BtnRemvoe.Click += new System.EventHandler(this.BtnRemvoe_Click);
            // 
            // CodeSnippetEditorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 496);
            this.Controls.Add(this.BtnRemvoe);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CodeSnippetEditorFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.CodeSnippetEditorFrm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton ButtonEnable;
        private System.Windows.Forms.RadioButton ButtonDisable;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.RichTextBox TxtBoxCode;
        private ObjectListView listView;
        private OLVColumn olvColumn1;
        private OLVColumn olvColumn2;
        private OLVColumn olvColumn3;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnRemvoe;
    }
}