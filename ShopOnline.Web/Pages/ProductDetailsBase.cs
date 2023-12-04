using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;
using System.Xml.Linq;

namespace ShopOnline.Web.Pages
{
    public class ProductDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        //public int Id = 1;

        [Inject]
        public IProductService ProductService { get; set; }

        public ProductDto Product { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //Product = new ProductDto()
                //{
                //    Id = 0,
                //    Name = "No Data",
                //    Description = "No Description Data",
                //    ImageURL = "",
                //    Price = 3242,
                //    Qty = 0,
                //    CategoryId = 0,
                //    CategoryName = "No Category"
                //};

                Product = await ProductService.GetItem(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
