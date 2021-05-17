using System;

namespace KursAzureZad1.ReadModels
{
    public class ExerciseReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Distance { get; set; }
        public int Minutes { get; set; }
    }
}
