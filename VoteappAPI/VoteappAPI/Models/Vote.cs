using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteappAPI.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Votes { get; set; }
        public String VoteType { get; set; }
        public List<Choice> Choices { get; set; }
     
        public Vote()
        {
        }

      
    }
}