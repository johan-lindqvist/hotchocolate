using System;
using System.Linq.Expressions;
using HotChocolate.Language;
using HotChocolate.Utilities;
using HotChocolate.Types;

namespace HotChocolate.Data.Filters.Expressions
{
    public class QueryableComparableLowerThanHandler
        : QueryableComparableOperationHandler
    {
        public QueryableComparableLowerThanHandler(
            ITypeConverter typeConverter,
            InputParser inputParser)
            : base(typeConverter, inputParser)
        {
            CanBeNull = false;
        }

        protected override int Operation => DefaultFilterOperations.LowerThan;

        public override Expression HandleOperation(
            QueryableFilterContext context,
            IFilterOperationField field,
            IValueNode value,
            object? parsedValue)
        {
            Expression property = context.GetInstance();
            parsedValue = ParseValue(value, parsedValue, field.Type, context);

            if (parsedValue is null)
            {
                throw ThrowHelper.Filtering_CouldNotParseValue(this, value, field.Type, field);
            }

            return FilterExpressionBuilder.LowerThan(property, parsedValue);
        }
    }
}
