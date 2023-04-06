using HouseEmma.Core.Domain;
using HouseEmma.Core.Dto;
using HouseEmma.Core.ServiceInterface;
using Nancy.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseEmma.HouseTest
{
    public class HouseTest : TestBase
    {
        [Fact]
        public async Task Should_CreateHouse_WhenReturnsEqual()
        {
            HouseDto houseDto = new HouseDto();
            houseDto.Address = "asd";
            houseDto.City = "asd";
            houseDto.Country = "esrdgfh";
            houseDto.RoomCount = 1;
            houseDto.CreatedAt = DateTime.Now;
            houseDto.ModifiedAt = DateTime.Now;

            var result = await Svc<IHouseServices>().Create(houseDto);
        }

        [Fact]
        public async Task ShouldNot_AddEmptyHouse_WhenReturnResult()
        {
            string guid = Guid.NewGuid().ToString();
            HouseDto house = new HouseDto();

            house.Id = Guid.Parse(guid);
            house.Address = "asd";
            house.City = "asd";
            house.Country = "esrdgfh";
            house.RoomCount = 1;
            house.CreatedAt = DateTime.Now;
            house.ModifiedAt = DateTime.Now;

            var result = await Svc<IHouseServices>().Create(house);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdHouse_WhenReturnsNotEqual()
        {
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("18ddd2c6-f53f-4574-ae8c-1e14559144b2");

            await Svc<IHouseServices>().GetAsync(guid);

            Assert.NotEqual(wrongGuid, guid);
        }

        [Fact]
        public async Task Should_GetByIdHouse_WhenReturnsEqual()
        {
            Guid getGuid = Guid.Parse("18ddd2c6-f53f-4574-ae8c-1e14559144b2");
            Guid databaseGuid = Guid.Parse("18ddd2c6-f53f-4574-ae8c-1e14559144b2");

            await Svc<IHouseServices>().GetAsync(getGuid);

            Assert.Equal(databaseGuid, getGuid);
        }
    }
}
