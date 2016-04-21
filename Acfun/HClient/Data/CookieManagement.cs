using System.Data;
using System.Linq;

namespace HClient.Data
{
    internal class CookieManagement
    {
        private static DBEntities db = null;

        public static DBEntities Db
        {
            get { return CookieManagement.db; }
            set { CookieManagement.db = value; }
        }
        public CookieManagement(DBEntities dbe) 
        {
            db = dbe;
        }
        public void CreateCOOKIE(COOKIE cookie)
        {
            db.COOKIE.AddObject(cookie);
            db.SaveChanges();

        }

        public void DelCOOKIE(string COOKIEid)
        {
            System.Guid id = System.Guid.Parse(COOKIEid);
            COOKIE COOKIE = new COOKIE();
            COOKIE.ID = id;
            if (id != null)
            {
                db.ObjectStateManager.ChangeObjectState(COOKIE, EntityState.Deleted);
                db.SaveChanges();
            }
        }

        public void UpdateCOOKIE(COOKIE cookie)
        {
            db.COOKIE.Attach(cookie);
            db.ObjectStateManager.ChangeObjectState(cookie, EntityState.Modified);
            db.SaveChanges();
        }

        public IQueryable<COOKIE> ListAllCOOKIE()
        {
            IQueryable<COOKIE> COOKIEList = from g in db.COOKIE
                                            where g.ID.ToString().Length > 0
                                            select g;
            return COOKIEList;
        }
    }
}