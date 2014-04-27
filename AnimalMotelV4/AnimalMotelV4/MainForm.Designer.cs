namespace AnimalMotelV4
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtName = new System.Windows.Forms.TextBox();
            this.lstBoxAnimalObject = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtImportantInfo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstBoxGender = new System.Windows.Forms.ListBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblAnimalObject = new System.Windows.Forms.Label();
            this.lblImportantInfo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImageLoad = new System.Windows.Forms.Button();
            this.checkBoxListAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddAnimal = new System.Windows.Forms.Button();
            this.grpBoxSpecs = new System.Windows.Forms.GroupBox();
            this.checkBoxUnderQuarantine = new System.Windows.Forms.CheckBox();
            this.lblDaisInQuarantine = new System.Windows.Forms.Label();
            this.txtDaysInQarantine = new System.Windows.Forms.TextBox();
            this.txtSpecificData = new System.Windows.Forms.TextBox();
            this.lblCommonData = new System.Windows.Forms.Label();
            this.lstBoxCategory = new System.Windows.Forms.ListBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lvRegisteredAnimals = new System.Windows.Forms.ListView();
            this.lblSpecialData = new System.Windows.Forms.Label();
            this.txtSpecialData = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tlStrMenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tlStrMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tlStrMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tlStrMenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlStrMenuItemXML = new System.Windows.Forms.ToolStripMenuItem();
            this.tlStrMenuItemImportFromXML = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tlStrMenuItemExportToXML = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlStrMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpBoxSpecs.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(50, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(131, 20);
            this.txtName.TabIndex = 0;
            // 
            // lstBoxAnimalObject
            // 
            this.lstBoxAnimalObject.FormattingEnabled = true;
            this.lstBoxAnimalObject.Location = new System.Drawing.Point(370, 34);
            this.lstBoxAnimalObject.Name = "lstBoxAnimalObject";
            this.lstBoxAnimalObject.Size = new System.Drawing.Size(148, 225);
            this.lstBoxAnimalObject.TabIndex = 4;
            this.lstBoxAnimalObject.SelectedIndexChanged += new System.EventHandler(this.lstBoxAnimalObject_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(528, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 129);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(7, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Name";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(10, 72);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(26, 13);
            this.lblAge.TabIndex = 10;
            this.lblAge.Text = "Age";
            // 
            // txtImportantInfo
            // 
            this.txtImportantInfo.Location = new System.Drawing.Point(682, 36);
            this.txtImportantInfo.Multiline = true;
            this.txtImportantInfo.Name = "txtImportantInfo";
            this.txtImportantInfo.Size = new System.Drawing.Size(146, 223);
            this.txtImportantInfo.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstBoxGender);
            this.groupBox2.Location = new System.Drawing.Point(13, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 91);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gender";
            // 
            // lstBoxGender
            // 
            this.lstBoxGender.FormattingEnabled = true;
            this.lstBoxGender.Location = new System.Drawing.Point(9, 19);
            this.lstBoxGender.Name = "lstBoxGender";
            this.lstBoxGender.Size = new System.Drawing.Size(159, 56);
            this.lstBoxGender.TabIndex = 2;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(248, 14);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 13;
            this.lblCategory.Text = "Category";
            // 
            // lblAnimalObject
            // 
            this.lblAnimalObject.AutoSize = true;
            this.lblAnimalObject.Location = new System.Drawing.Point(408, 14);
            this.lblAnimalObject.Name = "lblAnimalObject";
            this.lblAnimalObject.Size = new System.Drawing.Size(72, 13);
            this.lblAnimalObject.TabIndex = 14;
            this.lblAnimalObject.Text = "Animal Object";
            // 
            // lblImportantInfo
            // 
            this.lblImportantInfo.AutoSize = true;
            this.lblImportantInfo.Location = new System.Drawing.Point(721, 14);
            this.lblImportantInfo.Name = "lblImportantInfo";
            this.lblImportantInfo.Size = new System.Drawing.Size(72, 13);
            this.lblImportantInfo.TabIndex = 15;
            this.lblImportantInfo.Text = "Important Info";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnImageLoad);
            this.groupBox1.Controls.Add(this.checkBoxListAll);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAddAnimal);
            this.groupBox1.Controls.Add(this.grpBoxSpecs);
            this.groupBox1.Controls.Add(this.lblImportantInfo);
            this.groupBox1.Controls.Add(this.lblAnimalObject);
            this.groupBox1.Controls.Add(this.lblCategory);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtImportantInfo);
            this.groupBox1.Controls.Add(this.lblAge);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.lstBoxAnimalObject);
            this.groupBox1.Controls.Add(this.lstBoxCategory);
            this.groupBox1.Controls.Add(this.txtAge);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(856, 332);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Animal Specifications";
            // 
            // btnImageLoad
            // 
            this.btnImageLoad.Location = new System.Drawing.Point(546, 183);
            this.btnImageLoad.Name = "btnImageLoad";
            this.btnImageLoad.Size = new System.Drawing.Size(115, 37);
            this.btnImageLoad.TabIndex = 20;
            this.btnImageLoad.Text = "Image Load";
            this.btnImageLoad.UseVisualStyleBackColor = true;
            this.btnImageLoad.Click += new System.EventHandler(this.btnImageLoad_Click);
            // 
            // checkBoxListAll
            // 
            this.checkBoxListAll.AutoSize = true;
            this.checkBoxListAll.Location = new System.Drawing.Point(524, 242);
            this.checkBoxListAll.Name = "checkBoxListAll";
            this.checkBoxListAll.Size = new System.Drawing.Size(93, 17);
            this.checkBoxListAll.TabIndex = 19;
            this.checkBoxListAll.Text = "List all animals";
            this.checkBoxListAll.UseVisualStyleBackColor = true;
            this.checkBoxListAll.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(525, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Animal Photo";
            // 
            // btnAddAnimal
            // 
            this.btnAddAnimal.Location = new System.Drawing.Point(370, 272);
            this.btnAddAnimal.Name = "btnAddAnimal";
            this.btnAddAnimal.Size = new System.Drawing.Size(148, 34);
            this.btnAddAnimal.TabIndex = 17;
            this.btnAddAnimal.Text = "Add animal";
            this.btnAddAnimal.UseVisualStyleBackColor = true;
            this.btnAddAnimal.Click += new System.EventHandler(this.btnAddAnimal_Click);
            // 
            // grpBoxSpecs
            // 
            this.grpBoxSpecs.Controls.Add(this.checkBoxUnderQuarantine);
            this.grpBoxSpecs.Controls.Add(this.lblDaisInQuarantine);
            this.grpBoxSpecs.Controls.Add(this.txtDaysInQarantine);
            this.grpBoxSpecs.Controls.Add(this.txtSpecificData);
            this.grpBoxSpecs.Controls.Add(this.lblCommonData);
            this.grpBoxSpecs.Location = new System.Drawing.Point(13, 227);
            this.grpBoxSpecs.Name = "grpBoxSpecs";
            this.grpBoxSpecs.Size = new System.Drawing.Size(333, 79);
            this.grpBoxSpecs.TabIndex = 16;
            this.grpBoxSpecs.TabStop = false;
            this.grpBoxSpecs.Text = "Mammal Specifications";
            // 
            // checkBoxUnderQuarantine
            // 
            this.checkBoxUnderQuarantine.AutoSize = true;
            this.checkBoxUnderQuarantine.Location = new System.Drawing.Point(21, 56);
            this.checkBoxUnderQuarantine.Name = "checkBoxUnderQuarantine";
            this.checkBoxUnderQuarantine.Size = new System.Drawing.Size(110, 17);
            this.checkBoxUnderQuarantine.TabIndex = 5;
            this.checkBoxUnderQuarantine.Text = "Under Quarantine";
            this.checkBoxUnderQuarantine.UseVisualStyleBackColor = true;
            this.checkBoxUnderQuarantine.CheckedChanged += new System.EventHandler(this.checkBoxUnderQuarantine_CheckedChanged);
            // 
            // lblDaisInQuarantine
            // 
            this.lblDaisInQuarantine.AutoSize = true;
            this.lblDaisInQuarantine.Location = new System.Drawing.Point(150, 55);
            this.lblDaisInQuarantine.Name = "lblDaisInQuarantine";
            this.lblDaisInQuarantine.Size = new System.Drawing.Size(97, 13);
            this.lblDaisInQuarantine.TabIndex = 4;
            this.lblDaisInQuarantine.Text = "Days in Quarantine";
            // 
            // txtDaysInQarantine
            // 
            this.txtDaysInQarantine.Location = new System.Drawing.Point(253, 52);
            this.txtDaysInQarantine.Name = "txtDaysInQarantine";
            this.txtDaysInQarantine.Size = new System.Drawing.Size(61, 20);
            this.txtDaysInQarantine.TabIndex = 3;
            // 
            // txtSpecificData
            // 
            this.txtSpecificData.Location = new System.Drawing.Point(120, 26);
            this.txtSpecificData.Name = "txtSpecificData";
            this.txtSpecificData.Size = new System.Drawing.Size(70, 20);
            this.txtSpecificData.TabIndex = 1;
            // 
            // lblCommonData
            // 
            this.lblCommonData.AutoSize = true;
            this.lblCommonData.Location = new System.Drawing.Point(18, 29);
            this.lblCommonData.Name = "lblCommonData";
            this.lblCommonData.Size = new System.Drawing.Size(63, 13);
            this.lblCommonData.TabIndex = 0;
            this.lblCommonData.Text = "No. of teeth";
            // 
            // lstBoxCategory
            // 
            this.lstBoxCategory.FormattingEnabled = true;
            this.lstBoxCategory.Location = new System.Drawing.Point(200, 34);
            this.lstBoxCategory.Name = "lstBoxCategory";
            this.lstBoxCategory.Size = new System.Drawing.Size(159, 186);
            this.lstBoxCategory.TabIndex = 3;
            this.lstBoxCategory.SelectedIndexChanged += new System.EventHandler(this.lstBoxCategory_SelectedIndexChanged);
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(83, 69);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(98, 20);
            this.txtAge.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lvRegisteredAnimals);
            this.groupBox4.Controls.Add(this.lblSpecialData);
            this.groupBox4.Controls.Add(this.txtSpecialData);
            this.groupBox4.Location = new System.Drawing.Point(21, 380);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(847, 188);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "List of registered animals with general data";
            // 
            // lvRegisteredAnimals
            // 
            this.lvRegisteredAnimals.Location = new System.Drawing.Point(13, 19);
            this.lvRegisteredAnimals.Name = "lvRegisteredAnimals";
            this.lvRegisteredAnimals.Size = new System.Drawing.Size(403, 158);
            this.lvRegisteredAnimals.TabIndex = 7;
            this.lvRegisteredAnimals.UseCompatibleStateImageBehavior = false;
            // 
            // lblSpecialData
            // 
            this.lblSpecialData.AutoSize = true;
            this.lblSpecialData.Location = new System.Drawing.Point(427, 28);
            this.lblSpecialData.Name = "lblSpecialData";
            this.lblSpecialData.Size = new System.Drawing.Size(68, 13);
            this.lblSpecialData.TabIndex = 6;
            this.lblSpecialData.Text = "Special Data";
            // 
            // txtSpecialData
            // 
            this.txtSpecialData.Location = new System.Drawing.Point(430, 44);
            this.txtSpecialData.Multiline = true;
            this.txtSpecialData.Name = "txtSpecialData";
            this.txtSpecialData.Size = new System.Drawing.Size(389, 134);
            this.txtSpecialData.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(888, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlStrMenuItemNew,
            this.tlStrMenuItemOpen,
            this.tlStrMenuItemSave,
            this.tlStrMenuItemSaveAs,
            this.toolStripSeparator5,
            this.tlStrMenuItemXML,
            this.toolStripSeparator6,
            this.toolStripMenuItem1,
            this.tlStrMenuItemExit});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // tlStrMenuItemNew
            // 
            this.tlStrMenuItemNew.Name = "tlStrMenuItemNew";
            this.tlStrMenuItemNew.Size = new System.Drawing.Size(122, 22);
            this.tlStrMenuItemNew.Text = "New";
            this.tlStrMenuItemNew.Click += new System.EventHandler(this.tlStrMenuItemNew_Click);
            // 
            // tlStrMenuItemOpen
            // 
            this.tlStrMenuItemOpen.Name = "tlStrMenuItemOpen";
            this.tlStrMenuItemOpen.Size = new System.Drawing.Size(122, 22);
            this.tlStrMenuItemOpen.Text = "Open...";
            this.tlStrMenuItemOpen.Click += new System.EventHandler(this.tlStrMenuItemOpen_Click);
            // 
            // tlStrMenuItemSave
            // 
            this.tlStrMenuItemSave.Name = "tlStrMenuItemSave";
            this.tlStrMenuItemSave.Size = new System.Drawing.Size(122, 22);
            this.tlStrMenuItemSave.Text = "Save";
            this.tlStrMenuItemSave.Click += new System.EventHandler(this.tlStrMenuItemSave_Click);
            // 
            // tlStrMenuItemSaveAs
            // 
            this.tlStrMenuItemSaveAs.Name = "tlStrMenuItemSaveAs";
            this.tlStrMenuItemSaveAs.Size = new System.Drawing.Size(122, 22);
            this.tlStrMenuItemSaveAs.Text = "Save as...";
            this.tlStrMenuItemSaveAs.Click += new System.EventHandler(this.tlStrMenuItemSaveAs_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(119, 6);
            // 
            // tlStrMenuItemXML
            // 
            this.tlStrMenuItemXML.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlStrMenuItemImportFromXML,
            this.toolStripSeparator7,
            this.tlStrMenuItemExportToXML});
            this.tlStrMenuItemXML.Name = "tlStrMenuItemXML";
            this.tlStrMenuItemXML.Size = new System.Drawing.Size(122, 22);
            this.tlStrMenuItemXML.Text = "XML";
            // 
            // tlStrMenuItemImportFromXML
            // 
            this.tlStrMenuItemImportFromXML.Name = "tlStrMenuItemImportFromXML";
            this.tlStrMenuItemImportFromXML.Size = new System.Drawing.Size(187, 22);
            this.tlStrMenuItemImportFromXML.Text = "Import from XML File";
            this.tlStrMenuItemImportFromXML.Click += new System.EventHandler(this.tlStrMenuItemImportFromXML_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(184, 6);
            // 
            // tlStrMenuItemExportToXML
            // 
            this.tlStrMenuItemExportToXML.Name = "tlStrMenuItemExportToXML";
            this.tlStrMenuItemExportToXML.Size = new System.Drawing.Size(187, 22);
            this.tlStrMenuItemExportToXML.Text = "Export to XML File";
            this.tlStrMenuItemExportToXML.Click += new System.EventHandler(this.tlStrMenuItemExportToXML_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(119, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDataToolStripMenuItem,
            this.loadDataToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem1.Text = "Database";
            // 
            // saveDataToolStripMenuItem
            // 
            this.saveDataToolStripMenuItem.Name = "saveDataToolStripMenuItem";
            this.saveDataToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.saveDataToolStripMenuItem.Text = "Save Data";
            this.saveDataToolStripMenuItem.Click += new System.EventHandler(this.saveDataToolStripMenuItem_Click);
            // 
            // loadDataToolStripMenuItem
            // 
            this.loadDataToolStripMenuItem.Name = "loadDataToolStripMenuItem";
            this.loadDataToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.loadDataToolStripMenuItem.Text = "Load Data";
            this.loadDataToolStripMenuItem.Click += new System.EventHandler(this.loadDataToolStripMenuItem_Click);
            // 
            // tlStrMenuItemExit
            // 
            this.tlStrMenuItemExit.Name = "tlStrMenuItemExit";
            this.tlStrMenuItemExit.Size = new System.Drawing.Size(122, 22);
            this.tlStrMenuItemExit.Text = "Exit";
            this.tlStrMenuItemExit.Click += new System.EventHandler(this.tlStrMenuItemExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem9});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton2.Text = "Help";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem9.Text = "About";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(888, 588);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Form1";
            //this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpBoxSpecs.ResumeLayout(false);
            this.grpBoxSpecs.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ListBox lstBoxAnimalObject;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtImportantInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstBoxGender;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblAnimalObject;
        private System.Windows.Forms.Label lblImportantInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddAnimal;
        private System.Windows.Forms.GroupBox grpBoxSpecs;
        private System.Windows.Forms.CheckBox checkBoxUnderQuarantine;
        private System.Windows.Forms.Label lblDaisInQuarantine;
        private System.Windows.Forms.TextBox txtDaysInQarantine;
        private System.Windows.Forms.TextBox txtSpecificData;
        private System.Windows.Forms.Label lblCommonData;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBoxListAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSpecialData;
        private System.Windows.Forms.TextBox txtSpecialData;
        private System.Windows.Forms.Button btnImageLoad;
        private System.Windows.Forms.ListBox lstBoxCategory;
        private System.Windows.Forms.ListView lvRegisteredAnimals;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem tlStrMenuItemNew;
        private System.Windows.Forms.ToolStripMenuItem tlStrMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem tlStrMenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem tlStrMenuItemSaveAs;
        private System.Windows.Forms.ToolStripMenuItem tlStrMenuItemXML;
        private System.Windows.Forms.ToolStripMenuItem tlStrMenuItemExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem tlStrMenuItemImportFromXML;
        private System.Windows.Forms.ToolStripMenuItem tlStrMenuItemExportToXML;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataToolStripMenuItem;

    }
}

