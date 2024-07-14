using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ResfulAPI.Models
{
    public partial class database_SWP391_Auto99_version31Context : DbContext
    {
        public database_SWP391_Auto99_version31Context()
        {
        }

        public database_SWP391_Auto99_version31Context(DbContextOptions<database_SWP391_Auto99_version31Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AutoPart> AutoParts { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<BlogCategory> BlogCategories { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<CarAutoPart> CarAutoParts { get; set; } = null!;
        public virtual DbSet<CarBrand> CarBrands { get; set; } = null!;
        public virtual DbSet<CarDesign> CarDesigns { get; set; } = null!;
        public virtual DbSet<CarImg> CarImgs { get; set; } = null!;
        public virtual DbSet<CarOrder> CarOrders { get; set; } = null!;
        public virtual DbSet<CarSubImg> CarSubImgs { get; set; } = null!;
        public virtual DbSet<CarSubImgtype> CarSubImgtypes { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientAccount> ClientAccounts { get; set; } = null!;
        public virtual DbSet<ClientNumberPlate> ClientNumberPlates { get; set; } = null!;
        public virtual DbSet<ClientService> ClientServices { get; set; } = null!;
        public virtual DbSet<EmployeeProfile> EmployeeProfiles { get; set; } = null!;
        public virtual DbSet<EngineAndChassi> EngineAndChasses { get; set; } = null!;
        public virtual DbSet<Feature> Features { get; set; } = null!;
        public virtual DbSet<GeneralInfoCar> GeneralInfoCars { get; set; } = null!;
        public virtual DbSet<HistoryServiceInvoice> HistoryServiceInvoices { get; set; } = null!;
        public virtual DbSet<InFoInvoiceDetail> InFoInvoiceDetails { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<ObjectVoucher> ObjectVouchers { get; set; } = null!;
        public virtual DbSet<PolicyFee> PolicyFees { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoleFeature> RoleFeatures { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<StatusCategory> StatusCategories { get; set; } = null!;
        public virtual DbSet<TestDriveService> TestDriveServices { get; set; } = null!;
        public virtual DbSet<Voucher> Vouchers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("ConnectionName"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccId)
                    .HasName("PK__Account__A471AFFA2EA1F76D");

                entity.ToTable("Account");

                entity.Property(e => e.AccId).HasColumnName("accID");

                entity.Property(e => e.AccName)
                    .HasMaxLength(50)
                    .HasColumnName("accName");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(90)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Account__roleID__6B24EA82");
            });

            modelBuilder.Entity<AutoPart>(entity =>
            {
                entity.ToTable("AutoPart");

                entity.Property(e => e.AutoPartId).HasColumnName("autoPartID");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("createdOn");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modifiedOn");

                entity.Property(e => e.PartImg)
                    .HasMaxLength(100)
                    .HasColumnName("partIMG");

                entity.Property(e => e.PartName)
                    .HasMaxLength(200)
                    .HasColumnName("partName");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AutoPartCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_AutoPart_Account");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.AutoPartModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_AutoPart_Account1");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.BlogId).HasColumnName("blogID");

                entity.Property(e => e.BlogCategoryId).HasColumnName("blogCategoryID");

                entity.Property(e => e.BlogImg)
                    .HasMaxLength(255)
                    .HasColumnName("blogIMG");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("createdOn");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modifiedOn");

                entity.Property(e => e.ParentId).HasColumnName("parentID");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .HasColumnName("title");

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .HasColumnName("url");

                entity.HasOne(d => d.BlogCategory)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.BlogCategoryId)
                    .HasConstraintName("FK_Blog_BlogCategory");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.BlogCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Blog_Account2");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.BlogModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Blog_Account1");
            });

            modelBuilder.Entity<BlogCategory>(entity =>
            {
                entity.ToTable("BlogCategory");

                entity.Property(e => e.BlogCategoryId).HasColumnName("blogCategoryID");

                entity.Property(e => e.BlogCategory1)
                    .HasMaxLength(255)
                    .HasColumnName("blogCategory");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.CarId).HasColumnName("carID");

                entity.Property(e => e.BrandId).HasColumnName("brandID");

                entity.Property(e => e.CarName)
                    .HasMaxLength(50)
                    .HasColumnName("carName");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("createdOn");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("date")
                    .HasColumnName("modifiedOn");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.StatusId).HasColumnName("statusID");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Car__brandID__70DDC3D8");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CarCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Car_Account");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.CarModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Car_Account1");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Car_StatusCategory");
            });

            modelBuilder.Entity<CarAutoPart>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CarAutoPart");

                entity.Property(e => e.AutoPartId).HasColumnName("autoPartID");

                entity.Property(e => e.CarId).HasColumnName("carID");

                entity.HasOne(d => d.AutoPart)
                    .WithMany()
                    .HasForeignKey(d => d.AutoPartId)
                    .HasConstraintName("FK_CarAutoPart_AutoPart");

                entity.HasOne(d => d.Car)
                    .WithMany()
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK_CarAutoPart_Car");
            });

            modelBuilder.Entity<CarBrand>(entity =>
            {
                entity.HasKey(e => e.BrandId)
                    .HasName("PK__CarBrand__06B772B9F129B822");

                entity.ToTable("CarBrand");

                entity.Property(e => e.BrandId).HasColumnName("brandID");

                entity.Property(e => e.BrandImg)
                    .HasMaxLength(100)
                    .HasColumnName("brandIMG");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(90)
                    .HasColumnName("brandName");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("createdOn");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("date")
                    .HasColumnName("modifiedOn");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CarBrandCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_CarBrand_Account");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.CarBrandModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_CarBrand_Account1");
            });

            modelBuilder.Entity<CarDesign>(entity =>
            {
                entity.HasKey(e => e.DesignId)
                    .HasName("PK__CarDesig__62A1565DBE504A37");

                entity.ToTable("CarDesign");

                entity.Property(e => e.DesignId).HasColumnName("designID");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("createdOn");

                entity.Property(e => e.Design)
                    .HasMaxLength(40)
                    .HasColumnName("design");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("date")
                    .HasColumnName("modifiedOn");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CarDesignCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_CarDesign_Account");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.CarDesignModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_CarDesign_Account1");
            });

            modelBuilder.Entity<CarImg>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CarIMG");

                entity.Property(e => e.CarId).HasColumnName("carID");

                entity.Property(e => e.CarImg1)
                    .HasMaxLength(100)
                    .HasColumnName("carIMG");

                entity.HasOne(d => d.Car)
                    .WithMany()
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__CarIMG__carID__7A672E12");
            });

            modelBuilder.Entity<CarOrder>(entity =>
            {
                entity.ToTable("CarOrder");

                entity.Property(e => e.CarorderId).HasColumnName("carorderID");

                entity.Property(e => e.CarId).HasColumnName("carID");

                entity.Property(e => e.CarorderCode)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("carorderCode");

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("createdOn");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modifiedOn");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("orderDate");

                entity.Property(e => e.OrderValue).HasColumnName("orderValue");

                entity.Property(e => e.Paid).HasColumnName("paid");

                entity.Property(e => e.PaymentRequired).HasColumnName("paymentRequired");

                entity.Property(e => e.PaymentType).HasColumnName("paymentType");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status");

                entity.Property(e => e.VoucherId).HasColumnName("voucherID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.CarOrders)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__CarOrder__carID__7B5B524B");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.CarOrders)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__CarOrder__client__7C4F7684");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.CarOrders)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_CarOrder_Account1");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.CarOrders)
                    .HasForeignKey(d => d.VoucherId)
                    .HasConstraintName("FK_CarOrder_Voucher");
            });

            modelBuilder.Entity<CarSubImg>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CarSubIMG");

                entity.Property(e => e.CarId).HasColumnName("carID");

                entity.Property(e => e.CarSubImg1)
                    .HasMaxLength(100)
                    .HasColumnName("carSubIMG");

                entity.Property(e => e.CarSubImgtypeId).HasColumnName("carSubIMGTypeID");

                entity.HasOne(d => d.Car)
                    .WithMany()
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK_CarSubIMG_Car");

                entity.HasOne(d => d.CarSubImgtype)
                    .WithMany()
                    .HasForeignKey(d => d.CarSubImgtypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarSubIMG_CarSubIMGType1");
            });

            modelBuilder.Entity<CarSubImgtype>(entity =>
            {
                entity.ToTable("CarSubIMGType");

                entity.Property(e => e.CarSubImgtypeId).HasColumnName("carSubIMGTypeID");

                entity.Property(e => e.CarSubImgtype1)
                    .HasMaxLength(50)
                    .HasColumnName("carSubIMGType");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.ClientName)
                    .HasMaxLength(40)
                    .HasColumnName("clientName");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .HasColumnName("email");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.NoId)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("noID");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");
            });

            modelBuilder.Entity<ClientAccount>(entity =>
            {
                entity.HasKey(e => e.AccId);

                entity.ToTable("ClientAccount");

                entity.Property(e => e.AccId)
                    .ValueGeneratedNever()
                    .HasColumnName("accID");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .HasColumnName("email");

                entity.Property(e => e.Pass)
                    .HasMaxLength(255)
                    .HasColumnName("pass");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Acc)
                    .WithOne(p => p.ClientAccount)
                    .HasForeignKey<ClientAccount>(d => d.AccId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientAccount_Client");
            });

            modelBuilder.Entity<ClientNumberPlate>(entity =>
            {
                entity.ToTable("ClientNumberPlate");

                entity.Property(e => e.ClientNumberPlateId).HasColumnName("clientNumberPlateID");

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.NumberPlate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numberPlate");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientNumberPlates)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_ClientNumberPlate_Client");
            });

            modelBuilder.Entity<ClientService>(entity =>
            {
                entity.ToTable("ClientService");

                entity.Property(e => e.ClientServiceId).HasColumnName("clientServiceID");

                entity.Property(e => e.BrandId).HasColumnName("brandID");

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.CrewChiefId).HasColumnName("crewChiefID");

                entity.Property(e => e.DateService)
                    .HasColumnType("date")
                    .HasColumnName("dateService");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.NumberPlate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numberPlate");

                entity.Property(e => e.ServiceId).HasColumnName("serviceID");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ClientServices)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_ClientService_CarBrand");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientServices)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__ClientSer__clien__5535A963");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ClientServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__ClientSer__servi__5629CD9C");
            });

            modelBuilder.Entity<EmployeeProfile>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__Employee__C134C9A1A506DF1C");

                entity.ToTable("EmployeeProfile");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("employeeID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("createdOn");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Idno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("IDNo");

                entity.Property(e => e.Img)
                    .HasMaxLength(255)
                    .HasColumnName("img");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .HasColumnName("lastName");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modifiedOn");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(90)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.EmployeeProfile)
                    .HasForeignKey<EmployeeProfile>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeProfile_Account");
            });

            modelBuilder.Entity<EngineAndChassi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EngineAndChassis");

                entity.Property(e => e.CarId).HasColumnName("carID");

                entity.Property(e => e.CylinderCapacity).HasColumnName("cylinderCapacity");

                entity.Property(e => e.EngineType)
                    .HasMaxLength(200)
                    .HasColumnName("engineType");

                entity.Property(e => e.FuelSystem)
                    .HasMaxLength(200)
                    .HasColumnName("fuelSystem");

                entity.Property(e => e.FuelTankCapacity).HasColumnName("fuelTankCapacity");

                entity.Property(e => e.Gear)
                    .HasMaxLength(200)
                    .HasColumnName("gear");

                entity.Property(e => e.MaximumCapacity)
                    .HasMaxLength(200)
                    .HasColumnName("maximumCapacity");

                entity.Property(e => e.MaximumTorque)
                    .HasMaxLength(200)
                    .HasColumnName("maximumTorque");

                entity.Property(e => e.NumberOfCylinder)
                    .HasMaxLength(200)
                    .HasColumnName("numberOfCylinder");

                entity.Property(e => e.VariableValveSystem)
                    .HasMaxLength(200)
                    .HasColumnName("variableValveSystem");

                entity.HasOne(d => d.Car)
                    .WithMany()
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__EngineAnd__carID__06CD04F7");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.ToTable("Feature");

                entity.Property(e => e.FeatureId).HasColumnName("featureID");

                entity.Property(e => e.Feature1)
                    .HasMaxLength(50)
                    .HasColumnName("feature");
            });

            modelBuilder.Entity<GeneralInfoCar>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GeneralInfoCar");

                entity.Property(e => e.CarId).HasColumnName("carID");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.DesignId).HasColumnName("designID");

                entity.Property(e => e.Fuel)
                    .HasMaxLength(30)
                    .HasColumnName("fuel");

                entity.Property(e => e.MadeIn)
                    .HasMaxLength(90)
                    .HasColumnName("madeIn");

                entity.Property(e => e.NumberOfSeat).HasColumnName("numberOfSeat");

                entity.HasOne(d => d.Car)
                    .WithMany()
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__GeneralIn__carID__07C12930");

                entity.HasOne(d => d.Design)
                    .WithMany()
                    .HasForeignKey(d => d.DesignId)
                    .HasConstraintName("FK__GeneralIn__desig__08B54D69");
            });

            modelBuilder.Entity<HistoryServiceInvoice>(entity =>
            {
                entity.HasKey(e => e.ServiceInvoiceId);

                entity.ToTable("HistoryServiceInvoice");

                entity.Property(e => e.ServiceInvoiceId).HasColumnName("serviceInvoiceID");

                entity.Property(e => e.ClientServiceId).HasColumnName("clientServiceID");

                entity.Property(e => e.DateComplete)
                    .HasColumnType("datetime")
                    .HasColumnName("dateComplete");

                entity.Property(e => e.Feedback).HasColumnName("feedback");
            });

            modelBuilder.Entity<InFoInvoiceDetail>(entity =>
            {
                entity.HasKey(e => e.InfoDetailId);

                entity.ToTable("InFoInvoiceDetail");

                entity.Property(e => e.InfoDetailId).HasColumnName("infoDetailID");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .HasColumnName("productName");

                entity.Property(e => e.Quantity)
                    .HasMaxLength(50)
                    .HasColumnName("quantity");

                entity.Property(e => e.ServiceInvoiceId).HasColumnName("serviceInvoiceID");

                entity.Property(e => e.UnitPrice)
                    .HasMaxLength(55)
                    .HasColumnName("unitPrice");

                entity.HasOne(d => d.ServiceInvoice)
                    .WithMany(p => p.InFoInvoiceDetails)
                    .HasForeignKey(d => d.ServiceInvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InFoInvoiceDetail_HistoryServiceInvoice");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("createdOn");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(50)
                    .HasColumnName("locationName");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("date")
                    .HasColumnName("modifiedOn");

                entity.Property(e => e.PreRegFee).HasColumnName("preRegFee");

                entity.Property(e => e.RegFee).HasColumnName("regFee");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.LocationCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Location_Account");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.LocationModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Location_Account1");
            });

            modelBuilder.Entity<ObjectVoucher>(entity =>
            {
                entity.ToTable("ObjectVoucher");

                entity.Property(e => e.ObjectVoucherId).HasColumnName("objectVoucherID");

                entity.Property(e => e.ObjectVoucher1)
                    .HasMaxLength(50)
                    .HasColumnName("objectVoucher");
            });

            modelBuilder.Entity<PolicyFee>(entity =>
            {
                entity.HasKey(e => e.FeeId);

                entity.ToTable("PolicyFee");

                entity.Property(e => e.FeeId).HasColumnName("feeID");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("createdOn");

                entity.Property(e => e.Fee).HasColumnName("fee");

                entity.Property(e => e.FeeName)
                    .HasMaxLength(50)
                    .HasColumnName("feeName");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("date")
                    .HasColumnName("modifiedOn");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PolicyFeeCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_PolicyFee_Account");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.PolicyFeeModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_PolicyFee_Account1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(90)
                    .HasColumnName("roleName");
            });

            modelBuilder.Entity<RoleFeature>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RoleFeature");

                entity.Property(e => e.FeatureId).HasColumnName("featureID");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.HasOne(d => d.Feature)
                    .WithMany()
                    .HasForeignKey(d => d.FeatureId)
                    .HasConstraintName("FK_RoleFeature_Feature");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RoleFeature_Role");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.ServiceId).HasColumnName("serviceID");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("createdOn");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modifiedOn");

                entity.Property(e => e.ServiceContent)
                    .HasMaxLength(500)
                    .HasColumnName("serviceContent");

                entity.Property(e => e.ServicePrice).HasColumnName("servicePrice");

                entity.Property(e => e.ServiceStatus).HasColumnName("serviceStatus");

                entity.Property(e => e.ServiceType)
                    .HasMaxLength(100)
                    .HasColumnName("serviceType");
            });

            modelBuilder.Entity<StatusCategory>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("StatusCategory");

                entity.Property(e => e.StatusId).HasColumnName("statusID");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(25)
                    .HasColumnName("statusName");
            });

            modelBuilder.Entity<TestDriveService>(entity =>
            {
                entity.ToTable("TestDriveService");

                entity.Property(e => e.TestDriveServiceId).HasColumnName("TestDriveServiceID");

                entity.Property(e => e.CarId).HasColumnName("carID");

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.DateService)
                    .HasColumnType("datetime")
                    .HasColumnName("dateService");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.ToTable("Voucher");

                entity.Property(e => e.VoucherId).HasColumnName("voucherID");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("createdOn");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.DiscountType).HasColumnName("discountType");

                entity.Property(e => e.DiscountValue).HasColumnName("discountValue");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("endDate");

                entity.Property(e => e.MaxUsage).HasColumnName("maxUsage");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modifiedOn");

                entity.Property(e => e.ObjectVoucherId).HasColumnName("objectVoucherID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("startDate");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UsedCount).HasColumnName("usedCount");

                entity.Property(e => e.VoucherCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("voucherCode");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.VoucherCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Voucher_Account");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.VoucherModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Voucher_Account1");

                entity.HasOne(d => d.ObjectVoucher)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.ObjectVoucherId)
                    .HasConstraintName("FK_Voucher_ObjectVoucher");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
