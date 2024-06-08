using Microsoft.AspNetCore.Identity;

namespace AuthDemo.Domain.Entities;

public class UserEntity : IdentityUser<int>
{
    public UserEntity(string firstName,
        string lastName,
        string userName,
        string email,
        string region,
        string createdBy,
        DateTime createdOn,
        string? modifiedBy,
        DateTime? modifiedOn,
        bool deleted)
    {
        FirstName = firstName;
        LastName = lastName;
        Region = region;
        UserName = userName;
        Email = email;
        CreatedBy = createdBy;
        CreatedOn = createdOn;
        ModifiedBy = modifiedBy;
        ModifiedOn = modifiedOn;
        Deleted = deleted;
    }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Region { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool Deleted { get; set; }
}