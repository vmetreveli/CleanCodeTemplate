// using Cai.Send.Domain.Entities.EventDictionary;
// using Cai.Send.Domain.Entities.EventDictionary.DomainObjects;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace Cai.Send.Infrastructure.Context.Configurations;
//
// public class EventDictionaryConfig : IEntityTypeConfiguration<EventsDictionary>
// {
//     public void Configure(EntityTypeBuilder<EventsDictionary> builder)
//     {
//         builder.HasKey(e => e.Id);
//
//         builder.Property(e => e.Id)
//             .HasConversion(x => x.Value,
//                 v => EventDictionaryId.Create(v))
//             .HasColumnName("EventDictionaryId");
//
//         builder.Property(e => e.CreatedOn);
//
//         builder.Property(e => e.Description)
//             .HasMaxLength(500);
//
//         builder.Property(e => e.IsDeleted);
//
//         builder.Property(e => e.Name)
//             .HasMaxLength(100)
//             .IsUnicode(false);
//         builder.Property(e => e.ModifiedOn);
//
//         builder.Property(c => c.CreatedOn).IsRequired();
//         builder.Property(c => c.ModifiedOn);
//         builder.Property(c => c.DeletedOn);
//         builder.Property(c => c.IsDeleted).IsRequired();
//
//         builder.HasQueryFilter(c => !c.IsDeleted);
//     }
// }

