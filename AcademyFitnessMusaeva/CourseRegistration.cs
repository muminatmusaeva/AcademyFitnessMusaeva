//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class CourseRegistration
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int CourseId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public bool IsDone { get; set; }
        public int TotalPoint { get; set; }
        public byte[] CertificateImage { get; set; }
        public string Comment { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}
