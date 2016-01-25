using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using Article.baseUtils;

namespace Article
{
    public partial class Splash : SplashScreen
    {
        public Splash()
        {
            this.ShowMode = DevExpress.XtraSplashScreen.ShowMode.Form;
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {

        }
        /// <summary>
        /// 测试数据库连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Splash_Load(object sender, EventArgs e)
        {
            try
            {
                SqlLiteConn conn = new SqlLiteConn();
                conn.getConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库迷之消失:"+ex.Message); 
            }
            return;
        }
    }
}