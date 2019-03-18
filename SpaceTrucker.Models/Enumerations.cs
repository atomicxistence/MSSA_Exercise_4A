using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceTrucker.Models
{
    enum WarpFactor { WarpOne = 1, WarpTwo, WarpThree, WarpFour,
                       WarpFive, WarpSix, WarpSeven, WarpEight, WarpNine }

    enum WeaponSystem { None, Weak = 25, Average = 50, Powerful = 75 } // chances of winning a fight

    enum Capacity { Small = 5, Medium = 10, Large = 15 } // number of Ores 
}
