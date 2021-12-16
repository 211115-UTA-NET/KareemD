using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsApp.App 
{
    public class Record
    {
        //ex: [10/7] Computer: ock VS you: Paper => you Wi! ]

        public DateTime Date { get;}
        public string PC { get;}
        public string Player {get;}
        public string result {get;}

        public Record(DateTime date, string pc, string player, string result)
        {
            this.Date = date;
            this.PC = pc;
            this.Player = player;
            this.result=result;
        }

    }
}