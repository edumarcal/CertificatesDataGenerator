using CertificatesDataGenerator.Extensions;
using CertificatesDataGenerator.Helpers;
using CertificatesDataGenerator.Models;

var source = args[0];
var destination = args[1];
var rootPath = args[2];
var searchPattern = args[3];

var certificates = await JsonFileReader.ReadAsync<LinkedList<Certificate>>(source);

certificates ??= new LinkedList<Certificate>();

var filenames = Directory.GetFiles(rootPath, searchPattern, SearchOption.AllDirectories);

foreach (var filename in filenames)
{
    var names = filename.Split(" - ");

    if (names.Length == 4)
    {
        var year = names[1];
        var description = names[2];

        var isAny = certificates.Any(x => x.Year == year && x.Description == description);
        if (!isAny)
        {
            var certificate = new Certificate(year: year,
                                              workload: names[3].GetWorkload(),
                                              description: description,
                                              institute: names[0].GetInstituite(),
                                              link: string.Empty);

            certificates.AddFirst(certificate);
        }

    }
}

await JsonFileReader.WriteAsync(destination, certificates);
