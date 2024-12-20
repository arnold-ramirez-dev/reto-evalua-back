namespace API.Support.DTO.Clients
{
    public class DtoGetListCliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public bool Estado { get; set; }
        public string CodigoPais { get; set; }
        public string NumeroTelefono { get; set; }
        public string NombrePais { get; set; }
    }
}
