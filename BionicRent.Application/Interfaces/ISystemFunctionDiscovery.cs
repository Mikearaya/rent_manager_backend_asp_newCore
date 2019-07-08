/*
 * @CreateTime: Jan 8, 2019 10:31 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 7, 2019 8:45 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicRent.Application.Models;

namespace BionicRent.Application.Interfaces {
    public interface ISystemFunctionDiscovery {
        IEnumerable<MvcControllerInfo> GetFunctions ();

    }
}