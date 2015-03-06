using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderAPI
{
    public enum  EEntrustTypes
    {
        ENTRUST_BUY_SELL = 48,  //买卖
        ENTRUST_QUERY, //查询
        ENTRUST_CANCEL, //撤单
        ENTRUST_APPEND, //补单
        ENTRUST_COMFIRM, //确认
        ENTRUST_BIG, //大宗
        ENTRUST_FIN = 54,  //融资委托
        ENTRUST_SLO = 55,  //融券委托
        ENTRUST_CLOSE = 56,  //信用平仓
        ENTRUST_CREDIT_NORMAL = 57,  //信用普通委托
        ENTRUST_CANCEL_OPEN = 58,  //撤单补单
    };
}
