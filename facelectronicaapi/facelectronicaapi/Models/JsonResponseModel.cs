using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacElectronicaApi.Models
{
    /// <summary>
    /// Clase utilizada para establecer un formato de respuesta de las solicitudes del Api
    /// </summary>
    public class JsonResponseModel
    {
        /// <summary>
        /// Datos de respuesta de la petición
        /// </summary>
        public Object Data { get; set; } = null;

        /// <summary>
        /// Indica si la petición finalizó correctamente o no
        /// </summary>
        public Boolean IsValid { get; private set; } = true;

        /// <summary>
        /// Mensaje de respuesta de la petición
        /// </summary>
        public String Message { get; set; } = null;

        /// <summary>
        /// Exepción de la petición
        /// </summary>
        public Exception Exception { get; private set; } = null;

        /// <summary>
        /// Adiciona una exepción a la respuesta del Api
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        public void CreateExeception(Exception ex, string message = null)
        {
            this.IsValid = false;

            this.Exception = Utils.UtilException.GetInnerException(ex);

            if (!string.IsNullOrWhiteSpace(message))
            {
                this.Message = message;
            }
            else
            {
                this.Message = ex.Message;
            }
        }
    }
}