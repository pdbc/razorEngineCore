using System.Collections.Generic;
using System.Linq;

namespace RazorEngine.Mailing.Library.Models
{
    public  class AuditProfileViewModel: AuditViewModel
    {
        /// <summary>
        /// Firstname
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Lastname
        /// </summary>
        public string Lastname { get; set; }

        //public string Language { get; set; }

        /// <summary>
        /// DateOfBirth
        /// </summary>
        public string DateOfBirth { get; set; }

        /// <summary>
        /// EmailAddress
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// MobileNumber
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// MobileNumberPrefix
        /// </summary>
        public string MobileNumberPrefix { get; set; }

        /// <summary>
        /// RecoveryEmailAddresses
        /// </summary>
        public List<string> RecoveryEmailAddresses { get; set; }

        /// <summary>
        /// HasRecoveryEmailAddresses
        /// </summary>
        /// <returns></returns>
        public bool HasRecoveryEmailAddresses => RecoveryEmailAddresses != null && RecoveryEmailAddresses.ToList().Any();
        /// <summary>
        /// HasMobileNumber
        /// </summary>
        /// <returns></returns>
        public bool HasMobileNumber => !string.IsNullOrWhiteSpace(MobileNumber);

    }
}
