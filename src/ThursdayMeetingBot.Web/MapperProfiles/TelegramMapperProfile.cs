using AutoMapper;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;

namespace ThursdayMeetingBot.Web.MapperProfiles
{
    /// <summary>
    ///     Profile for mapping of telegram entities to DTO.
    /// </summary>
    public class TelegramMapperProfile : Profile
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        public TelegramMapperProfile()
        {
            CreateMap<User, UserDto>(MemberList.Destination);

            CreateMap<Update, MessageDto>(MemberList.Destination)
                .ForMember(dest => dest.Id,
                    opt => opt.Ignore())
                .ForMember(dest => dest.MessageId,
                    opt => opt.MapFrom(src => src.Message.MessageId))
                .ForMember(dest => dest.Text,
                    opt => opt.MapFrom(src => src.Message.Text))
                .ForMember(dest => dest.ChatId,
                    opt => opt.MapFrom(src => src.Message.Chat.Id))
                .ForMember(dest => dest.UserId,
                    opt => opt.MapFrom(src => src.Message.From.Id));


            CreateMap<ChatType, ChatTypeDto>(MemberList.Destination)
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => (int) src))
                .ForMember(dest => dest.Alias,
                    opt => opt.MapFrom(src => src.ToString()));

            CreateMap<Update, ChatDto>(MemberList.Destination)
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.Message.Chat.Id))
                .ForMember(dest => dest.Title,
                    opt => opt.MapFrom(src => src.Message.Chat.Title))
                .ForMember(dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.Message.Chat.FirstName))
                .ForMember(dest => dest.LastName,
                    opt => opt.MapFrom(src => src.Message.Chat.LastName))
                .ForMember(dest => dest.Username,
                    opt => opt.MapFrom(src => src.Message.Chat.Username))
                .ForMember(dest => dest.SenderId,
                    opt => opt.MapFrom(src => src.Message.From.Id))
                .ForPath(dest => dest.ChatType.Id,
                    opt => opt.MapFrom(src => (int) src.Message.Chat.Type))
                .ForPath(dest => dest.ChatType.Alias,
                    opt => opt.MapFrom(src => src.Message.Chat.Type.ToString()));
        }
    }
}