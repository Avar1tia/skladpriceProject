//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SkladPrice.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class loginhistory
    {
        public int id { get; set; }
        public Nullable<int> id_user { get; set; }
        public Nullable<System.DateTime> LoginDateTime { get; set; }
        public string TypeVxod { get; set; }
    
        public virtual users users { get; set; }
    }
}
