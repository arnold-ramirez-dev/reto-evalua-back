using API.Support.DTO.Clients;
using API.Support.DTO.Generic;
using MediatR;

namespace API.Queries.Clients
{
    public class GetListClienteEFQuery : PaginateRequest, IRequest<Response<PaginateResponse<DtoGetListCliente>>>
    {
    }
}
