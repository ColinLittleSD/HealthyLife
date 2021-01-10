using HappyLife.Data;
using HappyLife.Models;
using HappyLife.Models.happinessmodels;
using HealthyLife.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyLife.Services
{
    public class HappinessService
    {
        private readonly Guid _userId;

        public HappinessService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateHappiness(HappinessCreate model)
        {
            var entity =
                new Happiness()
                {
                    OwnerId = _userId,
                    HappinessLevel = model.HappinessLevel,
                    EmotionNotes = model.EmotionNotes,
                    Date = model.Date,
                    PersonId = model.PersonId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Happinesses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<HappinessListItem> GetHappinesses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Happinesses
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new HappinessListItem
                                {
                                    HappinessId = e.HappinessId,
                                    HappinessLevel = e.HappinessLevel,
                                    EmotionNotes = e.EmotionNotes,
                                    Date = e.Date,
                                    PersonName = e.Person.Name
                                }
                        );

                return query.ToArray();
            }
        }

        public HappinessDetail GetHappinessById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Happinesses
                        .Single(e => e.HappinessId == id && e.OwnerId == _userId);
                return
                    new HappinessDetail
                    {
                        HappinessId = entity.HappinessId,
                        HappinessLevel = entity.HappinessLevel,
                        EmotionNotes = entity.EmotionNotes,
                        Date = entity.Date,
                        PersonId = entity.PersonId,
                        PersonName = entity.Person.Name
                    };
            }
        }

        public bool UpdateHappiness(HappinessEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Happinesses
                        .Single(e => e.HappinessId == model.HappinessId && e.OwnerId == _userId);

                entity.HappinessLevel = model.HappinessLevel;
                entity.EmotionNotes = model.EmotionNotes;
                entity.Date = model.Date;
                entity.PersonId = model.PersonId;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
