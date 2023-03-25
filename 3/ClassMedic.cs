using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    public abstract class Medic
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Specialization { get; set; }
        public string WorkExperience { get; set; }

        public virtual void Info()
        {
            Console.WriteLine($"\n{Name}\nВозраст - {Age}\nСпециализация - {Specialization}\nСтаж - {WorkExperience}");
        }

        public virtual void Heal(Patient patient)
        {
            if (new Random().Next(0, 11) > 1)
            {
                patient.State = "здоров";
                Console.WriteLine($"\nУспешное лечение, пациент {patient.State}");
            }
            else
            {
                patient.State = "нездоров";
                Console.WriteLine($"\nНеуспешное лечение, пациент {patient.State}");
            }
        }
    }
    public class Therapist : Medic
    {
        public bool RoundOfVisit { get; set; }

        public override void Info()
        {
            base.Info();
            if (RoundOfVisit == true)
            {
                Console.WriteLine("Врач совершает визиты на дом");
            }
        }
    }

    public class Neurolog : Medic
    {
        public override void Heal(Patient patient)
        {
            if (new Random().Next(0, 11) > 3)
            {
                patient.State = "здоров";
                Console.WriteLine($"\nУспешное лечение, пациент {patient.State}");
            }
            else
            {
                patient.State = "нездоров";
                Console.WriteLine($"\nНеуспешное лечение, пациент {patient.State}");
            }
        }
    }

    public class Oculist : Medic
    {
        public override void Heal(Patient patient)
        {
            if (new Random().Next(0, 11) > 2)
            {
                patient.State = "здоров";
                Console.WriteLine($"\nУспешное лечение, пациент {patient.State}");
            }
            else
            {
                patient.State = "нездоров";
                Console.WriteLine($"\nНеуспешное лечение, пациент {patient.State}");
            }
        }
    }
}