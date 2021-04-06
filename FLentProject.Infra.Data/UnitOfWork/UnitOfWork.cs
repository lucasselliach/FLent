using FLentProject.Infra.Data.RavenDb.Interfaces;
using FLentProject.Infra.Data.UnitOfWork.Interfaces;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace FLentProject.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDocumentStore _documentStore;
        private IDocumentSession _documentSession;

        public UnitOfWork(IDocumentStoreHolder documentStoreHolder)
        {
            _documentStore = documentStoreHolder.DocumentStore;
            _documentSession = null;
        }

        public IDocumentSession OpenSession()
        {
            return _documentSession ??= _documentStore.OpenSession();
        }
    }
}
