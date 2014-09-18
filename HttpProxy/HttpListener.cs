using System;
using System.Net;
using System.Net.Sockets;
//using eGuard.ProxyServer ;
using System.IO;

namespace HttpProxy
{
    public sealed class HttpListener : Listener
    {
        ///<summary>Initializes a new instance of the HttpListener class.</summary>
        ///<param name="Port">The port to listen on.</param>
        ///<remarks>The HttpListener will start listening on all installed network cards.</remarks>
        public HttpListener(int Port) : this(IPAddress.Any, Port) { }
        ///<summary>Initializes a new instance of the HttpListener class.</summary>
        ///<param name="Port">The port to listen on.</param>
        ///<param name="Address">The address to listen on. You can specify IPAddress.Any to listen on all installed network cards.</param>
        ///<remarks>For the security of your server, try to avoid to listen on every network card (IPAddress.Any). Listening on a local IP address is usually sufficient and much more secure.</remarks>
        public HttpListener(IPAddress Address, int Port) : base(Port, Address) { }
        ///<summary>Called when there's an incoming client connection waiting to be accepted.</summary>
        ///<param name="ar">The result of the asynchronous operation.</param>
        public override void OnAccept(IAsyncResult ar)
        {
            try
            {
                Socket NewSocket = ListenSocket.EndAccept(ar);

                if (NewSocket != null)
                {
                    HttpClient NewClient = new HttpClient(NewSocket, new DestroyDelegate(this.RemoveClient));
                    NewClient.StartHandshake();

                }
            }
            catch
            {

            }
            try
            {
                //Restart Listening
                ListenSocket.BeginAccept(new AsyncCallback(this.OnAccept), ListenSocket);
            }
            catch
            {
                Dispose();
            }
        }
        ///<summary>Returns a string representation of this object.</summary>
        ///<returns>A string with information about this object.</returns>
        public override string ToString()
        {
            return "HTTP service on " + Address.ToString() + ":" + Port.ToString();
        }

    }
}
