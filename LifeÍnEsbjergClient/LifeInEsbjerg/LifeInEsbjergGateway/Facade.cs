using LifeInEsbjergGateway.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInEsbjergGateway
{
   public class Facade
    {
        public CompanyGatewayService GetCompanyGateway()
        {
            return new CompanyGatewayService();
        }
        public CategoryGatewayService GetCategoryGateway()
        {
            return new CategoryGatewayService();
        }

        public TagGatewayService GetTagGateway()
        {
            return new TagGatewayService();
        }

        public RatingGatewayService GetRatingGateway()
        {
            return new RatingGatewayService();
        }

        public ReviewGatewayService GetReviewGateway()
        {
            return new ReviewGatewayService();
        }
    }
}
