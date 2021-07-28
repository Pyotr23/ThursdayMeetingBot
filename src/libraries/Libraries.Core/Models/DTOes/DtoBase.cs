using System;
using ThursdayMeetingBot.Libraries.Core.Models.Entities.Base;

namespace ThursdayMeetingBot.Libraries.Core.Models.DTOes
{
    /// <summary>
    ///     Base DTO model.
    /// </summary>
    /// <typeparam name="TKey"> Type of entry unique identifier. </typeparam>
    public record DtoBase<TKey> : AggregatedEntity<TKey>
        where TKey : IEquatable<TKey>
    { }
}