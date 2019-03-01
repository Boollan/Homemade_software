namespace 打开文件获取路径
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_open = new System.Windows.Forms.Button();
            this.button_folder = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(336, 77);
            this.textBox1.TabIndex = 0;
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(12, 95);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(99, 32);
            this.button_open.TabIndex = 1;
            this.button_open.Text = "获取文件路径";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // button_folder
            // 
            this.button_folder.Location = new System.Drawing.Point(232, 95);
            this.button_folder.Name = "button_folder";
            this.button_folder.Size = new System.Drawing.Size(97, 32);
            this.button_folder.TabIndex = 2;
            this.button_folder.Text = "获取文件夹路径";
            this.button_folder.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 269);
            this.Controls.Add(this.button_folder);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Button button_folder;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

