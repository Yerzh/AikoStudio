//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AikoStudio
{
    using System;
    using System.Collections.Generic;
    
    public partial class GroupSubject
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
    
        public virtual GroupOfStudents GroupOfStudents { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
