using System.Data;
using System.Linq;

namespace HClient.Data
{
    internal class POManagement
    {
        private static DBEntities db = null;

        public static DBEntities Db
        {
            get { return POManagement.db; }
            set { POManagement.db = value; }
        }
        public POManagement(DBEntities dbe) 
        {
            db = dbe;
        }
        public void CreatePO(PO po)
        {
            db.PO.AddObject(po);
            db.SaveChanges();

        }

        public void DelPO(string POid)
        {
            System.Guid id = System.Guid.Parse(POid);
            PO PO = new PO();
            PO.ID = id;
            if (id != null)
            {
                db.ObjectStateManager.ChangeObjectState(PO, EntityState.Deleted);
                db.SaveChanges();
            }
        }

        public void UpdatePO(PO PO)
        {
            db.PO.Attach(PO);
            db.ObjectStateManager.ChangeObjectState(PO, EntityState.Modified);
            db.SaveChanges();
        }

        public IQueryable<PO> ListAllPO()
        {
            IQueryable<PO> POList = from g in db.PO
                                    where g.ID.ToString().Length > 0
                                    select g;
            return POList;
        }
    }
}