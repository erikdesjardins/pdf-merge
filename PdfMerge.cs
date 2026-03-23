using System;
using System.IO;
using System.Linq;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;

var merger = new PdfMerger(new PdfDocument(new PdfWriter(Console.OpenStandardOutput())));
foreach (var fileName in args)
{
    using var file = new PdfDocument(new PdfReader(fileName));
    merger.Merge(file, 1, file.GetNumberOfPages());
}
merger.Close();
