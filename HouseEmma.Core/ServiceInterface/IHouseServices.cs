using HouseEmma.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HouseEmma.Core.ServiceInterface
{
    public interface IHouseServices
    {
        Task<House> GetAsync(Guid id);
        Task<House> Create(HouseDto dto);
        Task<House> Update(HouseDto dto);
        Task<House> Delete(Guid id);
    }
}
