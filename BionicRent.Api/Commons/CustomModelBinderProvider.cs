/*
 * @CreateTime: Jun 7, 2019 6:56 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 7, 2019 6:56 PM
 * @Description: Modify Here, Please 
 */
using BionicRent.Commons.QueryHelpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BionicRent.Api.Commons {
    public class CustomModelBinderProvider : IModelBinderProvider {
        public IModelBinder GetBinder (ModelBinderProviderContext context) {
            if (context.Metadata.ModelType.IsSubclassOf (typeof (ApiQueryString)))
                return new CustomModelBinder ();

            return null;
        }
    }
}