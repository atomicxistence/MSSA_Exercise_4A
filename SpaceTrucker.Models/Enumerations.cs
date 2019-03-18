using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceTrucker.Models
{
    public enum WarpFactor
    {
        WarpOne = 1,
        WarpTwo,
        WarpThree,
        WarpFour,
        WarpFive,
        WarpSix,
        WarpSeven,
        WarpEight,
        WarpNine,
    }

    
    public enum WeaponSystem  // chances of winning a fight
    {
        None,
        Weak = 25,
        Average = 50,
        Powerful = 75,
    } 

    public enum Capacity // number of Ores 
    {
        Small = 5,
        Medium = 10,
        Large = 15,
    } 
}
