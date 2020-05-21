// <copyright file="ConfigurationDataRepository.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories.ConfigurationData
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Configuration data entity class.
    /// </summary>
    public class ConfigurationDataRepository : BaseRepository<ConfigurationDataEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationDataRepository"/> class.
        /// </summary>
        /// <param name="configuration">Represents the application configuration.</param>
        /// <param name="isFromAzureFunction">Flag to show if created from Azure Function.</param>
        public ConfigurationDataRepository(IConfiguration configuration, bool isFromAzureFunction = false)
            : base(
                  configuration,
                  PartitionKeyNames.ConfigurationDataTable.TableName,
                  PartitionKeyNames.ConfigurationDataTable.SendToEveryoneKey,
                  isFromAzureFunction)
        {
        }

        /// <summary>
        /// Get configuration data from datatable.
        /// </summary>
        /// <returns>configuration data.</returns>
        public async Task<ConfigurationDataEntity> GetConfigDataSendOptionAsync()
        {
            return await this.GetAsync(PartitionKeyNames.ConfigurationDataTable.TableName, PartitionKeyNames.ConfigurationDataTable.SendToEveryoneKey);
        }
    }
}