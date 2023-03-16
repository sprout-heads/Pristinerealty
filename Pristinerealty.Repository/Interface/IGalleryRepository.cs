using Pristinerealty.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pristinerealty.Repository.Interface
{
    public interface IGalleryRepository
    {
        Task<IEnumerable<Gallery>> GetAllGallery();
        Task<Gallery> GetById(int id);
        Task<int> Add(Gallery Gallery);
        Task<int> Delete(int id);
    }
}
