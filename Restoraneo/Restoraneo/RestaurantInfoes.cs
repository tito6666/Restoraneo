//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restoraneo
{
    using System;
    using System.Collections.Generic;
    
    public partial class RestaurantInfoes
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string KitchenType { get; set; }
        public string HoursOfWork { get; set; }
        public string PaymentType { get; set; }
    
        public virtual Restaurants Restaurants { get; set; }
    }
}
