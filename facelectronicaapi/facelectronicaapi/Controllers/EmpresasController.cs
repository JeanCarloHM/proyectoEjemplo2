
using FacElectronicaApi.DBContext;
using FacElectronicaApi.DBContext.Entities;
using FacElectronicaApi.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace FacElectronicaApi.Controllers
{
    /// <summary>
    /// Clase utilizada para administrar las empresas del sistema de facturación
    /// </summary>
    //[Authorize]
    [RoutePrefix("api/empresas")]
    public class EmpresasController : ApiController
    {
        /// <summary>
        /// Consulta todas las empresas del sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("obtener")]
        public JsonResponseModel Obtener()
        {
            JsonResponseModel response = new JsonResponseModel();

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    response.Data = unitOfWork.EmpresasRepository.GetAll().ToList();
                }
            }
            catch (Exception ex)
            {
                response.CreateExeception(ex);
            }

            return response;
        }

        /// <summary>
        /// Consulta una empresa con su nit
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("obtener/{nit}")]
        public JsonResponseModel Obtener(Decimal nit)
        {
            JsonResponseModel response = new JsonResponseModel();

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    response.Data = unitOfWork.EmpresasRepository.Obtener(nit);
                }
            }
            catch (Exception ex)
            {
                response.CreateExeception(ex);
            }

            return response;
        }

        /// <summary>
        /// Agrega una nueva empresa al sistema de facturación
        /// </summary>
        /// <param name="empresa"></param>
        [HttpPost]
        [Route("agregar")]
        public JsonResponseModel Agregar([FromBody]EmpresasEntity empresa)
        {
            JsonResponseModel response = new JsonResponseModel();

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    empresa.Estado = DBContext.Types.EstadosEmpresasType.Habilitada;

                    unitOfWork.EmpresasRepository.Add(empresa);

                    unitOfWork.SaveChanges();

                    response.Message = "La empresa fue creada";
                }
            }
            catch (Exception ex)
            {
                response.CreateExeception(ex);
            }

            return response;
        }

        /// <summary>
        /// Modifica una empresa existente en el sistema de facturación
        /// </summary>
        /// <param name="empresa"></param>
        [HttpPut]
        [Route("modificar")]
        public JsonResponseModel Modificar([FromBody]EmpresasEntity empresa)
        {
            JsonResponseModel response = new JsonResponseModel();

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.EmpresasRepository.Update(empresa);

                    unitOfWork.SaveChanges();

                    response.Message = "Le empresa fue modificada";
                }
            }
            catch (Exception ex)
            {
                response.CreateExeception(ex);
            }

            return response;
        }

        /// <summary>
        /// Elimina una empresa del sistema de facturación
        /// </summary>
        /// <param name="nit"></param>
        [HttpDelete]
        [Route("eliminar/{nit}")]
        public JsonResponseModel Elimina(Decimal nit)
        {
            JsonResponseModel response = new JsonResponseModel();

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    EmpresasEntity empresa = unitOfWork.EmpresasRepository.Obtener(nit);

                    if(empresa == null)
                    {
                        throw new Exception($"La empresa {nit} no existe");
                    }
                    else
                    {
                        string mensaje = $"La empresa '{nit}-{empresa.RazonSocial}' fue eliminada";

                        unitOfWork.EmpresasRepository.Delete(empresa);

                        unitOfWork.SaveChanges();

                        response.Message = mensaje;
                    }
                }
            }
            catch (Exception ex)
            {
                response.CreateExeception(ex);
            }

            return response;
        }
    }
}
