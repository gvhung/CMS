using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace CRM.Store
{
   public class CRMContextInitilizer: DropCreateDatabaseIfModelChanges<CRMContext>
    {
      
    }
}
