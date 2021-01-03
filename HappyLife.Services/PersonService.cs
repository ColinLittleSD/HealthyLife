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
                    HealthGoals = model.HealthGoals
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

    }
}
