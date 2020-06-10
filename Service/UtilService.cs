using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pallet.Database;
using Pallet.Models;

namespace Pallet.Services
{
    public class UtilService
    {
        private readonly IWebHostEnvironment _env;
        private const string folderName = "/files/";

        public UtilService(IWebHostEnvironment env)
        {
            this._env = env;
        }

        private string GetPath()
        {
            return _env.WebRootPath + folderName;
        }

        public async Task<List<string>> ImportFiles(IFormFileCollection uploaded_files)
        {

            try
            {
                List<string> data = new List<string>();
                string path_for_Uploaded_Files = GetPath();

                if (!Directory.Exists(path_for_Uploaded_Files))
                {
                    Directory.CreateDirectory(GetPath());
                }
                
                foreach (var uploaded_file in uploaded_files)
                {
                  
                    string uploaded_Filename = $"{Guid.NewGuid().ToString()}{System.IO.Path.GetExtension(uploaded_file.FileName)}";
                    string new_Filename_on_Server = $"{path_for_Uploaded_Files}\\{uploaded_Filename}";
                   
                    using (FileStream stream = new FileStream(new_Filename_on_Server, FileMode.Create))
                    {
                        await uploaded_file.CopyToAsync(stream);
                    }

                    data.Add(path_for_Uploaded_Files);
                    data.Add(uploaded_Filename);
                }

               return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void ImportText(string path, string name, string text)
        {
            try
            {
                string filePath = $"{path}{name}.txt";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (!File.Exists(filePath)){
                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        sw.WriteLine(text);
                        sw.Close();
                    }
                }else{
                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                        sw.WriteLine(text);
                        sw.Close();
                    }
                }
            }
            catch (Exception) { }
        }

    }
}