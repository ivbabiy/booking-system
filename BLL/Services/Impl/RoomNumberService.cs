using vcs.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using vcs.DAL.Entities;
using vcs.BLL.DTO;
using vcs.DAL.Repositories.Interfaces;
using AutoMapper;
using vcs.DAL.UnitOfWork;
using vcs.CCL.Security;
using vcs.CCL.Security.Identity;

namespace vcs.BLL.Services.Impl
{
    public class RoomNumberService
        : IRoomNumberService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public RoomNumberService( 
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<RoomNumberDTO> GetRooms(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Admin)
                && userType != typeof(Client))
            {
                throw new MethodAccessException();
            }
            var id = user.id;
            var recordsEntities = 
                _database
                    .Records
                    .Find(z => z.worker.id == id, pageNumber, pageSize);
            var mapper = 
                new MapperConfiguration(
                    cfg => cfg.CreateMap<RoomNumber, RoomNumberDTO>()
                    ).CreateMapper();
            var streetsDto = 
                mapper
                    .Map<IEnumerable<RoomNumber>, List<RoomNumberDTO>>(
                        recordsEntities);
            return streetsDto;
        }

        public void AddStreet(RoomNumberDTO RoomNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Admin)
                || userType != typeof(Client))
            {
                throw new MethodAccessException();
            }
            if (RoomNumber == null)
            {
                throw new ArgumentNullException(nameof(RoomNumber));
            }

            validate(RoomNumber);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RoomNumberDTO, RoomNumber()).CreateMapper();
            var RecordEntity = mapper.Map<RoomNumberDTO, RoomNumber>(RoomNumber);
            _database.Records.Create(RecordEntity);
        }

        private void validate(RoomNumberDTO record)
        {
            if (record.id == 0)
            {
                throw new ArgumentException("ID повинне містити значення!");
            }
        }
    }
}
