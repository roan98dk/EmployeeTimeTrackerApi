using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// Client/customer information
    /// </summary>
    public class Client
    {
        /// <summary>
        /// A unique client id in the case of a later name change.
        /// </summary>
        public Guid Id { get; set; }

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

        /// <summary>
        /// Work tasks related to the client, both planned and completed.
        /// </summary>
        public ICollection<WorkTask> WorksTasks { get; set; } = new List<WorkTask>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public Client() { }

        /// <summary>
        /// Constructor for a new client.
        /// </summary>
        /// <param name="addClient">New client information</param>
        public Client(AddClient addClient)
        {
            Id = Guid.NewGuid();
            Name = addClient.Name;
            HourRate = addClient.HourRate;
        }
    }
}
