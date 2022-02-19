using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Classes
{
    public class Opportunity
    {
        public string Name { get; set; }
        public string CloseDate { get; set; }
        public string StageName { get; set; }
        public string Email__c { get; set; }


        public Opportunity(string name, string email)
        {
            this.Name = name;
            this.CloseDate = "2023-08-01";
            this.StageName = "New";
            this.Email__c = email;
        }
    }
}
