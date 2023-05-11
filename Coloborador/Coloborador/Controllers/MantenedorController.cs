using Microsoft.AspNetCore.Mvc;
using Coloborador.Datos;
using Coloborador.Models;

namespace Coloborador.Controllers
{
    public class MantenedorController : Controller
    {
        ColaboradorDatos _colaboradorDatos = new ColaboradorDatos();

        public IActionResult Listar()
        {
            //MONTRARA UNA LISTA DE CONTACTOS
            var oLista = _colaboradorDatos.Listar();
            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //METODO SOLO DEVUELVE LA VISTA
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(ColaboradorModel oColaborador)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO A LA BD
            if (!ModelState.IsValid)
                return View();


            var respuesta = _colaboradorDatos.Guardar(oColaborador);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
                return View();
        }


        public IActionResult Editar(int id)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocolaborador = _colaboradorDatos.Obtener(id);
            return View(ocolaborador);
        }
        [HttpPost]
        public IActionResult Editar(ColaboradorModel oColaborador)
        {
            //METODO RECIBE EL OBJETO PARA EDITARLO A LA BD
            if (!ModelState.IsValid)
                return View();


            var respuesta = _colaboradorDatos.Editar(oColaborador);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
                return View();
        }
        public IActionResult Eliminar(int id)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocolaborador = _colaboradorDatos.Obtener(id);
            return View(ocolaborador);
        }
        [HttpPost]
        public IActionResult Eliminar(ColaboradorModel oColaborador)
        {
            //METODO RECIBE EL OBJETO PARA ELIMINARLO DE LA BD



            var respuesta = _colaboradorDatos.Eliminar(oColaborador.id);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
                return View();
        }



    }
}
