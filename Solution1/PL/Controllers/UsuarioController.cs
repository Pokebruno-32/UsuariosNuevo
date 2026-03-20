using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAll();
            return View(result); // Renderiza la vista GetAll.cshtml
        }

        [HttpGet]
        public IActionResult Form(int? id)
        {
            ML.Usuario usuario = new ML.Usuario();

            if (id.HasValue)
            {
                ML.Result result = BL.Usuario.GetById(id.Value);
                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                }
            }

            return PartialView("Form", usuario);
        }

        [HttpPost]
        public IActionResult Form(ML.Usuario usuario)
        {
            ML.Result result;

            if (usuario.IdUsuario == 0)
            {             
                result = BL.Usuario.Add(usuario);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(usuario.Password))
                {
                    ML.Result existing = BL.Usuario.GetById(usuario.IdUsuario);
                    if (existing.Correct)
                    {
                        var usuarioExistente = (ML.Usuario)existing.Object;
                        usuario.Password = usuarioExistente.Password; // conserva la contraseña actual
                    }
                }

                result = BL.Usuario.Update(usuario);
            }

            return Json(new { success = result.Correct, message = result.ErrorMessage });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            ML.Result result = BL.Usuario.Delete(id);

            return Json(new { success = result.Correct, message = result.ErrorMessage });
        }
    }
}
