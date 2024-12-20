using API.Contexts;
using API.Queries.Clients;
using API.Support.Constants;
using API.Support.DTO.Clients;
using API.Support.DTO.Generic;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Handlers.Clients
{
    public class GetListClienteSPHandler(RetoDBContext dbContext) : IRequestHandler<GetListClienteSPQuery, Response<PaginateResponse<DtoGetListCliente>>>
    {
        private readonly RetoDBContext _dbContext = dbContext;

        public async Task<Response<PaginateResponse<DtoGetListCliente>>> Handle(GetListClienteSPQuery query, CancellationToken cancellationToken)
        {
            var response = new Response<PaginateResponse<DtoGetListCliente>>();

            query.PageNumber = query.PageNumber > 0 ? query.PageNumber : 1;
            query.RowPageNumber = query.RowPageNumber > 0 ? query.RowPageNumber : 3;

            var pageNumberParam = new SqlParameter("@NumeroPagina", query.PageNumber);
            var rowsPerPageParam = new SqlParameter("@RegistrosPorPagina", query.RowPageNumber);

            var result = await _dbContext.DtoGetListClienteSP
                .FromSqlRaw("EXEC RETO.SP_LISTAR_CLIENTE @NumeroPagina, @RegistrosPorPagina", pageNumberParam, rowsPerPageParam)
                .ToListAsync(cancellationToken);

            response.Data = new PaginateResponse<DtoGetListCliente>
            {
                TotalRow = result[0].Total,
                List = result.Select(c => new DtoGetListCliente
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    ApPaterno = c.ApPaterno,
                    ApMaterno = c.ApMaterno,
                    CodigoPais = c.CodigoPais,
                    Estado = c.Estado,
                    NumeroTelefono = c.NumeroTelefono,
                    NombrePais = c.NombrePais
                }).ToList()
            };

            response.IsSuccess = true;
            response.Message = Message.ListingCorrect;

            return response;
        }
    }
}
