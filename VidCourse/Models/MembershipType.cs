using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidCourse.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        public short SingUpFree { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }


    }
}