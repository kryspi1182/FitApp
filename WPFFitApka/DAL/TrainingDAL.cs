using WPFFitApka.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FitApka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Collections.ObjectModel;

namespace FitApka.DAL
{
    public class TrainingDAL
    {
        FitAplikacjaDBContext FitAplikacjaDBContext = FitAplikacjaDBContext.GetDBContext();
        public TrainingDAL() { }

        public ObservableCollection<Training> GetTrainings()
        {
            var result = new ObservableCollection<Training>();
            var tmpList = FitAplikacjaDBContext.Treningi
                .Select(x => new Training()
                {
                    Id = (int)x.IdTreningi,
                    Name = x.Nazwa,
                    Duration = (int)x.Czas,
                    Exercises = new List<Exercise>()
                }).ToList();



            foreach (Training y in tmpList)
            {
                var exerciseList = FitAplikacjaDBContext.CwiczeniaTrening
                    .Where(x => x.IdTreningi1 == y.Id)
                    .ToList();

                foreach (var z in exerciseList)
                {
                    //Exercise exercise = new Exercise();
                    var exercise = FitAplikacjaDBContext.Cwiczenia
                        .Where(x => x.IdCwiczenia == z.IdCwiczenia1)
                        .Select(x => new Exercise()
                        {
                            Id = (int)x.IdCwiczenia,
                            Name = x.Nazwa,
                            Description = x.Opis,
                            Repetition = (int)x.Powtorzenia
                        }).FirstOrDefault();

                    y.Exercises.Add(exercise);
                }

                result.Add(y);
            }

            return result;
        }

    }
}

