﻿using System.Text.Json;

namespace Choon.Api.Extensions
{
	public static class IFormFileExtensions
	{
		public static T Deserialize<T>(this IFormFile formFile)
		{
			using var stream = formFile.OpenReadStream();

			return JsonSerializer.Deserialize<T>(stream)!;
		}
	}
}