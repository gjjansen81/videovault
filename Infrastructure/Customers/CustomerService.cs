using AutoMapper;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;
using VideoVault.Domain.Entities;

namespace Infrastructure.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomerService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> GetCustomersAsync()
        {
            return _mapper.Map<List<CustomerDto>>(await _context.Customers.ToListAsync());
        }

        public async Task<CustomerDto> GetCustomerAsync(int id)
        {
            return _mapper.Map<CustomerDto>(await _context.Customers
                .Include( a => a.Address)
                .FirstOrDefaultAsync(x => x.Id ==id));
        }

        public async Task<CustomerDto> UpsertCustomerAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            Customer entity;
            if (customer.Id != 0)
            {
                //_context.Customers.Update(customer);
                entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == customer.Id);

                // Validate entity is not null
                if (entity != null)
                {
                    entity = customer;
                    //entity.Name = customer.Name;
                }
            }
            else
            {
                entity = (await _context.Customers.AddAsync(customer)).Entity;
            }

            await _context.CommitTransactionAsync();
            return _mapper.Map<CustomerDto>(entity);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
                _context.Customers.Remove(entity);
        }
    }
}
