namespace Lab3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxObjects = new ListBox();
            propertyGrid1 = new PropertyGrid();
            comboBoxTypes = new ComboBox();
            btnLoad = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // listBoxObjects
            // 
            listBoxObjects.FormattingEnabled = true;
            listBoxObjects.Location = new Point(28, 12);
            listBoxObjects.Name = "listBoxObjects";
            listBoxObjects.Size = new Size(342, 364);
            listBoxObjects.TabIndex = 0;
            listBoxObjects.SelectedIndexChanged += listBoxObjects_SelectedIndexChanged;
            // 
            // propertyGrid1
            // 
            propertyGrid1.Location = new Point(405, 56);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(383, 361);
            propertyGrid1.TabIndex = 1;
            // 
            // comboBoxTypes
            // 
            comboBoxTypes.FormattingEnabled = true;
            comboBoxTypes.Location = new Point(405, 12);
            comboBoxTypes.Name = "comboBoxTypes";
            comboBoxTypes.Size = new Size(173, 28);
            comboBoxTypes.TabIndex = 2;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(205, 388);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(165, 29);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "Load from XML";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(685, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(585, 11);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(28, 388);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(171, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save to XML";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 429);
            Controls.Add(btnSave);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(btnLoad);
            Controls.Add(comboBoxTypes);
            Controls.Add(propertyGrid1);
            Controls.Add(listBoxObjects);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxObjects;
        private PropertyGrid propertyGrid1;
        private ComboBox comboBoxTypes;
        private Button btnLoad;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnSave;
    }
}
