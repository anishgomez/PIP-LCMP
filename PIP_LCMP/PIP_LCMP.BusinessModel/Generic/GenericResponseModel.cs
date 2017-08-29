using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP_LCMP.BusinessEntities.Generic
{
    public class GenericResponseModel
    {
        public bool IsSuccess { get; set; }

        public object Response { get; set; }

        public string ResponseMessage { get; set; }
    }
}
