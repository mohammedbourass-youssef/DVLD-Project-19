using DataAccessLAyer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public  class clsTestTypes
    {
        public int ID { get; set; } 
        public string title { get; set; }
        public string Description { get; set; }
        public double fees { get; set; }

        static public DataTable GetAllRecords()
        {
            return clsTestTypesDataAccess.GetApplicationstypes();
        }

        clsTestTypes(int id,string title, string description, double fees)
        {
            this.ID = id;
            this.title = title;
            this.fees = fees;
            this.Description = description;
        }
       public static clsTestTypes Find(int ID)
        {
           
            string title = string.Empty;
            double fees = 0.0;
            string Description = string.Empty ;
            return (clsTestTypesDataAccess.Find(ID,ref title,ref Description,ref fees))?new clsTestTypes(ID,title,Description,fees) : null;
        }
        public bool Save()
        {
            return clsTestTypesDataAccess.Update(ID,title,Description,fees);
        }
    }
}
