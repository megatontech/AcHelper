using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Article.baseUtils;
using System.Threading;

namespace Article.forms
{
    public partial class CommentBox : Form
    {
        private WebUtil webutil = new WebUtil();
        private Point currPos, newPos, fromPos, fromNewPos;
        private bool IsMouseDown = false;
        public CommentBox()
        {
            InitializeComponent();
        }
        private void fileSaveItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        private void BindData()
        {
        }
        private void commentBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //确定当前位置
                IsMouseDown = true;
                currPos = Control.MousePosition;
                fromPos = Location;
            }
        }

        private void commentBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                //确定新位置
                newPos = Control.MousePosition;
                //
                fromNewPos.X = newPos.X - currPos.X + fromPos.X;
                fromNewPos.Y = newPos.Y - currPos.Y + fromPos.Y;
                Location = fromNewPos;
                fromPos = fromNewPos;
                currPos = newPos;
            }
        }

        private void commentBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsMouseDown = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = webutil.comment(textBox1.Text, this.richEditControl.Text, webutil.cookiec);
            MessageBox.Show(s1);
            this.Close();
        }

    }
}
