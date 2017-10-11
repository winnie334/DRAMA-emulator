using ScintillaNET;
namespace DRAMA_Emulator_GUI
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
            this.buttonRun = new System.Windows.Forms.Button();
            this.textEditor = new ScintillaNET.Scintilla();
            this.SuspendLayout();
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(16, 15);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(123, 39);
            this.buttonRun.TabIndex = 1;
            this.buttonRun.Text = "buttonRun";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.ButtonRun_Click);
            // 
            // textEditor
            // 
            this.textEditor.Location = new System.Drawing.Point(16, 79);
            this.textEditor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textEditor.Name = "textEditor";
            this.textEditor.Size = new System.Drawing.Size(789, 803);
            this.textEditor.TabIndex = 2;
            this.textEditor.Text = "scintilla1";
            this.textEditor.Margins[0].Width = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 897);
            this.Controls.Add(this.textEditor);
            this.Controls.Add(this.buttonRun);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonRun;
        private Scintilla textEditor;
    }
}

