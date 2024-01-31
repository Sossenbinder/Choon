using Choon.Api.Features.Common.Web.Binders;
using Microsoft.AspNetCore.Mvc;

namespace Choon.Api.Features.Common.Web.Attributes;

public class MultipartFormJsonAttribute : ModelBinderAttribute
{
    public MultipartFormJsonAttribute()
    {
		BinderType = typeof(JsonModelBinder);
	}
}