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
                                    PersonName = e.Person.Name
                                }
                        );

                return query.ToArray();
            }
        }

        public ExerciseDetail GetExerciseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exercises
                        .Single(e => e.ExerciseId == id && e.OwnerId == _userId);
                return
                    new ExerciseDetail
                    {
                        ExerciseId = entity.ExerciseId,
                        Activity = entity.Activity,
                        TimeSpentOnActivity = entity.TimeSpentOnActivity,
                        Date = entity.Date,
                        PersonId = entity.PersonId,
                        PersonName = entity.Person.Name
                    };
            }
        }

        public bool UpdateExercise(ExerciseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exercises
                        .Single(e => e.ExerciseId == model.ExerciseId && e.OwnerId == _userId);

                entity.Activity = model.Activity;
                entity.TimeSpentOnActivity = model.TimeSpentOnActivity;
                entity.Date = model.Date;
                entity.PersonId = model.PersonId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteExercise(int exerciseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exercises
                        .Single(e => e.ExerciseId == exerciseId && e.OwnerId == _userId);

                ctx.Exercises.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
