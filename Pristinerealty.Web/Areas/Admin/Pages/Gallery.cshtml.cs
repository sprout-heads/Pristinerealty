using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pristinerealty.Entity;
using Pristinerealty.Repository;
using Pristinerealty.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Pristinerealty.Web.Areas.Admin.Pages
{
    [Authorize]
    public class GalleryModel : PageModel
    {
        public List<Gallery> photoGraphyList { get; set; }
        public IEnumerable<Gallery> gallery { get; set; }
        public Pristinerealty.Entity.Gallery Objgallery { get; set; }

        public string Title { get; set; }

        public string pathFile { get; set; }

        private readonly IGalleryRepository galleryRepository;
        private IWebHostEnvironment hostingEnv;
        public GalleryModel(IGalleryRepository galleryRepository, IWebHostEnvironment env)
        {
            this.galleryRepository = galleryRepository;
            this.hostingEnv = env;
        }

        public async Task OnGetAsync(int id)
        {
            gallery = await galleryRepository.GetAllGallery();



            if (id > 0)
            {
              
                Objgallery = await galleryRepository.GetById(id);
                pathFile = Objgallery.Name;

                if (pathFile != null)
                {
                    string OldPath = Path.Combine(hostingEnv.WebRootPath, "Gallery", pathFile);
                    System.IO.File.Delete(OldPath);
                    var count = galleryRepository.Delete(id);
                }

                Response.Redirect("/Admin/Gallery");
            }
        }


       



        public void OnPost(List<IFormFile> files)
        {
            string txtTitle = Request.Form["Title"];

            Gallery gallery = new Gallery
            { 
                Title = this.Title


            };

            if (files != null)
            {
                foreach (var item in files)
                {
                    if (item.Length > 0)
                    {

                        var FileDic = "Gallery";

                        string FilePath = Path.Combine(hostingEnv.WebRootPath, FileDic);

                        if (!Directory.Exists(FilePath))

                            Directory.CreateDirectory(FilePath);

                        var fileName = item.FileName;

                        var filePath = Path.Combine(FilePath, fileName);

                        string ImagePath = "~/Gallery/" + item.FileName;

                        using (FileStream fs = System.IO.File.Create(filePath))
                        {
                            item.CopyTo(fs);
                            gallery.Name = fileName;
                            gallery.Path = ImagePath;
                            gallery.Title = txtTitle;
                          

                            var articleId = galleryRepository.Add(gallery);
                        }


                    }
                }
                Response.Redirect("/Admin/Gallery");
            }
        }
    }
}
