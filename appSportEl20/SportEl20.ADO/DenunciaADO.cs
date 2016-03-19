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
            DENUNCIACreado = Obtener(ID_DENUNCIA);

            var detalle = denuncia.DETALLE_FOTOS;
            CrearDetalle(detalle, ID_DENUNCIA);

            return DENUNCIACreado;
        }

        public void CrearDetalle(List<DETALLE_FOTO> DETALLE_FOTO, int ID_DENUNCIA)
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
                        comando.Parameters.Add(new SqlParameter("@ID_DENUNCIA", ID_DENUNCIA));
                        comando.Parameters.Add(new SqlParameter("@FOTODENUNCIA", item.FOTODENUNCIA));
                        ID_DENUNCIA = (int)comando.ExecuteScalar();
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
                        }
                    }
                }
            }
            return DENUNCIAEncontrado;
        }

        public List<DENUNCIA> ObtenerXUsuario(int ID_USUARIO)
        {
            List<DENUNCIA> DENUNCIAesEncontrado = new List<DENUNCIA>();
            DENUNCIA DENUNCIAEncontrado = null;
            string sql = "SELECT * FROM DENUNCIA WHERE ID_USUARIO=@ID_USUARIO";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
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

                            DENUNCIAesEncontrado.Add(DENUNCIAEncontrado);
                        }
                    }
                }
            }
            return DENUNCIAesEncontrado;
        }

        public List<DENUNCIA> Listar()
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

                            DENUNCIAesEncontrado.Add(DENUNCIAEncontrado);
                        }
                    }
                }
            }
            return DENUNCIAesEncontrado;
        }
    }
}
