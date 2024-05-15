
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Net;

namespace AIArticleSiteTemplateProject.Services
{
    public class NetworkConnection : IDisposable
    {
        private string _networkName;
        private readonly string _networkPath;

        public NetworkConnection(string networkPath, NetworkCredential credentials)
        {
            _networkPath = networkPath;
            _networkName = networkPath.Split('\\')[2]; // Extract the share name from the network path

            var netResource = new NetResource
            {
                Scope = ResourceScope.GlobalNetwork,
                ResourceType = ResourceType.Disk,
                DisplayType = ResourceDisplaytype.Share,
                RemoteName = networkPath
            };

            var userName = string.IsNullOrEmpty(credentials.Domain)
                ? credentials.UserName
                : $@"{credentials.Domain}\{credentials.UserName}";

            var result = WNetAddConnection2(netResource, credentials.Password, userName, 0);
            if (result != 0)
            {
                throw new Win32Exception(result, "Failed to connect to network share");
            }
        }

        ~NetworkConnection()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            WNetCancelConnection2(_networkName, 0, true);
        }

        [DllImport("mpr.dll", EntryPoint = "WNetAddConnection2A")]
        private static extern int WNetAddConnection2(NetResource netResource, string password, string username, int flags);

        [DllImport("mpr.dll", EntryPoint = "WNetCancelConnection2A")]
        private static extern int WNetCancelConnection2(string name, int flags, bool force);
    }

    [StructLayout(LayoutKind.Sequential)]
    public class NetResource
    {
        public ResourceScope Scope;
        public ResourceType ResourceType;
        public ResourceDisplaytype DisplayType;
        public int Usage;
        public string LocalName;
        public string RemoteName;
        public string Comment;
        public string Provider;
    }

    public enum ResourceScope : int
    {
        Connected = 1,
        GlobalNetwork,
        Remembered,
        Recent,
        Context
    }

    public enum ResourceType : int
    {
        Any = 0,
        Disk = 1,
        Print = 2,
        Reserved = 8,
    }

    public enum ResourceDisplaytype : int
    {
        Generic = 0,
        Domain = 1,
        Server = 2,
        Share = 3,
        File = 4,
        Group = 5,
        Network = 6,
        Root = 7,
        Shareadmin = 8,
        Directory = 9,
        Tree = 10,
        Ndscontainer = 11
    }
}
