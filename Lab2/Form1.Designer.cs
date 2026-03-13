namespace Lab2
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
            canvasPanel = new Panel();
            shapeComboBox = new ComboBox();
            label1 = new Label();
            colorButton = new Button();
            clearButton = new Button();
            shapesListBox = new ListBox();
            label2 = new Label();
            deleteButton = new Button();
            SuspendLayout();
            // 
            // canvasPanel
            // 
            canvasPanel.BackColor = Color.White;
            canvasPanel.Location = new Point(307, 0);
            canvasPanel.Name = "canvasPanel";
            canvasPanel.Size = new Size(728, 580);
            canvasPanel.TabIndex = 0;
            // 
            // shapeComboBox
            // 
            shapeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            shapeComboBox.FormattingEnabled = true;
            shapeComboBox.Location = new Point(11, 46);
            shapeComboBox.Name = "shapeComboBox";
            shapeComboBox.Size = new Size(151, 28);
            shapeComboBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 181);
            label1.Name = "label1";
            label1.Size = new Size(128, 20);
            label1.TabIndex = 2;
            label1.Text = "Select shape type:";
            // 
            // colorButton
            // 
            colorButton.Location = new Point(11, 86);
            colorButton.Name = "colorButton";
            colorButton.Size = new Size(151, 29);
            colorButton.TabIndex = 3;
            colorButton.Text = "Choose color";
            colorButton.UseVisualStyleBackColor = true;
            colorButton.Click += ColorButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(11, 126);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(151, 29);
            clearButton.TabIndex = 4;
            clearButton.Text = "Clear canvas";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += ClearButton_Click;
            // 
            // shapesListBox
            // 
            shapesListBox.FormattingEnabled = true;
            shapesListBox.Location = new Point(12, 204);
            shapesListBox.Name = "shapesListBox";
            shapesListBox.Size = new Size(273, 304);
            shapesListBox.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 11);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 6;
            label2.Text = "Created shapes:";
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(11, 527);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(274, 29);
            deleteButton.TabIndex = 7;
            deleteButton.Text = "Delete selected";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += DeleteButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 581);
            Controls.Add(deleteButton);
            Controls.Add(label2);
            Controls.Add(shapesListBox);
            Controls.Add(clearButton);
            Controls.Add(colorButton);
            Controls.Add(label1);
            Controls.Add(shapeComboBox);
            Controls.Add(canvasPanel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel canvasPanel;
        private ComboBox shapeComboBox;
        private Label label1;
        private Button colorButton;
        private Button clearButton;
        private ListBox shapesListBox;
        private Label label2;
        private Button deleteButton;
    }
}
