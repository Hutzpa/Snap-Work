using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SnapWork.Models
{
    static class Support
    {
        public static List<string> cities = new List<string> { "Вінниця", "Дніпро", "Донецьк", "Житомир", "Запоріжжя", "Івано-Франківськ", "Кропивницький", "Київ", "Луганськ", "Луцьк", "Львів", "Миколаїв", "Одесса", "Полтава", "Рівне", "Сімферополь", "Суми", "Тернопіль", "Ужгород", "Харків", "Херсон", "Хмельницький", "Черкаси", "Чернігів", "Чернівці" };

        public static List<string> jobList = new List<string> { "Торгівля",@"Транспорт\Логістика","Будівництво", @"Телекоммунікації\Зв'язок", @"Ресторанний бізнес",@"Юриспорденція", @"Керівництво персоналом/HR@", "Охорона та безпека", "Спорт та фітнес", "Туризм та відпочинок", "Навчання", @"Медицина/фармацевтика", "IT","Нерухомість" };

        [Obsolete("Добавить заполнение списков в самом начале по запросу Sql")]
        public static void FillDropDown(Picker picker, List<string> elements)
        {
            for(int i = 0; i < elements.Count; i++)
            {
                picker.Items.Add(elements[i]);
            }
        }
        
        
    }
}
