using Pristinerealty.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pristinerealty.Repository
{
   public interface IResumeRepository
    { 


        Task<IEnumerable<Resumes>> FileUpload(Resumes file);
        Task<IEnumerable<Resumes>> GetAllResumes();
        Task<Resumes> GetById(int id);
        Task<int> Add(Resumes cv);
        Task<int> Edit(Resumes cv);
        Task<int> Delete(int id);
    }
}
