namespace Console;
using NAudio.Wave;

public static class Audio
{
    public static readonly SoundManager Instance = new SoundManager();
}

public class SoundManager
{
    private WaveOutEvent _output;
    private AudioFileReader _reader;

    public void Play(string path)
    {
        if (!File.Exists(path))
        {
            System.Console.WriteLine($"[SoundManager] Fichier introuvable: {path}");
            return;
        }

        var audioFile = new AudioFileReader(path);
        var outputDevice = new DirectSoundOut(); // <-- ici

        outputDevice.Init(audioFile);
        outputDevice.Play();

        outputDevice.Dispose();
        audioFile.Dispose();
    }

    public void Stop()
    {
        _output?.Stop();
        _output?.Dispose();
        _reader?.Dispose();
    }
}
