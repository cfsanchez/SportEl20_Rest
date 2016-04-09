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
    public class DenunciaADO
    {
        string CadenaConexion = ConfigurationManager.ConnectionStrings["DBSportEl20"].ConnectionString;


        public DENUNCIA Crear(DENUNCIA denuncia)
        {
            int ID_DENUNCIA = 0;
            DENUNCIA DENUNCIACreado = null;
            string sql = "INSERT INTO [DENUNCIA] (ID_USUARIO,TIPODENUNCIA,FECHADENUNCIA,DESCRIPCION,ESTADO) VALUES (@ID_USUARIO,@TIPODENUNCIA,@FECHADENUNCIA,@DESCRIPCION,@ESTADO);"
                + "SELECT SCOPE_IDENTITY()";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@ID_USUARIO", denuncia.ID_USUARIO));
                    comando.Parameters.Add(new SqlParameter("@TIPODENUNCIA", denuncia.TIPODENUNCIA));
                    comando.Parameters.Add(new SqlParameter("@FECHADENUNCIA", denuncia.FECHADENUNCIA));
                    comando.Parameters.Add(new SqlParameter("@DESCRIPCION", denuncia.DESCRIPCION));
                    comando.Parameters.Add(new SqlParameter("@ESTADO", denuncia.ESTADO));
                    ID_DENUNCIA = (int)(decimal)comando.ExecuteScalar();
                }
            }

            denuncia.DETALLE_FOTOS.ForEach(x => x.ID_DENUNCIA = ID_DENUNCIA);

            CrearDetalleFoto(denuncia.DETALLE_FOTOS);

            DENUNCIACreado = Obtener(ID_DENUNCIA);
            return DENUNCIACreado;
        }

        public void CrearDetalleFoto(List<DETALLE_FOTO> DETALLE_FOTO)
        {
            if (DETALLE_FOTO == null)
            {
                return;
            }

            string sql = "INSERT INTO [DETALLE_FOTO] (ID_DENUNCIA,FOTODENUNCIA) VALUES (@ID_DENUNCIA,@FOTODENUNCIA)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();

                foreach (var item in DETALLE_FOTO)
                {
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@ID_DENUNCIA", item.ID_DENUNCIA));
                        comando.Parameters.Add(new SqlParameter("@FOTODENUNCIA", item.FOTODENUNCIA));
                        comando.ExecuteNonQuery();
                    }
                }
            }
        }

        public DENUNCIA Obtener(int ID_DENUNCIA)
        {
            DENUNCIA DENUNCIAEncontrado = null;
            string sql = "SELECT * FROM DENUNCIA WHERE ID_DENUNCIA=@ID_DENUNCIA";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@ID_DENUNCIA", ID_DENUNCIA));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            DENUNCIAEncontrado = new DENUNCIA()
                            {
                                ID_DENUNCIA = (int)resultado["ID_DENUNCIA"],
                                ID_USUARIO = (int)resultado["ID_USUARIO"],
                                TIPODENUNCIA = (string)resultado["TIPODENUNCIA"],
                                FECHADENUNCIA = (DateTime)resultado["FECHADENUNCIA"],
                                DESCRIPCION = (string)resultado["DESCRIPCION"],
                                ESTADO = (string)resultado["ESTADO"],
                            };
                            var fotos = ObtenerDetalleFoto(DENUNCIAEncontrado.ID_DENUNCIA);
                            DENUNCIAEncontrado.DETALLE_FOTOS = fotos;
                        }
                    }
                }
            }
            return DENUNCIAEncontrado;
        }

        public List<DETALLE_FOTO> ObtenerDetalleFoto(int ID_DENUNCIA)
        {
            List<DETALLE_FOTO> oLista = new List<DETALLE_FOTO>();
            string sql = "SELECT * FROM DETALLE_FOTO WHERE ID_DENUNCIA=@ID_DENUNCIA";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@ID_DENUNCIA", ID_DENUNCIA));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            oLista.Add(new DETALLE_FOTO()
                            {
                                ID_DETALLE_DENUNCIA = (int)resultado["ID_DETALLE_DENUNCIA"],
                                ID_DENUNCIA = (int)resultado["ID_DENUNCIA"],
                                FOTODENUNCIA = (string)resultado["FOTODENUNCIA"],
                            });
                        }
                    }
                }
            }
            return oLista;
        }

        public DENUNCIA Modificar(DENUNCIA denuncia)
        {
            DENUNCIA SEG_USUARIOModificado = null;
            string sql = "UPDATE DENUNCIA SET ID_USUARIO=@ID_USUARIO, TIPODENUNCIA=@TIPODENUNCIA, FECHADENUNCIA=@FECHADENUNCIA, DESCRIPCION=@DESCRIPCION, ESTADO=@ESTADO WHERE ID_DENUNCIA=@ID_DENUNCIA";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@ID_USUARIO", denuncia.ID_USUARIO));
                    comando.Parameters.Add(new SqlParameter("@TIPODENUNCIA", denuncia.TIPODENUNCIA));
                    comando.Parameters.Add(new SqlParameter("@FECHADENUNCIA", denuncia.FECHADENUNCIA));
                    comando.Parameters.Add(new SqlParameter("@DESCRIPCION", denuncia.DESCRIPCION));
                    comando.Parameters.Add(new SqlParameter("@ESTADO", denuncia.ESTADO));
                    comando.Parameters.Add(new SqlParameter("@ID_DENUNCIA", denuncia.ID_DENUNCIA));
                    comando.ExecuteNonQuery();
                }
            }
            SEG_USUARIOModificado = Obtener(denuncia.ID_DENUNCIA);
            return SEG_USUARIOModificado;
        }

        public void Eliminar(int id)
        {
            string sql = "DELETE FROM DENUNCIA WHERE ID_DENUNCIA=@ID_DENUNCIA";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@ID_DENUNCIA", id));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<DENUNCIA> ListarTodos()
        {
            List<DENUNCIA> DENUNCIAesEncontrado = new List<DENUNCIA>();
            DENUNCIA DENUNCIAEncontrado = null;
            string sql = "SELECT * FROM DENUNCIA";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            DENUNCIAEncontrado = new DENUNCIA()
                            {
                                ID_DENUNCIA = (int)resultado["ID_DENUNCIA"],
                                ID_USUARIO = (int)resultado["ID_USUARIO"],
                                TIPODENUNCIA = (string)resultado["TIPODENUNCIA"],
                                FECHADENUNCIA = (DateTime)resultado["FECHADENUNCIA"],
                                DESCRIPCION = (string)resultado["DESCRIPCION"],
                                ESTADO = (string)resultado["ESTADO"],
                            };

                            DENUNCIAesEncontrado.Add(DENUNCIAEncontrado);
                        }
                    }
                }
            }
            return DENUNCIAesEncontrado;
        }

        public List<DENUNCIA> ObtenerXUsuario(int ID_USUARIO)
        {
            List<DENUNCIA> DENUNCIAesEncontrado = new List<DENUNCIA>();
            DENUNCIA DENUNCIAEncontrado = null;
            string sql = "SELECT * FROM DENUNCIA a INNER JOIN SEG_USUARIO b ON B.ID_USUARIO= a.ID_USUARIO WHERE a.ID_USUARIO=@ID_USUARIO";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@ID_USUARIO", ID_USUARIO));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            DENUNCIAEncontrado = new DENUNCIA()
                            {
                                ID_DENUNCIA = (int)resultado["ID_DENUNCIA"],
                                ID_USUARIO = (int)resultado["ID_USUARIO"],
                                TIPODENUNCIA = (string)resultado["TIPODENUNCIA"],
                                FECHADENUNCIA = (DateTime)resultado["FECHADENUNCIA"],
                                DESCRIPCION = (string)resultado["DESCRIPCION"],
                                ESTADO = (string)resultado["ESTADO"],
                            };

                            DENUNCIAEncontrado.USUARIO = new USUARIO
                            {
                                ID_USUARIO = (int)resultado["ID_USUARIO"],
                                NOMBRE = (string)resultado["NOMBRE"],
                                APE_PAT = (string)resultado["APE_PAT"],
                                APE_MAT = (string)resultado["APE_MAT"],
                                TIPOPROFESION = (string)resultado["TIPOPROFESION"],
                                SEXO = (string)resultado["SEXO"],
                                EMAIL = (string)resultado["EMAIL"],
                                COD_PERFIL = (string)resultado["COD_PERFIL"],
                                NombreFull = string.Format("{0} {1}, {2}", (string)resultado["APE_PAT"], (string)resultado["APE_MAT"], (string)resultado["NOMBRE"]),
                            };
                            DENUNCIAEncontrado.DETALLE_FOTOS = ObtenerDetalleFoto(DENUNCIAEncontrado.ID_DENUNCIA);

                            DENUNCIAesEncontrado.Add(DENUNCIAEncontrado);
                        }
                    }
                }
            }
            return DENUNCIAesEncontrado;
        }

        public List<DENUNCIA> ObtenerXAdministrador()
        {
            List<DENUNCIA> DENUNCIAesEncontrado = new List<DENUNCIA>();
            DENUNCIA DENUNCIAEncontrado = null;
            string sql = "SELECT * FROM DENUNCIA a INNER JOIN SEG_USUARIO b ON B.ID_USUARIO= a.ID_USUARIO";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            DENUNCIAEncontrado = new DENUNCIA()
                            {
                                ID_DENUNCIA = (int)resultado["ID_DENUNCIA"],
                                ID_USUARIO = (int)resultado["ID_USUARIO"],
                                TIPODENUNCIA = (string)resultado["TIPODENUNCIA"],
                                FECHADENUNCIA = (DateTime)resultado["FECHADENUNCIA"],
                                DESCRIPCION = (string)resultado["DESCRIPCION"],
                                ESTADO = (string)resultado["ESTADO"],
                            };

                            DENUNCIAEncontrado.USUARIO = new USUARIO
                            {
                                ID_USUARIO = (int)resultado["ID_USUARIO"],
                                NOMBRE = (string)resultado["NOMBRE"],
                                APE_PAT = (string)resultado["APE_PAT"],
                                APE_MAT = (string)resultado["APE_MAT"],
                                TIPOPROFESION = (string)resultado["TIPOPROFESION"],
                                SEXO = (string)resultado["SEXO"],
                                EMAIL = (string)resultado["EMAIL"],
                                COD_PERFIL = (string)resultado["COD_PERFIL"],
                                NombreFull = string.Format("{0} {1}, {2}", (string)resultado["APE_PAT"], (string)resultado["APE_MAT"], (string)resultado["NOMBRE"]),
                            };

                            DENUNCIAEncontrado.DETALLE_FOTOS = ObtenerDetalleFoto(DENUNCIAEncontrado.ID_DENUNCIA);

                            DENUNCIAesEncontrado.Add(DENUNCIAEncontrado);
                        }
                    }
                }
            }
            return DENUNCIAesEncontrado;
        }
    }
}
