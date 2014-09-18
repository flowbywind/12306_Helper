using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Specialized;
using System.Threading;
using System.IO;

namespace HttpProxy
{
    public sealed class HttpClient : Client
    {
        // private variables
        /// <summary>Holds the value of the UserIP</summary>
        private long m_GuestAddress;
        /// <summary>Holds the value of the UserID</summary>
        private int m_GuestID;
        /// <summary>Holds the value of the ValidUser property.</summary>
        private bool m_bIsValidUser;
        /// <summary>Holds the value of the Ftp(web)Query property.</summary>
        private bool m_bIsFtpConn;
        /// <summary>Holds the value of the DesitinationFtp(web)Socket property.</summary>
        private Socket m_DestinationFtpSocket;
        //private string m_strCurrentHost = "" ;
        /// <summary>Holds the value of the HttpQuery property.</summary>
        private string m_HttpQuery = "";
        /// <summary>Holds the value of the RequestedPath property.</summary>
        private string m_RequestedPath = null;
        /// <summary>Holds the value of the HeaderFields property.</summary>
        private StringDictionary m_HeaderFields = null;
        /// <summary>Holds the value of the HttpVersion property.</summary>
        private string m_HttpVersion = "";
        /// <summary>Holds the value of the HttpRequestType property.</summary>
        private string m_HttpRequestType = "";
        /// <summary>Holds the POST data</summary>
        private string m_HttpPost = null;
        ///<summary>Initializes a new instance of the HttpClient class.</summary>
        ///<param name="ClientSocket">The <see cref ="Socket">Socket</see> connection between this proxy server and the local client.</param>
        ///<param name="Destroyer">The callback method to be called when this Client object disconnects from the local client and the remote server.</param>
        public HttpClient(Socket ClientSocket, DestroyDelegate Destroyer)
            : base(ClientSocket, Destroyer)
        {
            m_bIsFtpConn = false;
            m_bIsValidUser = false;
        }
        ///<summary>Gets or sets the Guest Address.</summary>
        ///<value>A long representing the Address.</value>
        public long GuestAddress
        {
            get
            {
                return m_GuestAddress;
            }
            set
            {
                m_GuestAddress = value;
            }
        }
        ///<summary>Gets or sets the Guest ID.</summary>
        ///<value>A int representing the ID.</value>
        public int GuestID
        {
            get
            {
                return m_GuestID;
            }
            set
            {
                m_GuestID = value;
            }
        }
        ///<summary>Gets or sets a StringDictionary that stores the header fields.</summary>
        ///<value>A StringDictionary that stores the header fields.</value>
        private Socket DestinationFtpSocket
        {
            get
            {
                return m_DestinationFtpSocket;
            }
            set
            {
                if (m_DestinationFtpSocket != null)
                    m_DestinationFtpSocket.Close();
                m_DestinationFtpSocket = value;
            }
        }
        ///<summary>Gets or sets a StringDictionary that stores the header fields.</summary>
        ///<value>A StringDictionary that stores the header fields.</value>
        private StringDictionary HeaderFields
        {
            get
            {
                return m_HeaderFields;
            }
            set
            {
                m_HeaderFields = value;
            }
        }
        ///<summary>Gets or sets the HTTP version the client uses.</summary>
        ///<value>A string representing the requested HTTP version.</value>
        private string HttpVersion
        {
            get
            {
                return m_HttpVersion;
            }
            set
            {
                m_HttpVersion = value;
            }
        }
        ///<summary>Gets or sets the HTTP request type.</summary>
        ///<remarks>
        ///Usually, this string is set to one of the three following values:
        ///<list type="bullet">
        ///<item>GET</item>
        ///<item>POST</item>
        ///<item>CONNECT</item>
        ///</list>
        ///</remarks>
        ///<value>A string representing the HTTP request type.</value>
        private string HttpRequestType
        {
            get
            {
                return m_HttpRequestType;
            }
            set
            {
                m_HttpRequestType = value;
            }
        }
        ///<summary>Gets or sets the requested path.</summary>
        ///<value>A string representing the requested path.</value>
        public string RequestedPath
        {
            get
            {
                return m_RequestedPath;
            }
            set
            {
                m_RequestedPath = value;
            }
        }
        ///<summary>Gets or sets the query string, received from the client.</summary>
        ///<value>A string representing the HTTP query string.</value>
        private string HttpQuery
        {
            get
            {
                return m_HttpQuery;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                m_HttpQuery = value;
            }
        }
        ///<summary>Starts receiving data from the client connection.</summary>
        public override void StartHandshake()
        {

            try
            {
                ClientSocket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(this.OnReceiveQuery), ClientSocket);
            }
            catch
            {
                Dispose();
            }

        }

        ///<summary>Called when we received some data from the client connection.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnReceiveQuery(IAsyncResult ar)
        {
            int Ret;
            try
            {
                Ret = ClientSocket.EndReceive(ar);
            }
            catch
            {
                Ret = -1;
            }
            if (Ret <= 0)
            { //Connection is dead :(
                Dispose();
                return;
            }
            HttpQuery += Encoding.ASCII.GetString(Buffer, 0, Ret);
            //	Console.WriteLine(HttpQuery);
            //if received data is valid HTTP request...
            if (IsValidQuery(HttpQuery))
            {
                ProcessQuery(HttpQuery);
                //else, keep listening
            }
            else
            {
                try
                {

                }
                catch
                {
                    Dispose();
                }
            }
        }
        ///<summary>Checks whether a specified string is a valid HTTP query string.</summary>
        ///<param name="Query">The query to check.</param>
        ///<returns>True if the specified string is a valid HTTP query, false otherwise.</returns>
        private bool IsValidQuery(string Query)
        {
            int index = Query.IndexOf("\r\n\r\n");
            if (index == -1)
                return false;
            HeaderFields = ParseQuery(Query);
            if (HttpRequestType.ToUpper().Equals("POST"))
            {
                try
                {
                    //int length = int.Parse((string)HeaderFields["Content-Length"]);
                    //return Query.Length >= index + 6 + length;
                    return true;
                }
                catch
                {
                    SendBadRequest();
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        ///<summary>Processes a specified query and connects to the requested HTTP web server.</summary>
        ///<param name="Query">A string containing the query to process.</param>
        ///<remarks>If there's an error while processing the HTTP request or when connecting to the remote server, the Proxy sends a "400 - Bad Request" error to the client.</remarks>
        private void ProcessQuery(string Query)
        {

            HeaderFields = ParseQuery(Query);
            if (HeaderFields == null)//|| !HeaderFields.ContainsKey("Host")) 
            {
                SendBadRequest();
                return;
            }
            int Port;
            string Host;
            int Ret;
            if (true == m_bIsValidUser)
            {
                SendLoginRequest();
                Dispose();
                return;
            }
            if (HttpRequestType.ToUpper().Equals("CONNECT"))
            { //HTTPS
                Ret = RequestedPath.IndexOf(":");
                if (Ret >= 0)
                {
                    Host = RequestedPath.Substring(0, Ret);
                    if (RequestedPath.Length > Ret + 1)
                        Port = int.Parse(RequestedPath.Substring(Ret + 1));
                    else
                        Port = 443;
                }
                else
                {
                    Host = RequestedPath;
                    Port = 443;
                }
            }
            else
            { //Normal HTTP
                Ret = ((string)HeaderFields["Host"]).IndexOf(":");
                if (Ret > 0)
                {
                    Host = ((string)HeaderFields["Host"]).Substring(0, Ret);
                    Port = int.Parse(((string)HeaderFields["Host"]).Substring(Ret + 1));
                }
                else
                {
                    Host = (string)HeaderFields["Host"];
                    Port = 80;
                }
                if (HttpRequestType.ToUpper().Equals("POST"))
                {
                    int index = Query.IndexOf("\r\n\r\n");
                    m_HttpPost = Query.Substring(index + 4);
                }
            }
            try
            {

                if (true == m_bIsFtpConn)
                {
                    IPEndPoint DestinationEndPoint = new IPEndPoint(Dns.Resolve(Host).AddressList[0], Port);
                    DestinationFtpSocket = new Socket(DestinationEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    if (HeaderFields.ContainsKey("Proxy-Connection") && HeaderFields["Proxy-Connection"].ToLower().Equals("keep-alive"))
                        DestinationFtpSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, 1);
                    DestinationFtpSocket.BeginConnect(DestinationEndPoint, new AsyncCallback(this.OnFtpConnected), DestinationFtpSocket);
                    m_bIsFtpConn = false;

                }
                else
                {
                    IPEndPoint DestinationEndPoint = new IPEndPoint(Dns.Resolve(Host).AddressList[0], Port);
                    DestinationSocket = new Socket(DestinationEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    if (HeaderFields.ContainsKey("Proxy-Connection") && HeaderFields["Proxy-Connection"].ToLower().Equals("keep-alive"))
                        DestinationSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, 1);
                    DestinationSocket.BeginConnect(DestinationEndPoint, new AsyncCallback(this.OnConnected), DestinationSocket);
                }
            }
            catch
            {
                SendBadRequest();
                return;
            }
        }
        ///<summary>Called when we connect the remote ftp server.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnFtpConnected(IAsyncResult ar)
        {
            try
            {
                DestinationFtpSocket.EndConnect(ar);
                string rq = "USER Anonymous\r\n";
                DestinationFtpSocket.BeginSend(Encoding.ASCII.GetBytes(rq), 0, rq.Length, SocketFlags.None, new AsyncCallback(this.OnFtpUserQuerySent), DestinationFtpSocket);

            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Called when we send the USER command.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnFtpUserQuerySent(IAsyncResult ar)
        {
            try
            {
                if (DestinationFtpSocket.EndSend(ar) == -1)
                {
                    Dispose();
                    return;
                }

                System.Threading.Thread.Sleep(800);
                DestinationFtpSocket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(this.OnFtpUserQueryRecv), DestinationFtpSocket);
            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Called when we send the PASS command.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnFtpUserQueryRecv(IAsyncResult ar)
        {
            try
            {
                int ret = DestinationFtpSocket.EndReceive(ar);
                if (ret == -1)
                {
                    Dispose();
                    return;
                }

                string rq = "PASS Unknown@sina.com.cn\r\n";
                DestinationFtpSocket.BeginSend(Encoding.ASCII.GetBytes(rq), 0, rq.Length, SocketFlags.None, new AsyncCallback(this.OnFtpPassQuerySent), DestinationFtpSocket);
            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Called when we receive the PASS response.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnFtpPassQuerySent(IAsyncResult ar)
        {
            try
            {
                if (DestinationFtpSocket.EndSend(ar) == -1)
                {
                    Dispose();
                    return;
                }

                DestinationFtpSocket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(this.OnFtpPassQueryRecv), DestinationFtpSocket);
            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Called when we send the PASV command.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnFtpPassQueryRecv(IAsyncResult ar)
        {
            try
            {
                int ret = DestinationFtpSocket.EndReceive(ar);
                if (ret == -1)
                {
                    Dispose();
                    return;
                }

                string rq = "PASV\r\n";
                DestinationFtpSocket.BeginSend(Encoding.ASCII.GetBytes(rq), 0, rq.Length, SocketFlags.None, new AsyncCallback(this.OnFtpPasvQuerySent), DestinationFtpSocket);
            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Called when we receive the PASV response.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnFtpPasvQuerySent(IAsyncResult ar)
        {
            try
            {
                if (DestinationFtpSocket.EndSend(ar) == -1)
                {
                    Dispose();
                    return;
                }

                DestinationFtpSocket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(this.OnFtpPasvQueryRecv), DestinationFtpSocket);
            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Called when we receive the download port.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnFtpPasvQueryRecv(IAsyncResult ar)
        {
            try
            {
                int ret = DestinationFtpSocket.EndReceive(ar);
                if (ret == -1)
                {
                    Dispose();
                    return;
                }

                IPEndPoint ConnectTo = ParsePasvIP(Encoding.ASCII.GetString(Buffer, 0, ret));
                DestinationSocket = new Socket(ConnectTo.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                DestinationSocket.BeginConnect(ConnectTo, new AsyncCallback(this.OnPasvConnected), DestinationSocket);

            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Called when we send TYPE command.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnPasvConnected(IAsyncResult ar)
        {
            try
            {
                DestinationSocket.EndConnect(ar);
                string rq = "TYPE I\r\n";
                DestinationFtpSocket.BeginSend(Encoding.ASCII.GetBytes(rq), 0, rq.Length, SocketFlags.None, new AsyncCallback(this.OnTypeQuerySent), DestinationFtpSocket);
            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Called when we receive the TYPE command response .</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnTypeQuerySent(IAsyncResult ar)
        {
            try
            {
                if (DestinationFtpSocket.EndSend(ar) == -1)
                {
                    Dispose();
                    return;
                }

                DestinationFtpSocket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(this.OnTypeQueryRecv), DestinationFtpSocket);
            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Called when we send the REST command.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnTypeQueryRecv(IAsyncResult ar)
        {
            try
            {
                int ret = DestinationFtpSocket.EndReceive(ar);
                if (ret == -1)
                {
                    Dispose();
                    return;
                }

                string rq = "REST 0\r\n";
                DestinationFtpSocket.BeginSend(Encoding.ASCII.GetBytes(rq), 0, rq.Length, SocketFlags.None, new AsyncCallback(this.OnRestQuerySent), DestinationFtpSocket);
            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Called when we received the REST response.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnRestQuerySent(IAsyncResult ar)
        {
            try
            {
                if (DestinationFtpSocket.EndSend(ar) == -1)
                {
                    Dispose();
                    return;
                }

                DestinationFtpSocket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(this.OnRestQueryRecv), DestinationFtpSocket);
            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Called when we send the RETR command.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnRestQueryRecv(IAsyncResult ar)
        {
            try
            {
                int ret = DestinationFtpSocket.EndReceive(ar);
                if (ret == -1)
                {
                    Dispose();
                    return;
                }

                string rq = "RETR ";
                rq += RequestedPath;
                rq += "\r\n";
                DestinationFtpSocket.BeginSend(Encoding.ASCII.GetBytes(rq), 0, rq.Length, SocketFlags.None, new AsyncCallback(this.OnFtpQuerySent), DestinationFtpSocket);
            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Called when we begin receive the data.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnFtpQuerySent(IAsyncResult ar)
        {
            try
            {
                if (DestinationFtpSocket.EndSend(ar) == -1)
                {
                    Dispose();
                    return;
                }


                StartRelay();
            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Called when we parse the PASV response .</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private IPEndPoint ParsePasvIP(string Reply)
        {
            int StartIndex, StopIndex;
            string IPString;
            StartIndex = Reply.IndexOf("(");
            if (StartIndex == -1)
            {
                return null;
            }
            else
            {
                StopIndex = Reply.IndexOf(")", StartIndex);
                if (StopIndex == -1)
                    return null;
                else
                    IPString = Reply.Substring(StartIndex + 1, StopIndex - StartIndex - 1);
            }
            string[] Parts = IPString.Split(',');
            if (Parts.Length == 6)
                return new IPEndPoint(IPAddress.Parse(String.Join(".", Parts, 0, 4)), int.Parse(Parts[4]) * 256 + int.Parse(Parts[5]));
            else
                return null;
        }
        ///<summary>Parses a specified HTTP query into its header fields.</summary>
        ///<param name="Query">The HTTP query string to parse.</param>
        ///<returns>A StringDictionary object containing all the header fields with their data.</returns>
        ///<exception cref="ArgumentNullException">The specified query is null.</exception>
        private StringDictionary ParseQuery(string Query)
        {
            StringDictionary retdict = new StringDictionary();
            string[] Lines = Query.Replace("\r\n", "\n").Split('\n');
            int Cnt, Ret;
            //Extract requested URL
            if (Lines.Length > 0)
            {
                //Parse the Http Request Type
                Ret = Lines[0].IndexOf(' ');
                if (Ret > 0)
                {
                    HttpRequestType = Lines[0].Substring(0, Ret);
                    Lines[0] = Lines[0].Substring(Ret).Trim();
                }
                //Parse the Http Version and the Requested Path
                Ret = Lines[0].LastIndexOf(' ');
                if (Ret > 0)
                {
                    HttpVersion = Lines[0].Substring(Ret).Trim();
                    RequestedPath = Lines[0].Substring(0, Ret);
                }
                else
                {
                    RequestedPath = Lines[0];
                }
                //Remove http:// if present
                if (RequestedPath.Length >= 7 && RequestedPath.Substring(0, 7).ToLower().Equals("http://"))
                {
                    Ret = RequestedPath.IndexOf('/', 7);
                    if (Ret == -1)
                        RequestedPath = "/";
                    else
                        RequestedPath = RequestedPath.Substring(Ret);
                }

                if (RequestedPath.Length >= 6 && RequestedPath.Substring(0, 6).ToLower().Equals("ftp://"))
                {
                    m_bIsFtpConn = true;
                    Ret = RequestedPath.IndexOf('/', 6);
                    if (Ret == -1)
                        RequestedPath = "/";
                    else
                        RequestedPath = RequestedPath.Substring(Ret);
                }

            }
            for (Cnt = 1; Cnt < Lines.Length; Cnt++)
            {
                Ret = Lines[Cnt].IndexOf(":");
                if (Ret > 0 && Ret < Lines[Cnt].Length - 1)
                {
                    try
                    {
                        retdict.Add(Lines[Cnt].Substring(0, Ret), Lines[Cnt].Substring(Ret + 1).Trim());
                    }
                    catch { }
                }
            }
            return retdict;
        }
        ///<summary>Sends a "400 - Bad Request" error to the client.</summary>
        private void SendBadRequest()
        {
            string brs = "HTTP/1.1 400 Bad Request\r\nConnection: close\r\nContent-Type: text/html\r\n\r\n<html><head><title>400 Bad Request</title></head><body><div align=\"center\"><table border=\"0\" cellspacing=\"3\" cellpadding=\"3\" bgcolor=\"#C0C0C0\"><tr><td><table border=\"0\" width=\"500\" cellspacing=\"3\" cellpadding=\"3\"><tr><td bgcolor=\"#B2B2B2\"><p align=\"center\"><strong><font size=\"2\" face=\"Verdana\">400 Bad Request</font></strong></p></td></tr><tr><td bgcolor=\"#D1D1D1\"><font size=\"2\" face=\"Verdana\"> The proxy server could not understand the HTTP request!<br><br> Please contact your network administrator about this problem.</font></td></tr></table></center></td></tr></table></div></body></html>";
            try
            {
                ClientSocket.BeginSend(Encoding.ASCII.GetBytes(brs), 0, brs.Length, SocketFlags.None, new AsyncCallback(this.OnErrorSent), ClientSocket);
            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Sends a "You must login" error to the client.</summary>
        private void SendLoginRequest()
        {
            string brs = "HTTP/1.1 400 Bad Request\r\nConnection: close\r\nContent-Type: text/html\r\n\r\n<html><head><title>400 Bad Request</title></head><body><div align=\"center\"><table border=\"0\" cellspacing=\"3\" cellpadding=\"3\" bgcolor=\"#C0C0C0\"><tr><td><table border=\"0\" width=\"500\" cellspacing=\"3\" cellpadding=\"3\"><tr><td bgcolor=\"#B2B2B2\"><p align=\"center\"><strong><font size=\"2\" face=\"Verdana\">400 Bad Request</font></strong></p></td></tr><tr><td bgcolor=\"#D1D1D1\"><font size=\"2\" face=\"Verdana\"> 请先运行客户端登陆，谢谢！<br><br> Please contact your network administrator about this problem.</font></td></tr></table></center></td></tr></table></div></body></html>";
            try
            {
                ClientSocket.BeginSend(Encoding.ASCII.GetBytes(brs), 0, brs.Length, SocketFlags.None, new AsyncCallback(this.OnErrorSent), ClientSocket);
            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Rebuilds the HTTP query, starting from the HttpRequestType, RequestedPath, HttpVersion and HeaderFields properties.</summary>
        ///<returns>A string representing the rebuilt HTTP query string.</returns>
        private string RebuildQuery()
        {
            string ret = HttpRequestType + " " + RequestedPath + " " + HttpVersion + "\r\n";
            if (HeaderFields != null)
            {
                foreach (string sc in HeaderFields.Keys)
                {
                    if (sc.Length < 6 || !sc.Substring(0, 6).Equals("proxy-"))
                        ret += System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sc) + ": " + (string)HeaderFields[sc] + "\r\n";
                }
                ret += "\r\n";
                if (m_HttpPost != null)
                    ret += m_HttpPost;
            }
            return ret;
        }
        ///<summary>Returns text information about this HttpClient object.</summary>
        ///<returns>A string representing this HttpClient object.</returns>
        public override string ToString()
        {
            return ToString(false);
        }
        ///<summary>Returns text information about this HttpClient object.</summary>
        ///<returns>A string representing this HttpClient object.</returns>
        ///<param name="WithUrl">Specifies whether or not to include information about the requested URL.</param>
        public string ToString(bool WithUrl)
        {
            string Ret;
            try
            {
                if (DestinationSocket == null || DestinationSocket.RemoteEndPoint == null)
                    Ret = "Incoming HTTP connection from " + ((IPEndPoint)ClientSocket.RemoteEndPoint).Address.ToString();
                else
                    Ret = "HTTP connection from " + ((IPEndPoint)ClientSocket.RemoteEndPoint).Address.ToString() + " to " + ((IPEndPoint)DestinationSocket.RemoteEndPoint).Address.ToString() + " on port " + ((IPEndPoint)DestinationSocket.RemoteEndPoint).Port.ToString();
                if (HeaderFields != null && HeaderFields.ContainsKey("Host") && RequestedPath != null)
                    Ret += "\r\n" + " requested URL: http://" + HeaderFields["Host"] + RequestedPath;
            }
            catch
            {
                Ret = "HTTP Connection";
            }
            return Ret;
        }

        ///<summary>Called when the Bad Request error has been sent to the client.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnErrorSent(IAsyncResult ar)
        {
            try
            {
                ClientSocket.EndSend(ar);
            }
            catch { }
            Dispose();
        }
        ///<summary>Called when we're connected to the requested remote host.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnConnected(IAsyncResult ar)
        {
            try
            {
                DestinationSocket.EndConnect(ar);
                string rq;
                if (HttpRequestType.ToUpper().Equals("CONNECT"))
                { //HTTPS
                    rq = HttpVersion + " 200 Connection established\r\nProxy-Agent: Mentalis Proxy Server\r\n\r\n";
                    ClientSocket.BeginSend(Encoding.ASCII.GetBytes(rq), 0, rq.Length, SocketFlags.None, new AsyncCallback(this.OnOkSent), ClientSocket);
                }
                else
                { //Normal HTTP
                    rq = RebuildQuery();
                    DestinationSocket.BeginSend(Encoding.ASCII.GetBytes(rq), 0, rq.Length, SocketFlags.None, new AsyncCallback(this.OnQuerySent), DestinationSocket);
                }
            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Called when the HTTP query has been sent to the remote host.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnQuerySent(IAsyncResult ar)
        {
            try
            {
                if (DestinationSocket.EndSend(ar) == -1)
                {
                    Dispose();
                    return;
                }
                StartRelay();
            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Called when an OK reply has been sent to the local client.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        private void OnOkSent(IAsyncResult ar)
        {
            try
            {
                if (ClientSocket.EndSend(ar) == -1)
                {
                    Dispose();
                    return;
                }
                StartRelay();
            }
            catch
            {
                Dispose();
            }
        }

        public void OnReadLocalFile(string FileName)
        {
            Byte[] Buffer = new Byte[1024];
            FileStream fstr = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read);
            int Length = 0;
            Length = fstr.Read(Buffer, 0, 1024);

            while (1024 == Length)
            {
                //				Console.Write(Encoding.ASCII.GetString(Buffer, 0, Length));
                Length = fstr.Read(Buffer, 0, 1024);
                ClientSocket.Send(Buffer, 0, Length, System.Net.Sockets.SocketFlags.None);

            }

            fstr.Close();
        }


    }
}
