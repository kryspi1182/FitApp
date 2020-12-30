using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Configuration;
using System.Text;
using FitApka.DAL;
using WPFFitApka.Model;

namespace FitApka.Controller
{
    class TrainingController
    {
        TrainingDAL trainingDAL = new TrainingDAL();

        public ObservableCollection<Training> GetTrainings()
        {
            return trainingDAL.GetTrainings();
        }
    }
}
