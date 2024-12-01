using DataAccessLAyer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class clsClassesTypes
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public int MinAge { get; set; }
        public int ValidaateLength { get; set; }
        public double fees { get; set; }
        static public DataTable GetAllClassTypeName()
        {
            return clsClassTypeDataAccess.GetAllClassTypeName();
        }
        clsClassesTypes(int _ID,string Name,string description,int MinAge,int ValidaateLength,double fees)
        {
            this.ID = _ID;
            this.Name = Name;
            this.description = description;
            this.MinAge = MinAge;
            this.ValidaateLength = ValidaateLength;
            this.fees = fees;

        }
        static public int Find(string Name)
        {
            int ID = 0;
            return (clsClassTypeDataAccess.Find(ref ID,Name)) ?  ID : 0;
        }

        public static clsClassesTypes Find(int id)
        {
            //int id = 0;
            string Name = "";
            string description = "";
            int MinAge = 0;
            int ValidaateLength = 0;
            double fees = 0;
            if (clsClassTypeDataAccess.Find(id, ref Name, ref description, ref MinAge, ref ValidaateLength, ref fees))
                return new clsClassesTypes(id, Name, description, MinAge, ValidaateLength, fees);
            else
                return null;
        }
    }
}
