using HouseEmma.Models;
using Microsoft.AspNetCore.Mvc;

namespace HouseEmma.Controllers
{
    public class HouseController : Controller
    {
        private readonly IHouseServices _houseServices;

        public HouseController
            (
                IHouseServices houseServices
            )
        {
            _houseServices = houseServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.RealEstates
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new HouseIndexViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    City = x.City,
                    Country = x.Country,
                    RoomCount = x.RoomCount,
                    CreatedAt = x.CreatedAt,
                    ModifiedAt = x.ModifiedAt
                });
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            HouseCreateUpdateViewModel vm = new();

            return View("Update", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(HouseCreateUpdateViewModel vm)
        {
            var dto = new HouseDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                City = vm.City,
                Country = vm.Country,
                RoomCount = vm.RoomCount,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };
            var result = await _houseServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var house = await _houseServices.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var vm = new HouseCreateUpdateViewModel();

            vm.Id = house.Id;
            vm.Address = house.Address;
            vm.City = house.City;
            vm.Country = house.Country;
            vm.RoomCount = house.RoomCount;
            vm.CreatedAt = house.CreatedAt;
            vm.ModifiedAt = house.ModifiedAt;


            return View("Update", vm);
        }


        [HttpPost]
        public async Task<IActionResult> Update(HouseCreateUpdateViewModel vm)
        {
            var dto = new HouseDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                City = vm.City,
                Country = vm.Country,
                RoomCount = vm.RoomCount,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _houseServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var house = await _houseServices.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var vm = new HouseDetailsViewModel();

            vm.Id = house.Id;
            vm.Address = house.Address;
            vm.City = house.City;
            vm.Country = house.Country;
            vm.RoomCount = house.RoomCount;
            vm.CreatedAt = house.CreatedAt;
            vm.ModifiedAt = house.ModifiedAt;
            return View(vm);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var house = await _houseServices.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var vm = new HouseDeleteViewModel();

            vm.Id = house.Id;
            vm.Address = house.Address;
            vm.City = house.City;
            vm.Country = house.Country;
            vm.RoomCount = house.RoomCount;
            vm.CreatedAt = house.CreatedAt;
            vm.ModifiedAt = house.ModifiedAt;

            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var houseId = await _houseServices.Delete(id);

            if (houseId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
