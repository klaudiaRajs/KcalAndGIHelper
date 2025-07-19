using Diabetic.Models;

namespace Diabetic.Data.Repositories.Interfaces;

public interface IUserRepository
{
    public UserProfile Get(string userId); 
    public bool Upsert(UserProfile userProfile);
}