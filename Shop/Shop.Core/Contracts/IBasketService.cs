using System.Collections.Generic;
using System.Web;
using Shop.Core.ViewModels;

namespace Shop.Core.Contracts
{
    public interface IBasketService
    {
        void AddToBasket(HttpContextBase httpContext, string productId);
        BasketSummaryViewModel GetBasketSummary(HttpContextBase httpContext);
        List<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext);
        void RemoveFromBasket(HttpContextBase httpContext, string itemId);
    }
}