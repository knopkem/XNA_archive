using Microsoft.Xna.Framework.Audio;

namespace Marblets
{
    public class Cue
    {
        private readonly SoundEffectInstance _effect;

        public Cue(SoundEffect effect)
        {
            _effect = effect.CreateInstance();
            IsPlaying = false;
        }

        public bool IsPlaying { get; set; }

        public void Play()
        {
            _effect.Play();
            IsPlaying = true;
        }

        public void Stop()
        {
            _effect.Stop();
            IsPlaying = false;
        }

        public void Resume()
        {
            _effect.Resume();
            IsPlaying = true;
        }

        public void Pause()
        {
            _effect.Pause();
            IsPlaying = false;
        }
    }
}