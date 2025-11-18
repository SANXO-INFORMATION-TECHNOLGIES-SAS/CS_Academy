using System.Text.Json;
using InscripcionesWebApp.Models;

namespace InscripcionesWebApp.Services
{
    public class InscripcionService
    {
        private readonly string _dataPath;
        private readonly object _lock = new();

        public InscripcionService(IWebHostEnvironment env)
        {
            var dataDir = Path.Combine(env.ContentRootPath, "data");
            if (!Directory.Exists(dataDir)) Directory.CreateDirectory(dataDir);
            _dataPath = Path.Combine(dataDir, "inscripciones.json");
            if (!File.Exists(_dataPath))
            {
                File.WriteAllText(_dataPath, "[]");
            }
        }

        public List<Inscripcion> ObtenerInscripciones()
        {
            lock (_lock)
            {
                try
                {
                    var json = File.ReadAllText(_dataPath);
                    var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var lista = JsonSerializer.Deserialize<List<Inscripcion>>(json, opts);
                    return lista ?? new List<Inscripcion>();
                }
                catch
                {
                    // Si el JSON está corrupto, renunciar a un array vacío (mejor opción en un reto educativo)
                    return new List<Inscripcion>();
                }
            }
        }

        public void AgregarInscripcion(Inscripcion ins)
        {
            lock (_lock)
            {
                var lista = ObtenerInscripciones();
                lista.Add(ins);
                Guardar(lista);
            }
        }

        public void EditarInscripcion(Inscripcion modelo)
        {
            lock (_lock)
            {
                var lista = ObtenerInscripciones();
                var idx = lista.FindIndex(i => i.Id == modelo.Id);
                if (idx >= 0)
                {
                    lista[idx] = modelo;
                    Guardar(lista);
                }
            }
        }

        public void EliminarInscripcion(string id)
        {
            lock (_lock)
            {
                var lista = ObtenerInscripciones();
                lista.RemoveAll(i => i.Id == id);
                Guardar(lista);
            }
        }

        private void Guardar(List<Inscripcion> lista)
        {
            var opts = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(lista, opts);
            File.WriteAllText(_dataPath, json);
        }
    }
}
