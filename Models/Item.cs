using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace BackEndPoints.Models
{
    public class Item
    {
        // A complex type must have a public default constructor and public writable properties to bind.
        // When model binding occurs, the class is instantiated using the public default constructor.
        public Item()
        {
            id = 0;
            name = "";
            category = "";
            description = "";
            estimatedValue = 0;
            imageDirectory = "";
            imageName = "";
        }
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

        /*
        public void SavePhoto(string ImageName, string ImageDirectory)
        {
            string path = ImageDirectory + '/' + ImageName;
            File.Create(path);
        }
        */



    }
}
