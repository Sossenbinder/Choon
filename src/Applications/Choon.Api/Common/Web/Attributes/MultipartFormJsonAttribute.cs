using Choon.Api.Common.Web.Binders;
using Microsoft.AspNetCore.Mvc;

namespace Choon.Api.Common.Web.Attributes;

public class MultipartFormJsonAttribute : ModelBinderAttribute
{
    public MultipartFormJsonAttribute()
    {
		BinderType = typeof(JsonModelBinder);
	}
}