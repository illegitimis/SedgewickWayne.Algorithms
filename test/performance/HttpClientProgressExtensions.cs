namespace SedgewickWayne.Algorithms.PerformanceTests;

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// <see href="https://gist.github.com/dalexsoto/9fd3c5bdbe9f61a717d47c5843384d11"/>
/// </summary>
internal static class HttpClientProgressExtensions
{
	public static async Task DownloadDataAsync(
		this HttpClient client,
		Uri requestUrl,
		Stream destination,
		IProgress<float> progress = null,
		CancellationToken cancellationToken = default(CancellationToken))
	{
		using var response = await client.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
		var contentLength = response.Content.Headers.ContentLength;

		using var download = await response.Content.ReadAsStreamAsync();
		
		// no progress... no contentLength... very sad
		if (progress is null || !contentLength.HasValue)
		{
			await download.CopyToAsync(destination);
			return;
		}

		// Such progress and contentLength much reporting Wow!
		var progressWrapper = new Progress<long>(totalBytes => progress.Report(GetProgressPercentage(totalBytes, contentLength.Value)));
		await download.CopyToDestinationStreamWithProgressAsync(destination, 81920, progressWrapper, cancellationToken);

		float GetProgressPercentage(float totalBytes, float currentBytes) => (totalBytes / currentBytes) * 100f;
	}
}
