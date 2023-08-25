using Infrastructure.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Imaging;

namespace TOYOTA.Model.Entities
{
    public class Employee : IEntity
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public byte[]? Photo { get; set; }
        public string PhotoPath { get; set; }
        public short? AnnualLeave { get; set; }
        public int? Salary { get; set; }
        public bool? IsActive { get; set; }

        //[NotMapped]
        //public string Base64Photo
        //{
        //    get
        //    {
        //        if (Photo != null)
        //        {
        //            var base64Str = string.Empty;

        //            using (var ms = new MemoryStream())
        //            {
        //                int offSet = EmployeeId<=8 ? 78 : 0;
        //                ms.Write(Photo, offSet, Photo.Length - offSet);
        //                var bmp = new Bitmap(ms);

        //                using (var ms1 = new MemoryStream())
        //                {
        //                    bmp.Save(ms1, ImageFormat.Jpeg);
        //                    base64Str = Convert.ToBase64String(ms1.ToArray());
        //                }

        //                return base64Str;
        //            }
        //        }

        //        return string.Empty;
        //    }
        //}

        public List<Order>? Order { get; set; }
    }
}
