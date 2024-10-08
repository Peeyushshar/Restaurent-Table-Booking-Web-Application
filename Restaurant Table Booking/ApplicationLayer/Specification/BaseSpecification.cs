﻿using Restaurant_Table_Booking.Application.ISpecification;
using System.Linq.Expressions;

namespace Restaurant_Table_Booking.Application.Specification
{
    public abstract class BaseSpecification<T> : ISpecification<T> where T : class
    {
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; }
        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
        protected void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        protected void ApplyOrderByDescending(Expression<Func<T, object>>
       orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

    }
}
