using System;
using System.IO;
using iText.Kernel.Pdf;

var files = args.Skip(1);

var outputStream = new MemoryStream();

using (var output = new PdfDocument(new PdfWriter(outputStream)))
using (var merger = new PdfMerger(output))
foreach (var fileName in files)
{
    using var file = new PdfDocument(new PdfReader(fileName));
    merger.merge(file, 1, file.GetNumberOfPages());
}

outputStream.Position = 0;
outputStream.CopyTo(Console.OpenStandardOutput());
