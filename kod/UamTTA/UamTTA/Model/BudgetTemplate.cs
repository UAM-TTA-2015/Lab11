using System.Collections.Generic;
using UamTTA.Tools;

namespace UamTTA.Model
{
    public class BudgetTemplate : ModelBase
    {
        public BudgetTemplate()
        {
            Accounts = new List<Account>();
        }

        public string Name { get; set; }

        public Duration Duration { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Accounts: {Accounts.ToElementsString()}, Duration: {Duration}";
        }
    }
}