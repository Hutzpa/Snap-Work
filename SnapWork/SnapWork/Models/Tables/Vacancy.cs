using System;

namespace SnapWork.Models
{
    public class Vacancy
    {
        public int IdVacancy { get; set; }
        public int IdUserPlacement { get; set; }
        [Obsolete]
        public string Photo { get; set; }
        public string NameVacancy { get; set; }
        public int IdTypeJob { get; set; }
        public decimal Payment { get; set; }
        public string City { get; set; }
        public DateTime DatePlacement { get; set; }
        public string Description { get; set; }
        public VacancyState VacancyState { get; set; }
        public VacancyFormed VacanceFormed { get; set; }
    }
}
