using System.ComponentModel.DataAnnotations;

namespace Doctors.Models
{
    public class Fees
    {
        public string? DoctorFeeId { get; set; }
        public int DoctorId { get; set; }
        public decimal Amount { get; set; }
        public decimal Total { get; set; }
        public string? Payment { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public decimal? DoctorFeeAmount { get; internal set; }
        public decimal? DoctorFeeTotal { get; internal set; }
        public string? DoctorFeePayment { get; internal set; }
        public string? DoctorFeeType { get; internal set; }
        public string? DoctorFeeDescription { get; internal set; }
        [Key]
        public string? FeeId { get; internal set; }
    }
}
