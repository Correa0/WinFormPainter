
namespace projectPaint
{
    partial class frmPaint
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelDraw = new System.Windows.Forms.Panel();
            this.rbLineWidth5 = new System.Windows.Forms.RadioButton();
            this.rbLineWidth10 = new System.Windows.Forms.RadioButton();
            this.rbLineWidth15 = new System.Windows.Forms.RadioButton();
            this.btnColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelDraw
            // 
            this.panelDraw.Location = new System.Drawing.Point(12, 33);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(776, 405);
            this.panelDraw.TabIndex = 0;
            // 
            // rbLineWidth5
            // 
            this.rbLineWidth5.AutoSize = true;
            this.rbLineWidth5.Location = new System.Drawing.Point(13, 10);
            this.rbLineWidth5.Name = "rbLineWidth5";
            this.rbLineWidth5.Size = new System.Drawing.Size(31, 17);
            this.rbLineWidth5.TabIndex = 1;
            this.rbLineWidth5.TabStop = true;
            this.rbLineWidth5.Text = "5";
            this.rbLineWidth5.UseVisualStyleBackColor = true;
            // 
            // rbLineWidth10
            // 
            this.rbLineWidth10.AutoSize = true;
            this.rbLineWidth10.Location = new System.Drawing.Point(50, 10);
            this.rbLineWidth10.Name = "rbLineWidth10";
            this.rbLineWidth10.Size = new System.Drawing.Size(37, 17);
            this.rbLineWidth10.TabIndex = 1;
            this.rbLineWidth10.TabStop = true;
            this.rbLineWidth10.Text = "10";
            this.rbLineWidth10.UseVisualStyleBackColor = true;
            // 
            // rbLineWidth15
            // 
            this.rbLineWidth15.AutoSize = true;
            this.rbLineWidth15.Location = new System.Drawing.Point(93, 10);
            this.rbLineWidth15.Name = "rbLineWidth15";
            this.rbLineWidth15.Size = new System.Drawing.Size(37, 17);
            this.rbLineWidth15.TabIndex = 1;
            this.rbLineWidth15.TabStop = true;
            this.rbLineWidth15.Text = "15";
            this.rbLineWidth15.UseVisualStyleBackColor = true;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(151, 7);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 2;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // frmPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.rbLineWidth15);
            this.Controls.Add(this.rbLineWidth10);
            this.Controls.Add(this.rbLineWidth5);
            this.Controls.Add(this.panelDraw);
            this.Name = "frmPaint";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDraw;
        private System.Windows.Forms.RadioButton rbLineWidth5;
        private System.Windows.Forms.RadioButton rbLineWidth10;
        private System.Windows.Forms.RadioButton rbLineWidth15;
        private System.Windows.Forms.Button btnColor;
    }
}

