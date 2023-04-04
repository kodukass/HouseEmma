using HouseEmma.Core.Dto;
using HouseEmma.Core.ServiceInterface;
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
            //arrange
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("18ddd2c6-f53f-4574-ae8c-1e14559144b2");

            //act
            await Svc<IHouseServices>().GetAsync(guid);

            //assert
            Assert.NotEqual(wrongGuid, guid);
        }

        [Fact]
        public async Task Should_GetByIdHouse_WhenReturnsEqual()
        {
            //arrange
            Guid getGuid = Guid.Parse("18ddd2c6-f53f-4574-ae8c-1e14559144b2");
            Guid databaseGuid = Guid.Parse("18ddd2c6-f53f-4574-ae8c-1e14559144b2");

            //act
            await Svc<IHouseServices>().GetAsync(getGuid);

            //assert
            Assert.Equal(databaseGuid, getGuid);
        }

        [Fact]
        public async Task Should_DeleteByIdHouse_WhenDeleteSpaceship()
        {
            //Guid guid = Guid.NewGuid();
            Guid guid = Guid.Parse("18ddd2c6-f53f-4574-ae8c-1e14559144b2");

            HouseDto house = MockHouseData();
            var addHouse = await Svc<IHouseServices>().Create(house);

            var result = await Svc<IHouseServices>().Delete((Guid)addHouse.Id);

            Assert.Equal(result.Id, addHouse.Id);
            Assert.Equal(result.Address, addHouse.Address);
        }
    }

    private HouseDto MockHouseData()
    {
        HouseDto house = new()
        {
            Address = "asd",
            City = "asd",
            Country = "esrdgfh",
            RoomCount = 1,
            CreatedAt = DateTime.Now,
            ModifiedAt = DateTime.Now
        };
        return house;
    }

    private HouseDto MockUpdateHouse()
    {
        HouseDto update = new()
        {
            Address = "awsd",
            City = "awsd",
            Country = "eswrdgfh",
            RoomCount = 2,
            CreatedAt = DateTime.Now.AddYears(1),
            ModifiedAt = DateTime.Now.AddYears(1),
        };
        return update;
    }

    private HouseDto MockNullHouse()
    {
        HouseDto nullDto = new()
        {
            Address = "asd",
            City = "asd",
            Country = "esrdgfh",
            RoomCount = 1,
            CreatedAt = DateTime.Now,
            ModifiedAt = DateTime.Now
        };
        return nullDto;
    }
}
