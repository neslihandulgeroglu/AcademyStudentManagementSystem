using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSEntityLayer.Models;
using ASMSDataAccessLayer.ContractsDAL;
    

namespace ASMSDataAccessLayer.ImplementationsDAL
{
    public class CityRepo:RepositoryBase<City,byte>,ICityRepo
    {
        public CityRepo(MyContext myContext):base(myContext)
        {
            //ctor oluşturmamızın sebebi
            //kalıltım aldığımız class'ın ctor'ında myContext
            //istendiği için 

        }

    }
}
