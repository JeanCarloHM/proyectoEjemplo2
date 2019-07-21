using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacElectronicaApi.Utils
{
    public static class UtilException
    {
        /// <summary>
        /// Obtiene la exepción interna generada
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception GetInnerException(Exception ex)
        {
            if(ex.InnerException != null)
            {
                return GetInnerException(ex.InnerException);
            }
            else
            {
                return ex;
            }
        }
    }
}