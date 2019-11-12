using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U
{
    //Denne class bruges til at holde al den information som riots api giver når man laver en GET request
    class SummonerInfo
    {
        

        public class root
        {
            public string id { get; set; }
            public string accountId { get; set; }
            public string puuid { get; set; }
            public string name { get; set; }
            public int profileIconId { get; set; }
            public int revisionDate { get; set; }
            public int summonerLevel { get; set; }
        }
    }
}
