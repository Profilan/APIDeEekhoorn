﻿using APIDeEekhoorn.Logic.Repositories;
using APIDeEekhoorn.Logic.Services;
using APIDeEekhoorn.Logic.SharedKernel;
using APIDeEekhoorn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace APIDeEekhoorn.Controllers
{
    public class DashboardController : EekApiController
    {
        private readonly DashboardRepository _dashboardRepository;
        private readonly UserRepository _userRepository;
        private SystemLogger logger;

        public DashboardController()
        {
            _dashboardRepository = new DashboardRepository();
            _userRepository = new UserRepository();
            logger = new SystemLogger();
        }

        /**
         * @api {get} /api/dashboard Request Dashboard information
         * @apiVersion 1.0.0
         * @apiName GetDashboard
         * @apiGroup Dashboard
         * 
         *
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam {String} debcode Debtor Code
         * @apiParam {String} apikey Unique key for the user
         * 
         * @apiParamExample Request-Example:
         *      /api/dashboard?debcode=000504&apikey=fftt2sQjjaiSXnX2Qnvr3XnahdDB3ZRDLTnRtpJr
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      {
         *          "Quantity": {
         *              "Year": {
         *                  "Items": [
         *                      {
         *                          "EAN": "8714713056163",
         *                          "Amount": 993
         *                      },
         *                      {
         *                          "EAN": "8714713057887",
         *                          "Amount": 875
         *                      },
         *                      ...
         *                  ],
         *              "Quarter":
         *                  "Items": [
         *                      {
         *                          "EAN": "8714713056163",
         *                          "Amount": 993
         *                      },
         *                      {
         *                          "EAN": "8714713057887",
         *                          "Amount": 875
         *                      },
         *                      ...
         *                  ],
         *              "Month":
         *                  "Items": [
         *                      {
         *                          "EAN": "8714713056163",
         *                          "Amount": 993
         *                      },
         *                      {
         *                          "EAN": "8714713057887",
         *                          "Amount": 875
         *                      },
         *                      ...
         *                  ]
         *          },
         *          "Sales": {
         *              "Year": {
         *                  "Items": [
         *                      {
         *                          "EAN": "8714713056163",
         *                          "Amount": 993
         *                      },
         *                      {
         *                          "EAN": "8714713057887",
         *                          "Amount": 875
         *                      },
         *                      ...
         *                  ],
         *              "Quarter":
         *                  "Items": [
         *                      {
         *                          "EAN": "8714713056163",
         *                          "Amount": 993
         *                      },
         *                      {
         *                          "EAN": "8714713057887",
         *                          "Amount": 875
         *                      },
         *                      ...
         *                  ],
         *              "Month":
         *                  "Items": [
         *                      {
         *                          "EAN": "8714713056163",
         *                          "Amount": 993
         *                      },
         *                      {
         *                          "EAN": "8714713057887",
         *                          "Amount": 875
         *                      },
         *                      ...
         *                  ]
         *              }
         *          }
         *      }
         * 
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * @apiError (Error 4xx) {404} NotFound There are no records for this debtor.
         * 
         */
        [Route("api/dashboard")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetDashboard(string debcode, string apikey)
        {
            try
            {
                if (debcode == null)
                {
                    return BadRequest("Parameter debcode is required");
                }

                if (apikey == null)
                {
                    return BadRequest("Parameter apikey is required");
                }

                var username = HttpContext.Current.User.Identity.Name;
                var user = _userRepository.GetByUsername(username);

                if (user.ApiKey != apikey)
                {
                    return BadRequest("The apikey does not match with the logged in user");
                }

                var salesMonth = _dashboardRepository.SalesPerMonthListByDebcode(debcode);
                var salesQuarter = _dashboardRepository.SalesPerQuarterListByDebcode(debcode);
                var salesYear = _dashboardRepository.SalesPerYearListByDebcode(debcode);
                var quantityMonth = _dashboardRepository.QuantityPerMonthListByDebcode(debcode);
                var quantityQuarter = _dashboardRepository.QuantityPerQuarterListByDebcode(debcode);
                var quantityYear = _dashboardRepository.QuantityPerYearListByDebcode(debcode);

                if (salesMonth.Count() == 0 || salesQuarter.Count() == 0 || salesYear.Count() == 0
                    || quantityMonth.Count() == 0 || quantityQuarter.Count() == 0 || quantityYear.Count() == 0)
                {
                    return NotFound();
                }

                var dashboardModel = new Dashboard();

                foreach (var quantity in quantityMonth)
                {
                    dashboardModel.Quantity.Month.Items.Add(new Item()
                    {
                        EAN = quantity.EAN,
                        Amount = quantity.Quantity
                    });
                }

                foreach (var quantity in quantityQuarter)
                {
                    dashboardModel.Quantity.Quarter.Items.Add(new Item()
                    {
                        EAN = quantity.EAN,
                        Amount = quantity.Quantity
                    });
                }

                foreach (var quantity in quantityYear)
                {
                    dashboardModel.Quantity.Year.Items.Add(new Item()
                    {
                        EAN = quantity.EAN,
                        Amount = quantity.Quantity
                    });
                }

                foreach (var amount in salesMonth)
                {
                    dashboardModel.Sales.Month.Items.Add(new Item()
                    {
                        EAN = amount.EAN,
                        Amount = amount.Quantity
                    });
                }

                foreach (var amount in salesQuarter)
                {
                    dashboardModel.Sales.Quarter.Items.Add(new Item()
                    {
                        EAN = amount.EAN,
                        Amount = amount.Quantity
                    });
                }

                foreach (var amount in salesYear)
                {
                    dashboardModel.Sales.Year.Items.Add(new Item()
                    {
                        EAN = amount.EAN,
                        Amount = amount.Quantity
                    });
                }

                logger.Log(ErrorType.INFO, "GetDashboard()", RequestContext.Principal.Identity.Name, "", "api/dashboard", startDate);

                return Ok(dashboardModel);

            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetDashboard()", RequestContext.Principal.Identity.Name, e.Message, "api/dashboard");

                return InternalServerError(e);
            }
        }
    }
}
