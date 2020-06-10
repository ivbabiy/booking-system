using System;
 using System.Collections.Generic;
 using System.Text;

 namespace vcs.DAL.Entities
 {
     public class RoomNumber
     {
         public int id { get; set; }
         public  Booking Booking { get; set; }
     }
 }