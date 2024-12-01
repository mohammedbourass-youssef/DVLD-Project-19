using DataAccessLAyer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class clsTest
    {

        public int  testID {  get; set; }
        public int testapoitement {  get; set; }

        
        public bool testresult { get; set; }
        public string notes { get; set; }
        public int userID { get; set; }
        
        public clsTest()
        {
            testID = 0;
            testapoitement = 0;
            testresult = false;
            notes = string.Empty;
            userID = 0;
        }
       public bool Save()
        {
           
            testID =  clsTestDataAccess.AddNewTest(testapoitement, testresult,notes,userID);
            return (testID > 0);
            
        }





    }
}
