using DataAccessLAyer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class clsApplicationTypes
    {
        public  int ID { get; set; }
        public string title {  get; set; }
        public double fees { get; set; }
        static public DataTable GetAllApplicationsNAmes()
        {
            return clsApplicationsTypeDataAccess.GetApplicationstypes();
        }
        clsApplicationTypes(int id,string title,double _fees)
        {
            ID = id;
            this.title = title;
            this.fees = _fees;
        }
        public bool Save()
        {
            return clsApplicationsTypeDataAccess.Update(ID, title, fees);   
        }
        public static clsApplicationTypes Find(int id)
        {
            string title = string.Empty;
            double _fees = 0.0;
            return (clsApplicationsTypeDataAccess.Find(id, ref title, ref _fees)) ? new clsApplicationTypes(id, title, _fees) : null;
        }
    }
}
