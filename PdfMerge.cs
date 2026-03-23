using System;
using System.IO;
using System.Linq;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;

var files = args.Skip(1);

var outputStream = new MemoryStream();

var merger = new PdfMerger(new PdfDocument(new PdfWriter(outputStream)));
foreach (var fileName in files)
{
    using var file = new PdfDocument(new PdfReader(fileName));
    merger.Merge(file, 1, file.GetNumberOfPages());
}
merger.Close();

outputStream.Position = 0;
outputStream.CopyTo(Console.OpenStandardOutput());
