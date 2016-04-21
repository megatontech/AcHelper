using System.Data;
using System.Linq;

namespace HClient.Data
{
    internal class ConfigManagement
    {
        private static DBEntities db = null;

        public static DBEntities Db
        {
            get { return ConfigManagement.db; }
            set { ConfigManagement.db = value; }
        }
        public ConfigManagement(DBEntities dbe) 
        {
            db = dbe;
        }
        public void CreateCONFIG(CONFIG config)
        {
            db.CONFIG.AddObject(config);
            db.SaveChanges();

        }

        public void DelCONFIG(string configid)
        {
            System.Guid id = System.Guid.Parse(configid);
            CONFIG CONFIG = new CONFIG();
            CONFIG.CONFIG_ID = id;
            if (id != null)
            {
                db.ObjectStateManager.ChangeObjectState(CONFIG, EntityState.Deleted);
                db.SaveChanges();
            }
        }

        public void UpdateCONFIG(CONFIG CONFIG)
        {
            db.CONFIG.Attach(CONFIG);
            db.ObjectStateManager.ChangeObjectState(CONFIG, EntityState.Modified);
            db.SaveChanges();
        }

        public IQueryable<CONFIG> ListAllCONFIG()
        {
            IQueryable<CONFIG> CONFIGList = from g in db.CONFIG
                                            where g.CONFIG_ID.ToString().Length > 0
                                            select g;
            return CONFIGList;
        }
    }
}