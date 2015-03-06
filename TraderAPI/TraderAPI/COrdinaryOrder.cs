using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderAPI
{
    public struct COrdinaryOrder
    {
        char[] m_strAccountID;
        //char[] m_strExchangeID; //市场
        //char[] m_strExchangeName; //市场名字
        //char[] m_strProductID;
        //char[] m_strProductName;
        //char[] m_strInstrumentID;
        //char[] m_strInstrumentName;
        //int m_nSessionID;
        //int m_nFrontID;
        //double m_dLimitPrice; //限价单的限价，就是报价
        //int m_nVolumeTotalOriginal; //最初委托量
        //char[] m_strOrderSysID; //委托号
        //int m_nVolumeTraded; //已成交量
        //int m_nVolumeTotal; //当前总委托量 股票不需要总委托量
        //double m_dFrozenMargin; //冻结保证金
        //double m_dFrozenCommission; //冻结手续费
        //double m_dTradedPrice; //成交均价
        //double m_dCancelAmount;
        //double m_dTradeAmount; //成交额 期货=均价*量*合约乘数

        //int m_nErrorID;
        //char[] m_strErrorMsg;
        //char[] m_strInsertDate; //日期
        //char[] m_strInsertTime; //时间
        //int m_nOrderID;         //下单 ID
        //char[] m_strOptName; //展示委托属性的中文
        EBrokerPriceType m_nOrderPriceType; //类型，例如市价单 限价单
        EEntrustBS m_nDirection; //期货多空 股票买卖
        EOffset_Flag_Type m_nOffsetFlag;
        EHedge_Flag_Type m_nHedgeFlag;
        EEntrustSubmitStatus m_nOrderSubmitStatus; //提交状态，股票回头想想怎么填 股票里面不需要报单状态
        EEntrustStatus m_nOrderStatus; //委托状态
        EEntrustTypes m_eEntrustType; //委托类别
    }
}
