using AutoMapper;
using Course_Project.DatabaseContext;
using Course_Project.DTOs;
using Course_Project.Models;
using Course_Project.Repository.Interfaces;

namespace Course_Project.MappingProfile
{
    public class MappingProfile:Profile
    {
        private readonly ApplicationDbContext _context;
        public MappingProfile(ApplicationDbContext context)
        {
            _context = context;
        }
        public MappingProfile()
        {
            CreateMap<CarEntity, CarDto>()
                .ForCtorParam("Name",
                    opt => opt.MapFrom(g => string.Join(' ', g.Brand, g.Name)));

            CreateMap<CarDto, CarEntity>()
            .ForMember(entity => entity.Brand,
                opt => opt.MapFrom(dto => SetBrand(dto.Name)))

            .ForMember(entity => entity.Name,
                opt => opt.MapFrom(dto => SetName(dto.Name)));
        }
        public CarDto GetCarDetails(int Id)
        {
            var carentity = _context.Cars.Where(x => x.Id == Id).FirstOrDefault();
            if (carentity is null)
            {
                throw new Exception($"Graphic card with Id = {Id} not found!");
            }

            var carDto = new CarDto(carentity.Id,
                string.Join(' ', carentity.Brand, carentity.Name),
                (DateOnly)carentity.Year, carentity.Mileage, carentity.Cost);
            return carDto;
        }
        public string SetBrand(string clyde)
        {
             return clyde.Split(' ')[0];
        }
        public string SetName(string clyde)
        {
            return clyde.Split(' ')[1];
        }
    }
}
