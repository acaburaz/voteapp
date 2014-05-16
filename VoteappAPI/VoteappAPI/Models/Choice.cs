using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteappAPI.Models
{
    public class Choice
    {
        public int ChoiceId { get; set; }
        public String Text { get; set; }
        public List<Voter> Voters {get;set;}
        public DateTime Timestamp { get; set; }
        public int GetVotes()
        {
            return Voters.Count;
        }

        public String GetChoice(){
            return Text;
        }
    }
}