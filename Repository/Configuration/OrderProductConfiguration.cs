using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryConfiguration
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasData
                (
                    new OrderProduct
                    {
                        OrderId = new Guid("7af85729-62fb-4ec6-95c6-10c0579ffb45"),
                        ProductId = new Guid("938165ce-7696-4c10-8857-3cd2cd223beb")
                    },
                    new OrderProduct
                    {
                        OrderId = new Guid("7af85729-62fb-4ec6-95c6-10c0579ffb45"),
                        ProductId = new Guid("66bc3b07-b3ae-44b0-92ed-e7464f8b0428")
                    },
                    new OrderProduct
                    {
                        OrderId = new Guid("7af85729-62fb-4ec6-95c6-10c0579ffb45"),
                        ProductId = new Guid("ced493be-b94e-4780-8e0a-9ce27182e5be")
                    },
                    new OrderProduct
                    {
                        OrderId = new Guid("5e9eeebd-81ad-475d-994d-386e0c460aae"),
                        ProductId = new Guid("0fcf2f00-a415-4a23-9247-8335705d9dda")
                    },
                    new OrderProduct
                    {
                        OrderId = new Guid("5e9eeebd-81ad-475d-994d-386e0c460aae"),
                        ProductId = new Guid("722571c6-1a0a-43d4-be8b-6c04301b7f58")
                    },
                    new OrderProduct
                    {
                        OrderId = new Guid("3afdb361-a0b1-4bab-b43f-701b9780b8a8"),
                        ProductId = new Guid("d17e36ba-ff69-4e13-bbbe-0e6b302647b3")
                    },
                    new OrderProduct
                    {
                        OrderId = new Guid("3afdb361-a0b1-4bab-b43f-701b9780b8a8"),
                        ProductId = new Guid("722571c6-1a0a-43d4-be8b-6c04301b7f58")
                    },
                    new OrderProduct
                    {
                        OrderId = new Guid("3afdb361-a0b1-4bab-b43f-701b9780b8a8"),
                        ProductId = new Guid("0fcf2f00-a415-4a23-9247-8335705d9dda")
                    },
                    new OrderProduct
                    {
                        OrderId = new Guid("3e4dbe37-8389-4f73-a53f-5fcaf06e03d8"),
                        ProductId = new Guid("d17e36ba-ff69-4e13-bbbe-0e6b302647b3")
                    },
                    new OrderProduct
                    {
                        OrderId = new Guid("3e4dbe37-8389-4f73-a53f-5fcaf06e03d8"),
                        ProductId = new Guid("938165ce-7696-4c10-8857-3cd2cd223beb")
                    },
                    new OrderProduct
                    {
                        OrderId = new Guid("535770b2-16fc-441c-a420-a41ea87f6b07"),
                        ProductId = new Guid("66bc3b07-b3ae-44b0-92ed-e7464f8b0428")
                    },
                    new OrderProduct
                    {
                        OrderId = new Guid("a79a95b0-36ec-4ab3-bfd4-d4e73a2ae612"),
                        ProductId = new Guid("938165ce-7696-4c10-8857-3cd2cd223beb")
                    },
                    new OrderProduct
                    {
                        OrderId = new Guid("a79a95b0-36ec-4ab3-bfd4-d4e73a2ae612"),
                        ProductId = new Guid("66bc3b07-b3ae-44b0-92ed-e7464f8b0428")
                    },
                    new OrderProduct
                    {
                        OrderId = new Guid("a79a95b0-36ec-4ab3-bfd4-d4e73a2ae612"),
                        ProductId = new Guid("ced493be-b94e-4780-8e0a-9ce27182e5be")
                    },
                    new OrderProduct
                    {
                        OrderId = new Guid("a79a95b0-36ec-4ab3-bfd4-d4e73a2ae612"),
                        ProductId = new Guid("d17e36ba-ff69-4e13-bbbe-0e6b302647b3")
                    },
                    new OrderProduct
                    {
                        OrderId = new Guid("a79a95b0-36ec-4ab3-bfd4-d4e73a2ae612"),
                        ProductId = new Guid("722571c6-1a0a-43d4-be8b-6c04301b7f58")
                    },
                    new OrderProduct
                    {
                        OrderId = new Guid("a79a95b0-36ec-4ab3-bfd4-d4e73a2ae612"),
                        ProductId = new Guid("0fcf2f00-a415-4a23-9247-8335705d9dda")
                    }
                );
        }
    }
}
