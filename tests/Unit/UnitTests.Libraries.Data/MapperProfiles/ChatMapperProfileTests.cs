using AutoMapper;
using ThursdayMeetingBot.Libraries.Core.Models.DTOes;
using ThursdayMeetingBot.Libraries.Data.MapperProfiles;
using ThursdayMeetingBot.Libraries.Data.Models;
using Xunit;

namespace Tests.Unit.ThursdayMeetingBot.Libraries.Data.MapperProfiles
{
    public class ChatMapperProfileTests
    {
        private readonly IMapper _mapper;
        
        public ChatMapperProfileTests()
        {
            var configuration = new MapperConfiguration(x 
                => x.AddProfile<ChatMapperProfile>());
            _mapper = configuration.CreateMapper();
        }
        
        [Fact]
        public void MapChatDtoToChat_CorrectData_SuccessMap()
        {
            var dto = new ChatDto
            {
                Id = 23,
                Title = "Title",
                Username = "Username",
                FirstName = "Firstname",
                LastName = "Lastname",
                ChatType = new ChatTypeDto
                {
                    Id = 86,
                    Alias = "Alias"
                },
                SenderId = 2
            };

            var chat = _mapper.Map<Chat>(dto);
            
            Assert.Equal(dto.Id, chat.Id);
            Assert.Equal(dto.Title, chat.Title);
            Assert.Equal(dto.Username, chat.Username);
            Assert.Equal(dto.FirstName, chat.FirstName);
            Assert.Equal(dto.LastName, chat.LastName);
            Assert.Equal(dto.ChatType.Id, chat.ChatType.Id);
            Assert.Equal(dto.ChatType.Alias, chat.ChatType.Alias);
            Assert.Empty(chat.Users);
        }
    }
}