using Raven.Client.Documents;

namespace FLentProject.Infra.Data.RavenDb.Interfaces
{
    public interface IDocumentStoreHolder
    {
        IDocumentStore DocumentStore { get; }
    }
}
