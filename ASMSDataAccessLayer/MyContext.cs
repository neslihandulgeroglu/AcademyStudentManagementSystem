using ASMSEntityLayer.IdentityModels;
using ASMSEntityLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSDataAccessLayer
{
    public class MyContext:IdentityDbContext<AppUser,AppRole,string>
    {
        public MyContext(DbContextOptions<MyContext>options):base(options)
        {

        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Neighbourhood> Neighbourhoods { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseGroup> CourseGroups { get; set; }
        public virtual DbSet<StudentsCourseGroup> StudentsCourses { get; set; }
        public virtual DbSet<StudentAttendance> StudentAttendances { get; set; }
        public virtual DbSet<UsersAddress> UsersAddresses { get; set; }
        public virtual DbSet<Mother> Mothers { get; set; }
        public virtual DbSet<Child> Children { get; set; }

        //OVERRİDE
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CourseGroup>().HasIndex(cg => new { cg.PortalCode }).IsUnique(true);
            base.OnModelCreating(builder);
            //builder.Entity<District>().HasOne(d => d.City)//bİRE
            //    .WithMany(c => c.Districts)//çOK İLİŞKİ
            //    .HasForeignKey(d => d.CityId)//ne ÜZERİNDEN 
            //    .OnDelete(DeleteBehavior.NoAction);//HANGİ DAVRANIŞLA(İLÇE SİLİNEMEZ)

        }




    }
}
