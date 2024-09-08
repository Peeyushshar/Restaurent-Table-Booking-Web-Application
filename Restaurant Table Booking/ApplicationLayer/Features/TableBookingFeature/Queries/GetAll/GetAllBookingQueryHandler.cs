using ApplicationLayer.DTOs.TableBookingDtos.ResponseDto;
using ApplicationLayer.IUnitOfWork;
using AutoMapper;
using MediatR;
using Restaurant_Table_Booking.Application.Specification;
using static Shared.Enums.BookingTimeEnum;
using static Shared.Enums.OccassionEnum;
using static Shared.Enums.PaymentModeEnum;
using static Shared.Enums.StatusEnum;

namespace ApplicationLayer.Features.TableBookingFeature.Queries.GetAll
{
    public class GetAllBookingQueryHandler : IRequestHandler<GetAllBookingQuery, List<GetBookingResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        public GetAllBookingQueryHandler(IMapper mapper, IUnitOfWorkRepository unitOfWorkRepository)
        {
            _mapper = mapper;
            _unitOfWorkRepository = unitOfWorkRepository;
        }
        public async Task<List<GetBookingResponseDto>> Handle(GetAllBookingQuery request, CancellationToken cancellationToken)
        {
            var query = request.FilterQuery;
            int skip = (request.PageNo - 1) * request.PageSize;
            if(request.FilterOn == "Occassion")
            {
                Enum.TryParse(request.FilterQuery, true, out OccassionType occassionFilter);
                query=occassionFilter.ToString();
            }
            if (request.FilterOn == "BookingTime")
            {
                Enum.TryParse(request.FilterQuery, true, out BookingTime bookingFilter);
                query = bookingFilter.ToString();
            }
            if (request.FilterOn == "PaymentMode")
            {
                Enum.TryParse(request.FilterQuery, true, out PaymentMode paymentFilter);
                query = paymentFilter.ToString();
            }
            if (request.FilterOn == "Status")
            {
                Enum.TryParse(request.FilterQuery, true, out Status statusFilter);
                query = statusFilter.ToString();
            }

            var spec = new BookingByNameSpec(request.FilterOn, query, request.SortBy, skip, request.PageSize, request.IsAscending);
            var bookings = await _unitOfWorkRepository.TableBookingRepository.ListAsync(spec);

            var pagedResult = bookings.ToList();
            return _mapper.Map<List<GetBookingResponseDto>>(pagedResult);

        }
    }
}
