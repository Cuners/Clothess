//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp6
{
    using System;
    using System.Collections.Generic;
    
    public partial class Buyer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pasport { get; set; }
    
        public virtual User User { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
