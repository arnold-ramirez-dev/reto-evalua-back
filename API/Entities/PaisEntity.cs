using System.Collections.Generic;

namespace API.Entities
{
    public class PaisEntity
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<ClienteEntity> Clientes { get; set; } = [];
    }
}
