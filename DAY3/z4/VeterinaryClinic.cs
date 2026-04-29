using System;

namespace VetClinic
{
    class VeterinaryClinic
    {
        private Pet[] pets;

        public VeterinaryClinic(Pet[] pets)
        {
            this.pets = pets;
        }

        public Pet GetOldestPet()
        {
            return Pet.GetOldestPet(pets);
        }

        public Pet[] GetPetsByOwner(string ownerName)
        {
            return Pet.GetPetsByOwner(pets, ownerName);
        }

        public void PrintAllPets()
        {
            Console.WriteLine("Все животные в клинике:");
            foreach (var pet in pets)
                Console.WriteLine($"  {pet}");
        }
    }
}