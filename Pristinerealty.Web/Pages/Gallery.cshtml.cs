using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pristinerealty.Entity;
using Pristinerealty.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pristinerealty.Web.Pages
{
    public class GalleryModel : PageModel
    {
        public List<Gallery> photoGalleryList { get; set; }
        public IEnumerable<Gallery> gallery { get; set; }
        private readonly IGalleryRepository galleryRepository;

        public GalleryModel(IGalleryRepository galleryRepository)
        {
            this.galleryRepository = galleryRepository;
        }
        public async Task OnGetAsync()
        {
            gallery = await galleryRepository.GetAllGallery();

        }
    }
}
