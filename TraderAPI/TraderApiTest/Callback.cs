using System;
using NetApi;
using System.Threading;

namespace TraderApiTest
{
    class Callback : XtTraderApiCallback
    {
        public int m_nRequestId;
        public string accountID = "37000205_02";

        public override void onConnected(bool success, String errorMsg)
        {
            System.Console.WriteLine("connect " + success);
            if (success)
            {
                System.Console.WriteLine("connect success!");
                m_TraderApi.userLogin("trade1", "123", ++this.m_nRequestId);//客户端用户登录       
            }
            else
            {
                System.Console.WriteLine("connect failed! " + errorMsg);
                //exit(-1);
            }
        }

        public override void onUserLogin(String userName, String password, int nRequestId, XtError error)
        {
            System.Console.WriteLine("UserLogin " + (error.isSuccess() ? " rtn success" : (" ERR ID" + error.errorID() + " msg: " + error.errorMsg() + userName)));

            //m_TraderApi.userLogout("trade1", "123", ++this.m_nRequestId);//客户端用户登出（测试无效）
            //m_TraderApi.reqAccountDetail(accountID, ++this.m_nRequestId);//请求资金明细
            //m_TraderApi.reqOrderDetail(accountID, ++this.m_nRequestId);//请求资金明细
            //m_TraderApi.reqDealDetail(accountID, ++this.m_nRequestId);//请求成交明细
            //m_TraderApi.reqPositionDetail(accountID, ++this.m_nRequestId);//请求持仓明细
            //m_TraderApi.reqPositionStatics(accountID, ++this.m_nRequestId);//请求持仓统计         
            //m_TraderApi.reqPriceData("SZ", "002208", ++this.m_nRequestId);//行情数据请求

            COrdinaryOrder ordinaryOrder = new COrdinaryOrder();
            ordinaryOrder.m_strAccountID = accountID;   
            ordinaryOrder.m_ePriceType = EPriceType.PRTP_BUY1;
            ordinaryOrder.m_nVolume = 200;
            ordinaryOrder.m_dSuperPrice = 0;
            ordinaryOrder.m_strMarket = "SZ";
            ordinaryOrder.m_strInstrument = "002589";
            ordinaryOrder.m_eOperationType = EOperationType.OPT_BUY;
            ordinaryOrder.m_eHedgeFlag = EHedge_Flag_Type.HEDGE_FLAG_ARBITRAGE;         
            m_TraderApi.order(ordinaryOrder, ++this.m_nRequestId);//下单操作(普通单)


            //CGroupOrder groupOrder = new CGroupOrder();
            //m_TraderApi.order(groupOrder, ++this.m_nRequestId);//下单操作(组合单)
            //CAlgorithmOrder algorithmOrder = new CAlgorithmOrder();
            //m_TraderApi.order(algorithmOrder, ++this.m_nRequestId);//下单操作(算法单)
            //int orderID = 1;
            //m_TraderApi.cancel(orderID, ++this.m_nRequestId);//撤单操作


        }

        public override void onUserLogout(String userName, String password, int nRequestId, XtError error)
        {
            System.Console.WriteLine("onUserLogout " + (error.isSuccess() ? " rtn success" : (" ERR ID" + error.errorID() + " msg: " + error.errorMsg() + userName)));
        }

        public override void onReqAccountDetail(String accountID, int nRequestId, CAccountDetail data, bool isLast, XtError error)
        {
            System.Console.WriteLine("onReqAccountDetail:" + " isLast " + isLast + (error.isSuccess() ? " rtn  success" : (" ERR ID" + error.errorID() + " msg: " + error.errorMsg())));
        }

        public override void onReqOrderDetail(String accountID, int nRequestId, COrderDetail data, bool isLast, XtError error)
        {
            System.Console.WriteLine("onReqOrderDetail:" + " isLast " + isLast + (error.isSuccess() ? " rtn success" : (" ERR ID" + error.errorID() + " msg: " + error.errorMsg())));
        }

        public override void onReqDealDetail(String accountID, int nRequestId, CDealDetail data, bool isLast, XtError error)
        {
            System.Console.WriteLine("onReqDealDetail:" + " isLast " + isLast + (error.isSuccess() ? " rtn success" : (" ERR ID" + error.errorID() + " msg: " + error.errorMsg())));
        }

        public override void onReqPositionDetail(String accountID, int nRequestId, CPositionDetail data, bool isLast, XtError error)
        {
            System.Console.WriteLine("onReqPositionDetail:" + " isLast " + isLast + (error.isSuccess() ? " rtn  success" + data.ToString() : (" ERR ID" + error.errorID() + " msg: " + error.errorMsg())));
        }

        public override void onReqPositionStatics(String accountID, int nRequestId, CPositionStatics data, bool isLast, XtError error)
        {
            System.Console.WriteLine("onReqPositionStatics:" + " isLast " + isLast + (error.isSuccess() ? " rtn  success" + data.ToString() : (" ERR ID" + error.errorID() + " msg: " + error.errorMsg())));
        }

        public override void onReqPriceData(int nRequestId, CPriceData data, XtError error)
        {
            System.Console.WriteLine("onReqPriceData OpenPrice: " + data.m_dOpenPrice);
        }

        public override void onOrder(int nRequestId, int orderID, XtError error)
        {
            System.Console.WriteLine("onOrder ID:" + orderID + (error.isSuccess() ? " success" : (" ERR ID" + error.errorID() + " msg: " + error.errorMsg())));
        }

        public override void onCancel(int nRequestId, XtError error)
        {
            System.Console.WriteLine("onCancel " + (error.isSuccess() ? " success" : (" ERR ID" + error.errorID() + " msg: " + error.errorMsg())));
        }



        /// <summary>
        /// 委托明细
        /// </summary>
        /// <param name="data"></param>
        public override void onRtnOrderDetail(COrderDetail data)
        {
            System.Console.WriteLine("onRtnOrderDetail");
            if (data.m_nErrorID == 0 || data.m_nErrorID == 2147483647)//INT_MAX limits in c++
            {
                System.Console.WriteLine("onRtnOrderDetail"
                        + "\n    m_nOrderStatus:  " + data.m_nOrderStatus
                        + "\n    m_nOrderID: " + data.m_nOrderID
                        //+ "\n     time: " + makeCurTimestamp()
                        + "\n   instrumentID: " + data.m_strInstrumentID);
            }
            else
            {
                System.Console.WriteLine("onRtnOrderDetai] Failure,    " + data.m_nOrderID
                        + "\n        , ErrorID: " + data.m_nErrorID
                        + "\n        , ErrorMsg: " + data.m_strErrorMsg);
            }
        }
        /// <summary>
        /// 成交明细
        /// </summary>
        /// <param name="data"></param>
        public override void onRtnDealDetail(CDealDetail data)
        {
            System.Console.WriteLine("onRtnDealDetail " + data.ToString());
        }
        /// <summary>
        /// 委托错误信息
        /// </summary>
        /// <param name="data"></param>
        public override void onRtnOrderError(COrderError data)
        {
            System.Console.WriteLine("onRtnOrderError " + data.ToString());
        }
        /// <summary>
        /// 撤销信息
        /// </summary>
        /// <param name="data"></param>
        public override void onRtnCancelError(CCancelError data)
        {
            System.Console.WriteLine("onRtnCancelError " + data.ToString());
        }
        /// <summary>
        /// 用户登录状态
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="status"></param>
        /// <param name="errorMsg"></param>
        public override void onRtnLoginStatus(String accountID, EBROKER_LOGIN_STATUS status, String errorMsg)
        {
            System.Console.WriteLine("onRtnLoginStatus id " + accountID + ((status == EBROKER_LOGIN_STATUS.BROKER_LOGIN_STATUS_OK) ? (status + "") : (" with error " + errorMsg)));
            String stockAccountID = "37000088";
            if (status == EBROKER_LOGIN_STATUS.BROKER_LOGIN_STATUS_OK && stockAccountID == accountID)
            {
                {
                    if (accountID == stockAccountID)
                    {

                        for (int i = 0; i < 1; ++i)
                        {
                            COrdinaryOrder orderInfo = new COrdinaryOrder();
                            orderInfo.m_strAccountID = accountID;
                            orderInfo.m_nVolume = 1000;
                            orderInfo.m_eOperationType = EOperationType.OPT_SELL;
                            orderInfo.m_dPrice = 15.29;   // priceType != PRTP_FIX
                            orderInfo.m_ePriceType = EPriceType.PRTP_FIX;
                            orderInfo.m_strInstrument = "000002";
                            orderInfo.m_strMarket = "SZ";
                            System.Console.WriteLine("stock order");
                            m_TraderApi.order(orderInfo, 100);
                            System.Console.WriteLine("after stock order");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 1; ++i)
                        {
                            COrdinaryOrder orderInfo = new COrdinaryOrder();
                            orderInfo.m_strAccountID = accountID;
                            orderInfo.m_nVolume = 1;
                            orderInfo.m_eOperationType = EOperationType.OPT_SELL;
                            //orderInfo.m_dPrice = 97.2;   // priceType != PRTP_FIX
                            orderInfo.m_ePriceType = EPriceType.PRTP_FIX;
                            orderInfo.m_strInstrument = "000002";
                            orderInfo.m_strMarket = "SZ";
                            orderInfo.m_strProduct = "IF1502";
                            System.Console.WriteLine("order");
                            m_TraderApi.order(orderInfo, 100);
                            System.Console.WriteLine("after order");
                        }
                    }
                }//*/
                //*
                {
                    CGroupOrder orderInfo = new CGroupOrder();
                    orderInfo.m_orderParam = new CAlgorithmOrder();
                    orderInfo.m_orderParam.m_dSingleVolumeRate = 0.5;
                    orderInfo.m_orderParam.m_dSuperPrice = 1;
                    orderInfo.m_orderParam.m_dPriceRangeMax = 100;
                    orderInfo.m_orderParam.m_dPriceRangeMin = 1;
                    orderInfo.m_orderParam.m_dPlaceOrderInterval = 0.001;
                    orderInfo.m_orderParam.m_dWithdrawOrderInterval = 10;
                    orderInfo.m_orderParam.m_eOperationType = EOperationType.OPT_SELL;
                    orderInfo.m_orderParam.m_ePriceType = EPriceType.PRTP_LATEST;
                    orderInfo.m_orderParam.m_eSingleVolumeType = EVolumeType.VOLUME_FIX;
                    orderInfo.m_orderParam.m_nMaxOrderCount = 1000;
                    orderInfo.m_orderParam.m_nMaxWithdrawCount = 100;
                    orderInfo.m_orderParam.m_strAccountID = stockAccountID;
                    orderInfo.m_nOrderNum = 18;
                    orderInfo.m_strInstrument = new String[18];
                    orderInfo.m_strMarket = new String[18];
                    orderInfo.m_nVolume = new int[18];// = 200;
                    for (int i = 0; i < 18; i++)
                    {
                        String strInstrumentID = "";
                        int instrumentid = 2 * i + 2;
                        if (instrumentid < 10)
                        {
                            strInstrumentID = "00000";
                        }
                        else
                        {
                            strInstrumentID = "0000";
                        }
                        strInstrumentID += instrumentid;
                        orderInfo.m_strInstrument[i] = strInstrumentID;
                        orderInfo.m_strMarket[i] = "SZ";
                        orderInfo.m_nVolume[i] = 200;// = 200;
                    }
                    m_TraderApi.order(orderInfo, 18);
                    //System.Console.WriteLine("Order time: " + makeCurTimestamp());//  + std::endl;
                }//*/
                //*
                {
                    CAlgorithmOrder orderInfo = new CAlgorithmOrder();
                    orderInfo.m_dPlaceOrderInterval = 0.001;
                    orderInfo.m_dPriceRangeMax = 100;
                    orderInfo.m_dPriceRangeMin = 6.7;
                    orderInfo.m_dSingleVolumeRate = 0.005;
                    orderInfo.m_dSuperPrice = 0.5;
                    orderInfo.m_dWithdrawOrderInterval = 10;
                    orderInfo.m_eOperationType = EOperationType.OPT_BUY;
                    orderInfo.m_ePriceType = EPriceType.PRTP_LATEST;
                    orderInfo.m_eSingleVolumeType = EVolumeType.VOLUME_FIX;
                    orderInfo.m_nMaxOrderCount = 300;
                    orderInfo.m_strAccountID = stockAccountID;
                    orderInfo.m_strInstrument = "000002";
                    orderInfo.m_strMarket = "SZ";
                    orderInfo.m_nVolume = 500;
                    m_TraderApi.order(orderInfo, 19);
                }//*/
            }
        }
        /// <summary>
        /// 结算状态
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="status"></param>
        /// <param name="errorMsg"></param>
        public override void onRtnDeliveryStatus(String accountID, bool status, String errorMsg)
        {
            System.Console.WriteLine("onRtnDeliveryStatus ID:" + accountID + (status ? "OK" : " with Msg " + errorMsg));
        }
        /// <summary>
        /// 账号信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="errorMsg"></param>
        public override void onRtnRCMsg(String accountID, String errorMsg)
        {
            System.Console.WriteLine("onRtnRCMsg ID:" + accountID + " with Msg " + errorMsg);
        }
        /// <summary>
        /// 资金账号资金明细信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="accountDetail"></param>
        public override void onRtnAccountDetail(String accountID, CAccountDetail accountDetail)
        {
            System.Console.WriteLine("onRtnAccountDetail ID:" + accountID + " with detail " + accountDetail.ToString());
        }
        /// <summary>
        /// 未知
        /// </summary>
        /// <param name="data"></param>
        public override void onRtnNetValue(CNetValue data)
        {
            System.Console.WriteLine("onRtnNetValue, productid: " + data.m_nProductId);
        }
    }
}
