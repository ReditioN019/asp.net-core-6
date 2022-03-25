using CRUDDatatableAjax.Data;
using CRUDDatatableAjax.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDDatatableAjax.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PersonController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Person> objPersonList = _db.Persons; //Obtiene los datos de la tabla person de la bd y la convertirá a una lista con IEnumerable
            return View(objPersonList); //Le pasamos el objCategoryList a la vista.
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //token anti falsificación. ....(?). Previene el ataque de solicitudes entre sitios.
        public IActionResult Create(Person obj) //en los param recibimos un obj de Persona
        {
            //Añadimos una validacion personalizada. Esta son validaciones desde el lado del cliente
            if (obj.Name == obj.LastName)
            {
                //ModelState.AddModelError("CustomError", "El Apellido no puede ser igual al nombre.");
                ModelState.AddModelError("LastName", "El Apellido no puede ser igual al nombrbalabdasdlasds.");
            }

            if (!ModelState.IsValid) return View(obj); //Si el modelo no es válido...

            _db.Persons.Add(obj); //Entiendo que en EF esto es como el insert de sql
            _db.SaveChanges(); //Guarda en la bd los cambios. En este caso los datos ingresados
            TempData["success"] = "Persona añadida con éxito!";
            return RedirectToAction("Index"); //en vez de ir a una vista, redirigimos a la vista Index del mismo controller (la q está arriba)
        }



        [HttpGet]
        public IActionResult Edit(int? id) //Que significa el ?
        {
            if(id == null || id == 0 ) return NotFound();

            var PersonFromDb = _db.Persons.Find(id);//Aquí encontraremos la categoria que queremos actualiza mediante la id

            if(PersonFromDb == null) return NotFound();

            return View(PersonFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Person obj)
        {
            if (obj.Name == obj.LastName)
            {
                ModelState.AddModelError("LastName", "El Apellido no puede ser igual al nombrbalabdasdlasds.");
            }

            if (!ModelState.IsValid) return View(obj);

            _db.Persons.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Persona actualizada con éxito!"; //Esto es un dato temporal que se mostrara como alerta
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int? id) //Que significa el ?
        {
            if (id == null || id == 0) return NotFound();

            var PersonFromDb = _db.Persons.Find(id);//Aquí encontraremos la categoria que queremos actualiza mediante la id

            if (PersonFromDb == null) return NotFound();

            return View(PersonFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Persons.Find(id);

            if(obj == null) return NotFound();

            _db.Persons.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Persona eliminada con éxito!";
            return RedirectToAction("Index");
        }
    }
}
