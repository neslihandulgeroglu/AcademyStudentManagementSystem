using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSBusinessLayer.ContractsBLL;
using ASMSEntityLayer.ResultModels;
using ASMSEntityLayer.ViewModels;
using ASMSDataAccessLayer.ContractsDAL;
using AutoMapper;
using ASMSEntityLayer.Models;

namespace ASMSBusinessLayer.ImplementationsBLL
{
    public class UsersAddressBusinessEngine : IUsersAddressBusinessEngine
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UsersAddressBusinessEngine(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public IResult Add(UsersAddressVM address)
        {
            try
            {
                UsersAddress newadress = _mapper.Map<UsersAddressVM, UsersAddress>(address);
                return _unitOfWork.UsersAddressRepo.Add(newadress) ?
                     new SuccessResult("Adres Eklendi") :
                     new ErrorResult("Adres Eklenemedi");

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IDataResult<ICollection<UsersAddressVM>> GetAll(string userId)
        {
            try
            {
                if (userId!=null)
                {
                    var userAddressList = _unitOfWork.UsersAddressRepo.GetAll(x=>x.UserId == userId, includeEntities: "Neighbourhood");
                    var result =_mapper.Map<IQueryable<UsersAddress>,ICollection<UsersAddressVM>>(userAddressList);
                    return new SuccessDataResult<ICollection<UsersAddressVM>>(result, $"{result.Count}address has been found");
                }
                else
                {
                    throw new Exception("userId is null so it could not able to find useraddres");
                }
            }
            catch (Exception)
            {
                 
                throw;
            }
        }

    }
}
