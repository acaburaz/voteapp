using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteappAPI.Models
{
    public class VoteType
    {
        public int VoteId { get; set; }
        public String namn { get; set; }
        public int Votes { get; set; }

        public  VoteType(){
        }
    }
}