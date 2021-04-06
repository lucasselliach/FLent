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


        public IDocumentStore DocumentStore { get; }

        public DocumentStoreHolder(IHostingEnvironmentHolder hostingEnvironmentHolder)
        {
            
        }
    }
}
