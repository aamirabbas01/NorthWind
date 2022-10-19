using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DALNorthWind.Data;
using DALNorthWind.Models;
using Microsoft.AspNetCore.Authorization;
using BLNorthWind.BL;

namespace NorthWind.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IBLWorkService<Order> _workService;
        private readonly IBLWorkService<Customer> _workServiceCustomer;

        public OrdersController(IBLWorkService<Order> workService, IBLWorkService<Customer> workServiceCustomer)
        {
            _workService = workService;
            _workServiceCustomer = workServiceCustomer;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            //var applicationDBContext = _context.Order.Include(o => o.Customer);
            return View(await _workService.GetAll());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _workService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = id;
            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_workServiceCustomer.GetAll().Result, "Id", "FirstName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderDate,OrderNumber,CustomerId,TotalAmount")] Order order)
        {
            if (ModelState.IsValid)
            {
                await _workService.Create(order);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_workServiceCustomer.GetAll().Result, "Id", "FirstName", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _workService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_workServiceCustomer.GetAll().Result, "Id", "FirstName", order.CustomerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderDate,OrderNumber,CustomerId,TotalAmount")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _workService.Update(order);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_workServiceCustomer.GetAll().Result, "Id", "FirstName", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _workService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var order =await _workService.GetById(id);
            await _workService.Delete(order);
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return (_workService.GetById(id) == null ? false : true);
        }
    }
}
