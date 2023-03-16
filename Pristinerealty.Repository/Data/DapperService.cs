using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Pristinerealty.Repository
{
    public class DapperService : IDapperService
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;

        public DapperService(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {

            // throw new NotImplementedException();

            int result;
            using (IDbConnection db = new SqlConnection(connectionString))
            {

                result = db.Query<int>(sp, parms, commandType: commandType).FirstOrDefault();
            }
            return result;

        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
            }
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<T>(sp, parms, commandType: commandType).ToList();
            }
        }




        public T Add<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                try
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();

                    using (var tran = db.BeginTransaction())
                    {
                        try
                        {
                            result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }

            return result;
        }

        public T Edit<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                try
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();

                    using (var tran = db.BeginTransaction())
                    {
                        try
                        {
                            result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }

            return result;
        }

        public DbConnection GetDbconnection()
        {
            return new SqlConnection(connectionString);
        }

        public void Dispose()
        {

        }
    }
}
