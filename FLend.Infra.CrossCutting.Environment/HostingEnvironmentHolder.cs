using CoreProject.Core.Interfaces.Apis;

namespace FLentProject.Infra.CrossCutting.Environment
{
    public class HostingEnvironmentHolder : IHostingEnvironmentHolder
    {
        public string ContentRootPath { get; set; }
    }
}
