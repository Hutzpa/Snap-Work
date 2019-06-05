using System;

namespace SnapWork
{
    public class Vacancy
    {
        public int idVacancy;
        public int idUserPlacement;
        [Obsolete]
        public string photo;
        public string nameVacancy;
        public int idTypeJob;
        public decimal payment;
        public string city;
        public DateTime datePlacement;
        public string description;
        public VacancyState vacancyState;
        public VacancyFormed vacanceFormed;
    }
}
