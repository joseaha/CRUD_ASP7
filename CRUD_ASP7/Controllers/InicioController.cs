using CRUD_ASP7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static CRUD_ASP7.Datos.ApplicationDBContex;

namespace CRUD_ASP7.Controllers
{
    public class InicioController : Controller
    {   // DI ApplicationDbContexto
        private readonly ApplicationDbContexto _context;

        public InicioController(ApplicationDbContexto context)
        {
            _context = context;
        }

        [HttpGet]//Tipo de metodo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contactos.ToListAsync());
        }
        //Debe existir dos metodos uno que nos retorna una vista y otro que realiza la accion deseada
        //Metodos del CRUD
        /*************
            Create
         *************/
        /// <summary>
        /// metodo que nos retorna la vista create
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Metodo que ingresa un nuevo contacto en la base de datos
        /// </summary>
        /// <param name="contacto">Nuevo registro</param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contacto contacto)
        {
            try
            {
                //ModelState.IsValid valida si las reglas del modelo se cumple
                if (ModelState.IsValid)
                {
                    contacto.ReleaseDate = DateTime.Now;
                    _context.Contactos.Add(contacto);
                    _context.SaveChanges();
                }
                //Regresa a la vista Index
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return View();
        }
        /*************
           Edit
        *************/
        /// <summary>
        /// Metodo que nos retorna la vista edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit( int id)
        {
            var Contacto = _context.Contactos.Find(id);
            return View(Contacto);
        }
        /// <summary>
        /// Metodo que modifica el registro indicado en la base de datos 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modelo"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone,PhoneNumber,Email")] Contacto modelo)
        {
            if (id != modelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(modelo);
        }
        /*************
           Details
        *************/
        /// <summary>
        /// Metodo que retorna la vista Details
        /// </summary>
        /// <returns></returns>
        public IActionResult Details(int id)
        {

            var Contacto = _context.Contactos.Find(id);
            return PartialView(Contacto);
        }
        /// <summary>
        /// Metodo que nos muestra los datos de un registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Details")]
        public async Task<IActionResult> Details(int? id)
        {
            //Validamos que se ingreso un Id correcto
            if (id == null)
            {
                return NotFound();
            }
            //Si el Id Ingresado es correcto obtenemos el conctacto que se desea obtner los detalles
            var contacto = await _context.Contactos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }
        /*************
           Delete
        *************/
        /// <summary>
        /// Metodo que elimina un registro en la base de datos por medio de id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            //Obtenemos el contacto que deseamos eliminar
            var ContactoDelete = await _context.Contactos.FindAsync(id);
            //Verificamos que exista en la base de datos
            if (ContactoDelete == null)
            {
                //si no existe el dato en la base de datos redirecionamos a Index
                return RedirectToAction(nameof(Index));
            }
            try
            {
                //Si el Dato existe lo eliminamos de la base de datos
                _context.Contactos.Remove(ContactoDelete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }/// <summary>
         /// Metodo que nos retorna la vista delete
         /// </summary>
         /// <returns></returns>
        public IActionResult Delete(int id)
        {
            var Contacto = _context.Contactos.Find(id);
            return View(Contacto);
        }
        [HttpGet]
        public IActionResult _EditContact(int id)
        {
            var contacto = _context.Contactos.FirstOrDefault(c => c.Id == id);
            return PartialView("_EditContact", contacto);
        }
        [HttpGet]
        public IActionResult _DeleteContact(int id)
        {
            var Contacto = _context.Contactos.Find(id);
            return PartialView("_DeleteContact",Contacto);
        }
        [HttpGet]
        public IActionResult _DetailsContact(int id)
        {
     
            var contacto =  _context.Contactos.Find(id);

            return PartialView("_DetailsContact",contacto);

        }
        [HttpGet]    
        public IActionResult _SaludarContacto( int id)
        {
            var contacto = _context.Contactos.Find(id);
            return PartialView("_SaludarContacto", contacto);
        }
        //este fragmento de código se encarga de manejar errores en una aplicación ASP.NET Core.
        //Cuando se produce un error, el método Error() se ejecuta y devuelve una vista que muestra información sobre el error, incluido un identificador único de solicitud.
        //La respuesta generada no se almacena en caché en absoluto.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
