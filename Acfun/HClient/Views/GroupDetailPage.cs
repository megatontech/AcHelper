using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using HClient.Data;

namespace HClient
{
    /// <summary>
    /// A page that displays an overview of a single group, including a preview of the items
    /// within the group.
    /// </summary>
    public partial class GroupDetailPage : XtraUserControl
    {
        private PageGroup pageGroupCore;

        public PageGroup PageGroup { get { return pageGroupCore; } }

        public GroupDetailPage(GROUP dataGroup, PageGroup child)
        {
            InitializeComponent();
            pageGroupCore = new PageGroup();
            pageGroupCore.Caption = dataGroup.GROUP_TITLE;
            //imgpath:typeof(MainForm).Namespace + ".Resources.1.jpg"
            imageControl.Image = DevExpress.Utils.ResourceImageHelper.CreateImageFromResources(typeof(MainForm).Namespace + ".Assets." + dataGroup.GROUP_IMG, typeof(MainForm).Assembly);
            labelDescription.Text = dataGroup.GROUP_META.ToString();
            CreateLayout(dataGroup, child);
        }

        private void CreateLayout(GROUP dataGroup, PageGroup child)
        {
            //for (int i = 0; i < dataGroup.Items.Count; i++)
            //    CreateLayoutCore(dataGroup.Items[i], child, i);
        }

        private void CreateLayoutCore(THREAD item, PageGroup child, int index)
        {
            //((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            //DevExpress.XtraLayout.LayoutControlItem layoutTileItem = new DevExpress.XtraLayout.LayoutControlItem();
            //GroupItemDetailPage page = new GroupItemDetailPage(item, child, index);
            //page.Tag = pageGroupCore;
            //layoutTileItem.Control = page;
            //layoutTileItem.Location = new System.Drawing.Point(0, 0);
            //layoutTileItem.MinSize = new System.Drawing.Size(winLayoutControl1.Width, page.Height);
            //layoutTileItem.MaxSize = new System.Drawing.Size(0, page.Height);
            //layoutTileItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            //layoutTileItem.TextSize = new System.Drawing.Size(0, 0);
            //layoutTileItem.TextToControlDistance = 0;
            //layoutTileItem.TextVisible = false;
            //layoutControlGroup2.Add(layoutTileItem);
            //((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
        }
    }
}