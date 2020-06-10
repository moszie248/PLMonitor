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
    public class UserinfoService
    {

        private readonly LogService _log;
        private readonly DatabaseContext _context;
        public UserinfoService(LogService logService, DatabaseContext context)
        {
            this._context = context;
            this._log = logService;
        }

        public async Task<List<Object>> ReadAll(HttpContext httpContext)
        {
            try
            {
                List<Object> list = new List<Object>();
                using (var conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"call pms.s_userinfo(@vtype, null, '', '', '', '', null, '', '', '', null, '', null);";
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vtype", DbType = DbType.String, Value = "listalluser" });

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                list.Add(new
                                {
                                    refid = Convert.ToString(reader["refid"]),
                                    // role = Convert.ToString(reader["role"]),
                                    fullname = Convert.ToString($"{reader["firstname"]} {reader["surname"]}"),
                                    // username = Convert.ToString(reader["username"]),
                                    // password = Convert.ToString(reader["password"]),
                                    // language = Convert.ToString(reader["language"]),
                                    // idcard = Convert.ToString(reader["idcard"]),
                                    // mobilenumber = Convert.ToString(reader["mobilenumber"]),
                                    note = Convert.ToString(reader["note"]),
                                    // createby = Convert.ToString(reader["createby"]),
                                    // createtime = Convert.ToString(reader["createtime"]),
                                    visible = Convert.ToString(reader["visible"])
                                });
                            }
                        }

                    }
                }

                return list;
            }
            catch (Exception error)
            {
                _log.Error(httpContext, "ReadAllUserinfo", "Error", error.Message, error.StackTrace);
                return null;
            }
        }

        public async Task<List<Object>> ReadRole(HttpContext httpContext)
        {
            try
            {
                List<Object> list = new List<Object>();
                using (var conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"call pms.s_userinfo(@vtype, null, '', '', '', '', null, '', '', '', null, '', null);";
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vtype", DbType = DbType.String, Value = "listrole" });

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                list.Add(new
                                {
                                    refid = Convert.ToString(reader["refid"]),
                                    name = Convert.ToString(reader["name"])
                                });
                            }
                        }

                    }
                }

                return list;
            }
            catch (Exception error)
            {
                _log.Error(httpContext, "ReadAllRole", "Error", error.Message, error.StackTrace);
                return null;
            }
        }

        public async Task<List<Object>> ReadByStatus(HttpContext httpContext, bool status)
        {
            try
            {
                List<Object> list = new List<Object>();
                using (var conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"call pms.s_userinfo(@vtype, null, '', '', '', '', null, '', '', '', @bvisible, '', null);";
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vtype", DbType = DbType.String, Value = "listvisibleuser" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@bvisible", DbType = DbType.Boolean, Value = status });

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                list.Add(new
                                {
                                    refid = Convert.ToString(reader["refid"]),
                                    name = Convert.ToString(reader["name"])
                                });
                            }
                        }

                    }
                }

                return list;
            }
            catch (Exception error)
            {
                _log.Error(httpContext, "ReadAllRole", "Error", error.Message, error.StackTrace);
                return null;
            }
        }

        public async Task<int> Add(HttpContext httpContext)
        {
            try
            {
                int result = 0;
                using (var conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"call pms.s_userinfo(@vtype, @irole, @vfirstname, @vsurname, @vusername, @vpassword, @ilanguage, @vidcard, @vmobilenumber, @vnote, @bvisible, @vsearch, @vrefid);";
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vtype", DbType = DbType.String, Value = "adduser" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@irole", DbType = DbType.Int32, Value = 2 });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vfirstname", DbType = DbType.String, Value = "fn" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vsurname", DbType = DbType.String, Value = "ln" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vusername", DbType = DbType.String, Value = "Admin" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vpassword", DbType = DbType.String, Value = "p@ssw0rd" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@ilanguage", DbType = DbType.Int32, Value = 1 });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vidcard", DbType = DbType.String, Value = "1234567890123" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vmobilenumber", DbType = DbType.String, Value = "0898765432" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vnote", DbType = DbType.String, Value = "-" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@bvisible", DbType = DbType.Boolean, Value = true });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vsearch", DbType = DbType.String, Value = "" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vrefid", DbType = DbType.Int32, Value = null });

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                //result, Description
                                result = Convert.ToInt32(reader["result"]) > 0 ? 1 : 0;
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception error)
            {
                _log.Error(httpContext, "Add", "Error", error.Message, error.StackTrace);
                return 0;
            }
        }

        public async Task<int> Edit(HttpContext httpContext)
        {
            try
            {
                int result = 0;
                using (var conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"call pms.s_userinfo(@vtype, @irole, @vfirstname, @vsurname, @vusername, @vpassword, @ilanguage, @vidcard, @vmobilenumber, @vnote, @bvisible, @vsearch, @vrefid);";
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vtype", DbType = DbType.String, Value = "edituser" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@irole", DbType = DbType.Int32, Value = 2 });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vfirstname", DbType = DbType.String, Value = "fn" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vsurname", DbType = DbType.String, Value = "ln" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vusername", DbType = DbType.String, Value = "Admin" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vpassword", DbType = DbType.String, Value = "p@ssw0rd" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@ilanguage", DbType = DbType.Int32, Value = 1 });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vidcard", DbType = DbType.String, Value = "1234567890123" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vmobilenumber", DbType = DbType.String, Value = "0898765432" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vnote", DbType = DbType.String, Value = "-" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@bvisible", DbType = DbType.Boolean, Value = true });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vsearch", DbType = DbType.String, Value = "" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vrefid", DbType = DbType.Int32, Value = 5 }); //userID

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                //result, Description
                                result = Convert.ToInt32(reader["result"]) > 0 ? 1 : 0;
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception error)
            {
                _log.Error(httpContext, "Edit", "Error", error.Message, error.StackTrace);
                return 0;
            }
        }

        public async Task<int> Delete(HttpContext httpContext, int userid)
        {
            try
            {
                int result = 0;
                using (var conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        
                        cmd.CommandText = @"call pms.s_userinfo('deleteuser', null, '', '', '', '', null, '', '', '', null, '', @vrefid);";
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vtype", DbType = DbType.String, Value = "deleteuser" });
                        cmd.Parameters.Add(new MySqlParameter { ParameterName = "@vrefid", DbType = DbType.Int32, Value = userid }); //userID

                        result = await cmd.ExecuteNonQueryAsync();
                    }
                }
                return result;
            }
            catch (Exception error)
            {
                _log.Error(httpContext, "Delete", "Error", error.Message, error.StackTrace);
                return 0;
            }
        }
    }
}