using System;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Running;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace GifEncoderBenchmark
{
	class Program
	{
		static void Main(string[] args)
		{
			RunSizeTest();

			BenchmarkRunner.Run<Benchmark>();
		}

		static void RunSizeTest()
		{
			var images = Directory.EnumerateFiles("./assets")
				.Select(fileName => Image.Load(File.ReadAllBytes(fileName))).ToArray();
			var gif = Methods.Run(images);
			var stream = new MemoryStream();
			gif.SaveAsGif(stream);
			Console.WriteLine($"Gif size: {stream.Length / 1024}kb");
		}
	}
}