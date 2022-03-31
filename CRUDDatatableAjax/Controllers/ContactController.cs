using CRUDDatatableAjax.Data;
using CRUDDatatableAjax.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDDatatableAjax.Controllers
{
    public class ContactController : Controller
    {

        DataContact _DataContact = new DataContact();


        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetDataContact()
        { //La vista mostrara una lista de contactos
            var listaContactos = _DataContact.ContactList(); //Devuelve toda la lista de contactos que esta registrados en la bd
            return Json(listaContactos);
        }


        public IActionResult Create()
        {//Metodo donde solo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contacto contacto)
        {//Metodo recibe objeto para guardarlo en BD

            if(!ModelState.IsValid) return View();

            var respuesta = _DataContact.Create(contacto);

            if (respuesta) 
                return RedirectToAction("Index");
            else
                return View();
        }


        [HttpGet]
        public IActionResult Update(int id) 
        {//Metodo donde solo devuelve la vista

            var idContact = _DataContact.GetContactById(id);
            return View(idContact);
        }

        [HttpPost]
        public IActionResult Update(Contacto contacto) //Este metodo es para actualizarlo
        {

            if (!ModelState.IsValid) return View();

            var resp = _DataContact.Update(contacto);

            if (resp)
                return RedirectToAction("Index");
            else
                return View();
        }


        [HttpGet]
        public IActionResult Delete(int id) //El primer metodo es para obtener la id y mostrarlo a la vista
        {//Metodo donde solo devuelve la vista

            var idContact = _DataContact.GetContactById(id);
            return View(idContact);
        }

        [HttpPost]
        public IActionResult Delete(Contacto contacto) //el segundo metodo es para realizar las acciones
        {

            var resp = _DataContact.Delete(contacto.Id);

            if (resp)
                return RedirectToAction("Index");
            else
                return View();
        }


    }
}
