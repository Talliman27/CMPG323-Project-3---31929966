using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class ZoneRepository
    {
        private readonly Project3dbContext _context = new Project3dbContext();

        // GetAll method in ZoneRepository is inherited and used by the ZonesController
        public List<Zone> Getall()
        {
            return _context.Zone.ToList();
        }
    }
}
