using System.Net;

namespace ServicioSubirFTP.Helper
{
    public static class HelperTrasnferencias
    {
        public static void UploadFileToFtp(string ftpRemoteFilePath, string ftpUsername, string ftpPassword, string localFilePath, ILogger logger)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(ftpRemoteFilePath);

            ftpRequest.Credentials = new NetworkCredential(ftpUsername,ftpPassword);

            // Asigna las propiedades
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
            ftpRequest.UsePassive = true;
            ftpRequest.UseBinary = true;
            ftpRequest.KeepAlive = false;

            try
            {
                using (FileStream stmFile = File.OpenRead(localFilePath))
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
            catch (Exception)
            {
                throw;
            }

        }
    }
}
