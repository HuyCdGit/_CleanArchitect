using CleanArch.Domain.Host.ValueObjects;
using CleanArch.Domain.Menu;
using CleanArch.Domain.Menu.Entities;
using CleanArch.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.Configurations;

internal class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenuTable(builder);
        ConfigureMenuSectionTable(builder);
    }

    public void ConfigureMenuSectionTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.Sections, sb =>
        {
            sb.ToTable("MenuSections");
            sb.WithOwner().HasForeignKey("MenuId");
            sb.HasKey("Id", "MenuId");

            sb.Property(s => s.Id)
                .HasColumnName("MenuSectionId")
                .ValueGeneratedNever()
                .HasConversion(
                    MenuSectionId => MenuSectionId.Value,
                    value => MenuSectionId.Create(value)
                );
            sb.Property(s => s.Name).HasMaxLength(100);

            sb.Property(s => s.Description).HasMaxLength(100);

            sb.OwnsMany(s => s.Items, ib =>
            {
                ib.ToTable("MenuItem");

                ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");
                
                ib.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");



                ib.Property(i => i.Id)
                    .HasColumnName("MenuItemId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        MenuItemId => MenuItemId.Value,
                        value => MenuItemId.Create(value)
                    );

                ib.Property(s => s.Name).HasMaxLength(100);

                ib.Property(s => s.Description).HasMaxLength(100);
            });
            sb.Navigation(s => s.Items).Metadata.SetField("_items");
            sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
        });
        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    public void ConfigureMenuTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
        .ValueGeneratedNever()
        .HasConversion(
            MenuId => MenuId.Value,
            value => MenuId.Create(value)
        );

        builder.Property(m => m.Name).HasMaxLength(100);

        builder.Property(m => m.Description).HasMaxLength(100);
        
        builder.Property(m => m.HostId)
            .HasConversion(
            HostId => HostId.Value,
            value => HostId.Create(value)
        );
    }
}