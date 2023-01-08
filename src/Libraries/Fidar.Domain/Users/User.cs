using Fidar.Domain.Common;

namespace Fidar.Domain.Users;

public class User : BaseEntity
{
    public User(string name, int age, DateTime createOn, decimal credit)
    {
        Name = name;
        Age = age;
        CreateOn = createOn;
        Credit = credit;
    }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public DateTime CreateOn { get; set; }
    public decimal Credit { get; set; }
}
