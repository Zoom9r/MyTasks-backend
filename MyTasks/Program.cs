using MyTasks.Core.Services.Interfaces.ListOfTasks;
using MyTasks.Core.Services.Interfaces.MyTask;
using MyTasks.Core.Services.Interfaces.StatusType;
using MyTasks.Core.Services.Realizations.ListOfTasks;
using MyTasks.Core.Services.Realizations.MyTask;
using MyTasks.Core.Services.Realizations.Status;
using MyTasksDataBase;
using MyTasksDataBase.Repositories.Interfaces.Base;
using MyTasksDataBase.Repositories.Realizations.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddDbContext<MyTasksDBContext>();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<IListOfTasksService, ListOfTasksService>();
builder.Services.AddTransient<IStatusService, StatusService>();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddCors(options =>
     {
         options.AddPolicy("Notespolicy",
             builder =>
             {

                 builder.WithOrigins("*")
                         .AllowAnyHeader()
                         .AllowAnyMethod();
             });
     }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("Notespolicy");

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tasks}");

app.Run();