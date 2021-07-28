﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThursdayMeetingBot.Libraries.Core.Models.Entities.Base
{
    /// <summary>
    ///     Base model for aggregated entities.
    /// </summary>
    /// <typeparam name="TKey"> Type of entity unique index. </typeparam>
    public record AggregatedEntity<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     Unique identifier.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }
        
        /// <summary>
        ///     Created date.
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        
        /// <summary>
        ///     Updated date.
        /// </summary>
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;
    }
}