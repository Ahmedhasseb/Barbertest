using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Moduls
{
    public class EmployeeConfiguaration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Salary).IsRequired();
            builder.Property(e => e.Salary).IsRequired();
            builder.Property(e => e.Address).IsRequired();
            builder.Property(e => e.Age).IsRequired();

            builder.HasOne(e => e.Department)
                    .WithMany(e => e.Employee)
                    .HasForeignKey(e => e.DepartmentId)
                    .IsRequired();
            

        }
    }
}
