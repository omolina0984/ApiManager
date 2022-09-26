

namespace Infraestructura.General.Crypto
{
    //Interfaz para el servicio de criptografia 
    public interface ICryptographyService
    {
        public string Encriptar(string llaveSecreta, string valorRaw);
        public string Desencriptar(string llaveSecreta, string encrypted);
    }
}
