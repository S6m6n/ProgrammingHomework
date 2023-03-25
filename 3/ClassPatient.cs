using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    public abstract class Patient
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Disease { get; set; }

        public virtual void Info()
        {
            Console.WriteLine($"\n{Name}\nВозраст - {Age}\nМесто жительства - {Address}\nСтатус - {State}\nБолезнь - {Disease}");
        }

        public virtual void Registration(Medic medic)
        {
            Console.WriteLine($"\nПациент {Name} записан на прием к врачу - {medic.Specialization} {medic.Name}");
        }
    }

    public class TherapyPatient : Patient
    {
        public bool BlankQuestionnaire { get; set; }

        public override void Info()
        {
            base.Info();
            if (BlankQuestionnaire == true)
            {
                Console.WriteLine("В текущем году пациент прошел бланк-опросник");
            }
        }
    }

    public class OphthalmicPatient : Patient
    {
        public double VisualAcuity { get; set; }

        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Острота зрения - {VisualAcuity}");
        }
    }

    public class NeurologicalPatient : Patient
    {
        public bool CognitiveImpairment { get; set; }

        public override void Info()
        {
            base.Info();
            if (CognitiveImpairment == true)
            {
                Console.WriteLine("У пациента наблюдаются когнитивные нарушения");
            }
        }
    }
}