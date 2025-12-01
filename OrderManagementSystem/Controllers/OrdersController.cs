using OrderManagementSystem.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models;
using System.Security.Claims;

namespace OrderManagementSystem.Controllers
{
    [Authorize] 
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        private string GetCurrentUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var userId = GetCurrentUserId();
            return await _context.Orders.Where(o => o.UserId == userId).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(CreateOrderDto dto)
        {
            var order = new Order
            {
                ProductName = dto.ProductName,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                TotalAmount = dto.Quantity * dto.UnitPrice, 
                UserId = GetCurrentUserId() 
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrders), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, CreateOrderDto dto)
        {
            var userId = GetCurrentUserId();
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id && o.UserId == userId);

            if (order == null) return NotFound();

            order.ProductName = dto.ProductName;
            order.Quantity = dto.Quantity;
            order.UnitPrice = dto.UnitPrice;
            order.TotalAmount = dto.Quantity * dto.UnitPrice; 

            await _context.SaveChangesAsync();
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var userId = GetCurrentUserId();
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id && o.UserId == userId);

            if (order == null) return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}