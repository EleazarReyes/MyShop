using MyShop.Cores.Models;
using MyShop.Cores.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Cores.Contracts
{
    public interface IOrderService
    {
        void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems);
        List<Order> GetOrderList();
        Order GetOrder(string Id);
        void UpdateOrder(Order updateOrder);
    }
}
