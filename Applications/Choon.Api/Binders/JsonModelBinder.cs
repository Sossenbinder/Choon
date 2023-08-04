using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Choon.Api.Binders
{
	public class JsonModelBinder : IModelBinder
	{
		private const string PayloadConstant = "payload";

		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			if (bindingContext == null)
			{
				throw new ArgumentNullException(nameof(bindingContext));
			}

			// Check the value sent in
			var valueProviderResult = bindingContext.ValueProvider.GetValue(PayloadConstant);
			if (valueProviderResult != ValueProviderResult.None)
			{
				bindingContext.ModelState.SetModelValue(PayloadConstant, valueProviderResult);

				// Attempt to convert the input value
				var valueAsString = valueProviderResult.FirstValue;
				var result = JsonSerializer.Deserialize(valueAsString, bindingContext.ModelType);
				if (result != null)
				{
					bindingContext.Result = ModelBindingResult.Success(result);
					return Task.CompletedTask;
				}
			}

			return Task.CompletedTask;
		}
	}
}