using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace  dotnet_rpg.Models{

    public class Character{
         public int Id {get;set;} =0;
         public string name { get; set; }="Frodo";

         public int HitPoints { get; set; } = 100;

         public int Strength { get; set; } = 10;

         public int Defense { get; set; } = 10;

         public int Intelligence { get; set; }= 10;

         

         public RpgClass Class { get; set; } = RpgClass.Knight;
    }

}
