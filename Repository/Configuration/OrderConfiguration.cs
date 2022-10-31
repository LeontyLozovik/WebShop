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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData
                (
                    new Order
                    {
                        Id = new Guid("7af85729-62fb-4ec6-95c6-10c0579ffb45"),
                        OrderStatus = OrderStatusEnum.Active,
                        CustomerId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                    },
                    new Order
                    {
                        Id = new Guid("5e9eeebd-81ad-475d-994d-386e0c460aae"),
                        OrderStatus = OrderStatusEnum.Complete,
                        CustomerId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                    },
                    new Order
                    {
                        Id = new Guid("3afdb361-a0b1-4bab-b43f-701b9780b8a8"),
                        OrderStatus = OrderStatusEnum.Active,
                        CustomerId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                    },
                    new Order
                    {
                        Id = new Guid("3e4dbe37-8389-4f73-a53f-5fcaf06e03d8"),
                        OrderStatus = OrderStatusEnum.Complete,
                        CustomerId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                    },
                    new Order
                    {
                        Id = new Guid("535770b2-16fc-441c-a420-a41ea87f6b07"),
                        OrderStatus = OrderStatusEnum.Active,
                        CustomerId = new Guid("a4b2c053-38b6-620c-bc78-8d62a9998164")
                    },
                    new Order
                    {
                        Id = new Guid("a79a95b0-36ec-4ab3-bfd4-d4e73a2ae612"),
                        OrderStatus = OrderStatusEnum.Complete,
                        CustomerId = new Guid("a4b2c053-38b6-620c-bc78-8d62a9998164")
                    }
                );
        }
    }
}
