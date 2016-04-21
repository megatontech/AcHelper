using System.Drawing;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using HClient.Data;
using HClient.Utils;
using System.Collections.Generic;

namespace HClient
{
    public partial class MainForm : XtraForm
    {
        Dictionary<GROUP, PageGroup> groupsItemDetailPage;
        public MainForm()
        {
            InitializeComponent();
            windowsUIView.AddTileWhenCreatingDocument = DevExpress.Utils.DefaultBoolean.False;
            groupsItemDetailPage = new Dictionary<GROUP, PageGroup>();
            CreateLayout();
        }

        private void CreateLayout()
        {
            SqliteHelper halper = new SqliteHelper();
            GroupManagement gman = new GroupManagement(halper.GetEntity());
            ThreadManagement tman = new ThreadManagement(halper.GetEntity());
            foreach (GROUP group in gman.ListAllGroup())
            {
                tileContainer.Buttons.Add(new DevExpress.XtraBars.Docking2010.WindowsUIButton(group.GROUP_TITLE, null, -1, DevExpress.XtraBars.Docking2010.ImageLocation.AboveText, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, null, true, -1, true, null, false, false, true, null, group, -1, false, false));
                PageGroup pageGroup = new PageGroup();
                pageGroup.Parent = tileContainer;
                pageGroup.Caption = group.GROUP_TITLE;
                windowsUIView.ContentContainers.Add(pageGroup);
                groupsItemDetailPage.Add(group, CreateGroupItemDetailPage(group, pageGroup));
                foreach (THREAD thread in tman.ListAllThreadByGroup(group.GROUP_ID.ToString()))
                {
                    ItemDetailPage itemDetailPage = new ItemDetailPage(thread);
                    itemDetailPage.Dock = System.Windows.Forms.DockStyle.Fill;
                    BaseDocument document = windowsUIView.AddDocument(itemDetailPage);
                    document.Caption = thread.THREAD_TITLE;
                    pageGroup.Items.Add(document as Document);
                    CreateTile(document as Document, thread, group).ActivationTarget = pageGroup;
                }
            }
            windowsUIView.ActivateContainer(tileContainer);
            tileContainer.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(buttonClick);
        }

        private Tile CreateTile(Document document, THREAD thread, GROUP group)
        {
            Tile tile = new Tile();
            tile.Document = document;
            tile.Group = group.GROUP_TITLE;
            tile.Tag = thread;
            tile.Elements.Add(CreateTileItemElement(thread.THREAD_TITLE, TileItemContentAlignment.BottomLeft, Point.Empty, 9));
            tile.Elements.Add(CreateTileItemElement(thread.THREAD_TITLE, TileItemContentAlignment.Manual, new Point(0, 100), 12));
            tile.Appearances.Selected.BackColor = tile.Appearances.Hovered.BackColor = tile.Appearances.Normal.BackColor = Color.FromArgb(140, 140, 140);
            tile.Appearances.Selected.BorderColor = tile.Appearances.Hovered.BorderColor = tile.Appearances.Normal.BorderColor = Color.FromArgb(140, 140, 140);
            tile.Click += new TileClickEventHandler(tile_Click);
            windowsUIView.Tiles.Add(tile);
            tileContainer.Items.Add(tile);
            return tile;
        }

        private TileItemElement CreateTileItemElement(string text, TileItemContentAlignment alignment, Point location, float fontSize)
        {
            TileItemElement element = new TileItemElement();
            element.TextAlignment = alignment;
            if (!location.IsEmpty) element.TextLocation = location;
            element.Appearance.Normal.Options.UseFont = true;
            element.Appearance.Normal.Font = new System.Drawing.Font(new FontFamily("Segoe UI Symbol"), fontSize);
            element.Text = text;
            return element;
        }

        private void tile_Click(object sender, TileClickEventArgs e)
        {
            PageGroup page = ((e.Tile as Tile).ActivationTarget as PageGroup);
            if (page != null)
            {
                page.Parent = tileContainer;
                page.SetSelected((e.Tile as Tile).Document);
            }
        }

        private PageGroup CreateGroupItemDetailPage(GROUP group, PageGroup child)
        {
            GroupDetailPage page = new GroupDetailPage(group, child);
            PageGroup pageGroup = page.PageGroup;
            BaseDocument document = windowsUIView.AddDocument(page);
            pageGroup.Parent = tileContainer;
            pageGroup.Items.Add(document as Document);
            windowsUIView.ContentContainers.Add(pageGroup);
            windowsUIView.ActivateContainer(pageGroup);
            return pageGroup;
        }

        private void buttonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            GROUP tileGroup = (e.Button.Properties.Tag as GROUP);
            if (tileGroup != null)
            {

                windowsUIView.ActivateContainer(groupsItemDetailPage[tileGroup]);
            }
            else 
            {
                HDownLoadForm downloadform = new HDownLoadForm();
                downloadform.Show();
            }
        }
    }
}