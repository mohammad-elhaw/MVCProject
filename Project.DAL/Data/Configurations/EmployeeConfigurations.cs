using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DAL.Entities.EmployeeEntity;
using Project.DAL.Entities.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Data.Configurations
{
    public class EmployeeConfigurations : BaseEntityConfigurations<Employee>, IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("varchar(50)");
            builder.Property(e => e.Address).HasColumnType("varchar(150)");
            builder.Property(e => e.Salary).HasColumnType("decimal(10,2)");
            builder.Property(e => e.Gender)
                .HasConversion(empGender => empGender.ToString(),
                _gender => (Gender)Enum.Parse(typeof(Gender), _gender));

            builder.Property(e => e.EmployeeType)
                .HasConversion((EmpType)=> EmpType.ToString(),
                (_type)=> (EmployeeType)Enum.Parse(typeof(EmployeeType), _type));

            base.Configure(builder);
        }
    }
}
