using Bucket.Domain.Entities;
using k8s;
using System.IO;

namespace Bucket.UseCases.Services
{
    public class CurrentContextService
	{
        private IKubernetes? Context { get; set; }

        public bool IsConnectedToCluster => Context != null;

        public IKubernetes? GetContext() => Context;

        public void SwitchClusterContext(ClusterEntity clusterEntity)
        {
            if (IsConnectedToCluster)
            {
                Context?.Dispose();
            }

            var kubernetesConfig = KubernetesClientConfiguration.LoadKubeConfig(new FileInfo(clusterEntity.FilePath), false);
            var config = KubernetesClientConfiguration.BuildConfigFromConfigObject(kubernetesConfig);

            Context = new Kubernetes(config);
        }
    }
}