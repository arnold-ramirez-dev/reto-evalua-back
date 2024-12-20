using API.Entities.Base;

namespace API.Entities
{
    public class ClienteEntity : BaseEntity
    {
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string CodigoPais { get; set; }
        public string NumeroTelefono { get; set; }
        public virtual PaisEntity Pais { get; set; }
    }
}
