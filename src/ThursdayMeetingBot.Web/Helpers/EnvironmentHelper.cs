﻿using System;
using Microsoft.Extensions.Hosting;
using ThursdayMeetingBot.Web.Constants;

namespace ThursdayMeetingBot.Web.Helpers
{
    /// <summary>
    ///     A helper for working with the environment.
    /// </summary>
    internal static class EnvironmentHelper
    {
        /// <summary>
        ///     Get the environment.
        /// </summary>
        /// <returns> Environment (Development, Production and etc.). </returns>
        internal static string GetEnvironment()
        {
            return Environment.GetEnvironmentVariable(EnvironmentConstant.Name) 
                   ?? Environments.Production;
        }

        /// <summary>
        ///     Is the environment Development.
        /// </summary>
        /// <returns> Check result. </returns>
        internal static bool IsDevelopment()
        {
            return GetEnvironment().Equals(Environments.Development);
        }
    }
}