﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AcademyFitnessMusaeva
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AcademyFitnessMusaevaEntities2 : DbContext
    {
        public AcademyFitnessMusaevaEntities2()
            : base("name=AcademyFitnessMusaevaEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseRegistration> CourseRegistration { get; set; }
        public virtual DbSet<Trainer> Trainer { get; set; }
    }
}
