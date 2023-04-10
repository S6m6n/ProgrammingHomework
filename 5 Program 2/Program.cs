using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.Text;
using  _5_Program_2;

try
{
    //Считывает путь к файлу из %AppData%/Lesson12Homework.txt
    string csvPath = string.Empty;
    string txtPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Lesson12Homework.txt");
    using (var txtReader = new StreamReader(txtPath))
    { csvPath = txtReader.ReadToEnd(); }

    //Открывает указанный файл .csv
    var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
    { Delimiter = "\t", Encoding = Encoding.UTF8 };
    using (var streamReader = new StreamReader(csvPath))
    using (var csvReader = new CsvReader(streamReader, csvConfiguration))
    {
        var fileRecords = csvReader.GetRecords<FileRecord>();
        fileRecords.ToList();

        //Выводит в консоль список файлов, прочитанный из файла csv, отсортированный по дате изменения
        foreach (var item in fileRecords.OrderByDescending(item => item.LastChanges))
        {
            Console.WriteLine($"{item.Type}, {item.Title}, {item.Path}, {item.LastChanges}");
        }
    }

    //Удаляет файл %AppData%/Lesson12Homework.txt
    Directory.Delete(txtPath);
}
catch (DirectoryNotFoundException) { Console.WriteLine("Директорий не найден"); }
catch (FileNotFoundException) { Console.WriteLine("Файл не найден"); }
catch (InvalidDataException) { Console.WriteLine("Некоректные данные"); }
catch (System.UnauthorizedAccessException) { Console.WriteLine("Неавторизованный доступ"); }
catch (System.IO.IOException) { Console.WriteLine("Отказан доступ к данному пути"); }
catch (Exception ex) { Console.WriteLine("Неизвестная ошибка"); } //опять же,мне