
using System.Drawing;
using System.Drawing.Imaging;

if (args.Length != 1) throw new ArgumentException("The input filename must be specified");

var filename = args[0];

// Process multiple files
var files = Directory.GetFiles(".", filename);
foreach (var file in files)
{
    if (!file.Contains(".pixelated."))
    {
        Console.WriteLine("Reading " + file);
        // Load the bitmap file
        var source = new Bitmap(file);

        var result = Pixelator.Lib.Pixelator.Pixelate(source, 60);

        var filenameParts = file.Split(".");
        var targetFilename = string.Join('.', filenameParts.Take(filenameParts.Length - 1)) + ".pixelated.png";

        result.Save(targetFilename, ImageFormat.Png);

        Console.WriteLine("Created " + targetFilename);
    }
}