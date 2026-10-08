using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace sistema.Services
{
    public class CriptografiaService
    {
        private readonly byte[] _key;
        public CriptografiaService(IConfiguration configuration)
        {
            var keyBase64 = configuration["Encryption:Key"]
                ?? throw new InvalidOperationException("Encryption: Key não configurada.");
            _key = Convert.FromBase64String(keyBase64);
            if (_key.Length != 32)
                throw new InvalidOperationException("Encryption: Key deve ter 32 bytes.");
        }

        public string Criptografar(string texto)
        {
            byte[] nonce = RandomNumberGenerator.GetBytes(12);
            byte[] textoBytes = Encoding.UTF8.GetBytes(texto);
            byte[] cifra = new byte[textoBytes.Length];
            byte[] tag = new byte[16];
            using var aes = new AesGcm(_key, 16);
            aes.Encrypt(nonce, textoBytes, cifra, tag);
            byte[] pacote = new byte[nonce.Length + tag.Length + cifra.Length];
            Buffer.BlockCopy(nonce, 0, pacote, 0, nonce.Length);
            Buffer.BlockCopy(tag, 0, pacote, nonce.Length, tag.Length);
            Buffer.BlockCopy(cifra, 0, pacote, nonce.Length + tag.Length, cifra.Length);
            return Convert.ToBase64String(pacote);
        }

        public string Descriptografar(string valor)
        {
            byte[] pacote = Convert.FromBase64String(valor);
            byte[] nonce = pacote[..12];
            byte[] tag = pacote[12..28];
            byte[] cifra = pacote[28..];
            byte[] texto = new byte[cifra.Length];
            using var aes = new AesGcm(_key, 16);
            aes.Decrypt(nonce, cifra, tag, texto);
        return Encoding.UTF8.GetString(texto);
        }
    }
}