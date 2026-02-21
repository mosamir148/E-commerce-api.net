using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatCore.Entites;
using TalabatCore.Entites.Order_Agreggate;
using TalabatCore.Irepository;
using TalabatCore.Servise;

namespace TalabatServise
{
    public class OrderServise : IOrderServise
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;

        //private readonly IGenericinterface<Order> _order;
        //private readonly IGenericinterface<DeliveryMethode> _delivarymethode;
        //private readonly IGenericinterface<Product> _product;

        public OrderServise(IBasketRepository basketRepository, IUnitOfWork unitOfWork)
        {
            this._basketRepository = basketRepository;
            this._unitOfWork = unitOfWork;
            //    _order = Order;
            //    this._delivarymethode = delivarymethode;
            //    this._product = product;
            //
            //}
        }



        public async Task<Order?> createOrderAsync(string Email, string BasketId, int DeliveryMethodeId, TalabatCore.Entites.Order_Agreggate.Address address)
        {

            //هنا اول حاجه جبت الباسكت بid اللي جاي
            var basket = await _basketRepository.GetBasketAsync(BasketId);
            //عملت ليست من الاورد 
            var OrderItems = new List<OrderItem>();
            //عملت تشيك علي الباسكيت ان جايه باوردر
            if (basket?.Items?.Count > 0)
            {//عملت لووب عليها ممكن تكون شايله اكتر من منتج
                foreach (var item in basket.Items)
                {
                    //هنا علشان انا مش واثق في البيانات اللي الي اليوزر باعتها فجبت المنتج من الداتا بيز علشان مش يحصل 
                    //ويغير اي حاجه في الداتا الخاصه بالمنتج
                    var product = await _unitOfWork.Repositoe<Product>().GetByIdAsync(item.Id);
                    //ولاحظ مهمه جدا هنا ببعت الداتا اللي انا جايبها من الداتا بيز مش اللي هو باعتها علشان اعمل الاوردر ايتم لازم اعمل الكونستراكتور اللي بياخد مني النقطه دي
                    var productitemorder = new ProductItemOrder(product.Id, product.Name, product.PictureUrl);
                    //
                    var Orderitem = new OrderItem(productitemorder, product.Price, item.Quantity);

                    OrderItems.Add(Orderitem);
                }
            }

                //3 clac Subtotal

                var subTotal = OrderItems.Sum(item => item.quantity * item.Price);

                //get DeliveryMethode from repo

                var deliverymethode = await _unitOfWork.Repositoe<DeliveryMethode>().GetByIdAsync(DeliveryMethodeId);

                var order = new Order(Email, address, deliverymethode,OrderItems,subTotal);

                await _unitOfWork.Repositoe<Order>().Add(order);

                var result = await _unitOfWork.Complete();

                if(result <=0) 
                    return null;

                return order;

            
           
        }

        public Task<Order> GetOrderByIdForUserAsync(int orderId, string Email)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrderForUserAsync(string Email)
        {
            throw new NotImplementedException();
        }
    }

}
