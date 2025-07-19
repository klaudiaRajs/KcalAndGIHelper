using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;

namespace Diabetic.Data.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(ApplicationDbContext db) : base(db)
    {
    }


    public UserProfile Get(string userId)
    {
        try
        {
            return _db.UserProfiles
                .FirstOrDefault(a => a.UserId == userId) ?? new UserProfile { UserId = userId, KcalTarget = 0 };    
        } catch (Exception ex)
        {
            return new UserProfile();
        }
        
    }

    public bool Upsert(UserProfile userProfile)
    {
        try
        {
            UserProfile? existingProfile = _db.UserProfiles
                .FirstOrDefault(a => a.UserId == userProfile.UserId);

            if (existingProfile != null)
            {
                existingProfile.KcalTarget = userProfile.KcalTarget;
                _db.UserProfiles.Update(existingProfile);
            }
            else
            {
                _db.UserProfiles.Add(userProfile);
            }

            return _db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}