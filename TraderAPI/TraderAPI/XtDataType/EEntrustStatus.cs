using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderAPI
{
    public enum  EEntrustStatus
    {
        ENTRUST_STATUS_WAIT_END = 0,  //委托状态已经在ENTRUST_STATUS_CANCELED或以上，但是成交数额还不够，等成交回报来
        ENTRUST_STATUS_UNREPORTED = 48,  //未报
        ENTRUST_STATUS_WAIT_REPORTING, //待报
        ENTRUST_STATUS_REPORTED, //已报
        ENTRUST_STATUS_REPORTED_CANCEL, //已报待撤
        ENTRUST_STATUS_PARTSUCC_CANCEL, //部成待撤
        ENTRUST_STATUS_PART_CANCEL, //部撤
        ENTRUST_STATUS_CANCELED, //已撤
        ENTRUST_STATUS_PART_SUCC, //部成
        ENTRUST_STATUS_SUCCEEDED, //已成
        ENTRUST_STATUS_JUNK, //废单
        ENTRUST_STATUS_UNKNOWN, //未知
    };
}
