using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CRM.DAL.Entities;
namespace CRM.DAL
{
    public class CRMContextInitializer:DropCreateDatabaseIfModelChanges<CRMContext>
    {

        protected override void Seed(CRMContext context)
        {
            List<StatusMaster> defaultStatuses = new List<StatusMaster>();
            defaultStatuses.Add(new StatusMaster()
            {
                StatusId = 0,
                Description = "In-Active",
                StatusType = new StatusType() { Description = "General" }
            });
            defaultStatuses.Add(new StatusMaster()
            {
                StatusId = 1,
                Description = "Active",
                StatusType = new StatusType() {  Description = "General" }
            });
            defaultStatuses.Add(new StatusMaster()
            {
                StatusId = 2,
                Description = "Blocked",
                StatusType = new StatusType() {  Description = "General" }
            });
            defaultStatuses.Add(new StatusMaster()
            {
                StatusId = 3,
                Description = "Expired",
                StatusType = new StatusType() {  Description = "General" }
            });
            defaultStatuses.Add(new StatusMaster()
            {
                StatusId = 4,
                Description = "Assigned",
                StatusType = new StatusType() { Description = "Ticket" }
            });
            defaultStatuses.Add(new StatusMaster()
            {
                StatusId = 5,
                Description = "Work",
                StatusType = new StatusType() { Description = "Ticket" }
            });

            foreach (var s in defaultStatuses)
                context.GetEntities<StatusMaster>().Add(s);

            base.Seed(context);
        }
    }
}
