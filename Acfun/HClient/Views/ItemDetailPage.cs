using DevExpress.XtraEditors;
using HClient.Data;

namespace HClient
{
    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    public partial class ItemDetailPage : XtraUserControl
    {
        public ItemDetailPage(THREAD thread)
        {
            InitializeComponent();
            labelTitle.Text = thread.THREAD_TITLE;
            labelSubtitle.Text = thread.THREAD_TIME;
            //imageControl.Image = DevExpress.Utils.ResourceImageHelper.CreateImageFromResources(thread.THREAD_IMG, typeof(ItemDetailPage).Assembly);
            labelContent.Text = thread.THREAD_CONTENT;
        }
    }
}