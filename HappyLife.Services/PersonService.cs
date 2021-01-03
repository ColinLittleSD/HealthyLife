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
    public class PersonService
    {
        private readonly Guid _userId;

        public PersonService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePerson(PersonCreate model)
        {
            var entity =
                new Person()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Weight = model.Weight,
                    HealthGoals = model.HealthGoals,
                    DateStarted = model.DateStarted
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Persons.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PersonListItem> GetPerson()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Persons
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PersonListItem
                                {
                                    PersonId = e.PersonId,
                                    Name = e.Name,
                                    Weight = e.Weight,
                                    HealthGoals = e.HealthGoals,
                                    DateStarted = e.DateStarted
                                }
                        );

                return query.ToArray();
            }
        }

        public PersonDetail GetPersonById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Persons
                        .Single(e => e.PersonId == id && e.OwnerId == _userId);
                return
                    new PersonDetail
                    {
                        PersonId = entity.PersonId,
                        Name = entity.Name,
                        Weight = entity.Weight,
                        HealthGoals = entity.HealthGoals,
                        DateStarted = entity.DateStarted
                    };
            }
        }

        public bool UpdatePerson(PersonEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Persons
                        .Single(e => e.PersonId == model.PersonId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Weight = model.Weight;
                entity.HealthGoals = model.HealthGoals;
                entity.DateStarted = model.DateStarted;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePerson(int personId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Persons
                        .Single(e => e.PersonId == personId && e.OwnerId == _userId);

                ctx.Persons.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
