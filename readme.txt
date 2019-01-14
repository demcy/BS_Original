1. Domain - int nameId
2. DAL
2.1 public DbSet<Game> Games { get; set; }
2.2 public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
3.public void ConfigureServices(IServiceCollection services)
        {
3.1 mysql.data.entityframeworkcore + DAL
3.2 services.AddDbContext<AppDbContext>(options => 
                options.UseMySQL(
                    Configuration.GetConnectionString("DefaultConnection")));
3.3 "ConnectionStrings": {
    "DefaultConnection":
    "server=alpha.akaver.com;database=student2018_andreskaver_BattleShipDB;user=student2018;password=student2018",
    "DefaultConnectionLocalDb": "Server=(localdb)\\mssqllocaldb;Database=aspnet-WebApp-3CC37763-02DA-402C-B802-27B5DF641B5B;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
4.dotnet ef migrations add InitialDbCreation --project DAL --startup-project BattleShip_Web
5.dotnet ef database update  --project DAL --startup-project BattleShip_Web
6.

