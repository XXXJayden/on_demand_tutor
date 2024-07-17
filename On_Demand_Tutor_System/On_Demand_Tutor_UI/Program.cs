using BusinessObjects.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using On_Demand_Tutor_UI;
using Repositories.AccountRepository;
using Repositories.FeedBackRepositories;
using Repositories.ServiceRepository;
using Repositories.StudentRepositories;
using Services.AccountService;
using Services.AchievementServices;
using Services.BookingScheduleService;
using Services.BookingService;
using Services.EmailService;
using Services.FeedBackServices;
using Services.ModService;
using Services.ReportServices;
using Services.ScheduleService;
using Services.Sercurity;
using Services.ServiceServices;
using Services.StudentServices;
using Services.Tutors;
using Services.TutorServices;
using On_Demand_Tutor_UI;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<AccountDAO>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<PasswordHasher>();
builder.Services.AddScoped<BookingDAO>();
builder.Services.AddScoped<ITutorAccountService, TutorAccountService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<StudentDAO>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceServices, ServiceService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IModService, ModService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IBookingScheduleService, BookingScheduleService>();
builder.Services.AddScoped<FireBaseStorage, FireBaseStorage>();
builder.Services.AddScoped<IAchievementService, AchievementService>();
builder.Services.AddScoped<IServices, Services.Tutors.Services>();
builder.Services.AddScoped<ITutorService, Services.Tutors.TutorServices>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IFeedBackRepository, FeedBackRepository>();
builder.Services.AddScoped<IFeedBackService, FeedBackService>();
builder.Services.AddSignalR();


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();


builder.Services.AddDbContext<OnDemandTutorDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBDefault"));
});

builder.Services.AddScoped<IBookingService, BookingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapHub<SignalR>("/chatHub");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
