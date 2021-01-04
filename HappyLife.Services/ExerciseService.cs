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
    public class ExerciseService
    {
        private readonly Guid _userId;

        public ExerciseService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateExercise(ExerciseCreate model)
        {
            var entity =
                new Exercise()
                {
                    OwnerId = _userId,
                    Activity = model.Activity,
                    Date = model.Date,
                    TimeSpentOnActivity = model.TimeSpentOnActivity,
                    PersonId = model.PersonId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Exercises.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ExerciseListItem> GetExercises()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Exercises
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ExerciseListItem
                                {
                                    ExerciseId = e.ExerciseId,
                                    Activity = e.Activity,
                                    TimeSpentOnActivity = e.TimeSpentOnActivity,
                                    Date = e.Date,
                                    PersonId = e.PersonId
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
