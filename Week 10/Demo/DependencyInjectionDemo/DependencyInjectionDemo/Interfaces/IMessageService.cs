using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.Interfaces
{
    /// <summary>
    /// A demo interface for a message service.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// A method to get a message.
        /// </summary>
        /// <returns>Message</returns>
        string GetMessage();
    }
}
