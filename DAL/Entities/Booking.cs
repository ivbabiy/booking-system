using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text;

 namespace vcs.DAL.Entities
 {
     public class Booking
     {
         public int id { get; set; }
         public List<RoomNumber> RoomNumbers { get; set; }
     }
 }