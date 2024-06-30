using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailsDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public bool IsRentable { get; set; }
        public string BrandName { get; set; }
        public string UserName { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
