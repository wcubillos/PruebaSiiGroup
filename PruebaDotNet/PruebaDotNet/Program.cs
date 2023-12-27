using Microsoft.AspNetCore.Hosting;
using PruebaDotNet.Business.business;
using PruebaDotNet.Models.Interface;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;


namespace PruebaDotNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            builder.Services.AddAutoMapper(typeof(Program));


            builder.Services.AddTransient<Interoperability, GetInformation>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Listar}/{id?}");

            app.Run();
        }
    }
}