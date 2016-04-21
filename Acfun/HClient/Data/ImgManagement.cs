using System.Data;
using System.Linq;

namespace HClient.Data
{
    internal class ImgManagement
    {
        private static DBEntities db = null;

        public static DBEntities Db
        {
            get { return ImgManagement.db; }
            set { ImgManagement.db = value; }
        }
        public ImgManagement(DBEntities dbe) 
        {
            db = dbe;
        }
        public void CreateIMG(IMG img)
        {
            db.IMG.AddObject(img);
            db.SaveChanges();

        }

        public void DelIMG(string IMGid)
        {
            System.Guid id = System.Guid.Parse(IMGid);
            IMG IMG = new IMG();
            IMG.IMG_ID = id;
            if (id != null)
            {
                db.ObjectStateManager.ChangeObjectState(IMG, EntityState.Deleted);
                db.SaveChanges();
            }
        }

        public void UpdateIMG(IMG IMG)
        {
            db.IMG.Attach(IMG);
            db.ObjectStateManager.ChangeObjectState(IMG, EntityState.Modified);
            db.SaveChanges();
        }

        public IQueryable<IMG> ListAllIMG()
        {
            IQueryable<IMG> IMGList = from g in db.IMG
                                      where g.IMG_ID.ToString().Length > 0
                                      select g;
            return IMGList;
        }
        public IMG GetIMG(string imgid)
        {
            System.Guid id = System.Guid.Parse(imgid);
            IMG img = (IMG)from g in db.IMG 
                      where g.IMG_ID.Equals( id)
                          select g;
                      return img;
        }
    }
}