using vcs.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace vcs.BLL.Services.Interfaces
{
    public interface IRoomNumberService
    {
        IEnumerable<RoomNumberDTO> GetRoomNumbers(int page);
    }
}
