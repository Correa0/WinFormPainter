using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projectPaint
{
    public partial class frmResult : Form
    {
        public frmResult()
        {
            InitializeComponent();
            graphics = panelResult.CreateGraphics();
        }

        public Graphics graphics;

        private void frmResult_Load(object sender, EventArgs e)
        {

        }
    }
}
