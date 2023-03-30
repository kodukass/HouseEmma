using HouseEmma.Core.Domain;
using HouseEmma.Core.Dto;
using HouseEmma.Core.ServiceInterface;
using HouseEmma.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HouseEmma.ApplicationServices.Services
{
    public class HouseServices : IHouseServices
    {
        private readonly HouseEmmaContext _context;

    public HouseServices
        (
            HouseEmmaContext context
        )
    {
        _context = context;
    }

    public async Task<House> GetAsync(Guid id)
    {
        var result = await _context.Houses
            .FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task<House> Create(HouseDto dto)
    {
            House house = new();

            house.Id = Guid.NewGuid();
            house.Address = dto.Address;
            house.City = dto.City;
            house.Country = dto.Country;
            house.RoomCount = dto.RoomCount;
            house.ModifiedAt = DateTime.Now;
            house.CreatedAt = DateTime.Now;


        await _context.Houses.AddAsync(house);
        await _context.SaveChangesAsync();
        return house;
    }

    public async Task<House> Update(HouseDto dto)
    {
        House house = new();
        {
                house.Id = dto.Id;
                house.Address = dto.Address;
                house.City = dto.City;
                house.Country = dto.Country;
                house.RoomCount = dto.RoomCount;
                house.ModifiedAt = DateTime.Now;
                house.CreatedAt = dto.CreatedAt;
        };

        _context.Houses.Update(house);
        await _context.SaveChangesAsync();
        return house;
    }

    public async Task<House> Delete(Guid id)
    {
        var houseId = await _context.Houses
        .FirstOrDefaultAsync(x => x.Id == id);

        _context.Houses.Remove(houseId);
        await _context.SaveChangesAsync();

        return houseId;
    }
}
}

