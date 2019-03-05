using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishWaters.Data
{

    
    public class FishWaterEfcRepository
    {
        FishWaterDbContext _context;

        public FishWaterEfcRepository(FishWaterDbContext context)
        {
            _context = context;
        }

    }
}
