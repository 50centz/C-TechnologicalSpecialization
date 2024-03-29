﻿using HomeWork1.DB;
using HomeWork1.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductStorageController : ControllerBase
    {
        private ProductContext _context;

        public ProductStorageController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet(template: "GetProductInStorage")]
        public IActionResult GetProductInStorage(string StorageName)
        {
            try
            {
                using (_context)
                {
                    var storage = _context.Storages.FirstOrDefault(e => e.Name.Equals(StorageName));
                    int sstorageId = storage.Id;
                    

                    return Ok(_context.ProductStorages.FirstOrDefault(e => e.StorageId == sstorageId));

                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
