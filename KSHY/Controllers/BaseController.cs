using ISCommon.Constant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSHY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        //public TokenManagement _tokenManagement { get; set; }
        public IConfiguration Configuration { get; }
        public List<string> lstAccessSystem { get; set; } = new List<string>();
        //public SystemRootModel _systemRoot;
        public BaseController(IConfiguration configuration)
        {
            Configuration = configuration;
            //_tokenManagement = tokenManagement.Value;
            //_systemRoot = systemRoot.Value;
            //var strSystem = configuration[Constant.Config.AccessSystem];
            //var lstSystem = strSystem.Split(';').ToList();
            //foreach (var item in lstSystem)
            //{
            //    if (!string.IsNullOrEmpty(item))
            //    {
            //        lstAccessSystem.Add(item);
            //    }
            //}
        }
        public string ConnectString
        {
            get { return Configuration.GetConnectionString("KSHYContext"); }
        }
    }
}
