using ApplicationLayer.DTOs.TableBookingDtos.ResponseDto;
using MediatR;

namespace ApplicationLayer.Features.TableBookingFeature.Queries.GetAll
{
    public class GetAllBookingQuery:IRequest<List<GetBookingResponseDto>>
    {
        public string? FilterOn { get; set; }
        public string? FilterQuery { get; set; }
        public string? SortBy { get; set; }
        public bool IsAscending { get; set; } = true;
        public int PageNo { get; set; } =1;
        public int PageSize { get; set; } = 1000;
    }
}
