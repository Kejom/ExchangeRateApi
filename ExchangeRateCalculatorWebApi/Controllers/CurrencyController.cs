using ExchangeRateCalculatorWebApi.CurrencyCalculator;
using ExchangeRateCalculatorWebApi.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExchangeRateCalculatorWebApi.Controllers
{
    public class CurrencyController : ApiController
    {

        private ICurrencyCalc _currencycalc;

        public CurrencyController(ICurrencyCalc currencycalc)
        {
            _currencycalc = currencycalc;
        }


        [LogApiRequest]
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAvailableCurrencies()
        {
            return Ok(_currencycalc.GetAvailableCurrencies());
        }


        [LogApiRequest]
        [Route("Calculate/{amount}/{cur1}/{cur2}")]
        [HttpGet]
        public IHttpActionResult GetCalculatedCurrency( int amount, string cur1, string cur2)
        {
            try
            {
                var response = _currencycalc.CalculateCurrency(amount, cur1, cur2);
                return Ok(response);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
        }


        [LogApiRequest]
        [Route("ExchangeRate/{cur1}/{cur2}")]
        [HttpGet]
        public IHttpActionResult GetExchangeRate( string cur1, string cur2)
        {
            try
            {
                var response = _currencycalc.CalculateCurrency(1, cur1, cur2);
                return Ok(response);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
