using HappyLife.Data;
using HappyLife.Models;
using HealthyLife.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Services
{
    public class SleepService
    {
        private readonly Guid _userId;

        public SleepService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSleep(SleepCreate model)
        {
            var entity =
                new Sleep()
                {
                    OwnerId = _userId,
                    HoursSlept = model.HoursSlept,
                    WakeUpTime = model.WakeUpTime,
                    Date = model.Date,
                    PersonId = model.PersonId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sleeps.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SleepListItem> GetSleeps()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sleeps
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new SleepListItem
                                {
                                    SleepId = e.SleepId,
                                    HoursSlept = e.HoursSlept,
                                    WakeUpTime = e.WakeUpTime,
                                    Date = e.Date,
                                    PersonId = e.PersonId
                                    
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
