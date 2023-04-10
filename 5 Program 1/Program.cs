using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.IO.Compression;
using System.Text;

try
{
    //Распаковывает архив в папку рядом с запускаемым файлом программы
    string zipPath = @"D:\Users\HP\Downloads\LonaRPG.zip";       //Нюанс, необходимо ввести путь к сжатому файлу
    string extractPath = @"D:\Users\HP\Downloads";   //И путь распаковки
    ZipFile.ExtractToDirectory(zipPath, extractPath);

    //Считывает названия файлов и папок из указанной папки
    var directory = new DirectoryInfo(extractPath);
    var files = directory.GetFiles();

    //Записывает информацию о содержимом папки в текстовый файл в формате .csv
    var csvRecord = files.Select(u => new
    {
        Title = u.Name,
        Type = u.Extension.TrimStart('.'),
        Path = u.FullName,
        LastChanges = u.LastWriteTime
    });
    var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
    { Delimiter = "\t", Encoding = Encoding.UTF8 };
    string csvPath = Path.Combine(extractPath, "fileRedord.csv");
    using (var streamWriter = new StreamWriter(csvPath))
    using (var csvWriter = new CsvWriter(streamWriter, csvConfiguration))
    {
        csvWriter.WriteRecords(csvRecord);
    }

    //Удаляет папку с распакованным архивом
    Directory.Delete(extractPath);

    //Сохраняет путь к файлу csv в файле %AppData%/Lesson12Homework.txt
    string txtPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Lesson12Homework.txt");
    using (StreamWriter txtWriter = new StreamWriter(txtPath, false))
    { txtWriter.WriteLine(Path.Combine(extractPath, "fileRecord.csv")); }
}
catch (DirectoryNotFoundException) { Console.WriteLine("Директорий не найден"); }
catch (FileNotFoundException) { Console.WriteLine("Файл не найден"); }
catch (InvalidDataException) { Console.WriteLine("Некоректные данные"); }
catch(System.UnauthorizedAccessException) { Console.WriteLine("Неавторизованный доступ"); }
catch (System.IO.IOException) { Console.WriteLine("Отказан доступ к данному пути"); }
catch (Exception ex) { Console.WriteLine("Неизвестная ошибка"); } //мне