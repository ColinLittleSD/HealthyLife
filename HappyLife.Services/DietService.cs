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
    public class DietService
    {
        private readonly Guid _userId;

        public DietService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDiet(DietCreate model)
        {
            var entity =
                new Diet()
                {
                    OwnerId = _userId,
                    Breakfast = model.Breakfast,
                    Lunch = model.Lunch,
                    Dinner = model.Dinner,
                    Snacks = model.Snacks,
                    Liquids = model.Liquids,
                    Date = model.Date,
                    PersonId = model.PersonId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Diets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DietListItem> GetDiets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Diets
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new DietListItem
                                {
                                    DietId = e.DietId,
                                    Breakfast = e.Breakfast,
                                    Lunch = e.Lunch,
                                    Dinner = e.Dinner,
                                    Snacks = e.Snacks,
                                    Liquids = e.Liquids,
                                    Date = e.Date,
                                    PersonName = e.Person.Name
                                }
                        );

                return query.ToArray();
            }
        }
        public DietDetail GetDietById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Diets
                        .Single(e => e.DietId == id && e.OwnerId == _userId);
                return
                    new DietDetail
                    {
                        DietId = entity.DietId,
                        Breakfast = entity.Breakfast,
                        Lunch = entity.Lunch,
                        Dinner = entity.Dinner,
                        Snacks = entity.Snacks,
                        Liquids = entity.Liquids,
                        Date = entity.Date,
                        PersonId = entity.PersonId,
                        PersonName = entity.Person.Name
                    };
            }
        }
    }
}
