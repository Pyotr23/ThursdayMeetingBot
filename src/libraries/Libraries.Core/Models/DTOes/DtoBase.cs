using System;

namespace ThursdayMeetingBot.Libraries.Core.Models.DTOes
{
    /// <summary>
    ///     Base DTO model.
    /// </summary>
    /// <typeparam name="TKey"> Type of entry unique identifier. </typeparam>
    public record DtoBase<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     Unique identifier.
        /// </summary>
        public TKey Id { get; set; }
    }
}