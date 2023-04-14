using ServicioSubirFTP.Configuraciones;
using ServicioSubirFTP.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServicioSubirFTP.Gestores
{
    public class GestorSubidaFTP : IGestor
    {
        readonly IConfiguraciones Configuraciones;
        readonly IMediatorLogger Logger;

        public GestorSubidaFTP(IConfiguraciones configuraciones, IMediatorLogger logger)
        {
            Configuraciones = configuraciones;
            Logger = logger;
        }

        public void Handler()
        {

            DirectoryInfo di = new DirectoryInfo(Configuraciones.GetrutaFicheros);

            Logger.Publish(new Activity
            {
                Message = $"Número de ficheros a procesar {di.GetFiles().Count()}",
                Module = nameof(Handler),
                CreatedDate = DateTime.Now,
                Level = ASLogLevel.Information
            });

            foreach (var fi in di.GetFiles())
            {

                // Subimos el fichero al FTP
                Push(fi.Name);

                // Movemos el fichero a procesados
                mueveaProcesados(fi.Name);
            }

        }

        public void Push(string fichero)
        {
            Logger.Publish(new Activity { Message = $"Procesamos el fichero {fichero}", 
                Module = nameof(Push), 
                CreatedDate = DateTime.Now,
                Level = ASLogLevel.Information});

            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(Configuraciones.GetrutaFTP + fichero);

            ftpRequest.Credentials = new NetworkCredential(Configuraciones.GetusuarioFTP,
                Configuraciones.GetpasswordFTP);

            // Asigna las propiedades
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
            ftpRequest.UsePassive = true;
            ftpRequest.UseBinary = true;
            ftpRequest.KeepAlive = false;

            using (FileStream stmFile = File.OpenRead(Configuraciones.GetrutaFicheros + fichero))
            {
                // Obtiene el stream sobre la comunicación FTP
                using (Stream stmFTP = ftpRequest.GetRequestStream())
                {
                    int cnstIntLengthBuffer = 10;
                    byte[] arrBytBuffer = new byte[cnstIntLengthBuffer];
                    int intRead;

                    // Lee y escribe el archivo en el stream de comunicaciones
                    while ((intRead = stmFile.Read(arrBytBuffer, 0, cnstIntLengthBuffer)) != 0)
                        stmFTP.Write(arrBytBuffer, 0, intRead);
                    // Cierra el stream FTP
                    stmFTP.Close();
                }
                // Cierra el stream del archivo
                stmFile.Close();
            }
        }

        public void mueveaProcesados(string fichero)
        {
            string origen = Configuraciones.GetrutaFicheros + fichero;
            string destino = Configuraciones.GetrutaProcesados + fichero;

            Logger.Publish(new Activity
            {
                Message = $"Movemos el fichero de {origen} a {destino}",
                Module = nameof(mueveaProcesados),
                CreatedDate = DateTime.Now,
                Level = ASLogLevel.Information
            });

            if (File.Exists(destino))
            {
                Logger.Publish(new Activity
                {
                    Message = $"Ya existía el fichero en destino de procesados {destino}. Lo borramos",
                    Module = nameof(mueveaProcesados),
                    CreatedDate = DateTime.Now,
                    Level = ASLogLevel.Error
                });

                File.Delete(destino);
            }

            File.Move(origen, destino);

            if (File.Exists(origen))
            {
                Logger.Publish(new Activity
                {
                    Message = $"No se ha borrado el fichero original de {origen} !!!",
                    Module = nameof(mueveaProcesados),
                    CreatedDate = DateTime.Now,
                    Level = ASLogLevel.Error
                });
            }
        }
    }
}
