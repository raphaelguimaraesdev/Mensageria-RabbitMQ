using Newtonsoft.Json;
using System;
using System.Text;

namespace Mensageria.Server.Utilitarios
{
    public static class UtilObjeto
    {
        public static object Deserializar(this byte[] arrayBytes, Type type)
        {
            var json = Encoding.Default.GetString(arrayBytes);
            return JsonConvert.DeserializeObject(json, type);
        }

        public static string DeSerializeTexto(this byte[] arraBytes)
        {
            return Encoding.Default.GetString(arraBytes);
        }

        public static byte[] Serializar(this object obj)
        {
            if (obj == null)
            {
                return null;
            }
            var json = JsonConvert.SerializeObject(obj);
            return Encoding.ASCII.GetBytes(json);
        }
    }
}