using System.Collections.Generic;
using System.Net.Mail;

namespace RedTopDev.EmailHelper
{
    /// <summary>
    /// Mail Helper object
    /// </summary>
    public class Mail
    {
        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        public MailAddress From { get; set; }
        /// <summary>
        /// Gets or sets to.
        /// </summary>
        /// <value>
        /// To.
        /// </value>
        public MailAddressCollection To { get; set; }
        /// <summary>
        /// Gets or sets the cc.
        /// </summary>
        /// <value>
        /// The cc.
        /// </value>
        public MailAddressCollection CC { get; set; }
        /// <summary>
        /// Gets or sets the BCC.
        /// </summary>
        /// <value>
        /// The BCC.
        /// </value>
        public MailAddressCollection BCC { get; set; }
        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public int Port { get; set; }
        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public string Host { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Mail"/> is authenticate.
        /// </summary>
        /// <value>
        ///   <c>true</c> if authenticate; otherwise, <c>false</c>.
        /// </value>
        public bool Authenticate { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [enable SSL].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable SSL]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableSSL { get; set; }
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        public string Subject { get; set; }
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string Body { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is body HTML.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is body HTML; otherwise, <c>false</c>.
        /// </value>
        public bool IsBodyHtml { get; set; }
        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>
        /// The attachments.
        /// </value>
        public List<string> Attachments { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }
    }
}
