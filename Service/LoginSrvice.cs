using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Pallet.Database;
using Pallet.Models;

namespace Pallet.Services
{
    public class LoginService
    {

        private readonly LogService _log;
        private readonly DatabaseContext _context;
        public LoginService(LogService logService, DatabaseContext context)
        {
            this._context = context;
            this._log = logService;
        }

        public async Task<Object> Authentication(HttpContext httpContext, string username, string password)
        {
            try
            {
                Object list = null;
                using (var conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"call pms.s_userinfo(@vctype, null, '', '', @vusername, @vpassword, null, '', '', '', null, '', null);";
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vctype", DbType = DbType.String, Value = "checkuser" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vusername", DbType = DbType.String, Value = username });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vpassword", DbType = DbType.String, Value = password });

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                list = new {
                                    refid = Convert.ToInt32(reader["refid"]),
                                    username = Convert.ToString(reader["username"]),
                                    firstname = Convert.ToString(reader["firstname"]),
                                    surname = Convert.ToString(reader["surname"]),
                                    language = Convert.ToString(reader["language"])
                                };
                            }
                        }

                    }
                }

                return list;
            }
            catch (Exception error)
            {
                _log.Error(httpContext, "Authentication", "Error", error.Message, error.StackTrace);
                return null;
            }
        }
    }
}