using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace modul10_1302220105.Controllers
{
    public class Mahasiswa
    {
        public string Nama { get; set; }
        public string NIM { get; set; }
        public List<string> Course { get; set; }
        public int Year { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswa = new List<Mahasiswa> {
            new Mahasiswa {
                Nama = "Mahesa Athaya Zain", NIM = "1302220105", Course = ["KPL","BD","PBO"],Year = 2022
            },
            new Mahasiswa {
                Nama = "Raphael Permana Barus", NIM = "1302220140", Course = ["KPL","BD","PBO"],Year = 2022
            },
            new Mahasiswa {
                Nama = "Haikal Risnandar", NIM = "1302221050", Course = ["KPL","BD","PBO"],Year = 2022
            },
            new Mahasiswa {
                Nama = "Fersya Zufar", NIM = "1302223090", Course = ["KPL","BD","PBO"],Year = 2022
            },
            new Mahasiswa {
                Nama = "Darryl Frizangelo Rambi", NIM = "1302223154", Course = ["KPL","BD","PBO"],Year = 2022
            },
            new Mahasiswa {
                Nama = "Dafa Raimi Suandi", NIM = "1302223156", Course = ["KPL","BD","PBO"],Year = 2022
            }
        };


        [HttpGet]
        public IActionResult GetMahasiswa()
        {
            return Ok(mahasiswa);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= mahasiswa.Count)
            {
                return NotFound("Indeks mahasiswa tidak valid");
            }

            return Ok(mahasiswa[id]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Mahasiswa input)
        {
            Mahasiswa newMahasiswa = new Mahasiswa
            {
                Nama = input.Nama,
                NIM = input.NIM,
                Course = input.Course,
                Year = input.Year
            };

            mahasiswa.Add(newMahasiswa);

            return CreatedAtAction(nameof(Get), new
            {
                id = mahasiswa.IndexOf(newMahasiswa)
            }, newMahasiswa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= mahasiswa.Count)
            {
                return NotFound("Indeks mahasiswa tidak valid");
            }

            mahasiswa.RemoveAt(id);

            return NoContent();
        }
    }
}