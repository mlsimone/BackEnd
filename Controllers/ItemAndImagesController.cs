using System.IO;
using BackEndPoints.Data;
using BackEndPoints.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using NuGet.Configuration;

namespace BackEndPoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemAndImagesController : ControllerBase
    {

        private readonly DatabaseContextClass _context;

        public ItemAndImagesController(DatabaseContextClass context)                                 
        {
            _context = context;
        }

        // GET: api/Items1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            if (_context.Items == null)
            {
                return NotFound();
            }
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }


        // POST api/<DataAndImageHandler>
        [HttpPost]
        public async Task<ActionResult<Item>> PostItemAndImages([FromForm] ItemAndImages item)
        {

            if (!ModelState.IsValid)
            { 
            }
            // MLS 6/18-19/23 Having a problem with ModelBinding when using complex types Item and ItemAndImages
            // Item item3 = item.item;
            Item anItem = ItemAndImages.getItem(item);
            if (_context.Items == null)
            {
                return Problem("Entity set 'DatabaseContextClass.Items'  is null.");
            }
            _context.Items.Add(anItem);
            await _context.SaveChangesAsync();

            List<IFormFile> images = item.images;
            SaveImages(images, item?.imageDirectory, anItem.id);

            return CreatedAtAction("GetItem", new { id = anItem.id }, anItem);
            // got a 500 with this...no route matches?...return CreatedAtAction("GetItem", new { id = anItem.id });
        }

        
        public async void SaveImages(List<IFormFile> images, string? imageDirectory, int foreignKeyToItemTable)
        {
            string savePath = "c:\\temp\\uploads\\";
            long size = images.Sum(f => f.Length);

            foreach (var file in images)
            {
                IFormFile formFile = file;
                if (formFile.Length > 0)
                {
                    // MLS 6/20/23 Removed weird fileName characters in Front End
                    // there's a weird IMG_155.JPG:046398: tacked on to the end of the filename
                    // this logic strips off the stuff after the :
                    // int len = formFile.FileName.IndexOf(":");
                    // string fileName = formFile.FileName.Substring(0,len);
                    string fileName = formFile.FileName;
                    string directory = Path.Combine(savePath, imageDirectory);

                    if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
                    var filePath = Path.Combine(savePath, directory, fileName);    // Path.GetTempFileName();

                    // MLS 6/20/23 ToDo: save IMAGENames to Images table (Will need to create IMAGES table)

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                        
                    }
                }
            }
        }
 
    }
}
