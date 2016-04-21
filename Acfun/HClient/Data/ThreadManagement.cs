using System.Data;
using System.Linq;
using System;

namespace HClient.Data
{
    internal class ThreadManagement
    {
        private static DBEntities db = null;

        public static DBEntities Db
        {
            get { return ThreadManagement.db; }
            set { ThreadManagement.db = value; }
        }
        public ThreadManagement(DBEntities dbe) 
        {
            db = dbe;
        }

        public void CreateThread(THREAD thread)
        {
            try
            {

                db.THREAD.AddObject(thread);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        public void DelThread(string threadid)
        {
            System.Guid id = System.Guid.Parse(threadid);
            THREAD thread = new THREAD();
            thread.THREAD_ID = id;
            if (id != null)
            {
                db.ObjectStateManager.ChangeObjectState(thread, EntityState.Deleted);
                db.SaveChanges();
            }
        }

        public void UpdateThread(THREAD thread)
        {
            db.THREAD.Attach(thread);
            db.ObjectStateManager.ChangeObjectState(thread, EntityState.Modified);
            db.SaveChanges();
        }

        public IQueryable<THREAD> ListAllThread()
        {
            IQueryable<THREAD> THREADList = from g in db.THREAD
                                            where g.THREAD_ID.ToString().Length > 0
                                            select g;
            return THREADList;
        }
        public IQueryable<THREAD> ListAllThreadByGroup(string groupid)
        {
            IQueryable<THREAD> THREADList = from g in db.THREAD
                                            where g.GROUP_ID == groupid
                                            select g;
            return THREADList;
        }
        public IQueryable<THREAD> ListAllThreadByPO(string poid)
        {
            IQueryable<THREAD> THREADList = from g in db.THREAD
                                            where g.POID == poid
                                            select g;
            return THREADList;
        }
    }
}