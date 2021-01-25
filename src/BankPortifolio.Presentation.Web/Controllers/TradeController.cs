using BankPortifolio.Application.DTO;
using BankPortifolio.Application.Interfaces;
using BankPortifolio.Infra.CrossCutting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace BankPortifolio.Presentation.Web.Controllers
{
    public class TradeController : Controller 
    {
        readonly protected ITradeApp tradeApp;
        private readonly IConfiguration config;


        public TradeController(ITradeApp tradeApp, IConfiguration config)
        {
            this.tradeApp = tradeApp;
            this.config = config;
        }

        public IActionResult Index()
        {
            try
            {
                var trades = tradeApp.GetAll();
                return View(trades);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            InitializeViewBagTypeofClientSector();

            return View();
        }

        [HttpPost]
        public IActionResult Create(TradeDTO tradeDTO)
        {
            try
            {
                var useStoredProcedure = Convert.ToBoolean(config.GetSection("MySettings").GetSection("UseStoredProcedure").Value);

                tradeApp.Insert(tradeDTO, useStoredProcedure);

                InitializeViewBagTypeofClientSector();

                return Redirect("Index");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                tradeApp.Delete(id);

                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var trade = tradeApp.GetById(id);

                InitializeViewBagTypeofClientSector();

                return View(trade);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Edit(TradeDTO tradeDTO)
        {
            try
            {
                var useStoredProcedure = Convert.ToBoolean(config.GetSection("MySettings").GetSection("UseStoredProcedure").Value);

                tradeApp.Update(tradeDTO, useStoredProcedure);

                InitializeViewBagTypeofClientSector();

                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        void InitializeViewBagTypeofClientSector()
        {
            ViewBag.TypeOfClientSector = TypeOfClientSector.GetAllTypeOfClientSector();
        }
    }
}
