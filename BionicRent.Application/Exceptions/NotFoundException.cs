/*
 * @CreateTime: Apr 24, 2019 5:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 7:31 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicRent.Application.Exceptions {
    public class NotFoundException : Exception {
        public NotFoundException (string message) : base (message) { }

        public NotFoundException (string name, object key) : base ($"Entity \"{name}\" ({key}) was not found.") { }

    }
}