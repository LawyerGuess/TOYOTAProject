using TOYOTA.WebAPI.Extensions;
using TOYOTA.Busines.Extensions;
using TOYOTA.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAPIServices(builder.Configuration);
builder.Services.AddBusinessServices();

#region MyRegion
//builder.Services.AddAutoMapper(typeof(VehicleBs));
//builder.Services.AddAutoMapper(typeof(CategoryBs));
//builder.Services.AddAutoMapper(typeof(CustomerBs));
//builder.Services.AddAutoMapper(typeof(EmployeeBs));
//builder.Services.AddAutoMapper(typeof(OrderBs));
//builder.Services.AddAutoMapper(typeof(SparePartBs));
//builder.Services.AddAutoMapper(typeof(SupplierBs));

//builder.Services.AddControllers()
//    .AddJsonOptions(opt =>
//    opt.JsonSerializerOptions.ReferenceHandler = 
//    ReferenceHandler.IgnoreCycles);


//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddAutoMapper(typeof(VehicleBs));
//builder.Services.AddAutoMapper(typeof(CategoryBs));
//builder.Services.AddAutoMapper(typeof(CustomerBs));
//builder.Services.AddAutoMapper(typeof(EmployeeBs));
//builder.Services.AddAutoMapper(typeof(OrderBs));
//builder.Services.AddAutoMapper(typeof(SparePartBs));
//builder.Services.AddAutoMapper(typeof(SupplierBs));


//IoC Registration
//builder.Services.AddScoped<IVehicleBs, VehicleBs>();
//builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
//builder.Services.AddScoped<ICategoryBs, CategoryBs>();
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<ICustomerBs, CustomerBs>();
//builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
//builder.Services.AddScoped<IEmployeeBs, EmployeeBs>();
//builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
//builder.Services.AddScoped<IOrderBs, OrderBs>();
//builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//builder.Services.AddScoped<ISupplierBs, SupplierBs>();
//builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
//builder.Services.AddScoped<ISparePartBs, SparePartBs>();
//builder.Services.AddScoped<ISparePartRepository, SparePartRepository>(); 
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
    app.UseCustomException();
app.Run();
