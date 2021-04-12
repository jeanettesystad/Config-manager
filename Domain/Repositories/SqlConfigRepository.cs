using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Domain.Repositories
{
    public class SqlConfigRepository : IConfigdataRepository
    {
        private ConfigManagerContext context;

        public IEnumerable<Configdata> Configdatas => 
            context.Configdatas;

        public IEnumerable<Environment> Environments =>
            context.Environments.Include("Configdatas");

        public IEnumerable<Admin> Admins => context.Admins;

        public SqlConfigRepository(ConfigManagerContext context)
        {
            this.context = context;
        }

        #region configdata
        public Configdata GetConfigdataById(long id)
        {
            return context.Configdatas
                          .Where(c => c.Id == id)
                          .FirstOrDefault();
        }

      
        public bool InsertConfigdata(Configdata configdata)
        {
            context.Configdatas.Add(configdata);
            return SaveAndReturnTrue();
        }

        public bool DeleteConfigdata(long id)
        {
            context.Configdatas.Remove(GetConfigdataById(id));
            return SaveAndReturnTrue();
        }

        public bool UpdateConfigdata(Configdata configdata)
        {
            context.Configdatas.Update(configdata);
            return SaveAndReturnTrue();
        }

        public Environment GetEnvironmentById(long id)
        {
            return context.Environments
                          .Include("Configdatas")
                          .Where(e => e.Id == id)
                          .FirstOrDefault();
        }

        #endregion

        #region Environment
        public Environment InsertEnvironment(Environment environment)
        {
            context.Environments.Add(environment);
            context.SaveChanges();

            return environment;
        }

        public bool UpdateEnvironment(Environment environment)
        {
            context.Environments.Update(environment);
            return SaveAndReturnTrue();
        }

        public bool DeleteEnvironment(long id)
        {
            context.Environments.Remove(GetEnvironmentById(id));
            return SaveAndReturnTrue();
        }

        public bool SaveAndReturnTrue()
        {
            context.SaveChanges();
            return true;
        }

        #endregion

        #region Admin - Token

        public Admin GetAdminById(long id)
        {
            return context.Admins
                    .Where(a => a.Id == id)
                    .FirstOrDefault();
        }

        
        public string VerifyUser(string username)
        {
            string code = context.Admins
                .Where(a => a.Username == username)
                .Select(a => a.Password)
                .FirstOrDefault();

            if (code == null)
                code = "If no password found, use this as default";

            return Encrypt(username.Trim(), code.Trim());
            //return Encrypt("The quick brown fox jumps over the lazy dog", "A test password");
        }

      
        public string Encrypt(string plainText, string password)
        {

            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(plainText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesEncrypted = Encrypt(bytesToBeEncrypted, passwordBytes);

            return $"{{\"token\": \"{System.Convert.ToBase64String(bytesEncrypted)}\"}}";   
        }
        
        private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        

        #endregion








    }
}
