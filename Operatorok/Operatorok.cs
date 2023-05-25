using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatorok
{
    public class Operatorok
    {
        int elsoOperandus;
        string muveletiJel;
        int masodikOperandus;
        
        public Operatorok(string txtSorok)
        {
            var mezo = txtSorok.Split(" ");
            this.elsoOperandus = int.Parse(mezo[0]);
            this.muveletiJel = mezo[1];
            this.masodikOperandus = int.Parse(mezo[2]);
        }
        public int ElsoOperandus { get => elsoOperandus; set => elsoOperandus = value; }
        public string MuveletiJel { get => muveletiJel; set => muveletiJel = value; }
        public int MasodikOperandus { get => masodikOperandus; set => masodikOperandus = value; }
        public Operatorok(int ElsoOperandus, string MuveletiJel, int MasodikOperandus)
        {
            this.ElsoOperandus = ElsoOperandus;
            this.MuveletiJel = MuveletiJel;
            this.ElsoOperandus = MasodikOperandus;
        }

      
    }
   
}
