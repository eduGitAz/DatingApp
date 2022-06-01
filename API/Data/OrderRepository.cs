using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
            public OrderRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<OrderDto> GetOrderDtoByIdAsync(int id)
        {
               return await _context.Orders
                .Where(x => x.Id == id)
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }
  
        public async Task<IEnumerable<OrderDto>> GetOrdersDtoAsync(int appCompanyId)
        {
            return await _context.Orders
                .Where(x => x.AppCompany.Id == appCompanyId)
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
        public async Task<int> CountAllOrdersDtoAsync(int appCompanyId)
        {
            return  _context.Orders
                .Where(x => x.AppCompany.Id == appCompanyId).Count();
              
        }
        public async Task<int> CountNewOrdersDtoAsync(int appCompanyId)
        {
            return  _context.Orders
                .Where(x => x.AppCompany.Id == appCompanyId && x.AppOrderStatus.Name == "Nowe").Count();
              
        }
        public async Task<int> CountRealizedOrdersDtoAsync(int appCompanyId)
        {
            return  _context.Orders
                .Where(x => x.AppCompany.Id == appCompanyId && x.AppOrderStatus.Name == "Realizowane").Count();
              
        }
        public async Task<int> CountClosedOrdersDtoAsync(int appCompanyId)
        {
            return  _context.Orders
                .Where(x => x.AppCompany.Id == appCompanyId && x.AppOrderStatus.Name == "Zamknięte").Count();
 
        }

        public async Task<int> CountPercentOfServicesOrders(int appCompanyId)
        {
            return  _context.Orders
                .Where(x => x.AppCompany.Id == appCompanyId && x.AppOrderType.Name == "Serwis").Count();
        }
        public async Task<int> CountPercentOfInstallationOrders(int appCompanyId)
        {
            return  _context.Orders
                .Where(x => x.AppCompany.Id == appCompanyId && x.AppOrderType.Name == "Montaż").Count();
        }

        public async Task<AppOrder> GetOrderByIdAsync(int id)
        {
            return await _context.Orders 
            .Include(a => a.AppCompany)
            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AppOrder>> GetOrdersAsync()
        {
            return await _context.Orders
              .ToListAsync();
        }
        public void Update(AppOrder order)
        {
            _context.Entry(order).State = EntityState.Modified;
        }
        public async Task<bool> SaveAllAsync()
        {
             return await _context.SaveChangesAsync() > 0;
        }
        public async Task<AppOrder> Add(AppOrder order)
        {
            await _context.Orders.AddAsync(order);
            _context.SaveChanges(); 
            return order;
        }
        public async Task<AppOrder> Delete(int id)
        {
            var result = await _context.Orders
            .FirstOrDefaultAsync( c => c.Id == id);
            if(result != null)
            {
                _context.Orders.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }   

            return null;
        }

      
    }
} 