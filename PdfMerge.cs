using System;
using System.IO;
using System.Linq;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;

var writer = new PdfWriter(Console.OpenStandardOutput());
writer.SetCompressionLevel(9);

var merger = new PdfMerger(new PdfDocument(writer));
foreach (var fileName in args)
{
    using var file = new PdfDocument(new PdfReader(fileName));
    merger.Merge(file, 1, file.GetNumberOfPages());
}
merger.Close();
