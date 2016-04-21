using System;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using HClient.Data;

namespace HClient
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public partial class GroupItemDetailPage : DevExpress.XtraEditors.XtraUserControl
    {
        private PageGroup pageGroupCore;
        private int indexCore;

        public GroupItemDetailPage(THREAD item, PageGroup child, int index)
        {
            InitializeComponent();
            pageGroupCore = child;
            indexCore = index;
            labelTitle.Text = item.THREAD_TITLE;
            labelSubtitle.Text = item.THREAD_TIME;
            imageControl.Image = DevExpress.Utils.ResourceImageHelper.CreateImageFromResources(item.THREAD_IMG, typeof(ItemDetailPage).Assembly);
            labelDescription.Text = item.THREAD_CONTENT;
        }

        private void imageControlClick(object sender, EventArgs e)
        {
            BaseContentContainer documentContainer = pageGroupCore.Parent as BaseContentContainer;
            if (documentContainer != null) ActivateContainer(documentContainer.Manager);
        }

        private void ActivateContainer(DocumentManager manager)
        {
            WindowsUIView view = manager.View as WindowsUIView;
            if (view != null)
            {
                pageGroupCore.Parent = this.Tag as IContentContainer;
                pageGroupCore.SetSelected(pageGroupCore.Items[indexCore]);
                view.ActivateContainer(pageGroupCore);
            }
        }
    }
}