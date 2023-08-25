using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using TOYOTA.Busines.CustomExceptions;
using TOYOTA.Busines.Interfaces;
using TOYOTA.DataAccess.Interfaces;
using TOYOTA.Model.Dtos.Order;
using TOYOTA.Model.Entities;

namespace TOYOTA.Busines.Implementations
{
    public class OrderBs : IOrderBs
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;

        public OrderBs(IOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("Id value must be greater than 0.");

            var entity = await _repo.GetByIdAsync(id);
            entity.IsActive = false;
            await _repo.UpdateAsync(entity);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<OrderGetDto>> GetByIdAsync(int orderId, params string[] includeList)
        {
            if (orderId <= 0)
                throw new BadRequestException("Id value must be greater than 0.");

            var order = await _repo.GetByIdAsync(orderId, includeList);

            if (order == null)
                throw new NotFoundException("No content found with this id value.");

            var dto = _mapper.Map<OrderGetDto>(order);

            return ApiResponse<OrderGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetOrdersAsync(params string[] includeList)
        {
            var orders = await _repo.GetAllAsync(includeList: includeList);
            if (orders.Count > 0)
            {
                var returnList = _mapper.Map<List<OrderGetDto>>(orders);

                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetOrdersByShipAdressAsync(string shipadress, params string[] includeList)
        {
            var orders = await _repo.GetByShipAdressAsync(shipadress, includeList);
            if (orders != null)
            {
                var returnList = _mapper.Map<List<OrderGetDto>>(orders);

                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetOrdersByShipDateAsync(DateTime shipdate, params string[] includeList)
        {
            var orders = await _repo.GetByShipAdressAsync(shipdate.ToString(), includeList);
            if (orders != null)
            {
                var returnList = _mapper.Map<List<OrderGetDto>>(orders);

                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Source not found");
        }

        public async Task<ApiResponse<Order>> InsertAsync(OrderPostDto dto)
        {
            if (dto.ShipAdress.Length < 7)
                throw new BadRequestException("Content name must be at least 7 characters.");            

            var entity = _mapper.Map<Order>(dto);
            var insertedOrder = await _repo.InsertAsync(entity);

            return ApiResponse<Order>.Success(StatusCodes.Status201Created, insertedOrder);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(OrderPutDto dto)
        {
            if (dto.OrderId <= 0)
                throw new BadRequestException("Id value must be greater than 0.");
            if (dto.ShipAdress.Length < 7)
                throw new BadRequestException("Content name must be at least 7 characters.");

            var entity = _mapper.Map<Order>(dto);
            await _repo.UpdateAsync(entity);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
