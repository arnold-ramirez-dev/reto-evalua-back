using API.Contexts;
using API.Queries.Clients;
using API.Support.Constants;
using API.Support.DTO.Clients;
using API.Support.DTO.Generic;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Handlers.Clients
{
    public class GetListClienteEFHandler(RetoDBContext dbContext) : IRequestHandler<GetListClienteEFQuery, Response<PaginateResponse<DtoGetListCliente>>>
    {
        private readonly RetoDBContext _dbContext = dbContext;

        public async Task<Response<PaginateResponse<DtoGetListCliente>>> Handle(GetListClienteEFQuery query, CancellationToken cancellationToken)
        {
            Response<PaginateResponse<DtoGetListCliente>> res = new();

            query.PageNumber = query.PageNumber > 0 ? query.PageNumber : 1;
            query.RowPageNumber = query.RowPageNumber > 0 ? query.RowPageNumber : 3;

            var baseQuery = _dbContext.Clientes
                .AsNoTracking()
                .OrderByDescending(c => c.Id);

            res.Data = new PaginateResponse<DtoGetListCliente>
            {
                TotalRow = baseQuery.Count(),

                List = await baseQuery
                .Skip((query.PageNumber - 1) * query.RowPageNumber)
                .Take(query.RowPageNumber)
                .Select(c => new DtoGetListCliente
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    ApPaterno = c.ApPaterno,
                    ApMaterno = c.ApMaterno,
                    Estado = c.Estado,
                    CodigoPais = c.CodigoPais,
                    NumeroTelefono = c.NumeroTelefono,
                    NombrePais = c.Pais.Nombre
                })
                .ToListAsync(cancellationToken)
            };

            res.IsSuccess = true;
            res.Message = Message.ListingCorrect;

            return res;
        }
    }
}
