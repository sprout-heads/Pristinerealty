
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Pristinerealty.Entity;
using Pristinerealty.Repository;
using Pristinerealty.Repository.Interface;

namespace Pristinerealty.Repository
{
   public class GalleryRepository:IGalleryRepository
    {
        private readonly IDapperService _dapperService;
        public GalleryRepository(IDapperService dataService)
        {
            _dapperService = dataService;
        }

        public async Task<IEnumerable<Gallery>> GetAllGallery()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("InputType", "SELECT", DbType.String);
            var result = await Task.FromResult(_dapperService.GetAll<Gallery>("[dbo].[SP_SELECT_Gallery]", dbparams, commandType: CommandType.StoredProcedure));
            return result;

        }



        public async Task<Gallery> GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("InputType", "SELECT_BYID", DbType.String);
            dbparams.Add("GalleryId", id, DbType.Int32);
            var result = await Task.FromResult(_dapperService.Get<Gallery>("[dbo].[SP_SELECT_Gallery]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }




        public async Task<int> Add(Gallery Gallery)
        {

            var dbparams = new DynamicParameters();
            dbparams.Add("Name", Gallery.Name, DbType.String);
            dbparams.Add("Path", Gallery.Path, DbType.String);
            dbparams.Add("Title", Gallery.Title, DbType.String);
            dbparams.Add("NoOfViews", Gallery.NoOfViews, DbType.Int32);
            dbparams.Add("InputType", "INSERT", DbType.String);

            var result = await Task.FromResult(_dapperService.Add<int>("[dbo].[SP_IUD_Gallery]", dbparams, commandType: CommandType.StoredProcedure));
            return result;

        }


        public async Task<int> Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("GalleryId", id, DbType.Int32);
            dbparams.Add("InputType", "DELETE", DbType.String);
            var result = await Task.FromResult(_dapperService.Execute("[dbo].[SP_IUD_Gallery]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }




    }
}
