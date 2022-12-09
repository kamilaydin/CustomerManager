using CustomerAPI.Contexts;
using CustomerAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        HttpClient httpClient = new HttpClient();
        
        private readonly CustomerManageDbContext _context;

        public CustomersController(CustomerManageDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers/GetCustomers
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _context.Customers.Include(c => c.Addresses).Include(c => c.Phones).ToListAsync();

            foreach (Customer customer in customers)
            {
                if (IsUnusualName(customer.Name))
                    customer.UnUsualName = true;
            }

         

            return Ok(customers);
        }
        // GET: api/Customers/GetCustomerDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerDetails(int id)
        {
            var customer = _context.Customers
                .Where(customer => customer.Id == id)
                .FirstOrDefault();

            #region MVC Json POST İşlemi
            //Customer customer = new Customer();
            //customer.Name = "Yakup";
            //customer.Surname = "Yılmaz";
            //customer.Email = "abdurrahman@hotmail.com";
            //customer.Gender = 'm';
            //customer.SocialSecurityNumber = "147866556";
            //customer.Addresses = new List<Address>() {  new Address() { City = "Şanlıurfa", Country = "Türkiye", PostalCode = "06000", Street = "Test" } };
            //customer.Phones = new List<Phone>() { new Phone() { Number = "789456244", PhoneType = PhoneType.Business }, new Phone() { Number = "789456244", PhoneType = PhoneType.Home } };


            //string jsonString = JsonSerializer.Serialize<Customer>(customer);


            //StringContent content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
            //string url = "https://localhost:44340/api/Customers/PostCustomer";
            //HttpResponseMessage result = httpClient.PostAsync(url, content).Result; 
            #endregion

            return Ok(customer);
        }

        // GET: api/Customers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Customer>> GetCustomer(int id)
        //{

        //    var customers = _context.Customers
        //        .Include(customer => customer.Adresses)
        //        .Include(customer=> customer.Phones)
        //        .Where(customer => customer.CId == id)
        //        .FirstOrDefault();

        //    if (customers == null)
        //    {
        //        return NotFound();
        //    }

        //    return customers;
        //}

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutCustomer(Customer customer)
        {

            Customer updatedCustomer = await _context.Customers.FirstOrDefaultAsync(c=>c.Id == customer.Id);
            updatedCustomer.Name = customer.Name;
            updatedCustomer.Surname = customer.Surname;
            updatedCustomer.SocialSecurityNumber = customer.SocialSecurityNumber;
            updatedCustomer.Email = customer.Email;
            updatedCustomer.Gender = customer.Gender;
            updatedCustomer.Addresses = customer.Addresses;
            updatedCustomer.Phones = customer.Phones;
            _context.SaveChanges();
            return Ok(updatedCustomer);
        }

        [HttpPost]
        public IActionResult PostCustomer([FromBody] Customer customer)
        {

            #region Test
            //var customers = await _context.Customers
            //                                .Include(customer => customer.Addresses)
            //                                    .ThenInclude(Adress => Adress.City)
            //                                    .Include(customer => customer.Phones)

            //                                .Where(customer => customer.Id == customer.Id)
            //                                .FirstOrDefaultAsync();
            //Customer customer = new Customer();
            //customer.Name = "Abdurrahman";
            //customer.Surname = "Haliç";
            //customer.Email = "abdurrahman@hotmail.com";
            //customer.Gender = 'm';
            //customer.SocialSecurityNumber = "147866556";
            //customer.Addresses = new List<Address>() { new Address() { City = "Ankara", Country = "Türkiye", PostalCode = "06000", Street = "Kızılay" }, new Address() { City = "Adana", Country = "Türkiye", PostalCode = "06000", Street = "Abc" }, new Address() { City = "Eskişehir", Country = "Türkiye", PostalCode = "06000", Street = "Test" } };
            //customer.Phones = new List<Phone>() { new Phone() { Number = "05478963214", PhoneType = PhoneType.Mobile }, new Phone() { Number = "05478963214", PhoneType = PhoneType.Business }, new Phone() { Number = "05478963214", PhoneType = PhoneType.Home } };

            //var customers = await _context.Customers.Include(c => c.Addresses).Include(c => c.Phones).ToListAsync(); 
            #endregion

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        public bool IsUnusualName(string name)
        {
            // Count the number of occurrences of each vowel in the name
            int aCount = 0;
            int eCount = 0;
            int iCount = 0;
            int oCount = 0;
            int uCount = 0;

            string controlName = name.ToLower();

            for (int i = 0; i < controlName.Length; i++)
            {
                switch (controlName[i])
                {
                    case 'a':
                        aCount++;
                        break;
                    case 'e':
                        eCount++;
                        break;
                    case 'i':
                        iCount++;
                        break;
                    case 'o':
                        oCount++;
                        break;
                    case 'u':
                        uCount++;
                        break;
                }
            }

            // Return true if at least 3 of the same vowels are present
            return (aCount >= 3 || eCount >= 3 || iCount >= 3 || oCount >= 3 || uCount >= 3);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            Customer customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
