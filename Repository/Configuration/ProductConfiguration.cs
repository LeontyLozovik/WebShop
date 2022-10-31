using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.DataModels;
using Repository.Data;

namespace Repository.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
                (
                    new Product
                    { 
                        Id = new Guid("938165ce-7696-4c10-8857-3cd2cd223beb"),
                        Name = "Pants",
                        Price = 96.5,
                        Color = "Greey",
                        IsDeleted = false,
                        ShopId = new Guid("9f832c87-a0d9-4c59-a961-058cfdba39cd")
                    },
                    new Product
                    {
                        Id = new Guid("d17e36ba-ff69-4e13-bbbe-0e6b302647b3"),
                        Name = "Hoodie",
                        Price = 124.83,
                        Color = "Pink",
                        IsDeleted = false,
                        ShopId = new Guid("c85055bf-1cee-4be4-a00f-a2df51849c0f")
                    },
                    new Product
                    {
                        Id = new Guid("66bc3b07-b3ae-44b0-92ed-e7464f8b0428"),
                        Name = "T-shirt",
                        Price = 52,
                        Color = "Black, white",
                        IsDeleted = false,
                        ShopId = new Guid("e9d93d00-acce-4efe-8c7d-600dec7392c5")
                    },
                    new Product
                    {
                        Id = new Guid("722571c6-1a0a-43d4-be8b-6c04301b7f58"),
                        Name = "Jeans",
                        Price = 259.9,
                        Color = "Blue",
                        IsDeleted = false,
                        ShopId = new Guid("6d106c66-38cc-4404-9cf9-e9df73afd36d")
                    },
                    new Product
                    {
                        Id = new Guid("ced493be-b94e-4780-8e0a-9ce27182e5be"),
                        Name = "Boots",
                        Price = 120,
                        Color = "Green",
                        IsDeleted = false,
                        ShopId = new Guid("33ba5a7c-a100-4151-b849-08dde73d2e2a")
                    },
                    new Product
                    {
                        Id = new Guid("0fcf2f00-a415-4a23-9247-8335705d9dda"),
                        Name = "Bag",
                        Price = 2500,
                        Color = "Black",
                        IsDeleted = false,
                        ShopId = new Guid("85c10e91-42ec-49be-9266-9f53fcbd66f3")
                    }
                );
        }
    }
}
