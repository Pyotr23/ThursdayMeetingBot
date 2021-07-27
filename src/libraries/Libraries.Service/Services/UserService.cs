using AutoMapper;
using Microsoft.Extensions.Logging;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Data.Contexts;
using ThursdayMeetingBot.Libraries.Data.Models;

namespace ThursdayMeetingBot.Libraries.Service.Services
{
    public class UserService : BaseService<BotDbContext, UserDto, User, int>
    {
        public UserService(BotDbContext context, IMapper mapper, ILogger<UserService> logger)
            : base(context, mapper, logger)
        {
        }
    }
}