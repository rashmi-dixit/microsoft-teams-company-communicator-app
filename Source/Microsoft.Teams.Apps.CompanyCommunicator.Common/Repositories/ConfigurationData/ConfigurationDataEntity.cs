// <copyright file="ConfigurationDataEntity.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories.ConfigurationData
{
    using Microsoft.Azure.Cosmos.Table;

    /// <summary>
    /// Config data entity class.
    /// </summary>
    public class ConfigurationDataEntity : TableEntity
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or sets Value.
        /// </summary>
        public bool Value { get; set; }
    }
}