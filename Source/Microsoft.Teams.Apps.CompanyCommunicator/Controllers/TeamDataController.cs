// <copyright file="TeamDataController.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Apps.CompanyCommunicator.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Teams.Apps.CompanyCommunicator.Authentication;
    using Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories.ConfigurationData;
    using Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories.TeamData;
    using Microsoft.Teams.Apps.CompanyCommunicator.Models;

    /// <summary>
    /// Controller for the teams data.
    /// </summary>
    [Route("api/teamData")]
    [Authorize(PolicyNames.MustBeValidUpnPolicy)]
    public class TeamDataController : ControllerBase
    {
        private readonly TeamDataRepository teamDataRepository;
        private readonly ConfigurationDataRepository configurationDataRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamDataController"/> class.
        /// </summary>
        /// <param name="teamDataRepository">Team data repository instance.</param>
        /// <param name="configurationDataRepository">configuration data repository instance.</param>
        public TeamDataController(TeamDataRepository teamDataRepository, ConfigurationDataRepository configurationDataRepository)
        {
            this.teamDataRepository = teamDataRepository;
            this.configurationDataRepository = configurationDataRepository;
        }

        /// <summary>
        /// Get data for all teams.
        /// </summary>
        /// <returns>A list of team data.</returns>
        [HttpGet]
        public async Task<IEnumerable<TeamData>> GetAllTeamDataAsync()
        {
            var entities = await this.teamDataRepository.GetAllSortedAlphabeticallyByNameAsync();
            var result = new List<TeamData>();
            foreach (var entity in entities)
            {
                var team = new TeamData
                {
                    TeamId = entity.TeamId,
                    Name = entity.Name,
                };
                result.Add(team);
            }

            return result;
        }

        /// <summary>
        /// Get configuration data.
        /// </summary>
        /// <returns>a boolan value</returns>
        [HttpGet("sendToEnveryoneOptionEnableDisable")]
        public async Task<bool> GetConfigurationDataAsync()
        {
            var configurationValue = await this.configurationDataRepository.GetConfigDataSendOptionAsync();
            return configurationValue == null ? false : configurationValue.Value;
        }
    }
}
