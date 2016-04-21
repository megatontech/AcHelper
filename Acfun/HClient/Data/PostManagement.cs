using System.Data;
using System.Linq;

namespace HClient.Data
{
    internal class PostManagement
    {
       private static DBEntities db = null;

        public static DBEntities Db
        {
            get { return PostManagement.db; }
            set { PostManagement.db = value; }
        }
        public PostManagement(DBEntities dbe) 
        {
            db = dbe;
        }
        public void CreatePOST(POST post)
        {
            db.POST.AddObject(post);
            db.SaveChanges();

        }

        public void DelPOST(string POSTid)
        {
            System.Guid id = System.Guid.Parse(POSTid);
            POST POST = new POST();
            POST.POST_ID = id;
            if (id != null)
            {
                db.ObjectStateManager.ChangeObjectState(POST, EntityState.Deleted);
                db.SaveChanges();
            }
        }

        public void UpdatePOST(POST POST)
        {
            db.POST.Attach(POST);
            db.ObjectStateManager.ChangeObjectState(POST, EntityState.Modified);
            db.SaveChanges();
        }

        public IQueryable<POST> ListAllPOST()
        {
            IQueryable<POST> POSTList = from g in db.POST
                                        where g.POST_ID.ToString().Length > 0
                                        select g;
            return POSTList;
        }
        public IQueryable<POST> ListAllPOSTByThread(string threadid)
        {
            IQueryable<POST> POSTList = from g in db.POST
                                        where g.THREAD_ID == threadid
                                        select g;
            return POSTList;
        }
        public IQueryable<POST> ListAllPOSTByPOID(string poid)
        {
            IQueryable<POST> POSTList = from g in db.POST
                                        where g.POID == poid
                                        select g;
            return POSTList;
        }
    }
}