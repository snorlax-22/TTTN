using System.Collections.Generic;
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
            return _milkRepo.layTatCaDoChoiV3();
        }
    }
}
