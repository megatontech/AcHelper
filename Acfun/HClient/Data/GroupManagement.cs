using System.Data;
using System.Linq;
using System;
using HClient.Utils;

namespace HClient.Data
{
    public class GroupManagement
    {
        private static DBEntities db = null;

        public static DBEntities Db
        {
            get { return GroupManagement.db; }
            set { GroupManagement.db = value; }
        }
        public  GroupManagement(DBEntities dbe) 
        {
            db = dbe;
        }

        public void CreateGroup(GROUP group)
        {
            try
            {
                db.GROUP.AddObject(group);
                db.SaveChanges();
            }catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        public void DelGroup(string gid)
        {
            System.Guid id = System.Guid.Parse(gid);
            GROUP group = new GROUP();
            group.GROUP_ID = id;
            if (id != null)
            {
                db.ObjectStateManager.ChangeObjectState(group, EntityState.Deleted);
                db.SaveChanges();
            }
        }

        public void UpdateGroup(GROUP group)
        {
            db.GROUP.Attach(group);
            db.ObjectStateManager.ChangeObjectState(group, EntityState.Modified);
            db.SaveChanges();
        }

        public IQueryable<GROUP> ListAllGroup()
        {
            IQueryable<GROUP> groupList = from g in db.GROUP
                                          where g.GROUP_NO > 0
                                          select g;
            return groupList;
        }
    }
}