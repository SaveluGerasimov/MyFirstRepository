using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;

interface ICommand
{
    Task ExecuteAsync();
}

// Команда для получения информации о видео
class InfoCommand : ICommand
{
    private readonly YoutubeClient _client;
    private readonly string _videoUrl;

    public InfoCommand(YoutubeClient client, string videoUrl)
    {
        _client = client;
        _videoUrl = videoUrl;
    }

    public async Task ExecuteAsync()
    {
        var video = await _client.Videos.GetAsync(_videoUrl);
        Console.WriteLine("Название видео: " + video.Title);
        Console.WriteLine("Описание видео: " + video.Description);
    }
}

// Команда для загрузки видео
class DownloadCommand : ICommand
{
    private readonly YoutubeClient _client;
    private readonly string _videoUrl;
    private readonly string _outputFile;

    public DownloadCommand(YoutubeClient client, string videoUrl, string outputFile)
    {
        _client = client;
        _videoUrl = videoUrl;
        _outputFile = outputFile;
    }

    public async Task ExecuteAsync()
    {
        Console.WriteLine("Загрузка начата...");
        await _client.Videos.DownloadAsync(
            _videoUrl, 
            _outputFile, 
            builder => builder.SetPreset(YoutubeExplode.Converter.ConversionPreset.UltraFast));
        Console.WriteLine($"Видео скачано в файл: {_outputFile}");
    }
}

// Инвойсер/Пульт управления командами
class Pult
{
    private ICommand _infoCommand;
    private ICommand _downloadCommand;

    public void SetInfoCommand(ICommand command)
    {
        _infoCommand = command;
    }

    public void SetDownloadCommand(ICommand command)
    {
        _downloadCommand = command;
    }

    public async Task ShowInfo()
    {
        if (_infoCommand != null)
            await _infoCommand.ExecuteAsync();
        else
            Console.WriteLine("Команда вывода информации не установлена.");
    }

    public async Task DownloadVideo()
    {
        if (_downloadCommand != null)
            await _downloadCommand.ExecuteAsync();
        else
            Console.WriteLine("Команда скачивания не установлена.");
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Введите ссылку на YouTube видео:");
        string url = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(url))
        {
            Console.WriteLine("Ссылка не может быть пустой.");
            return;
        }

        var youtubeClient = new YoutubeClient();

        var pult = new Pult();

        // Формируем имя файла для скачивания на основании ID видео
        var videoId = YoutubeExplode.Videos.VideoId.Parse(url);
        string outputFileName = $"{videoId}.mp4";

        // Устанавливаем команды
        pult.SetInfoCommand(new InfoCommand(youtubeClient, url));
        pult.SetDownloadCommand(new DownloadCommand(youtubeClient, url, outputFileName));

        try
        {
            // Выполняем команды
            await pult.ShowInfo();
            Console.WriteLine();
            Console.WriteLine("Начинаем скачивание видео...");
            await pult.DownloadVideo();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }

        Console.WriteLine("Завершено. Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
