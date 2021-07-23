using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace GifEncoderBenchmark
{
	public static class Methods
	{
		public static Image<Rgba32> Run(Image<Rgba32>[] images)
		{
			var gif = new Image<Rgba32>(images[0].Width, images[0].Height);
			foreach (var image in images)
			{
				gif.Frames.AddFrame(image.Frames[0]);
			}

			return gif;
		}
	}
}