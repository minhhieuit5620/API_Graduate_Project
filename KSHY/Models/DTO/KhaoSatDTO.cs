using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSHY.Models.DTO
{
    public class KhaoSatDTO
    {
        public TblKhaoSat KhaoSat { get; set; }
        public TblChiTietKhaoSat[] CTKS { get; set; }       
    }
}
