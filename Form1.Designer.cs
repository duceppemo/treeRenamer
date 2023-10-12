namespace batchTextReplacer
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
            this.openFileDialogInput = new System.Windows.Forms.OpenFileDialog();
            this.buttonInput = new System.Windows.Forms.Button();
            this.buttonOutput = new System.Windows.Forms.Button();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.labelInput = new System.Windows.Forms.Label();
            this.labelOutput = new System.Windows.Forms.Label();
            this.labelDone = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.saveFileDialogOutput = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDictionary = new System.Windows.Forms.TextBox();
            this.buttonDictionary = new System.Windows.Forms.Button();
            this.openFileDialogDictionary = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxKeepKey = new System.Windows.Forms.CheckBox();
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // openFileDialogInput
            // 
            this.openFileDialogInput.Filter = "Newick Files|*.nwk|Tree Files|*.tree|Text Files|*.txt|All Files|*.*";
            // 
            // buttonInput
            // 
            this.buttonInput.Location = new System.Drawing.Point(282, 47);
            this.buttonInput.Margin = new System.Windows.Forms.Padding(2);
            this.buttonInput.Name = "buttonInput";
            this.buttonInput.Size = new System.Drawing.Size(76, 25);
            this.buttonInput.TabIndex = 0;
            this.buttonInput.Text = "Select";
            this.buttonInput.UseVisualStyleBackColor = true;
            this.buttonInput.Click += new System.EventHandler(this.buttonInput_Click);
            // 
            // buttonOutput
            // 
            this.buttonOutput.Location = new System.Drawing.Point(282, 80);
            this.buttonOutput.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOutput.Name = "buttonOutput";
            this.buttonOutput.Size = new System.Drawing.Size(76, 25);
            this.buttonOutput.TabIndex = 1;
            this.buttonOutput.Text = "Select";
            this.buttonOutput.UseVisualStyleBackColor = true;
            this.buttonOutput.Click += new System.EventHandler(this.buttonOutput_Click);
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(282, 146);
            this.buttonConvert.Margin = new System.Windows.Forms.Padding(2);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(76, 25);
            this.buttonConvert.TabIndex = 2;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(14, 53);
            this.labelInput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(47, 13);
            this.labelInput.TabIndex = 3;
            this.labelInput.Text = "Input file";
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(14, 86);
            this.labelOutput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(55, 13);
            this.labelOutput.TabIndex = 4;
            this.labelOutput.Text = "Output file";
            // 
            // labelDone
            // 
            this.labelDone.AutoSize = true;
            this.labelDone.Location = new System.Drawing.Point(152, 152);
            this.labelDone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDone.Name = "labelDone";
            this.labelDone.Size = new System.Drawing.Size(38, 13);
            this.labelDone.TabIndex = 5;
            this.labelDone.Text = "DONE";
            this.labelDone.Visible = false;
            // 
            // textBoxInput
            // 
            this.textBoxInput.AllowDrop = true;
            this.textBoxInput.Location = new System.Drawing.Point(90, 51);
            this.textBoxInput.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(174, 20);
            this.textBoxInput.TabIndex = 6;
            this.textBoxInput.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxInput_DragDrop);
            this.textBoxInput.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxInput_DragEnter);
            this.textBoxInput.MouseHover += new System.EventHandler(this.textBoxInput_MouseHover);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.AllowDrop = true;
            this.textBoxOutput.Location = new System.Drawing.Point(90, 84);
            this.textBoxOutput.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(174, 20);
            this.textBoxOutput.TabIndex = 7;
            this.textBoxOutput.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxOutput_DragDrop);
            this.textBoxOutput.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxOutput_DragEnter);
            this.textBoxOutput.MouseHover += new System.EventHandler(this.textBoxOutput_MouseHover);
            // 
            // saveFileDialogOutput
            // 
            this.saveFileDialogOutput.Filter = "Newick Files|*.nwk|Tree Files|*.tree|Text Files|*.txt|All Files|*.*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Dictionay file";
            // 
            // textBoxDictionary
            // 
            this.textBoxDictionary.AllowDrop = true;
            this.textBoxDictionary.Location = new System.Drawing.Point(90, 18);
            this.textBoxDictionary.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDictionary.Name = "textBoxDictionary";
            this.textBoxDictionary.Size = new System.Drawing.Size(174, 20);
            this.textBoxDictionary.TabIndex = 9;
            this.textBoxDictionary.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxDictionary_DragDrop);
            this.textBoxDictionary.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxDictionary_DragEnter);
            this.textBoxDictionary.MouseHover += new System.EventHandler(this.textBoxDictionary_MouseHover);
            // 
            // buttonDictionary
            // 
            this.buttonDictionary.Location = new System.Drawing.Point(282, 14);
            this.buttonDictionary.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDictionary.Name = "buttonDictionary";
            this.buttonDictionary.Size = new System.Drawing.Size(76, 25);
            this.buttonDictionary.TabIndex = 10;
            this.buttonDictionary.Text = "Select";
            this.buttonDictionary.UseVisualStyleBackColor = true;
            this.buttonDictionary.Click += new System.EventHandler(this.buttonDictionary_Click);
            // 
            // openFileDialogDictionary
            // 
            this.openFileDialogDictionary.Filter = "Text Files|*.txt|TSV Files|*.tsv|All Files|*.*";
            // 
            // checkBoxKeepKey
            // 
            this.checkBoxKeepKey.AutoSize = true;
            this.checkBoxKeepKey.Location = new System.Drawing.Point(90, 119);
            this.checkBoxKeepKey.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxKeepKey.Name = "checkBoxKeepKey";
            this.checkBoxKeepKey.Size = new System.Drawing.Size(105, 17);
            this.checkBoxKeepKey.TabIndex = 11;
            this.checkBoxKeepKey.Text = "Keep key values";
            this.checkBoxKeepKey.UseVisualStyleBackColor = true;
            this.checkBoxKeepKey.MouseHover += new System.EventHandler(this.checkBox1_MouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 191);
            this.Controls.Add(this.checkBoxKeepKey);
            this.Controls.Add(this.buttonDictionary);
            this.Controls.Add(this.textBoxDictionary);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.labelDone);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.buttonOutput);
            this.Controls.Add(this.buttonInput);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "treeRenamer v0.1.10";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogInput;
        private System.Windows.Forms.Button buttonInput;
        private System.Windows.Forms.Button buttonOutput;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.Label labelDone;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.SaveFileDialog saveFileDialogOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDictionary;
        private System.Windows.Forms.Button buttonDictionary;
        private System.Windows.Forms.OpenFileDialog openFileDialogDictionary;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.CheckBox checkBoxKeepKey;
        private System.Windows.Forms.ToolTip toolTip4;
    }
}

