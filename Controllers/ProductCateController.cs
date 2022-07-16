using BT2MWG.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BT2MWG.Controllers
{
    public class ProductCateController : Controller
    {
        int maxRows = 2;
        DataHelper dataHelper = new DataHelper();
        private List<Product> productsSearchedBrand;

        public ActionResult Toy()
        {

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                //builder.DataSource = "SNORLAX";
                //builder.UserID = "sa";
                //builder.Password = "123";
                //builder.InitialCatalog = "TTTN";
                builder.ConnectionString = "Data Source=SNORLAX;Initial Catalog=TTTN;User ID=sa;Password=123;Integrated Security=true;Connect Timeout=300;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();

                    String sql = "SELECT name, collation_name FROM sys.databases";

                    //using (SqlCommand command = new SqlCommand(sql, connection))
                    //{
                    //    using (SqlDataReader reader = command.ExecuteReader())
                    //    {
                    //        while (reader.Read())
                    //        {
                    //            Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                    //            var string1 = reader.GetString(0);  
                    //        }
                    //    }
                    //}
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone..................................................................");






            var products = dataHelper.initProducts();
            double pageCount = (double)((decimal)products.Count() / Convert.ToDecimal(maxRows));
            products = (from product in products select product)
                                             .Take(maxRows)
                                             .ToList();
            foreach (var item in products)
            {
                item.maxPage = (int)pageCount;
            }

            return View(products);
        }

        public IActionResult ToyQuery(QuerySearch qry)
        {
            // ajax -> post/get -> map fiel to qry -> exeute search

            var products = dataHelper.initProducts();
            // products.Where(e => e.Price > qry.priceFrom)
            //truy van theo dieu kien
            //order

            return View(products);
        }

        //task: chuyển cái này qua controller khác
        public IActionResult LoadToyBoxes(List<Product> aPList)
        {
            return PartialView("_OthersToy_Toy", aPList);
        }

        [HttpGet]
        public ActionResult SearchFilter(string jsonprd)
        {
            QuerySearch qry = JsonConvert.DeserializeObject<QuerySearch>(jsonprd);

            var products = dataHelper.initProducts();
            productsSearchedBrand = products;
            if (qry.CurrentPageIndex == null)
            {
                qry.CurrentPageIndex = 0;
            }
            try
            {
                if (qry.brand.Count != 0 || qry.kind.Count != 0)
                {
                    productsSearchedBrand = (from product in products
                                             where qry.brand.Contains(product.Brand)
                                             || qry.kind.Intersect(product.Kind).Any()
                                             select product)
                                             .Skip((int)((qry.CurrentPageIndex - 1) * maxRows))
                                             .Take(maxRows).ToList();
                    productsSearchedBrand = qry.orderType switch
                    {
                        "discountAsc" => productsSearchedBrand.OrderByDescending(x => x.Discount).ToList(),
                        "priceAsc" => productsSearchedBrand.OrderBy(x => x.Price).ToList(),
                        "priceDesc" => productsSearchedBrand.OrderByDescending(x => x.Price).ToList(),
                        _ => productsSearchedBrand.ToList(),
                    };
                }
                else
                {
                    productsSearchedBrand = (from product in products select product)
                                            .Skip((int)((qry.CurrentPageIndex - 1) * maxRows))
                                             .Take(maxRows).ToList();
                    productsSearchedBrand = qry.orderType switch
                    {
                        "discountAsc" => productsSearchedBrand.OrderByDescending(x => x.Discount).ToList(),
                        "priceAsc" => productsSearchedBrand.OrderBy(x => x.Price).ToList(),
                        "priceDesc" => productsSearchedBrand.OrderByDescending(x => x.Price).ToList(),
                        _ => productsSearchedBrand.ToList(),
                    };
                }
            }
            catch (ArgumentNullException)
            {
                return Json("Nothing");
            }
            string value = string.Empty;
            value = JsonConvert.SerializeObject(productsSearchedBrand, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }


        //private CustomerModel GetCustomers(int currentPage)
        //{
        //    int maxRows = 10;
        //    CustomerModel customerModel = new CustomerModel();

        //    customerModel.Customers = (from customer in this.Context.Customers
        //                               select customer)
        //                .OrderBy(customer => customer.CustomerID)
        //                .Skip((currentPage - 1) * maxRows)
        //                .Take(maxRows).ToList();

        //    double pageCount = (double)((decimal)this.Context.Customers.Count() / Convert.ToDecimal(maxRows));
        //    customerModel.PageCount = (int)Math.Ceiling(pageCount);

        //    customerModel.CurrentPageIndex = currentPage;

        //    return customerModel;
        //}
    }
}
