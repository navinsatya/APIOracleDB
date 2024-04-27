using APIOracleDB.Models;
using APIOracleDB.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIOracleDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayItemController : Controller
    {
        private readonly IDataAccess _dataAccess;

        public PayItemController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PayItem>> GetEmployees()
        {
            var employees = _dataAccess.GetItemsFromStoredProcedure();
            return Ok(employees);
        }

    }
}
