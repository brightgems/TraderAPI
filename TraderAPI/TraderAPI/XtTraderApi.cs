using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TraderAPI
{
    public class XtTraderApi
    {
        [DllImport("Tzb.dll")]
        public static extern int count(int init);

        /// <summary>
        /// 客户端用户登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <param name="nRequestId"></param>
        [DllImport("XtTraderApi.dll")]
        public static extern void userLogin(string userName,string passWord,int nRequestId);

        /// <summary>
        /// 客户端用户登出
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <param name="nRequestId"></param>
        [DllImport("XtTraderApi.dll")]
        public static extern void userLogout(string userName, string passWord, int nRequestId);

        /// <summary>
        /// 请求资金明细
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="nRequestId"></param>
        [DllImport("XtTraderApi.dll")]
        public static extern void reqAccountDetail(string accountID, int nRequestId);

        /// <summary>
        /// 请求委托明细
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="nRequestId"></param>
        [DllImport("XtTraderApi.dll")]
        public static extern void reqOrderDetail(string accountID, int nRequestId);

        /// <summary>
        /// 请求成交明细
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="nRequestId"></param>
        [DllImport("XtTraderApi.dll")]
        public static extern void reqDealDetail(string accountID, int nRequestId);

        /// <summary>
        /// 请求持仓明细
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="nRequestId"></param>
        [DllImport("XtTraderApi.dll")]
        public static extern void reqPositionDetail(string accountID, int nRequestId);

        /// <summary>
        /// 请求持仓统计
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="nRequestId"></param>
        [DllImport("XtTraderApi.dll")]
        public static extern void reqPositionStatics(string accountID, int nRequestId);

        /// <summary>
        /// 行情数据请求
        /// </summary>
        /// <param name="exchangeId"></param>
        /// <param name="instrumentId"></param>
        /// <param name="nRequestId"></param>
        [DllImport("XtTraderApi.dll")]
        public static extern void reqPriceData(string exchangeId,string instrumentId, int nRequestId);
    }
}
