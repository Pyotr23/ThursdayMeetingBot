using System;
using Microsoft.Extensions.Hosting;
using ThursdayMeetingBot.Libraries.Core.Constants;

namespace ThursdayMeetingBot.Libraries.Core.Helpers
{
    /// <summary>
    ///     A helper for working with the environment.
    /// </summary>
    public static class EnvironmentHelper
    {
        /// <summary>
        ///     Is the environment Development.
        /// </summary>
        /// <returns> Check result. </returns>
        public static bool IsDevelopment()
        {
            return GetEnvironment().Equals(Environments.Development);
        }
        
        private static string GetEnvironment()
        {
            return Environment.GetEnvironmentVariable(EnvironmentConstant.Name) 
                   ?? Environments.Production;
        }
    }
}