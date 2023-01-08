using Fidar.Domain.Common;

namespace Fidar.Domain.Users;

public class User : BaseEntity
{
    public User(string name, int age, decimal credit)
    {
        Name = name;
        Age = age;
        Credit = credit;
    }
    public string Name { get; private set; } = string.Empty;
    public int Age { get; private set; }
    public DateTime CreateOn { get; private set; }
    public decimal Credit { get; private set; }
    public void AddTime(DateTime date)
    {
        this.CreateOn = date;
    }

    
}
