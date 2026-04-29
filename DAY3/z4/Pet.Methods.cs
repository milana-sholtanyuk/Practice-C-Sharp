using System.Linq;

namespace VetClinic
{
    public partial class Pet
    {
        public static Pet GetOldestPet(Pet[] pets)
        {
            return pets.OrderByDescending(p => p.Age).FirstOrDefault();
        }

        public static Pet[] GetPetsByOwner(Pet[] pets, string ownerName)
        {
            return pets.Where(p => p.OwnerName.Equals(ownerName, System.StringComparison.OrdinalIgnoreCase)).ToArray();
        }
    }
}