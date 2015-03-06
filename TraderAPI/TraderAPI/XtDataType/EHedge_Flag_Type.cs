using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderAPI
{
    public enum EHedge_Flag_Type
    {
        HEDGE_FLAG_SPECULATION = 49,  //投机
        HEDGE_FLAG_ARBITRAGE = 50,  //套利
        HEDGE_FLAG_HEDGE = 51,  //套保
    };
}
