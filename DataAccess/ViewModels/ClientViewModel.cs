using DataAccess.Models;

namespace DataAccess.ViewModels
{
    public class ClientViewModel
    {
        /// <summary>
        /// A unique client id in the case of a later name change.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the client/customer.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The hourly rate set for the client.
        /// </summary>
        public int HourRate { get; set; }

        /// <summary>
        /// Constucts a view model from a <see cref="Client"/>
        /// </summary>
        /// <param name="client">The <see cref="Client"/></param>
        public ClientViewModel(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            HourRate = client.HourRate;
        }
    }
}
