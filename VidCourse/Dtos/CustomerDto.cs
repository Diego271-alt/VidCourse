using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidCourse.Models;

namespace VidCourse.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(225)]

        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        //No debemos usar modelos que nos generen una dependecia
        //Asi que eliminamos la siguiente linea ya que solo usaremos datos primitivos
        //En este casod ebemos crear otro DTO
        // public MembershipType MembershipType { get; set; }


        public MembershipTypeDto MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}