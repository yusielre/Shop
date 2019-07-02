namespace Shop.Web.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IQueryable<Order>> GetOrdersAsync(string userName);

        Task<IQueryable<OrderDetailTemp>> GetDetailTempsAsync(string userName);
    }

}
