namespace VetClinic
{
    public partial class Pet
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public string OwnerName { get; set; }

        public Pet(string name, string species, int age, string ownerName)
        {
            Name = name;
            Species = species;
            Age = age;
            OwnerName = ownerName;
        }

        public override string ToString()
        {
            return $"{Name} ({Species}, {Age} лет) – владелец: {OwnerName}";
        }
    }
}