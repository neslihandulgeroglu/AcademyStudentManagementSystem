using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSBusinessLayer.ContractsBLL;
using ASMSDataAccessLayer.ContractsDAL;
using ASMSEntityLayer.Models;
using ASMSEntityLayer.ResultModels;
using ASMSEntityLayer.ViewModels;
using AutoMapper;

namespace ASMSBusinessLayer.ImplementationsBLL
{
    public class NeighbourhoodBusinessEngine : INeighbourhoodBusinessEngine
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NeighbourhoodBusinessEngine(IUnitOfWork unitOfWork, IMapper mapper)//ÖZEL BİR METOT
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IDataResult<ICollection<NeighbourhoodVM>> GetNeighbourhoodsOfDistrict(int  districtId)
        {
            try
            {
                if (districtId>0)
                {

                    var neighbourhoods = _unitOfWork.NeighbourhoodRepo.GetAll(x => x.DistrictId == districtId);
                    ICollection<NeighbourhoodVM>result=_mapper.Map<IQueryable<Neighbourhood>, ICollection<NeighbourhoodVM>>(neighbourhoods);
                    return new SuccessDataResult<ICollection<NeighbourhoodVM>>(result);
                }
                else
                {
                    throw new Exception("DistrictId düzgün gelmedi.");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
