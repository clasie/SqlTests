namespace SqlTests
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
            LoadDataBtn = new Button();
            ResultRequest = new RichTextBox();
            UpdateDataBtn = new Button();
            InsertDataBtn = new Button();
            SuspendLayout();
            // 
            // LoadData
            // 
            LoadDataBtn.Location = new Point(383, 174);
            LoadDataBtn.Name = "LoadData";
            LoadDataBtn.Size = new Size(158, 23);
            LoadDataBtn.TabIndex = 0;
            LoadDataBtn.Text = "LoadData";
            LoadDataBtn.UseVisualStyleBackColor = true;
            LoadDataBtn.Click += LoadDataBtn_Click;
            // 
            // ResultRequest
            // 
            ResultRequest.Location = new Point(35, 33);
            ResultRequest.Name = "ResultRequest";
            ResultRequest.Size = new Size(506, 135);
            ResultRequest.TabIndex = 1;
            ResultRequest.Text = "";
            // 
            // UpdateData
            // 
            UpdateDataBtn.Location = new Point(249, 176);
            UpdateDataBtn.Name = "UpdateData";
            UpdateDataBtn.Size = new Size(105, 23);
            UpdateDataBtn.TabIndex = 2;
            UpdateDataBtn.Text = "UpdateData";
            UpdateDataBtn.UseVisualStyleBackColor = true;
            UpdateDataBtn.Click += UpdateDataBtn_Click;
            // 
            // InsertData
            // 
            InsertDataBtn.Location = new Point(60, 176);
            InsertDataBtn.Name = "InsertDataBtn";
            InsertDataBtn.Size = new Size(114, 23);
            InsertDataBtn.TabIndex = 3;
            InsertDataBtn.Text = "InsertData";
            InsertDataBtn.UseVisualStyleBackColor = true;
            InsertDataBtn.Click += InsertDataBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(InsertDataBtn);
            Controls.Add(UpdateDataBtn);
            Controls.Add(ResultRequest);
            Controls.Add(LoadDataBtn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button LoadDataBtn;
        private RichTextBox ResultRequest;
        private Button UpdateDataBtn;
        private Button InsertDataBtn;
    }
}
