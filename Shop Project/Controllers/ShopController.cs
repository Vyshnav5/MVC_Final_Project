using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_Project.Data;
using Shop_Project.Models;
using System.Drawing.Printing;
using System.Xml.Linq;

namespace Shop_Project.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Sh_Index()
        {
            return View();
        }
        
        public async Task<IActionResult> Shop_det(int? pageNumber)
        {

            int shopId = (int)TempData["S_id"]; 

            var shopDetails = await _context.Shop_Details
                                            .Where(s => s.S_id == shopId)
                                            .ToListAsync();

            return shopDetails != null && shopDetails.Count > 0 ?
                   View(shopDetails) :
                   Problem("No shop details found for the given S_id.");
        }

        public async Task<IActionResult> Sh_Edit(int? Id)
        {
            if (Id == null || _context.Shop_Details == null)
            {
                return NotFound();
            }
            var Shop_details = await _context.Shop_Details.FindAsync(Id);
            if (Shop_details == null)
            {
                return NotFound();
            }
            return View(Shop_details);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sh_Edit1(int S_id, Shop_details Shop_details)
        {
            if (S_id != Shop_details.S_id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(Shop_details);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Shop_det));
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }

            }
            return View(Shop_details);
        }
        
        public IActionResult Sh_Employee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Sh_Emp_Reg(Employee Emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Employees.Add(Emp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }       
                return RedirectToAction(nameof(Sh_Emp_det));

            }
            return View(Emp);
        }

        public async Task<IActionResult> Sh_Emp_det(int? pageNumber)
        {
            int? shopId = HttpContext.Session.GetInt32("S_id");

            var details = from t1 in _context.Employees
                          where t1.S_id == shopId
                          select t1;

            int pageSize = 5;
            return View(PaginatedList<Employee>.Create(details.ToList(),
                pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> SE_Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }
            var Employees = await _context.Employees.FindAsync(id);
            if (Employees == null)
            {
                return NotFound();
            }
           
            return View(Employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SE_Edit(int Id, Employee Employees)
        {
            if (Id != Employees.E_id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(Employees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Sh_Emp_det));
            }
            return View(Employees);
        }

        public async Task<IActionResult> SE_Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }
            var Employees = await _context.Employees.FindAsync(id);
            if (Employees == null)
            {
                return NotFound();
            }
            return View(Employees);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SE_Delete(int id)
        {
            {
                if (_context.Employees == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Employees' is null.");
                }
                var Employees = await _context.Employees.FindAsync(id);
                if (Employees != null)
                {
                    _context.Employees.Remove(Employees);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Sh_Emp_det));
            }
        }
        public async Task<IActionResult> Sh_Pro_det(int? pageNumber)
        {

            var joinedData = from t1 in _context.Category
                             join t2 in _context.Products on t1.C_id equals t2.C_id
                             select new Models.View1
                             {
                                 C_id = t1.C_id,
                                 C_name = t1.C_name,
                                 P_id = t2.P_id,
                                 P_name = t2.P_name,
                                 P_price = t2.P_price,

                             };

            int pageSize = 5;
            return View(await PaginatedList2<Models.View1>.CreateAsync(joinedData.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public IActionResult Sh_Cust()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Sh_Cust(Customer Cu)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Customers.Add(Cu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }     
                return RedirectToAction(nameof(Sh_Cust_det));

            }
            return View(Cu);
        }

        public async Task<IActionResult> Sh_Cust_det(int? pageNumber)
        {
            int pageSize = 5;
            return View(PaginatedList<Customer>.Create(_context.Customers.ToList(),
                 pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Sh_Cu_Edit(int? Id)
        {
            if (Id == null || _context.Customers == null)
            {
                return NotFound();
            }
            var Customers = await _context.Customers.FindAsync(Id);
            if (Customers == null)
            {
                return NotFound();
            }
            return View(Customers);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sh_Cu_Edit(int Id, Customer Customer)
        {
            if (Id != Customer.Cu_id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(Customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Sh_Cust_det));
            }
            return View(Customer);
        }


        public async Task<IActionResult> Sh_Cu_Delete(int? Id)
        {
            if (Id == null || _context.Customers == null)
            {
                return NotFound();
            }
            var Customer = await _context.Customers.FindAsync(Id);
            if (Customer == null)
            {
                return NotFound();
            }
            return View(Customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sh_Cu_Delete(int Id)
        {
            {
                if (_context.Customers == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Catogory' is null.");
                }
                var Customers = await _context.Customers.FindAsync(Id);
                if (Customers != null)
                {
                    _context.Customers.Remove(Customers);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Sh_Cust_det));
            }

        }
        public IActionResult Sh_Sale()
        {
            List<Product> productList = (from p in _context.Products select p).ToList();
            productList.Insert(0, new Product { P_id = 0, P_name = "--Select Product --" });
            ViewBag.ProductList = productList;

            List<Customer> customerList = (from c in _context.Customers select c).ToList();
            customerList.Insert(0, new Customer { Cu_id = 0, Cu_name = "--Select Customer --" });
            ViewBag.CustomerList = customerList;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sh_Sale(Sales sal)
        {
            if (ModelState.IsValid)
            {
                var s_id = HttpContext.Session.GetInt32("S_id");
                var product = await _context.Products.FindAsync(sal.P_id);
                if (product != null)
                {
                    //sal.S_id = s_id.Value;
                    try
                    {
                        _context.Sales.Add(sal);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {

                        throw;

                    }

                    return RedirectToAction(nameof(Sh_Sal_det));
                }
                ModelState.AddModelError(string.Empty, "Product not found.");
            }
            return View(sal);
        }



        public async Task<IActionResult> Sh_Sal_det(int? pageNumber)
        {
            int? shopId = HttpContext.Session.GetInt32("S_id");
            
            var joinedData = from t1 in _context.Shop_Details
                             join t2 in _context.Sales on t1.S_id equals t2.S_id
                             join t3 in _context.Products on t2.P_id equals t3.P_id
                             where t1.S_id == shopId.Value
                             select new View2
                             {
                                 S_id = t1.S_id,
                                 S_location = t1.S_location,
                                 P_name = t3.P_name,
                                 P_price = t3.P_price,
                                 Sl_date = t2.Sl_date
                             };

            int pageSize = 5;
            return View(await PaginatedList2<View2>.CreateAsync(joinedData.AsNoTracking(), pageNumber ?? 1, pageSize));
        }




        public IActionResult Sh_exp()
        {
            ViewBag.S_id = HttpContext.Session.GetInt32("S_id");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Sh_exp(Expense ex )
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _context.Expenses.Add(ex);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                 return RedirectToAction(nameof(Sh_Exp_det));

            }
            return View(ex);
        }

        public async Task<IActionResult> Sh_Exp_det(int? pageNumber)
        {
            if (TempData["S_id"] == null)
            {
                return Problem("S_id is not available.");
            }

            int? shopId = HttpContext.Session.GetInt32("S_id");

            var details = from t1 in _context.Expenses
                          where t1.S_id == shopId
                          select t1;

            int pageSize = 5;
            return View(PaginatedList<Expense>.Create(details.ToList(),
                pageNumber ?? 1, pageSize));
        }


        public async Task<IActionResult> Sh_noti()
        {
            return _context.Notifications != null ?
            View(await _context.Notifications.ToListAsync()) :
            Problem("Entity set 'ApplicationDbContext.Notification' is null.");
        }

        public IActionResult Sh_order()
        {
            ViewBag.S_id = HttpContext.Session.GetInt32("S_id");
            List<Product> productList = (from p in _context.Products select p).ToList();
            productList.Insert(0, new Product { P_id = 0, P_name = "--Select Product --" });
            ViewBag.ProductList = productList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sh_order(Order order)
        {
            var s_id = HttpContext.Session.GetInt32("S_id");

            order.S_id = s_id.Value;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(order);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Sh_Order_det));
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }


            }

            ViewBag.S_id = s_id;
            return View(order);
        }


        public async Task<IActionResult> Sh_Order_det(int? pageNumber)
        {

            int? shopId = HttpContext.Session.GetInt32("S_id");

            var joinedData = from t1 in _context.Shop_Details
                             join t2 in _context.Orders on t1.S_id equals t2.S_id
                             join t3 in _context.Products on t2.P_id equals t3.P_id
                             where t1.S_id == shopId.Value
                             select new View2
                             {
                                 S_id = t1.S_id,
                                 S_location = t1.S_location,
                                 P_name = t3.P_name,
                                 O_quantity = t2.O_quantity,
                             };

            int pageSize = 5;
            return View(await PaginatedList2<View2>.CreateAsync(joinedData.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public IActionResult Sh_comp()
        {
            ViewBag.S_id = HttpContext.Session.GetInt32("S_id");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sh_comp(Complaint Com)
        {
            //var s_id = HttpContext.Session.GetInt32("S_id");

            //Com.S_id = s_id.Value;

            if (ModelState.IsValid)
            {

                try
                {
                    _context.Complaint.Add(Com);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Sh_comp_det));


            }

            
            return View(Com);
        }


        public async Task<IActionResult> Sh_comp_det(int? pageNumber)
        {

            var s_id = HttpContext.Session.GetInt32("S_id");
            var details = from t1 in _context.Complaint
                          where t1.S_id == s_id
                          select t1;

            int pageSize = 5;
            return View(PaginatedList<Complaint>.Create(details.ToList(),
                pageNumber ?? 1, pageSize));
        }

       
    }
}
