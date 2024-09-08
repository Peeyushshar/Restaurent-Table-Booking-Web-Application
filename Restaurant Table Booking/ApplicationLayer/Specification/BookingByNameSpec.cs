using DomainLayer.Entities.TableBookingDb;

using System.Linq.Expressions;

namespace Restaurant_Table_Booking.Application.Specification
{
    public class BookingByNameSpec : BaseSpecification<TableBookingDetails>
    {
        //private occassionFilter = Enum.TryParse(filterQuery, true, out OccassionType occassionFilter);
        public BookingByNameSpec(string filterOn, string filterQuery, string sortBy, int skip, int take,  bool isAsce = true)

         : base(x => string.IsNullOrEmpty(filterOn) && string.IsNullOrEmpty(filterQuery)
                  || (x.CustomerName.Contains(filterQuery) && filterOn == "CustomerName")
                  || (x.Id.Equals(filterQuery) && filterOn == "Id")
                  || (x.MobileNo.ToString().Contains(filterQuery) && filterOn == "MobileNo")
                  || (x.NoOfMembers.ToString().Contains(filterQuery) && filterOn == "NoOfMembers")
                  || (x.Email.ToString().Contains(filterQuery) && filterOn == "Email")
                  || (x.BookingDate.ToString().Contains(filterQuery) && filterOn == "BookingDate")
                  || (x.BookingTime.ToString().Contains(filterQuery) && filterOn == "BookingTime")
                  || (x.CouponCode.ToString().Contains(filterQuery) && filterOn == "CouponCode")
                  || (x.CreatedBy.ToString().Contains(filterQuery) && filterOn == "CreatedBy")
                  || (x.Discount_In_Percent.ToString().Contains(filterQuery) && filterOn == "Discount_in_percentage")
                  || (x.Occassion.ToString().Contains(filterQuery) && filterOn == "Occassion")
                  || (x.PaymentMode.ToString().Contains(filterQuery) && filterOn == "PaymentMode")
                  || (x.Status.ToString().Contains(filterQuery) && filterOn == "Status"))
        {
            ApplyPaging(skip, take);
            ApplyOrderBy(x => x.Id);
        }

        private Expression<Func<TableBookingDetails, object>> GetSortingExpression(string sortBy)
        {
            return sortBy switch
            {
                "CustomerName" => x => x.CustomerName,
                "Id" => x => x.Id,
                "MobileNo" => x => x.MobileNo,
                "NoOfMembers" => x => x.NoOfMembers,
                "Email"=> x=> x.Email,
                _ => x => x.Id
            };
        }

    }
}
