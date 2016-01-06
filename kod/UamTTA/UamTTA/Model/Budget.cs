using System;
using System.Collections.Generic;
using UamTTA.Tools;

namespace UamTTA.Model
{
    public class Budget : ModelBase
    {
        public string Name { get; set; }

        public Duration Duration { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public ICollection<Account> RelatedAccounts { get; set; }

        public ICollection<Transfer> Operations { get; set; }

        public override string ToString()
        {
            return $"ValidFrom: {ValidFrom}, ValidTo: {ValidTo}, RelatedAccounts: {RelatedAccounts.ToElementsString()}, Operations: {Operations.ToElementsString()}";
        }
    }
}