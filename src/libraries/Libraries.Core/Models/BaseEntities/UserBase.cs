﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThursdayMeetingBot.Libraries.Core.Models.BaseEntities.Common;

namespace ThursdayMeetingBot.Libraries.Core.Models.BaseEntities
{
    /// <summary>
    ///     Base user model.
    /// </summary>
    public record UserBase<TKey> : AggregatedEntity<TKey>
    where TKey : IEquatable<TKey>
    {
        /// <inheritdoc cref="AggregatedEntity{TKey}"/>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override TKey Id { get; set; }
        
        /// <summary>
        ///     Username that starts with "@".
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     User first name.
        /// </summary>
        /// 
        public string FirstName { get; set; }

        /// <summary>
        ///     User last name.
        /// </summary>
        public string LastName { get; set; }
    }
}