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

        public SleepDetail GetSleepById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sleeps
                        .Single(e => e.SleepId == id && e.OwnerId == _userId);
                return
                    new SleepDetail
                    {
                        SleepId = entity.SleepId,
                        HoursSlept = entity.HoursSlept,
                        WakeUpTime = entity.WakeUpTime,
                        Date = entity.Date
                    };
            }
        }

        public bool UpdateSleep(SleepEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sleeps
                        .Single(e => e.SleepId == model.SleepId && e.OwnerId == _userId);

                entity.HoursSlept = model.HoursSlept;
                entity.WakeUpTime = model.WakeUpTime;
                entity.Date = model.Date;
                entity.PersonId = model.PersonId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSleep(int sleepId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sleeps
                        .Single(e => e.SleepId == sleepId && e.OwnerId == _userId);

                ctx.Sleeps.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
