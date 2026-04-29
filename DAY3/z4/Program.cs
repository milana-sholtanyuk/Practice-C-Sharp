using System;

namespace VetClinic
{
    class Program
    {
        static void Main()
        {
            Pet[] pets = new Pet[]
            {
                new Pet("Барсик", "Кот", 5, "Иван"),
                new Pet("Шарик", "Собака", 8, "Мария"),
                new Pet("Хома", "Хомяк", 2, "Иван"),
                new Pet("Мурка", "Кот", 12, "Елена")
            };

            var clinic = new VeterinaryClinic(pets);
            clinic.PrintAllPets();

            var oldest = clinic.GetOldestPet();
            Console.WriteLine($"\nСамое старое животное: {oldest}");

            string owner = "Иван";
            var ownerPets = clinic.GetPetsByOwner(owner);
            Console.WriteLine($"\nЖивотные владельца {owner}:");
            foreach (var pet in ownerPets)
                Console.WriteLine($"  {pet}");
        }
    }
}