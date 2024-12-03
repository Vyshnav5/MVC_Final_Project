using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shop_Project.Data;
using Shop_Project.Models;

namespace Shop_Project.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Admin_Index()
        {
            return View();
        }
        public IActionResult A_Shop_Reg()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> A_Shop_Reg(Shop_details mov, Login mo)
        {
           
                if (ModelState.IsValid)
                {



                    _context.Shop_Details.Add(mov);
                    await _context.SaveChangesAsync();

                    var shopId = mov.S_id;

                    mo.S_id = shopId;

                    _context.Login.Add(mo);
                    await _context.SaveChangesAsync();



                  return RedirectToAction(nameof(A_shop_det));


               
                }
                else
                {
                  return View();
                }
            
        }


        public async Task<IActionResult> A_shop_det()
        {
            var joinedData = from t1 in _context.Shop_Details
                             join t2 in _context.Login on t1.S_id equals t2.S_id
                             select new LogShop
                             {
                                 S_id = t1.S_id,
                                 S_location = t1.S_location,
                                 S_PH  = t1.S_PH,
                                 S_Email = t1.S_Email,
                                 L_id = t2.L_id,
                                 S_shopcode = t2.S_shopcode,
                                 S_Password = t2.S_Password,
                             };
            return View(joinedData.ToList());
            //return _context.Shop_Details != null ?
            //View(await _context.Shop_Details.ToListAsync()) :
            //Problem("Entity set 'ApplicationDbContext.Shop_Details' is null.");
        }
        public async Task<IActionResult> AS_Edit(int? Id)
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
        public async Task<IActionResult> AS_Edit1(int S_id, Shop_details Shop_details)
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
                    return RedirectToAction(nameof(A_shop_det));
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }

            }
            return View(Shop_details);
        }
        public async Task<IActionResult> AS_Delete(int? Id)
        {
            if (Id == null || _context.Shop_Details == null)
            {
                return NotFound();
            }
            var shop_Details = await _context.Shop_Details.FindAsync(Id);
            if (shop_Details == null)
            {
                return NotFound();
            }
            return View(shop_Details);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AS_Delete(int Id)
        {
            {
                if (_context.Shop_Details == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Shop_details' is null.");
                }
                var shop_Details = await _context.Shop_Details.FindAsync(Id);
                if (shop_Details != null)
                {
                    _context.Shop_Details.Remove(shop_Details);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(A_shop_det));
            }

        }

        public IActionResult AD_Emp_Reg()
        {
            List<Shop_details> cl = new List<Shop_details>();
            cl = (from c in _context.Shop_Details select c).ToList();
            cl.Insert(0, new Shop_details { S_id = 0, S_location = "--Select Location Name--" });
            ViewBag.message = cl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AD_Emp_Reg(Employee Emp)
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
                return RedirectToAction(nameof(AD_Emp_det));
            }
            return View(Emp);

        }

        public async Task<IActionResult> AD_Emp_det(int? pageNumber)
        {
            var joinedData = from t1 in _context.Shop_Details
                             join t2 in _context.Employees on t1.S_id equals t2.S_id
                             select new Models.View1
                             {
                                 S_id = t1.S_id,
                                 S_location = t1.S_location,
                                 E_id = t2.E_id,
                                 E_name = t2.E_name,
                                 E_ph = t2.E_ph,
                                 E_email = t2.E_email,
                                 E_position = t2.E_position
                             };

            int pageSize = 5;
            return View(await PaginatedList2<Models.View1>.CreateAsync(joinedData.AsNoTracking(), pageNumber ?? 1, pageSize));
        }




        public async Task<IActionResult> AE_Edit(int? id)
        {
            if (id == null || _context.Employees== null)
            {
                return NotFound();
            }
            var Employees = await _context.Employees.FindAsync(id);
            if (Employees == null)
            {
                return NotFound();
            }
            List<Shop_details> cl = new List<Shop_details>();
            cl = (from c in _context.Shop_Details select c).ToList();
            cl.Insert(0, new Shop_details { S_id = 0, S_location = "--Select Shop_details Name--" });
            ViewBag.message = cl;

            return View(Employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AE_Edit(int Id, Employee Employees)
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
            return RedirectToAction(nameof(AD_Emp_det));
            }
            return View(Employees);
        }

        public async Task<IActionResult> AE_Delete(int? id)
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
        public async Task<IActionResult> AE_Delete(int id)
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


            return RedirectToAction(nameof(AD_Emp_det));
            }
        }
        public IActionResult AD_CatoReg()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AD_CatoReg(Category mov)
        {
            if (ModelState.IsValid)
            {
               
                try
                {
                    _context.Category.Add(mov);
                   await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }  
                return RedirectToAction(nameof(AD_CatDet));

            }
            return View(mov);

        }
        public async Task<IActionResult> AD_CatDet()
        {
            return _context.Category != null ?
            View(await _context.Category.ToListAsync()) :
            Problem("Entity set 'ApplicationDbContext.Catogory' is null.");
        }

        public async Task<IActionResult> AD_Cat_Edit(int? Id)
        {
            if (Id == null || _context.Category == null)
            {
                return NotFound();
            }
            var Category = await _context.Category.FindAsync(Id);
            if (Category == null)
            {
                return NotFound();
            }
            return View(Category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>AD_Cat_Edit(int Id, Category Category)
        {
            if (Id != Category.C_id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(Category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(AD_CatDet));
            }
            return View(Category);
        }


        public async Task<IActionResult> AD_Cat_Delete(int? Id)
        {
            if (Id == null || _context.Category == null)
            {
                return NotFound();
            }
            var Category = await _context.Category.FindAsync(Id);
            if (Category == null)
            {
                return NotFound();
            }
            return View(Category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AD_Cat_Delete(int Id)
        {
            {
                if (_context.Category == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Catogory' is null.");
                }
                var category = await _context.Category.FindAsync(Id);
                if (category != null)
                {
                    _context.Category.Remove(category);
                }
                await _context.SaveChangesAsync();

                  return RedirectToAction(nameof(AD_CatDet));
            }

        }

        public IActionResult AD_pro()
        {
            List<Category> cl = new List<Category>();
            cl = (from c in _context.Category select c).ToList();
            cl.Insert(0, new Category { C_id = 0, C_name = "--Select Catoogory--" });
            ViewBag.message = cl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AD_pro(Product Pro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Products.Add(Pro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
               return RedirectToAction(nameof(AD_Pro_det));

            }
            return View(Pro);
        }

        public async Task<IActionResult> AD_Pro_det(int? pageNumber)
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


        public async Task<IActionResult>AD_pro_Edit(int? Id)
        {
            if (Id == null || _context.Products == null)
            {
                return NotFound();
            }
            var Products = await _context.Products.FindAsync(Id);
            if (Products == null)
            {
                return NotFound();
            }
            List<Category> cl = new List<Category>();
            cl = (from c in _context.Category select c).ToList();
            cl.Insert(0, new Category { C_id = 0, C_name = "--Select Catoogory--" });
            ViewBag.message = cl;
            
            return View(Products);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>AD_pro_Edit(int Id, Product Product)
        {
            if (Id != Product.P_id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(Product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(AD_Pro_det));
            }
            return View(Product);
        }


        public async Task<IActionResult> AD_pro_Delete(int? Id)
        {
            if (Id == null || _context.Products == null)
            {
                return NotFound();
            }
            var Products = await _context.Products.FindAsync(Id);
            if (Products == null)
            {
                return NotFound();
            }
            return View(Products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AD_pro_Delete(int Id)
        {
            {
                if (_context.Products == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Products' is null.");
                }
                var Products = await _context.Products.FindAsync(Id);
                if (Products != null)
                {
                    _context.Products.Remove(Products);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(AD_Pro_det));
            }

        }

        public IActionResult AD_noti()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AD_noti(Notification mov)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Notifications.Add(mov);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }    
                return RedirectToAction(nameof(AD_noti_det));

            }
            return View(mov);

        }
        public async Task<IActionResult> AD_noti_det()
        {
            return _context.Notifications != null ?
            View(await _context.Notifications.ToListAsync()) :
            Problem("Entity set 'ApplicationDbContext.Catogory' is null.");
        }

        public async Task<IActionResult> AD_not_Edit(int? Id)
        {
            if (Id == null || _context.Notifications == null)
            {
                return NotFound();
            }
            var Notification = await _context.Notifications.FindAsync(Id);
            if (Notification == null)
            {
                return NotFound();
            }
            return View(Notification);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AD_not_Edit(int Id, Notification Notification)
        {
            if (Id != Notification.N_id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(Notification);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(AD_noti_det));

                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
            }
            return View(Notification);
        }


        public async Task<IActionResult> AD_not_Delete(int? Id)
        {
            if (Id == null || _context.Notifications == null)
            {
                return NotFound();
            }
            var Notification = await _context.Notifications.FindAsync(Id);
            if (Notification == null)
            {
                return NotFound();
            }
            return View(Notification);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AD_not_Delete(int Id)
        {
            {
                if (_context.Notifications == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Notification' is null.");
                }
                var Notification = await _context.Notifications.FindAsync(Id);
                if (Notification != null)
                {
                    _context.Notifications.Remove(Notification);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(AD_noti_det));
            }

        }

        public async Task<IActionResult> AD_exp_det( int? pageNumber)
        {
            var details = from t1 in _context.Shop_Details
                          join t2 in _context.Expenses on t1.S_id equals t2.S_id
                         
                          select new Models.View1
                          {
                              S_id = t1.S_id,
                              S_location = t1.S_location,
                              Ex_type = t2.Ex_type,
                              Ex_amount = t2.Ex_amount,
                              Ex_date = t2.Ex_date,
                          };
            int pageSize = 5;
            return View(await PaginatedList2<Models.View1>.CreateAsync(details.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        [HttpPost]
        public async Task<IActionResult> AD_exp_det(string S_location , int? pageNumber)
        {
            var details = from t1 in _context.Shop_Details
                          join t2 in _context.Expenses on t1.S_id equals t2.S_id
                          where t1.S_location == S_location
                          select new Models.View1
                          {
                                   S_id = t1.S_id,
                              S_location = t1.S_location,
                                  Ex_type = t2.Ex_type,
                                  Ex_amount=t2.Ex_amount,
                                  Ex_date  = t2.Ex_date,
                          };
            int pageSize = 5;
            return View(await PaginatedList2<Models.View1>.CreateAsync(details.AsNoTracking(), pageNumber ?? 1, pageSize));

        }
       

        public async Task<IActionResult> AD_order_det(int? pageNumber)
        {
            var details = from t1 in _context.Shop_Details
                          join t2 in _context.Orders on t1.S_id equals t2.S_id
                          join t3 in _context.Products on t2.P_id equals t3.P_id
                          where t2.O_status == "RequestSent"

                          select new Models.View2
                          {
                              S_id = t1.S_id,
                              S_location = t1.S_location,
                              O_id   =  t2.O_id,
                              O_date = t2.O_date,
                              P_name = t3.P_name,
                              O_quantity = t2.O_quantity,
                              O_status  =t2.O_status,
                          };
            int pageSize = 5;
            return View(await PaginatedList2<Models.View2>.CreateAsync(details.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        [HttpPost]
        public async Task<IActionResult> AD_order_det(int? pageNumber,string O_date)
        {
            var details = from t1 in _context.Shop_Details
                          join t2 in _context.Orders on t1.S_id equals t2.S_id
                          join t3 in _context.Products on t2.P_id equals t3.P_id
                          where t2.O_status == "RequestSent" && t2.O_date == O_date

                          select new Models.View2
                          {
                              S_id = t1.S_id,
                              S_location = t1.S_location,
                              O_id = t2.O_id,
                              O_date = t2.O_date,
                              P_name = t3.P_name,
                              O_quantity = t2.O_quantity,
                              O_status = t2.O_status,
                          };
            int pageSize = 5;
            return View(await PaginatedList2<Models.View2>.CreateAsync(details.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        public async Task<IActionResult> AD_Order_accep(int? Id)
        {
            if (Id == null || _context.Orders == null)
            {
                return NotFound();
            }
            var Order = await _context.Orders.FindAsync(Id);
            if (Order == null)
            {
                return NotFound();
            }
            ViewBag.S_id = HttpContext.Session.GetInt32("S_id");
            List<Product> productList = (from p in _context.Products select p).ToList();
            productList.Insert(0, new Product { P_id = 0, P_name = "--Select Product --" });
            ViewBag.ProductList = productList;

            List<Shop_details> cl1 = new List<Shop_details>();
            cl1 = (from c in _context.Shop_Details select c).ToList();
            cl1.Insert(0, new Shop_details { S_id = 0, S_location = "--Select Location Name--" });
            ViewBag.message = cl1;
            

            return View(Order);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AD_Order_acc_rej(int O_id, Order Order)
        {
            if (O_id != Order.O_id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(Order);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(AD_order_det));
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }

            }
            return View(Order);
        }
        public async Task<IActionResult> AD_Order_rej(int? Id)
        {
            if (Id == null || _context.Orders == null)
            {
                return NotFound();
            }
            var Order = await _context.Orders.FindAsync(Id);
            if (Order == null)
            {
                return NotFound();
            }
            return View(Order);
        }

        public async Task<IActionResult> AD_Cust_det(int? pageNumber)
        {
            int pageSize = 5;
            return View(PaginatedList<Customer>.Create(_context.Customers.ToList(),
                 pageNumber ?? 1, pageSize));
        }


     
        public async Task<IActionResult> AD_comp_det(string S_location, int? pageNumber)
        {
            var details = from t1 in _context.Shop_Details
                          join t2 in _context.Complaint on t1.S_id equals t2.S_id

                          select new Models.View2
                          {
                              S_id = t1.S_id,
                              S_location = t1.S_location,
                              Cm_id = t2.Cm_id,
                              Cm_description = t2.Cm_description,
                              Cm_reply      = t2.Cm_reply

                          };
            int pageSize = 5;
            return View(await PaginatedList2<Models.View2>.CreateAsync(details.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        public async Task<IActionResult> AD_Com_reply(int? Id)
        {
            if (Id == null || _context.Complaint == null)
            {
                return NotFound();
            }
            var Com = await _context.Complaint.FindAsync(Id);
            if (Com == null)
            {
                return NotFound();
            }
            return View(Com);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AD_Com_reply(int Cm_id, Complaint Complaint)
        {
            if (Cm_id != Complaint.Cm_id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(Complaint);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(AD_comp_det));
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }

            }
            return View(Complaint);
        }

        public async Task<IActionResult> AD_Sal_det(int? pageNumber)
        {
            int? shopId = HttpContext.Session.GetInt32("S_id");

            var joinedData = from t1 in _context.Shop_Details
                             join t2 in _context.Sales on t1.S_id equals t2.S_id
                             join t3 in _context.Products on t2.P_id equals t3.P_id
                            
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


        [HttpPost]
        public async Task<IActionResult> AD_Sal_det(string S_location ,int? pageNumber)
        {
            int? shopId = HttpContext.Session.GetInt32("S_id");

            var joinedData = from t1 in _context.Shop_Details
                             join t2 in _context.Sales on t1.S_id equals t2.S_id
                             join t3 in _context.Products on t2.P_id equals t3.P_id
                             where t1.S_location == S_location
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
    }

}
