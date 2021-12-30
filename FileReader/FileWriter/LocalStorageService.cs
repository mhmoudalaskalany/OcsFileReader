using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using SimpleImpersonation;

namespace FileReader.FileWriter
{
    public static class LocalStorageService
    {
        private static readonly IConfiguration Configuration = AppConfiguration.ReadConfigurationFromAppSettings();



        public static void StoreBytes(byte[] bytes, string path, string name, string extension)
        {
            try
            {
                var username = Configuration["Network:Username"];
                var password = Configuration["Network:Password"];
                var domain = Configuration["Network:Domain"];
                var location = Configuration["StoragePath"];
                var credentials = new UserCredentials(domain, username, password);
                Impersonation.RunAsUser(credentials, LogonType.Interactive, () =>
               {
                   var uploadsFolderPath = Path.Combine($"{path}");
                   if (!Directory.Exists(uploadsFolderPath))
                       Directory.CreateDirectory(uploadsFolderPath);
                   var newFileName = name + "." + extension;
                   var filePath = Path.Combine(uploadsFolderPath, newFileName);
                   using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                   fs.Write(bytes, 0, bytes.Length);
               });

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public static void DownLoad(string remotePath, string uploadPath, string name,string key)
        {
            var username = Configuration[$"{key}:Username"];
            var password = Configuration[$"{key}:Password"];
            var domain = Configuration[$"{key}:Domain"];
            var location = Configuration["StoragePaths:Location"];
            var credentials = new UserCredentials(domain, username, password);
            var downloadPath = Path.Combine($"{remotePath}");
            Impersonation.RunAsUser(credentials, LogonType.Interactive, () =>
            {


                var memory = new MemoryStream();
                using (var stream = new FileStream(downloadPath, FileMode.Open))
                {
                    stream.CopyTo(memory);
                }
                memory.Position = 0;

                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);
                var newFileName = name + "." + "DBF";
                var filePath = Path.Combine(uploadPath, newFileName);
                using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                byte[] bytes = new byte[memory.Length];
                memory.Read(bytes, 0, (int)memory.Length);
                fs.Write(bytes, 0, bytes.Length);
                memory.Close();
            });
        }

        public static void DownLoadNoCredentials(string remotePath, string uploadPath, string name)
        {

            var downloadPath = Path.Combine($"{remotePath}");
            var memory = new MemoryStream();
            using (var stream = new FileStream(downloadPath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            var newFileName = name + "." + "DBF";
            var filePath = Path.Combine(uploadPath, newFileName);
            using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            byte[] bytes = new byte[memory.Length];
            memory.Read(bytes, 0, (int)memory.Length);
            fs.Write(bytes, 0, bytes.Length);
            memory.Close();
        }

        public static IEnumerable<object> GetDirectoriesAsync()
        {
            try
            {
                var username = Configuration["Network:Username"];
                var password = Configuration["Network:Password"];
                var domain = Configuration["Network:Domain"];
                var location = Configuration["StoragePaths:Location"];
                var credentials = new UserCredentials(domain, username, password);
                var result = Impersonation.RunAsUser(credentials, LogonType.Interactive, () => Directory.GetFiles(@location));
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }



    }
}
