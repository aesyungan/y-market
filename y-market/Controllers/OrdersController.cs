using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using y_market.Models;
using y_market.ViewModels;

namespace y_market.Controllers
{
    public class OrdersController : Controller
    {
        private y_marketContext db = new y_marketContext();
        // GET: Orders
        public ActionResult NewOrder()
        {
            var orderView = Session["orderView"] as OrderView;
            if (orderView == null)
            {
                orderView = new OrderView();
                orderView.Customer = new Customer();
                orderView.Products = new List<ProductOrder>();
                orderView.Product = new ProductOrder();
            }

            var lstP = db.Customers.ToList();
            lstP.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un cliente..]" });
            lstP = lstP.OrderBy(i => i.FullName).ToList();
            ViewBag.CustomerID = new SelectList(lstP, "CustomerID", "FullName");
            Session["orderView"] = orderView;
            return View(orderView);
        }
        [HttpPost]
        public ActionResult NewOrder(OrderView orderView)
        {
            var lstP = db.Customers.ToList();
            lstP.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un cliente..]" });
            lstP = lstP.OrderBy(i => i.FullName).ToList();
            ViewBag.CustomerID = new SelectList(lstP, "CustomerID", "FullName");


            orderView = Session["orderView"] as OrderView;
            var CustomerID = int.Parse(Request["CustomerID"]);
            orderView.Customer.CustomerID = CustomerID;
            if (CustomerID == 0)
            {
                ViewBag.Error = "Debe seleccionar un Cliente";
                return View(orderView);
            }
            var customers = db.Customers.Find(CustomerID);
            if (customers == null)
            {
                ViewBag.Error = "Cliente no existe";
                return View(orderView);
            }

            if (orderView.Products.Count == 0)
            {
                ViewBag.Error = "Debe ingresar detalle producto";
                return View(orderView);
            }
            var orderID = 0;
            using (var trasactio = db.Database.BeginTransaction())
            {
                try
                {
                    var order = new Order
                    {
                        CustomerID = CustomerID,
                        OrderDate = DateTime.Now,
                        OrderStatus = OrderStatus.Created,

                    };
                    db.Orders.Add(order);
                    db.SaveChanges();

                    orderID = db.Orders.ToList().Select(o => o.OrderID).Max();
                    foreach (var item in orderView.Products)
                    {
                        var orderDetail = new OrderDetail
                        {
                            Description = item.Description,
                            Price = item.Price,
                            Quantity = item.Quantity,
                            OrderID = orderID,
                            ProductID = item.ProductID
                        };
                        db.OrderDetails.Add(orderDetail);
                        db.SaveChanges();
                    }
                    trasactio.Commit();//confirmamos la transaction 
                }
                catch (Exception e)
                {

                    trasactio.Rollback();
                    ViewBag.Error = "Error->" + e.Message;
                    return View(orderView);
                }
            }
            ViewBag.Message = string.Format("La orden :{0}, grabada Ok", orderID);
            //data
            orderView = new OrderView();
            orderView.Customer = new Customer();
            orderView.Products = new List<ProductOrder>();
            orderView.Product = new ProductOrder();
            Session["orderView"] = orderView;
            return View(orderView);
            //RedirectToAction("NewOrder");
        }
        public ActionResult AddProduct()
        {
            var lstP = db.Products.ToList();
            lstP.Add(new Product { ProductID = 0, Description = "[Seleccione un producto..]" });
            lstP = lstP.OrderBy(i => i.Description).ToList();
            ViewBag.ProductID = new SelectList(lstP, "ProductID", "Description");
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductOrder productOrder)
        {
            var ProducID = int.Parse(Request["ProductID"]);//el select recupera

            var orderView = Session["orderView"] as OrderView;
            var lstP = db.Products.ToList();
            lstP.Add(new Product { ProductID = 0, Description = "[Seleccione un producto..]" });
            lstP = lstP.OrderBy(i => i.Description).ToList();
            ViewBag.ProductID = new SelectList(lstP, "ProductID", "Description");
            if (ProducID == 0)
            {
                ViewBag.Error = "Debe seleccionar un producto";
                return View(productOrder);
            }
            var product = db.Products.Find(ProducID);
            if (product == null)
            {
                ViewBag.Error = "Producto no existe";
                return View(productOrder);
            }
            productOrder = orderView.Products.ToList().Find(p => p.ProductID == ProducID);
            if (productOrder == null)
            {

                productOrder = new ProductOrder
                {
                    Description = product.Description,
                    Price = product.Price,
                    ProductID = product.ProductID,
                    Quantity = float.Parse(Request["Quantity"]),
                };
                orderView.Products.Add(productOrder);
            }
            else
            {
                productOrder.Quantity += float.Parse(Request["Quantity"]);
            }

            // Session["orderView"] = orderView; //no se graba por q el objeto esta en memoria cmo un puntero

            var lstC = db.Customers.ToList();
            lstC.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un cliente..]" });
            lstC = lstC.OrderBy(i => i.FullName).ToList();
            ViewBag.CustomerID = new SelectList(lstC, "CustomerID", "FullName");


            return View("NewOrder", orderView);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}