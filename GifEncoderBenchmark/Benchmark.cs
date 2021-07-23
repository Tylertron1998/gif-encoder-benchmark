using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace GifEncoderBenchmark
{
	public class Benchmark
	{

		private Image<Rgba32>[] _images;
		private MemoryStream _stream;

		[GlobalSetup]
		public void Populate()
		{
			_images = Directory.EnumerateFiles("./assets")
				.Select(fileName => Image.Load(File.ReadAllBytes(fileName))).ToArray();
		}

		[IterationSetup]
		public void SetupStream()
		{
			_stream = new MemoryStream();
		}

		[Benchmark]
		public int WriteGif()
		{
			var gif = Methods.Run(_images);
			gif.SaveAsGif(_stream);
			return 44;
		}
	}
}