using Raven.Client.Documents.Session;

namespace FLentProject.Infra.Data.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IDocumentSession OpenSession();
    }
}
