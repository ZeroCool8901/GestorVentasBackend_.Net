using GestorVentas_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorVentas_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoController : ControllerBase
    {
        private readonly GestorVentasContext _context;

        public ArchivoController(GestorVentasContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Archivo>>> GetArchivo()
        {
            if (_context.Archivos == null)
            {
                return NotFound();
            }
            return await _context.Archivos.ToListAsync();
        }

        // GET: api/Archivos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Archivo>> GetArchivo(int id)
        {
            if (_context.Archivos == null)
            {
                return NotFound();
            }
            var archivo = await _context.Archivos.FindAsync(id);

            if (archivo == null)
            {
                return NotFound();
            }

            return archivo;
        }

        // PUT: api/Archivos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchivo(int id, Archivo archivo)
        {
            if (id != archivo.Id)
            {
                return BadRequest();
            }

            _context.Entry(archivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchivoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Archivos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult PostArchivo([FromForm] List<IFormFile> files)
        {
            List<Archivo> archivos = new List<Archivo>();
            try
            {
                if (files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        Archivo archivo = new Archivo();
                        archivo.Nombre = System.Guid.NewGuid().ToString();
                        var filePath = "C:\\Users\\Juan C\\Documents\\ProgramacionIV\\Proyecto\\Backend\\GestorVentas_Backend\\uploads\\" + archivo.Nombre;
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            file.CopyToAsync(stream);
                        }
                        double tamanio = file.Length;
                        tamanio = tamanio / 1000000;
                        tamanio = Math.Round(tamanio, 2);
                        archivo.Nombre = Path.GetFileNameWithoutExtension(file.FileName);
                        archivo.Extension = Path.GetExtension(file.FileName).Substring(1);

                        archivo.Tamanio = tamanio;
                        archivo.Ubicacion = filePath;
                        archivos.Add(archivo);
                    }
                    _context.Archivos.AddRange(archivos);
                    _context.SaveChanges();

                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(archivos);
        }

        // DELETE: api/Archivos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArchivo(int id)
        {
            if (_context.Archivos == null)
            {
                return NotFound();
            }
            var archivo = await _context.Archivos.FindAsync(id);
            if (archivo == null)
            {
                return NotFound();
            }

            _context.Archivos.Remove(archivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArchivoExists(int id)
        {
            return (_context.Archivos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
