namespace BL
{
    public class Usuario
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.UsuariosContext context = new DL.UsuariosContext())
                {
                    var usuariosDB = context.Usuarios.ToList();
                    result.Objects = new List<object>();

                    foreach (DL.Usuario u in usuariosDB)
                    {
                        ML.Usuario usuario = new ML.Usuario
                        {
                            IdUsuario = u.IdUsuario,
                            NombreCompleto = u.NombreCompleto,
                            NombreUsuario = u.NombreUsuario,
                            Password = u.Password,
                            Correo = u.Correo,
                            Estatus = u.Estatus,
                            FechaAlta = u.FechaAlta,
                            FechaModificacion = u.FechaModificacion
                        };
                        result.Objects.Add(usuario);
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetById(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.UsuariosContext context = new DL.UsuariosContext())
                {
                    DL.Usuario? u = context.Usuarios.FirstOrDefault(x => x.IdUsuario == idUsuario);
                    if (u != null)
                    {
                        ML.Usuario usuario = new ML.Usuario
                        {
                            IdUsuario = u.IdUsuario,
                            NombreCompleto = u.NombreCompleto,
                            NombreUsuario = u.NombreUsuario,
                            Password = u.Password,
                            Correo = u.Correo,
                            Estatus = u.Estatus,
                            FechaAlta = u.FechaAlta,
                            FechaModificacion = u.FechaModificacion
                        };
                        result.Object = usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Usuario no encontrado.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.UsuariosContext context = new DL.UsuariosContext())
                {
                    DL.Usuario u = new DL.Usuario
                    {
                        NombreCompleto = usuario.NombreCompleto,
                        NombreUsuario = usuario.NombreUsuario,
                        Password = usuario.Password, 
                        Correo = usuario.Correo,
                        Estatus = usuario.Estatus,
                        FechaAlta = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                    context.Usuarios.Add(u);
                    context.SaveChanges();
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.UsuariosContext context = new DL.UsuariosContext())
                {
                    DL.Usuario? u = context.Usuarios.FirstOrDefault(x => x.IdUsuario == usuario.IdUsuario);
                    if (u != null)
                    {
                        u.NombreCompleto = usuario.NombreCompleto;
                        u.NombreUsuario = usuario.NombreUsuario;
                        u.Password = usuario.Password; 
                        u.Correo = usuario.Correo;
                        u.Estatus = usuario.Estatus;
                        u.FechaModificacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Usuario no encontrado.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.UsuariosContext context = new DL.UsuariosContext())
                {
                    DL.Usuario? u = context.Usuarios.FirstOrDefault(x => x.IdUsuario == idUsuario);
                    if (u != null)
                    {
                        context.Usuarios.Remove(u);
                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Usuario no encontrado.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
