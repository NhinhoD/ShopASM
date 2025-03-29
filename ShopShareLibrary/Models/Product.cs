using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopShareLibrary.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống Tên sản phẩm")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống Mô tả")]
        public string Description { get; set; }
        [Required, Range(0.1, 99999.99)]
        public decimal Price { get; set; }
        [Required, DisplayName("Hình ảnh sản phẩm")]
        public string Base64Img { get; set; }
        public int Quantity { get; set; }
        public bool Featured { get; set; }
        public DateTime DateUpload { get; set; } = DateTime.Now;
    }
}
