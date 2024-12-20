using System;

namespace API.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
