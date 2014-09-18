using System.Collections;
using System.Drawing;
using System.Net;
using aNyoNe.GetInfoFrom12306;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace _12306_Helper
{
    class GetDatas_Background
    {
        #region Get passengers for submit in background
        private bool _dataStatus = false;
        public bool DataStatus {
            get { return _dataStatus; }
        }
        protected void InitPassengerDTO(CookieContainer cookieContainer, String token)
        {
            var passengerAction = new GetPassengerAction();
            passengerAction.PostData = string.Format("_json_att=&REPEAT_SUBMIT_TOKEN={0}", token);
            passengerAction.GetPassengersAllJson((strPassenger) =>
            {
                var htmlTrans = new HTML_Translation();
                var returnStrings = htmlTrans.TranslationHtmlEx(strPassenger);
                if (returnStrings["data"]["normal_passengers"].Count() > 0)
                    _dataStatus= true;
                else
                {
                    _dataStatus= false;
                }
            }, cookieContainer);
        }
        #endregion

        #region Get Token and leftticket information for submit in background
        private bool _dataReady = false;
        public bool DataReady 
        {
            get { return _dataReady; }
        }

        private Hashtable _tokenDatas=new Hashtable();
        public Hashtable TokenDatas
        {
            get
            {
                if(_dataReady)
                    return _tokenDatas;
                else
                {
                    return null;
                }
            }
        }

        protected void InitTokenDatasDTO(CookieContainer cookieContainer,string postData)
        {
            TokenDatas.Clear();
            var submitAction = new SubmitOrderAction();
            var htmlTran = new HTML_Translation();
            submitAction.PostData = postData;
            submitAction.EnterSubmitPage((str) =>
            {
                var returnString = htmlTran.TranslationHtmlEx(str);
                if (returnString["messages"].Any())
                {
                    if (str.Contains("未完成订单"))
                    {
                        TokenDatas["errMsg"] = "你有未完成的订单等待处理";
                        return;
                    }
                    else
                    {
                        TokenDatas["errMsg"] = "获取Token失败";
                        return;
                    }
                }
                string tokenHtml = submitAction.GetTokenFromSubmitPage(cookieContainer);
                TokenDatas["Token"] =
                    System.Text.RegularExpressions.Regex.Match(tokenHtml,
                        "(?<=var globalRepeatSubmitToken = ')[0-9abcdefABCDEF]{32}").ToString();
                TokenDatas["leftTicket"] =
                    System.Text.RegularExpressions.Regex.Match(tokenHtml, "(?<='leftTicketStr':')[0-9A-Za-z]{30,50}")
                        .ToString();
                TokenDatas["keyCheck"] =
                    System.Text.RegularExpressions.Regex.Match(tokenHtml, "(?<='key_check_isChange':')[0-9A-Za-z]*")
                        .ToString();
                TokenDatas["trainLocation"] =
                    System.Text.RegularExpressions.Regex.Match(tokenHtml, "(?<='train_location':')[^']*").ToString();
                TokenDatas["purposeCodes"] =
                    System.Text.RegularExpressions.Regex.Match(tokenHtml, "(?<='purpose_codes':')[^']*").ToString();
                TokenDatas["ticketInfoForPassengerForm"] =
                    System.Text.RegularExpressions.Regex.Match(tokenHtml, "(?<=ticketInfoForPassengerForm=)[^;]*")
                        .ToString()
                        .Replace("'", "\"");
                var javaObj = htmlTran.TranslationHtmlEx(TokenDatas["ticketInfoForPassengerForm"].ToString());
                TokenDatas["queryLeftNewDetailDTO"] = javaObj["queryLeftNewDetailDTO"] as JObject;

                if (TokenDatas["Token"] != null && TokenDatas["Token"].ToString() != "" &&
                    TokenDatas["leftTicket"] != null && TokenDatas["leftTicket"].ToString() != "")
                {
                    _dataReady = true;
                }
                else
                {
                    _dataReady = false;
                }
            },cookieContainer);
        }
        #endregion

        #region Check submit information in background
        private bool _checkState = false;
        public bool CheckState
        {
            get { return _checkState; }
        }
        protected bool ChencSubmitDatas(CookieContainer cookieContainer, String postData)
        {
            var submitAction = new SubmitOrderAction();
            var translation = new HTML_Translation();
            submitAction.PostData = postData;
            var str = submitAction.CheckOrderInfoEx(cookieContainer);
            var returnString = translation.TranslationHtmlEx(str);
            if (returnString["data"]["errMsg"] != null && returnString["data"]["errMsg"].ToString() != "")
            {
                return  _checkState = false;
            }
            if (str.Contains("取消次数过多"))
            {
                return _checkState = false;
            }
            if (returnString["data"]["get608Msg"] != null)
            {
                return  _checkState = false;
            }
            if (returnString["messages"].Any())
            {
                return _checkState = false;
            }
            return _checkState = true;
        }
        #endregion

        #region Get randcode for submit in background
        private void GetRandCodeImgForSubmit(CookieContainer cookieContainer,Action<Image> callback )
        {
            var submitAction = new SubmitOrderAction();
            submitAction.GetOrderRandCodeImg((bit) =>
            {
                callback(bit);
            }, cookieContainer);
        }
        #endregion
    }
}
