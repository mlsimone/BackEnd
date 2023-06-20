using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace BackEndPoints.Models
{
    [BindProperties]
    public class ItemAndImages
    {
        // This complex type is NOT working
        // [ModelBinder(BinderType = typeof(FormDataJsonBinder))]
        //[BindProperty]
        // public Item item { get; set; }
        public int id { get; set; }
        public string name { get; set; }

        public string category { get; set; }  // home or fashion for now.
        public string description { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public double? estimatedValue { get; set; }

        public string? imageDirectory { get; set; }  // this is a directory which contains pictures of images

        //// below we use the name of the photo
        //// public IEnumerable<String>? ImageNames { get; set; }
        public String? imageName { get; set; }

        public List<IFormFile> images { get; set; }

        public static Item getItem(ItemAndImages item)
        {
            Item itemData = new Item();
            if (item != null)
            {
                itemData.id = item.id;
                itemData.name = item.name;
                itemData.category = item.category;
                itemData.description = item.description;
                itemData.estimatedValue = item.estimatedValue;
                itemData.imageDirectory = item.imageDirectory;
                itemData.imageName = item.imageName;
            }
            return itemData;

        }
    }



}