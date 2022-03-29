using CRUDDatatableAjax.Data;
using CRUDDatatableAjax.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDDatatableAjax.Controllers
{
    public class ContactController : Controller
    {

        DataContact _DataContact = new DataContact();

        public IActionResult Index()
        { //La vista mostrara una lista de contactos
            var listaContactos = _DataContact.ContactList(); //Devuelve toda la lista de contactos que esta registrados en la bd
            //return View(listaContactos);
            return View(listaContactos);
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

        [HttpPut]
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

            var idContact = _DataContact.GetContactById(1);
            return View(idContact);
        }

        [HttpDelete]
        public IActionResult Delete(Contacto contacto) //el segundo metodo es para realizar las acciones
        {

            if (!ModelState.IsValid) return View();

            var resp = _DataContact.Delete(contacto.Id);

            if (resp)
                return RedirectToAction("Index");
            else
                return View();
        }


    }
}
