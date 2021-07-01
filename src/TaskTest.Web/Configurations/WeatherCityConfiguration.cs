using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTest.Web.Entities;

namespace TaskTest.Web.Configurations
{
    public class WeatherCityConfiguration
        : IEntityTypeConfiguration<WeatherCity>
    {
        public void Configure(EntityTypeBuilder<WeatherCity> builder)
        {
            builder.HasKey(e => e.WeatherCityID);
        }
    }
}
