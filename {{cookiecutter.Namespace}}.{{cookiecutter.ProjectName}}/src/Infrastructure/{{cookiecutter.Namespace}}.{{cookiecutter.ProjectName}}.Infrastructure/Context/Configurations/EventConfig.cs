using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cai.Send.Infrastructure.Context.Configurations;

public class EventConfig : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(x => x.Id)
            .HasConversion(x =>
                    x.Value,
                value => EventId.Create(value))
            .ValueGeneratedOnAdd();
        //builder.Property(e => e.Id);
        //builder.Property(e => e.Id).ValueGeneratedOnAdd();


        builder.Property(e => e.CallbackChannel)
            .HasMaxLength(100)
            .IsUnicode(false);


        // builder.Property(e => e.EventDictionaryId)
        //     .HasConversion(x => x.Value,
        //         y => EventDictionaryId.Create(y)).IsRequired();
        builder.Property(e => e.EventPayload);
        builder.Property(e => e.Mobile)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.SenderSystemId);
        builder.Property(e => e.SocialAccount)
            .HasMaxLength(500)
            .IsUnicode(false);
        builder.Property(e => e.Status);

        // builder.Property(e => e.TransactionId)
        //     .HasConversion(x => x.Value,
        //         y => TransactionId.Create(y));

        builder.OwnsOne(e => e.TransactionId, modelNameBuilder =>
        {
            modelNameBuilder.Property(l => l.Value)
                .HasColumnName("transaction_id")
                .HasMaxLength(100);
        });

        // builder.HasOne(d => d.EventDictionary)
        //     .WithMany(p => p.Events)
        //     .HasForeignKey(d => d.EventDictionaryId);


        builder.Property(c => c.CreatedOn).IsRequired();
        builder.Property(c => c.ModifiedOn);
        builder.Property(c => c.DeletedOn);
        builder.Property(c => c.IsDeleted).IsRequired();

        builder.HasQueryFilter(c => !c.IsDeleted);
    }
}