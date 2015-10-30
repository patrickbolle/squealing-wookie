//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ElectricPineapple
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Game()
        {
            this.Game_User = new HashSet<Game_User>();
            this.Ratings = new HashSet<Rating>();
            this.Orders = new HashSet<Order>();
        }
    
        public int gameID { get; set; }
        public string title { get; set; }
        public int genre { get; set; }
        public int publisher { get; set; }
        public int ESRBRating { get; set; }
        public System.DateTime releaseDate { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public int platform { get; set; }
    
        public virtual ESRBRating ESRBRating1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Game_User> Game_User { get; set; }
        public virtual Publisher Publisher1 { get; set; }
        public virtual Platform Platform1 { get; set; }
        public virtual Genre Genre1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rating> Ratings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}