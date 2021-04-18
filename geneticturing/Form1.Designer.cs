namespace geneticturing
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new geneticturing.Form1.CustomDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specifyOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteMachineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.placeEncodedMachineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyDecodedMachineToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weightToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.weightToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.weightToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.weightToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.weightToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.weightToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.weightToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.addFoodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGlobalMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMachineToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add50RandomStoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add50RandomFoodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add50RandomGlobalMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.squareinfo = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSaveOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectionLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.populationMaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultAttackDamageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maxFoodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultEatAmountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maxTuringStepsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultStartEnergyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultMutationPercentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultFoodAmountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveMachineAsJFLAPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate New Map";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(0, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.Size = new System.Drawing.Size(672, 312);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 151;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 151;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 151;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 151;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.specifyOutputToolStripMenuItem,
            this.pasteMachineToolStripMenuItem,
            this.placeEncodedMachineToolStripMenuItem,
            this.copyDecodedMachineToClipboardToolStripMenuItem,
            this.addStoneToolStripMenuItem,
            this.addFoodToolStripMenuItem,
            this.addGlobalMemoryToolStripMenuItem,
            this.deleteObjectToolStripMenuItem,
            this.copyMachineToClipboardToolStripMenuItem,
            this.add50RandomStoneToolStripMenuItem,
            this.add50RandomFoodToolStripMenuItem,
            this.add50RandomGlobalMemoryToolStripMenuItem,
            this.saveMachineAsJFLAPToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(272, 334);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.copyToolStripMenuItem.Text = "Copy Machine";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // specifyOutputToolStripMenuItem
            // 
            this.specifyOutputToolStripMenuItem.Name = "specifyOutputToolStripMenuItem";
            this.specifyOutputToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.specifyOutputToolStripMenuItem.Text = "Specify Output";
            this.specifyOutputToolStripMenuItem.Click += new System.EventHandler(this.specifyOutputToolStripMenuItem_Click);
            // 
            // pasteMachineToolStripMenuItem
            // 
            this.pasteMachineToolStripMenuItem.Name = "pasteMachineToolStripMenuItem";
            this.pasteMachineToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.pasteMachineToolStripMenuItem.Text = "Paste Machine";
            this.pasteMachineToolStripMenuItem.Click += new System.EventHandler(this.pasteMachineToolStripMenuItem_Click);
            // 
            // placeEncodedMachineToolStripMenuItem
            // 
            this.placeEncodedMachineToolStripMenuItem.Name = "placeEncodedMachineToolStripMenuItem";
            this.placeEncodedMachineToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.placeEncodedMachineToolStripMenuItem.Text = "Place Encoded Machine";
            this.placeEncodedMachineToolStripMenuItem.Click += new System.EventHandler(this.placeEncodedMachineToolStripMenuItem_Click);
            // 
            // copyDecodedMachineToClipboardToolStripMenuItem
            // 
            this.copyDecodedMachineToClipboardToolStripMenuItem.Name = "copyDecodedMachineToClipboardToolStripMenuItem";
            this.copyDecodedMachineToClipboardToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.copyDecodedMachineToClipboardToolStripMenuItem.Text = "Copy Decoded Machine To Clipboard";
            this.copyDecodedMachineToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyDecodedMachineToClipboardToolStripMenuItem_Click);
            // 
            // addStoneToolStripMenuItem
            // 
            this.addStoneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weightToolStripMenuItem,
            this.weightToolStripMenuItem1,
            this.weightToolStripMenuItem2,
            this.weightToolStripMenuItem3,
            this.weightToolStripMenuItem4,
            this.weightToolStripMenuItem5,
            this.weightToolStripMenuItem6,
            this.weightToolStripMenuItem7});
            this.addStoneToolStripMenuItem.Name = "addStoneToolStripMenuItem";
            this.addStoneToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.addStoneToolStripMenuItem.Text = "Add Stone";
            // 
            // weightToolStripMenuItem
            // 
            this.weightToolStripMenuItem.Name = "weightToolStripMenuItem";
            this.weightToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.weightToolStripMenuItem.Text = "1 Weight";
            this.weightToolStripMenuItem.Click += new System.EventHandler(this.weightToolStripMenuItem_Click);
            // 
            // weightToolStripMenuItem1
            // 
            this.weightToolStripMenuItem1.Name = "weightToolStripMenuItem1";
            this.weightToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.weightToolStripMenuItem1.Text = "2 Weight";
            this.weightToolStripMenuItem1.Click += new System.EventHandler(this.weightToolStripMenuItem1_Click);
            // 
            // weightToolStripMenuItem2
            // 
            this.weightToolStripMenuItem2.Name = "weightToolStripMenuItem2";
            this.weightToolStripMenuItem2.Size = new System.Drawing.Size(121, 22);
            this.weightToolStripMenuItem2.Text = "3 Weight";
            this.weightToolStripMenuItem2.Click += new System.EventHandler(this.weightToolStripMenuItem2_Click);
            // 
            // weightToolStripMenuItem3
            // 
            this.weightToolStripMenuItem3.Name = "weightToolStripMenuItem3";
            this.weightToolStripMenuItem3.Size = new System.Drawing.Size(121, 22);
            this.weightToolStripMenuItem3.Text = "4 Weight";
            this.weightToolStripMenuItem3.Click += new System.EventHandler(this.weightToolStripMenuItem3_Click);
            // 
            // weightToolStripMenuItem4
            // 
            this.weightToolStripMenuItem4.Name = "weightToolStripMenuItem4";
            this.weightToolStripMenuItem4.Size = new System.Drawing.Size(121, 22);
            this.weightToolStripMenuItem4.Text = "5 Weight";
            this.weightToolStripMenuItem4.Click += new System.EventHandler(this.weightToolStripMenuItem4_Click);
            // 
            // weightToolStripMenuItem5
            // 
            this.weightToolStripMenuItem5.Name = "weightToolStripMenuItem5";
            this.weightToolStripMenuItem5.Size = new System.Drawing.Size(121, 22);
            this.weightToolStripMenuItem5.Text = "6 Weight";
            this.weightToolStripMenuItem5.Click += new System.EventHandler(this.weightToolStripMenuItem5_Click);
            // 
            // weightToolStripMenuItem6
            // 
            this.weightToolStripMenuItem6.Name = "weightToolStripMenuItem6";
            this.weightToolStripMenuItem6.Size = new System.Drawing.Size(121, 22);
            this.weightToolStripMenuItem6.Text = "7 Weight";
            this.weightToolStripMenuItem6.Click += new System.EventHandler(this.weightToolStripMenuItem6_Click);
            // 
            // weightToolStripMenuItem7
            // 
            this.weightToolStripMenuItem7.Name = "weightToolStripMenuItem7";
            this.weightToolStripMenuItem7.Size = new System.Drawing.Size(121, 22);
            this.weightToolStripMenuItem7.Text = "8 Weight";
            this.weightToolStripMenuItem7.Click += new System.EventHandler(this.weightToolStripMenuItem7_Click);
            // 
            // addFoodToolStripMenuItem
            // 
            this.addFoodToolStripMenuItem.Name = "addFoodToolStripMenuItem";
            this.addFoodToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.addFoodToolStripMenuItem.Text = "Add Food";
            this.addFoodToolStripMenuItem.Click += new System.EventHandler(this.addFoodToolStripMenuItem_Click);
            // 
            // addGlobalMemoryToolStripMenuItem
            // 
            this.addGlobalMemoryToolStripMenuItem.Name = "addGlobalMemoryToolStripMenuItem";
            this.addGlobalMemoryToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.addGlobalMemoryToolStripMenuItem.Text = "Add Global Memory";
            this.addGlobalMemoryToolStripMenuItem.Click += new System.EventHandler(this.addGlobalMemoryToolStripMenuItem_Click);
            // 
            // deleteObjectToolStripMenuItem
            // 
            this.deleteObjectToolStripMenuItem.Name = "deleteObjectToolStripMenuItem";
            this.deleteObjectToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.deleteObjectToolStripMenuItem.Text = "Delete Object";
            this.deleteObjectToolStripMenuItem.Click += new System.EventHandler(this.deleteObjectToolStripMenuItem_Click);
            // 
            // copyMachineToClipboardToolStripMenuItem
            // 
            this.copyMachineToClipboardToolStripMenuItem.Name = "copyMachineToClipboardToolStripMenuItem";
            this.copyMachineToClipboardToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.copyMachineToClipboardToolStripMenuItem.Text = "Copy Machine To Clipboard";
            this.copyMachineToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyMachineToClipboardToolStripMenuItem_Click);
            // 
            // add50RandomStoneToolStripMenuItem
            // 
            this.add50RandomStoneToolStripMenuItem.Name = "add50RandomStoneToolStripMenuItem";
            this.add50RandomStoneToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.add50RandomStoneToolStripMenuItem.Text = "Add 50 Random Stone";
            this.add50RandomStoneToolStripMenuItem.Click += new System.EventHandler(this.add50RandomStoneToolStripMenuItem_Click);
            // 
            // add50RandomFoodToolStripMenuItem
            // 
            this.add50RandomFoodToolStripMenuItem.Name = "add50RandomFoodToolStripMenuItem";
            this.add50RandomFoodToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.add50RandomFoodToolStripMenuItem.Text = "Add 50 Random Food";
            this.add50RandomFoodToolStripMenuItem.Click += new System.EventHandler(this.add50RandomFoodToolStripMenuItem_Click);
            // 
            // add50RandomGlobalMemoryToolStripMenuItem
            // 
            this.add50RandomGlobalMemoryToolStripMenuItem.Name = "add50RandomGlobalMemoryToolStripMenuItem";
            this.add50RandomGlobalMemoryToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.add50RandomGlobalMemoryToolStripMenuItem.Text = "Add 50 Random Global Memory";
            this.add50RandomGlobalMemoryToolStripMenuItem.Click += new System.EventHandler(this.add50RandomGlobalMemoryToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(277, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 33);
            this.button2.TabIndex = 2;
            this.button2.Text = "Zoom In";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(380, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 33);
            this.button3.TabIndex = 3;
            this.button3.Text = "Zoom Out";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(474, 46);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Advance";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // squareinfo
            // 
            this.squareinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.squareinfo.AutoSize = true;
            this.squareinfo.Location = new System.Drawing.Point(678, 84);
            this.squareinfo.Name = "squareinfo";
            this.squareinfo.Size = new System.Drawing.Size(0, 13);
            this.squareinfo.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(556, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "1";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(737, 42);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "off";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(881, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.autoSaveOffToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // autoSaveOffToolStripMenuItem
            // 
            this.autoSaveOffToolStripMenuItem.Name = "autoSaveOffToolStripMenuItem";
            this.autoSaveOffToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.autoSaveOffToolStripMenuItem.Text = "AutoSave Off";
            this.autoSaveOffToolStripMenuItem.Click += new System.EventHandler(this.autoSaveOffToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detectionLevelToolStripMenuItem,
            this.populationMaxToolStripMenuItem,
            this.defaultAttackDamageToolStripMenuItem,
            this.maxFoodToolStripMenuItem,
            this.defaultEatAmountToolStripMenuItem,
            this.maxTuringStepsToolStripMenuItem,
            this.defaultStartEnergyToolStripMenuItem,
            this.defaultMutationPercentToolStripMenuItem,
            this.defaultFoodAmountToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // detectionLevelToolStripMenuItem
            // 
            this.detectionLevelToolStripMenuItem.Name = "detectionLevelToolStripMenuItem";
            this.detectionLevelToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.detectionLevelToolStripMenuItem.Text = "Detection Level";
            this.detectionLevelToolStripMenuItem.Click += new System.EventHandler(this.detectionLevelToolStripMenuItem_Click);
            // 
            // populationMaxToolStripMenuItem
            // 
            this.populationMaxToolStripMenuItem.Name = "populationMaxToolStripMenuItem";
            this.populationMaxToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.populationMaxToolStripMenuItem.Text = "Population Max";
            this.populationMaxToolStripMenuItem.Click += new System.EventHandler(this.populationMaxToolStripMenuItem_Click);
            // 
            // defaultAttackDamageToolStripMenuItem
            // 
            this.defaultAttackDamageToolStripMenuItem.Name = "defaultAttackDamageToolStripMenuItem";
            this.defaultAttackDamageToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.defaultAttackDamageToolStripMenuItem.Text = "Default Attack Damage";
            this.defaultAttackDamageToolStripMenuItem.Click += new System.EventHandler(this.defaultAttackDamageToolStripMenuItem_Click);
            // 
            // maxFoodToolStripMenuItem
            // 
            this.maxFoodToolStripMenuItem.Name = "maxFoodToolStripMenuItem";
            this.maxFoodToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.maxFoodToolStripMenuItem.Text = "Max Food";
            this.maxFoodToolStripMenuItem.Click += new System.EventHandler(this.maxFoodToolStripMenuItem_Click);
            // 
            // defaultEatAmountToolStripMenuItem
            // 
            this.defaultEatAmountToolStripMenuItem.Name = "defaultEatAmountToolStripMenuItem";
            this.defaultEatAmountToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.defaultEatAmountToolStripMenuItem.Text = "Default Eat Amount";
            this.defaultEatAmountToolStripMenuItem.Click += new System.EventHandler(this.defaultEatAmountToolStripMenuItem_Click);
            // 
            // maxTuringStepsToolStripMenuItem
            // 
            this.maxTuringStepsToolStripMenuItem.Name = "maxTuringStepsToolStripMenuItem";
            this.maxTuringStepsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.maxTuringStepsToolStripMenuItem.Text = "Max Turing Steps";
            this.maxTuringStepsToolStripMenuItem.Click += new System.EventHandler(this.maxTuringStepsToolStripMenuItem_Click);
            // 
            // defaultStartEnergyToolStripMenuItem
            // 
            this.defaultStartEnergyToolStripMenuItem.Name = "defaultStartEnergyToolStripMenuItem";
            this.defaultStartEnergyToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.defaultStartEnergyToolStripMenuItem.Text = "Default Start Energy";
            this.defaultStartEnergyToolStripMenuItem.Click += new System.EventHandler(this.defaultStartEnergyToolStripMenuItem_Click);
            // 
            // defaultMutationPercentToolStripMenuItem
            // 
            this.defaultMutationPercentToolStripMenuItem.Name = "defaultMutationPercentToolStripMenuItem";
            this.defaultMutationPercentToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.defaultMutationPercentToolStripMenuItem.Text = "Default Mutation Percent";
            this.defaultMutationPercentToolStripMenuItem.Click += new System.EventHandler(this.defaultMutationPercentToolStripMenuItem_Click);
            // 
            // defaultFoodAmountToolStripMenuItem
            // 
            this.defaultFoodAmountToolStripMenuItem.Name = "defaultFoodAmountToolStripMenuItem";
            this.defaultFoodAmountToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.defaultFoodAmountToolStripMenuItem.Text = "Default Food Amount";
            this.defaultFoodAmountToolStripMenuItem.Click += new System.EventHandler(this.defaultFoodAmountToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Length:";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(184, 44);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(63, 20);
            this.txtLength.TabIndex = 11;
            this.txtLength.Text = "200";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(184, 64);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(63, 20);
            this.txtWidth.TabIndex = 12;
            this.txtWidth.Text = "200";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Width:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(656, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Auto Advance";
            // 
            // saveMachineAsJFLAPToolStripMenuItem
            // 
            this.saveMachineAsJFLAPToolStripMenuItem.Name = "saveMachineAsJFLAPToolStripMenuItem";
            this.saveMachineAsJFLAPToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.saveMachineAsJFLAPToolStripMenuItem.Text = "Save Machine as JFLAP";
            this.saveMachineAsJFLAPToolStripMenuItem.Click += new System.EventHandler(this.saveMachineAsJFLAPToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 371);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.squareinfo);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Genetic Turing";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        class CustomDataGridView : System.Windows.Forms.DataGridView
        {
            public CustomDataGridView()
            {
                DoubleBuffered = true;
            }
        }

        private System.Windows.Forms.Button button1;
        private CustomDataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label squareinfo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specifyOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteMachineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem placeEncodedMachineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weightToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem weightToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem weightToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem weightToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem weightToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem weightToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem weightToolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem addFoodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGlobalMemoryToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem deleteObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectionLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem populationMaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultAttackDamageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maxFoodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultEatAmountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maxTuringStepsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultStartEnergyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultMutationPercentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultFoodAmountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyDecodedMachineToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyMachineToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem add50RandomStoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem add50RandomFoodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem add50RandomGlobalMemoryToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem autoSaveOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMachineAsJFLAPToolStripMenuItem;
    }
}

