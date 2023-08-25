using Microsoft.Extensions.DependencyInjection;
using TOYOTA.Busines.Implementations;
using TOYOTA.Busines.Interfaces;
using TOYOTA.DataAccess.Implementations.EF.Repositories;
using TOYOTA.DataAccess.Interfaces;

namespace TOYOTA.Busines.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(VehicleBs));
            services.AddAutoMapper(typeof(CategoryBs));
            services.AddAutoMapper(typeof(CustomerBs));
            services.AddAutoMapper(typeof(EmployeeBs));
            services.AddAutoMapper(typeof(OrderBs));
            services.AddAutoMapper(typeof(SparePartBs));
            services.AddAutoMapper(typeof(SupplierBs));
            services.AddAutoMapper(typeof(AdminPanelUserBs));

            services.AddScoped<IVehicleBs, VehicleBs>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<ICategoryBs, CategoryBs>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerBs, CustomerBs>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeBs, EmployeeBs>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IOrderBs, OrderBs>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ISupplierBs, SupplierBs>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ISparePartBs, SparePartBs>();
            services.AddScoped<ISparePartRepository, SparePartRepository>();
            services.AddScoped<IAdminPanelUserBs, AdminPanelUserBs>();
            services.AddScoped<IAdminPanelUserRepository, AdminPanelUserRepository>();
        }
    }
}
