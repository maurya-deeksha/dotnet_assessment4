using Microsoft.AspNetCore.Mvc;

using Moq;

using rpgAPI.Controller;

using rpgAPI.Model;

using rpgAPI.Service;

using System.Net;
using Xunit;

namespace rpdAPITest

{

    public class UnitTest1

    {

     [Fact]

        public void GetId_Returns_Ok_With_Character()

        {

            // Arrange

            int characterId = 1;

            string Name = "Test Character";

            int HitPoint = 1;

            int Strength = 2;

            int Defense = 4;

            int Intelligence = 5;

            RPGClass CharacterClass = RPGClass.Knight;

            var mockCharacterService = new Mock<ICharacterService>();

            mockCharacterService.Setup(service => service.GetCharacterById(characterId))

                       .Returns(new ServiceResponse<Character>

                       {

                           Data = new Character { Id = characterId, Name = "Test Character" , HitPoint=1,Strength=2,Defense=4,Intelligence=5, CharacterClass= RPGClass.Knight},

                           Message = "Character found.",

                           Success = true // Or set to false if necessary

                       }); var controller = new CharacterController(mockCharacterService.Object);
 
            // Act

            var result = controller.GetId(characterId);
 
            // Assert

            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            var serviceResponse = Assert.IsType<ServiceResponse<Character>>(okResult.Value);

            var character = Assert.IsType<Character>(serviceResponse.Data);

            Assert.Equal("Character found.", serviceResponse.Message); 

            Assert.True(serviceResponse.Success);

            Assert.Equal(characterId, character.Id);

            Assert.Equal(Name, character.Name);

            Assert.Equal(HitPoint, character.HitPoint);

            Assert.Equal(Strength, character.Strength);

            Assert.Equal(Defense, character.Defense);

            Assert.Equal(Intelligence, character.Intelligence);

            Assert.Equal(CharacterClass, character.CharacterClass);
 
 
        }

        [Fact]

        public void GetCharacter_Returns_Ok_With_Character_List()

        {

            // Arrange

            var mockCharacterService = new Mock<ICharacterService>();

            mockCharacterService.Setup(service => service.GetAllCharacter())

                                 .Returns(new ServiceResponse<List<Character>>());
 
            var controller = new CharacterController(mockCharacterService.Object);
 
            // Act

            var result = controller.GetCharacter();
 
            // Assert

            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            Assert.Equal("200",okResult.StatusCode.ToString()); // Assuming an empty list is returned

        }

        [Fact]

        public void PostCharacter_Returns_Ok_With_Character_List()

        {

            // Arrange

            var mockCharacterService = new Mock<ICharacterService>();

            mockCharacterService.Setup(service => service.AddCharacter(It.IsAny<Character>()))

                                 .Returns(new ServiceResponse<List<Character>>()); // Assuming it returns updated character list
 
            var controller = new CharacterController(mockCharacterService.Object);

            var newCharacter = new Character(); // Initialize with required properties
 
            // Act

            var result = controller.PostCharacter(newCharacter);
 
            // Assert

            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            Assert.Equal("200", okResult.StatusCode.ToString()); // Assuming an empty list is returned

        }

    }

}