using Choon.Api.Binders;
using Microsoft.AspNetCore.Mvc;

namespace Choon.Api.Attributes
{
	public class MultipartFormJsonAttribute : ModelBinderAttribute
	{
		public MultipartFormJsonAttribute()
		{
			BinderType = typeof(JsonModelBinder);
		}
	}
}