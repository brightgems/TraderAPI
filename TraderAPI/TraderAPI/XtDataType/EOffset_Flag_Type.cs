using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderAPI
{
    public enum  EOffset_Flag_Type
    {
        EOFF_THOST_FTDC_OF_INVALID = -1,  //未知
        EOFF_THOST_FTDC_OF_Open = 48,  //开仓
        EOFF_THOST_FTDC_OF_Close = 49,  //平仓
        EOFF_THOST_FTDC_OF_ForceClose = 50,  //强平
        EOFF_THOST_FTDC_OF_CloseToday = 51,  //平今
        EOFF_THOST_FTDC_OF_CloseYesterday = 52,  //平昨
        EOFF_THOST_FTDC_OF_ForceOff = 53,  //强减
        EOFF_THOST_FTDC_OF_LocalForceClose = 54,  //本地强平
    };
}
