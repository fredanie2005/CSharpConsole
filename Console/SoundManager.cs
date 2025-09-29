using System;
using System.IO;
using NAudio.Wave;

namespace Console
{
    public static class Audio
    {
        public static readonly SoundManager Instance = new SoundManager();
    }

    public class SoundManager
    {
        private WaveOutEvent _output;
        private AudioFileReader _reader;
        private float _volume = 0.05f; 

        public float Volume
        {
            get => _volume;
            set
            {
                _volume = Math.Clamp(value, 0f, 1f);
                if (_reader != null)
                    _reader.Volume = _volume;
            }
        }
        
        public void Play(string path, bool loop = false)
        {
            Stop(); 

            if (!File.Exists(path))
            {
                System.Console.WriteLine($"[SoundManager] Fichier introuvable: {path}");
                return;
            }

            _reader = new AudioFileReader(path) { Volume = _volume };
            WaveStream playStream = _reader;

            if (loop)
                playStream = new LoopStream(_reader);

            _output = new WaveOutEvent();
            _output.Init(playStream);
            _output.Play();
        }

        public void Stop()
        {
            _output?.Stop();
            _output?.Dispose();
            _output = null;

            _reader?.Dispose();
            _reader = null;
        }
    }
    
    public class LoopStream : WaveStream
    {
        private readonly WaveStream _sourceStream;

        public LoopStream(WaveStream sourceStream)
        {
            _sourceStream = sourceStream;
        }

        public override WaveFormat WaveFormat => _sourceStream.WaveFormat;

        public override long Length => long.MaxValue;

        public override long Position
        {
            get => _sourceStream.Position;
            set => _sourceStream.Position = value;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalRead = 0;

            while (totalRead < count)
            {
                int read = _sourceStream.Read(buffer, offset + totalRead, count - totalRead);
                if (read == 0)
                {
                    _sourceStream.Position = 0;
                }
                totalRead += read;
            }

            return totalRead;
        }
    }
}
