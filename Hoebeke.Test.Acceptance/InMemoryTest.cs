using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using Hoebeke.WebApi;
using Microsoft.Owin.Hosting;
using NUnit.Framework;

namespace Hoebeke.Test.Acceptance
{

    [TestFixture]
    public abstract class InMemoryTest
    {
        private IDisposable _app;
        protected HttpClient HttpClient;

        /// <summary>
        /// will always be executed before the test is run
        /// getting a free port, newing up an httpclient and starting up the webapi application
        /// </summary>
        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var port = FreeTcpPort();
           
            HttpClient = new HttpClient { BaseAddress = new Uri("http://localhost:" + port) };
            _app = WebApp.Start<Startup>("http://localhost:" + port);
        }

        /// <summary>
        /// disposal of the webapi application
        /// </summary>
        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            _app.Dispose();
        }

        /// <summary>
        /// Scans for an unused port
        /// </summary>
        /// <returns></returns>
        private static int FreeTcpPort()
        {
            var l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            var port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            return port;
        }
    }
}
