using _3;

class Program
{
    static void Main(string[] args)
    {

        var therapist = new Therapist
        {
            Name = "Иван Иванов",
            Age = 44,
            Specialization = "Терапевт",
            WorkExperience = "20 лет",
            RoundOfVisit = true
        };

        var neurolog = new Neurolog
        {
            Name = "Петр Петров",
            Age = 45,
            Specialization = "Невролог",
            WorkExperience = "21 год"
        };

        var oculist = new Oculist
        {
            Name = "Семен Семенов",
            Age = 46,
            Specialization = "Окулист",
            WorkExperience = "22 года"
        };


        var patient1 = new OphthalmicPatient
        {
            Name = "Маргарита Петрова",
            Age = 40,
            Address = "Улица Пушкина, дом Колотушкина",
            Disease = "Косоглазие",
            State = "Больна",
            VisualAcuity = 0.5
        };

        var patient2 = new TherapyPatient
        {
            Name = "Зинаида Семеновна",
            Age = 39,
            Address = "Улица Черная, дом Темный 3",
            State = "Больна",
            Disease = "Бронхит",
            BlankQuestionnaire = true
        };

        var patient3 = new NeurologicalPatient
        {
            Name = "Галина Иванова",
            Age = 41,
            Address = "Улица Счастья, дом Радости 7",
            Disease = "Мигрень",
            State = "Больна",
            CognitiveImpairment = false
        };

        patient1.Info();
        patient1.Registration(oculist);

        oculist.Info();
        oculist.Heal(patient1);

        patient2.Info();
        patient2.Registration(therapist);

        therapist.Info();
        therapist.Heal(patient2);

        patient3.Info();
        patient3.Registration(neurolog);

        neurolog.Info();
        neurolog.Heal(patient3);
    }
}