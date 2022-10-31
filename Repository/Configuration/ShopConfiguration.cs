using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.DataModels;

namespace Repository.Configuration
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasData
                (
                    new Shop
                    { 
                        Id = new Guid("9f832c87-a0d9-4c59-a961-058cfdba39cd"),
                        Name = "Zara",
                        Address = "Voronyanskogo 59"
                    },
                    new Shop
                    {
                        Id = new Guid("c85055bf-1cee-4be4-a00f-a2df51849c0f"),
                        Name = "H&M",
                        Address = "Gazety Pravda 14"
                    },
                    new Shop
                    {
                        Id = new Guid("e9d93d00-acce-4efe-8c7d-600dec7392c5"),
                        Name = "Breshka",
                        Address = "Yakuba Kolasa 50"
                    }, 
                    new Shop
                    {
                        Id = new Guid("6d106c66-38cc-4404-9cf9-e9df73afd36d"),
                        Name = "Levi's",
                        Address = "Melezha 13"
                    },
                    new Shop
                    {
                        Id = new Guid("33ba5a7c-a100-4151-b849-08dde73d2e2a"),
                        Name = "Nike",
                        Address = "Kalinovskogo 1863"
                    },
                    new Shop
                    {
                        Id = new Guid("85c10e91-42ec-49be-9266-9f53fcbd66f3"),
                        Name = "Dior",
                        Address = "Zybitskaya 1"
                    }
                );
        }
    }
}
