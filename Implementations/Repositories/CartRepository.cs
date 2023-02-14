using SMS_MVCDTO.Context;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationContext _context;
        public CartRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Cart Create(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return cart;
        }

        public void Delete(Cart cart)
        {
            _context.Carts.Update(cart);
            _context.SaveChanges();
        }

        public IEnumerable<Cart> GetAll()
        {
            var carts = _context.Carts.ToList();
            return carts;
        }


        public IEnumerable<Cart> GetAllPendingTransaction()
        {
            //var carts = _context.Carts.Where(x => !x.IsPaid && !x.IsDeleted).GroupBy(y => y).Select(z => z.Key).AsEnumerable();
            var carts = _context.Carts.Where(w => !w.IsPaid && !w.IsDeleted).GroupBy(x => x.CustomermId).Select(g => g.First()).AsEnumerable();
            return carts;
        }



        public Cart GetById(int id)
        {
            var carts = _context.Carts.SingleOrDefault(x => !x.IsPaid && !x.IsDeleted && x.Id == id);
            return carts;
        }

        public IEnumerable<Cart> NotPaidByCustomerId(string customerId)
        {
            var carts = _context.Carts.Where(x => !x.IsPaid && !x.IsDeleted && x.CustomermId == customerId);
            return carts;
        }
        public double GetCartTotal(string customerId)
        {
            var cartTotal = _context.Carts.Where(x => !x.IsPaid && !x.IsDeleted && x.CustomermId == customerId).Sum(y => (y.Quantity * y.Price));
            return cartTotal;
        }

        /* public Cart GetById(int id)
         {
             throw new NotImplementedException();
         }

         public IEnumerable<Cart> GetByTransactionRef(int id)
         {
             throw new NotImplementedException();
         }

         public IEnumerable<Cart> GetTransactionByCustomerName(string customerName)
         {
             throw new NotImplementedException();
         }
        */

        public string Update(string customerId)
        {

            var carts = _context.Carts.Where(x => x.CustomermId == customerId);
            foreach (var cart in carts)
            {
                cart.IsPaid = true;
            }
            _context.Carts.UpdateRange(carts);
            _context.SaveChanges();
            return customerId;
        }

        public IEnumerable<Cart> GetByTransactionId(string transactionId)
        {
            var carts = _context.Carts.Where(x => !x.IsDeleted && x.TransactionId == transactionId);
            return carts;

        }

        public Cart NotPaidExist(string customerId)
        {
            var carts = _context.Carts.FirstOrDefault(x => !x.IsPaid && !x.IsDeleted && x.CustomermId == customerId);
            return carts;

        }
    }
}
