using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class DevicesRepository
    {
        private readonly Project3dbContext _context = new Project3dbContext();


        // GetAll method in DevicesRepository is inherited and used by the DevicesController
        public List<Device> GetAll()
        {
            return _context.Device.ToList();
        }
    }
}
