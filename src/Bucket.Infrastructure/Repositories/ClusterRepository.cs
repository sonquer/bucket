using Bucket.Domain.Entities;
using Bucket.Domain.Interfaces.Repositories;
using k8s;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Bucket.Infrastructure.Repositories
{
    public class ClusterRepository : IClusterRepository
    {
        public async Task<IEnumerable<ClusterEntity>> GetClusterConfiguration(CancellationToken cancellationToken)
        {
            var applicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var bucketApplicationDataPath = Path.Combine(applicationDataPath, "Bucket");

            if (Directory.Exists(bucketApplicationDataPath) == false)
            {
                Directory.CreateDirectory(bucketApplicationDataPath);
            }

            var clusterConfigurationFilePath = Path.Combine(bucketApplicationDataPath, "Clusters.json");
            if (File.Exists(clusterConfigurationFilePath) == false)
            {
                return new List<ClusterEntity>();
            }

            var clusterConfigurationsData = await File.ReadAllTextAsync(clusterConfigurationFilePath, cancellationToken);
            if (string.IsNullOrEmpty(clusterConfigurationsData))
            {
                return new List<ClusterEntity>();
            }

            var clusterConfigurations = JsonSerializer.Deserialize<IEnumerable<ClusterEntity>>(clusterConfigurationsData);

            return clusterConfigurations ?? new List<ClusterEntity>();
        }
    }
}
