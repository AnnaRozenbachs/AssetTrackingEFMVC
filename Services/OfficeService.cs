using AssetTrackingEFMVC.Enums;
using AssetTrackingEFMVC.Extensions;
using AssetTrackingEFMVC.Models;
using AssetTrackingEFMVC.Repositorys;
using System.Globalization;

namespace AssetTrackingEFMVC.Services
{
    public class OfficeService : IOfficeService
    {
        private IOfficeRepository _officeRepository;
        public OfficeService(IOfficeRepository officeRepository)
        {
           _officeRepository = officeRepository;
        }

        public Office GetOfficeById(int id)
        {
            var office = _officeRepository.GetById(id);
            return office;
        }

        public List<Office> GetOfficeList()
        {
            var offices = _officeRepository.GetAll();
            if (offices.Count == 0)
            {
                _officeRepository.AddRange(Office.OfficeList());
                offices = _officeRepository.GetAll();
            }

            return offices;
        }
    }
}
