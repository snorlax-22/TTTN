using System.Collections.Generic;
using System.Linq;
using TTTN.Controllers;
using TTTN.Helpers;
using TTTN.Models;
using TTTN.Repository;

namespace TTTN.Service
{
    public class MilkService
    {


        private MilkRepository _milkRepo;


        public MilkService(MilkRepository milkRepository)
        {
            _milkRepo = milkRepository;
        }

        public List<DOCHOI> layTatCaDoChoiV3()
        {
            var listmilk = _milkRepo.layTatCaDoChoiV3();
            var listNutri = _milkRepo.getAllNutritions();

            foreach(var item in listmilk)
            {
                if (listNutri.Any(x => x.id == item.Nutris.id))
                {
                    item.Nutris = listNutri.Where(x => x.id == item.Nutris.id).FirstOrDefault();
                }
            }
            //get nutri
            
            return listmilk;
        }
    }
}
