using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kris.Infrastructure.Validation
{
    public static class ValidationConstants
    {
        public const int MaxProductNameLength = 100;

        public const int MaxDescriptionLength = 1500;

        public const int MaxCategoryTypeLength = 200;

        public const double MaxPrice = 9999.99;

        public const double MinPrice = 0.01;

        public const int MinNameLength = 3;

        public const int MinDescLength = 5;

        public const int MinCategoryLength = 3;

    }
}
