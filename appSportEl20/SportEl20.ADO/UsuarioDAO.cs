using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportEl20.BE;
using System.Data.SqlClient;
using System.Configuration;

namespace SportEl20.ADO
{
    public class UsuarioDAO
    {
        string CadenaConexion = ConfigurationManager.ConnectionStrings["DBSportEl20"].ConnectionString;

        public USUARIO Crear(USUARIO usuario)
        {
            USUARIO USUARIOCreado = null;
            string sql = "INSERT INTO [SEG_USUARIO] (NOMBRE,APE_PAT,APE_MAT,TIPOPROFESION,SEXO,EMAIL,PASSWORD,COD_PERFIL) VALUES (@NOMBRE,@APE_PAT,@APE_MAT,@TIPOPROFESION,@SEXO,@EMAIL,@PASSWORD,@COD_PERFIL)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@NOMBRE", usuario.NOMBRE));
                    comando.Parameters.Add(new SqlParameter("@APE_PAT", usuario.APE_PAT));
                    comando.Parameters.Add(new SqlParameter("@APE_MAT", usuario.APE_MAT));
                    comando.Parameters.Add(new SqlParameter("@TIPOPROFESION", usuario.TIPOPROFESION));
                    comando.Parameters.Add(new SqlParameter("@SEXO", usuario.SEXO));
                    comando.Parameters.Add(new SqlParameter("@EMAIL", usuario.EMAIL));
                    comando.Parameters.Add(new SqlParameter("@PASSWORD", usuario.PASSWORD));
                    comando.Parameters.Add(new SqlParameter("@COD_PERFIL", usuario.COD_PERFIL));
                    comando.ExecuteNonQuery();
                }
            }
            USUARIOCreado = Obtener(usuario.EMAIL);
            return USUARIOCreado;
        }
        public USUARIO Obtener(string email)
        {
            USUARIO USUARIOEncontrado = null;
            string sql = "SELECT * FROM SEG_USUARIO WHERE email=@email";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@email", email));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            USUARIOEncontrado = new USUARIO()
                            {
                                ID_USUARIO = (int)resultado["ID_USUARIO"],
                                NOMBRE = (string)resultado["NOMBRE"],
                                APE_PAT = (string)resultado["APE_PAT"],
                                APE_MAT = (string)resultado["APE_MAT"],
                                TIPOPROFESION = (string)resultado["TIPOPROFESION"],
                                SEXO = (string)resultado["SEXO"],
                                EMAIL = (string)resultado["EMAIL"],
                                PASSWORD = (string)resultado["PASSWORD"],
                                COD_PERFIL = (string)resultado["COD_PERFIL"],
                                NombreFull = string.Format("{0} {1}, {2}", (string)resultado["APE_PAT"], (string)resultado["APE_MAT"], (string)resultado["NOMBRE"]),
                            };
                        }
                    }
                }
            }
            return USUARIOEncontrado;
        }

        public USUARIO ObtenerPorId(int id)
        {
            USUARIO USUARIOEncontrado = null;
            string sql = "SELECT * FROM SEG_USUARIO WHERE ID_USUARIO=@id";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id", id));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            USUARIOEncontrado = new USUARIO()
                            {
                                ID_USUARIO = (int)resultado["ID_USUARIO"],
                                NOMBRE = (string)resultado["NOMBRE"],
                                APE_PAT = (string)resultado["APE_PAT"],
                                APE_MAT = (string)resultado["APE_MAT"],
                                TIPOPROFESION = (string)resultado["TIPOPROFESION"],
                                SEXO = (string)resultado["SEXO"],
                                EMAIL = (string)resultado["EMAIL"],
                                PASSWORD = (string)resultado["PASSWORD"],
                                COD_PERFIL = (string)resultado["COD_PERFIL"],
                                NombreFull = string.Format("{0} {1}, {2}", (string)resultado["APE_PAT"], (string)resultado["APE_MAT"], (string)resultado["NOMBRE"]),
                            };
                        }
                    }
                }
            }
            return USUARIOEncontrado;
        }

        public USUARIO Modificar(USUARIO USUARIOAModificar)
        {
            USUARIO USUARIOModificado = null;
            string sql = "UPDATE SEG_USUARIO SET NOMBRE=@NOMBRE,APE_PAT=@APE_PAT,APE_MAT=@APE_MAT,TIPOPROFESION=@TIPOPROFESION,SEXO=@SEXO WHERE EMAIL=@EMAIL";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@NOMBRE", USUARIOAModificar.NOMBRE));
                    comando.Parameters.Add(new SqlParameter("@APE_PAT", USUARIOAModificar.APE_PAT));
                    comando.Parameters.Add(new SqlParameter("@APE_MAT", USUARIOAModificar.APE_MAT));
                    comando.Parameters.Add(new SqlParameter("@TIPOPROFESION", USUARIOAModificar.TIPOPROFESION));
                    comando.Parameters.Add(new SqlParameter("@SEXO", USUARIOAModificar.SEXO));
                    comando.Parameters.Add(new SqlParameter("@EMAIL", USUARIOAModificar.EMAIL));
                    comando.ExecuteNonQuery();
                }
            }
            USUARIOModificado = Obtener(USUARIOAModificar.EMAIL);
            return USUARIOModificado;
        }

    }
}
