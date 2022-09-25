using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// Adds a new <see cref="Client"/>
    /// </summary>
    public class AddClient
    {
        /// <summary>
        /// The name of the client/customer.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The hourly rate set for the client.
        /// </summary>
        [Required]
        [Range(50, 5000)]
        public int HourRate { get; set; }
    }
}
