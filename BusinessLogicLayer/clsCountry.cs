using DataAccessLAyer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ClsCountry
    {
        

        public static DataTable GetAllCountries()
        {
            return ClsCountriesDataAccess.GetAllCountries();
        }
       

        public static string FindByID(int id)
        {
            string Name = "";
            if (ClsCountriesDataAccess.FindById(id, ref Name))
                return Name;
            else
                return null;
        }
        public static int FindByName(string name)
        {
            int Id = 0;
            if (ClsCountriesDataAccess.FindByName(ref Id, name))
                return Id;
            else
                return -1;
        }
    }
}
