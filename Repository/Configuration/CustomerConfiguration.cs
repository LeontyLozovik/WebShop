using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData
                (
                    new Customer
                    {
                        Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                        Name = "Vensko Daria",
                        Address = "Cosmonavtov 38"
                    },
                    new Customer
                    {
                        Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                        Name = "Anton Starikevich",
                        Address = "Lermontova 142"
                    }, new Customer
                    {
                        Id = new Guid("a4b2c053-38b6-620c-bc78-8d62a9998164"),
                        Name = "Alexander Hleb",
                        Address = "Slobodskaya 3"
                    }
                );
        }
    }
}
