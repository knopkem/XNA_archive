using Microsoft.Xna.Framework;

namespace ClassicPacMan
{
    /// <summary>
    /// All four ghosts use the same sounds, and only one can be played at a time. So, instead of having to
    /// synchronize each other, they use this class.
    /// </summary>
    internal static class GhostSoundsManager
    {
        private static SoundBank soundBank_;
        private static Cue loopAttack_;
        private static Cue loopAttackFast_;
        private static Cue loopAttackVeryFast_;
        private static Cue loopBlue_;
        private static Cue loopDead_;

        public static void Init(Game game)
        {
            soundBank_ = (SoundBank) game.Services.GetService(typeof (SoundBank));
            InitCues();
        }

        public static void playLoopAttack()
        {
            playLoop(ref loopAttack_);
        }

        public static void playLoopAttackFast()
        {
            playLoop(ref loopAttackFast_);
        }

        public static void playLoopAttackVeryFast()
        {
            playLoop(ref loopAttackVeryFast_);
        }

        public static void playLoopBlue()
        {
            playLoop(ref loopBlue_);
        }

        public static void playLoopDead()
        {
            playLoop(ref loopDead_);
        }


        private static void playLoop(ref Cue cue)
        {
            if (!cue.IsPlaying)
            {
                StopLoops();
                InitCues();
                cue.Play();
            }
        }

        private static void InitCues()
        {
            loopAttack_ = soundBank_.GetCue(SoundBank.SoundTitle.GhostNormalLoop1);
            loopAttackFast_ = soundBank_.GetCue(SoundBank.SoundTitle.GhostFastLoop);
            loopAttackVeryFast_ = soundBank_.GetCue(SoundBank.SoundTitle.GhostVFastLoop);
            loopDead_ = soundBank_.GetCue(SoundBank.SoundTitle.GhostRunningHome);
            loopBlue_ = soundBank_.GetCue(SoundBank.SoundTitle.GhostChased);
        }

        public static void StopLoops()
        {
            loopAttack_.Stop();
            loopAttackFast_.Stop();
            loopAttackVeryFast_.Stop();
            loopDead_.Stop();
            loopBlue_.Stop();
        }

        public static void PauseLoops()
        {
            loopAttack_.Pause();
            loopAttackFast_.Pause();
            loopAttackVeryFast_.Pause();
            loopDead_.Pause();
            loopBlue_.Pause();
        }

        public static void ResumeLoops()
        {
            loopAttack_.Resume();
            loopAttackFast_.Resume();
            loopAttackVeryFast_.Resume();
            loopDead_.Resume();
            loopBlue_.Resume();
        }
    }
}