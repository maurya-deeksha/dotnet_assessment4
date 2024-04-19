using rpgAPI.Model;

using rpgAPI.Service;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;
using Xunit;

namespace rpdAPITest

{

    public class CharacterServiceTest

    {

        [Fact]

        public void GetAllCharacter_Returns_All_Characters()

        {

            // Arrange

            var characterService = new CharacterService();
 
            // Act

            var result = characterService.GetAllCharacter();
 
            // Assert

            Assert.NotNull(result);

            Assert.NotEmpty(result.Data);

            Assert.Equal(2, result.Data.Count); // Assuming there are two characters initially

        }
 
        [Fact]

        public void AddCharacter_Adds_New_Character()

        {

            // Arrange

            var characterService = new CharacterService();

            var newCharacter = new Character { Id = 2, Name = "Frodo" };
 
            // Act

            var result = characterService.AddCharacter(newCharacter);
 
            // Assert

            Assert.NotNull(result);

            Assert.NotEmpty(result.Data);

            Assert.Contains(newCharacter, result.Data);

        }
 
        [Fact]

        public void GetCharacterById_Returns_Character_IfExists()

        {

            // Arrange

            var characterService = new CharacterService();

            int existingCharacterId = 1;
 
            // Act

            var result = characterService.GetCharacterById(existingCharacterId);
 
            // Assert

            Assert.NotNull(result);

            Assert.True(result.Success);

            Assert.NotNull(result.Data);

            Assert.Equal(existingCharacterId, result.Data.Id);

        }
 
        [Fact]

        public void GetCharacterById_Returns_Null_If_Id_DoesntExist()

        {

            // Arrange

            var characterService = new CharacterService();

            int nonExistingCharacterId = 999; // Assuming this ID doesn't exist
 
            // Act

            var result = characterService.GetCharacterById(nonExistingCharacterId);
 
            // Assert

            Assert.NotNull(result);

            Assert.False(result.Success);

            Assert.Null(result.Data);

            Assert.Equal("Id Doesn't Exist", result.Message);

        }

    }

}
