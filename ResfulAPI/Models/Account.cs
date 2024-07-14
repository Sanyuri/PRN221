using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class Account
    {
        public Account()
        {
            AutoPartCreatedByNavigations = new HashSet<AutoPart>();
            AutoPartModifiedByNavigations = new HashSet<AutoPart>();
            BlogCreatedByNavigations = new HashSet<Blog>();
            BlogModifiedByNavigations = new HashSet<Blog>();
            CarBrandCreatedByNavigations = new HashSet<CarBrand>();
            CarBrandModifiedByNavigations = new HashSet<CarBrand>();
            CarCreatedByNavigations = new HashSet<Car>();
            CarDesignCreatedByNavigations = new HashSet<CarDesign>();
            CarDesignModifiedByNavigations = new HashSet<CarDesign>();
            CarModifiedByNavigations = new HashSet<Car>();
            CarOrders = new HashSet<CarOrder>();
            LocationCreatedByNavigations = new HashSet<Location>();
            LocationModifiedByNavigations = new HashSet<Location>();
            PolicyFeeCreatedByNavigations = new HashSet<PolicyFee>();
            PolicyFeeModifiedByNavigations = new HashSet<PolicyFee>();
            VoucherCreatedByNavigations = new HashSet<Voucher>();
            VoucherModifiedByNavigations = new HashSet<Voucher>();
        }

        public int AccId { get; set; }
        public string? AccName { get; set; }
        public string? Password { get; set; }
        public int? RoleId { get; set; }
        public string? Email { get; set; }
        public bool? Status { get; set; }

        public virtual Role? Role { get; set; }
        public virtual EmployeeProfile? EmployeeProfile { get; set; }
        public virtual ICollection<AutoPart> AutoPartCreatedByNavigations { get; set; }
        public virtual ICollection<AutoPart> AutoPartModifiedByNavigations { get; set; }
        public virtual ICollection<Blog> BlogCreatedByNavigations { get; set; }
        public virtual ICollection<Blog> BlogModifiedByNavigations { get; set; }
        public virtual ICollection<CarBrand> CarBrandCreatedByNavigations { get; set; }
        public virtual ICollection<CarBrand> CarBrandModifiedByNavigations { get; set; }
        public virtual ICollection<Car> CarCreatedByNavigations { get; set; }
        public virtual ICollection<CarDesign> CarDesignCreatedByNavigations { get; set; }
        public virtual ICollection<CarDesign> CarDesignModifiedByNavigations { get; set; }
        public virtual ICollection<Car> CarModifiedByNavigations { get; set; }
        public virtual ICollection<CarOrder> CarOrders { get; set; }
        public virtual ICollection<Location> LocationCreatedByNavigations { get; set; }
        public virtual ICollection<Location> LocationModifiedByNavigations { get; set; }
        public virtual ICollection<PolicyFee> PolicyFeeCreatedByNavigations { get; set; }
        public virtual ICollection<PolicyFee> PolicyFeeModifiedByNavigations { get; set; }
        public virtual ICollection<Voucher> VoucherCreatedByNavigations { get; set; }
        public virtual ICollection<Voucher> VoucherModifiedByNavigations { get; set; }
    }
}
