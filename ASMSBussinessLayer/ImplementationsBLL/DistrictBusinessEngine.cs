using ASMSBusinessLayer.ContractsBLL;
using ASMSDataAccessLayer.ContractsDAL;
using ASMSEntityLayer.Models;
using ASMSEntityLayer.ResultModels;
using ASMSEntityLayer.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSBusinessLayer.ImplementationsBLL
{
    public class DistrictBusinessEngine : IDistrictBusinessEngine
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DistrictBusinessEngine(IUnitOfWork unitOfWork,IMapper mapper)//ÖZEL BİR METOT
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IDataResult<ICollection<DistrictVM>> GetAllDistricts()
        {
            try
            {
                var districts = _unitOfWork.DistrictRepo.GetAll();
                ICollection<DistrictVM> result = _mapper.Map<IQueryable<District>,ICollection<DistrictVM>>(districts);
                return new SuccessDataResult<ICollection<DistrictVM>>(result);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDataResult<ICollection<DistrictVM>> GetDistrictsOfCity(byte cityId)
        {
            try
            {
                if (cityId>0)
                {
                    var cityDistricts = _unitOfWork.DistrictRepo.GetAll(x=>x.CityId==cityId
                        );
                    ICollection<DistrictVM> result = _mapper.Map<IQueryable<District>, ICollection<DistrictVM>>(cityDistricts);
                    return
                        new SuccessDataResult<ICollection<DistrictVM>>(
                            result,$"cityId={cityId}olan ilin {result.Count}adet ilçesi listelendi.");

                }
                else
                {
                    throw new Exception("Cityid düzgün gelmedi!");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
