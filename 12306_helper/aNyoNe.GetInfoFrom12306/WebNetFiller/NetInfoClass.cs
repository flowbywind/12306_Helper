using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aNyoNe.GetInfoFrom12306
{
    class NetInfoClass
    {
        private string _linkInfo;
        private string _method;
        private string _queryString;
        private string _postData;
        private string _backData;
        private string _referer;

        public NetInfoClass(string link,string referer,string method,string querystring,string postdata,string backdata)
        {
            this._linkInfo = link;
            this._method = method;
            this._queryString = querystring;
            this._postData = postdata;
            this._backData = backdata;
            this._referer = referer;
        }
        public string Referer
        {
            get { return _referer; }
            set { _referer = value; }
        }
        public string LinkInfo
        {
            get { return _linkInfo; }
            set { _linkInfo = value; }
        }
        public string Method
        {
            get { return _method; }
            set { _method = value; }
        }
        public string QueryString
        {
            get { return _queryString; }
            set { _queryString = value; }
        }
        public string PostData
        {
            get { return _postData; }
            set { _postData = value; }
        }
        public string BackData
        {
            get { return _backData; }
            set { _backData = value; }
        }

    }
}
