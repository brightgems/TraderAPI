using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderAPI
{
    public enum EEntrustSubmitStatus
    {
        ENTRUST_SUBMIT_STATUS_InsertSubmitted = 48,  //已经提交
        ENTRUST_SUBMIT_STATUS_CancelSubmitted, //撤单已经提交
        ENTRUST_SUBMIT_STATUS_ModifySubmitted, //修改已经提交
        ENTRUST_SUBMIT_STATUS_OSS_Accepted, //已经接受
        ENTRUST_SUBMIT_STATUS_InsertRejected, //报单已经被拒绝
        ENTRUST_SUBMIT_STATUS_CancelRejected, //撤单已经被拒绝
        ENTRUST_SUBMIT_STATUS_ModifyRejected, //改单已经被拒绝
    };
}
