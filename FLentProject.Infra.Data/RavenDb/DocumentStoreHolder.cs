using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CoreProject.Core.Interfaces.Apis;
using FLentProject.Infra.Data.RavenDb.Interfaces;
using Raven.Client.Documents;

namespace FLentProject.Infra.Data.RavenDb
{
    public class DocumentStoreHolder : IDocumentStoreHolder
    {
        private const string ServerUrl = "https://a.free.sgw.ravendb.cloud";
        private const string DatabaseName = "FLendDB";
        private const string CertificatePath = "\\free.sgw.client.certificate.with.password.pfx";
        private const string CertificatePass = "4B53CA4548DFD87978D3CFEE9712FBC7";

        public IDocumentStore DocumentStore { get; }

        public DocumentStoreHolder(IHostingEnvironmentHolder hostingEnvironmentHolder)
        {
            DocumentStore = new DocumentStore
            {
                Urls = new[] { ServerUrl },
                Database = DatabaseName,
                Certificate = new X509Certificate2(hostingEnvironmentHolder.ContentRootPath + CertificatePath, CertificatePass, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable)
            };

            DocumentStore.Initialize();
        }
    }
}
