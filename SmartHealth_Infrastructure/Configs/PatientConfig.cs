using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Infrastructure.Configs;

public class PatientConfig: IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
    }
}