using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace ClassicPacMan
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SoundBank : GameComponent
    {
        #region SoundTitle enum

        public enum SoundTitle
        {
            NewGame,
            PacManEat1,
            PacManEat2,
            GhostNormalLoop1,
            GhostFastLoop,
            GhostVFastLoop,
            GhostRunningHome,
            GhostChased,
            Intro,
            NewLevel,
            FruitEat,
            EatGhost,
            Death,
            ExtraLife
        }

        #endregion

        private readonly Dictionary<SoundTitle, SoundEffect> audioDic = new Dictionary<SoundTitle, SoundEffect>();

        public SoundBank(Game game)
            : base(game)
        {
            AddSound(SoundTitle.NewGame, "newgame");
            AddSound(SoundTitle.PacManEat1, "eatpill1");
            AddSound(SoundTitle.PacManEat2, "eatpill2");
            AddSound(SoundTitle.GhostNormalLoop1, "bg1");
            AddSound(SoundTitle.GhostFastLoop, "bg2");
            AddSound(SoundTitle.GhostVFastLoop, "bg3");
            AddSound(SoundTitle.GhostRunningHome, "bgghosteyes");
            AddSound(SoundTitle.GhostChased, "bgghost");
            AddSound(SoundTitle.Intro, "newgame"); //????
            AddSound(SoundTitle.FruitEat, "eatfruit");
            AddSound(SoundTitle.EatGhost, "eatghost");
            AddSound(SoundTitle.Death, "killed");
            AddSound(SoundTitle.ExtraLife, "extralife");
        }

        private void AddSound(SoundTitle title, string name)
        {
            var sEff = Game.Content.Load<SoundEffect>("audio/" + name);
            audioDic.Add(title, sEff);
        }

        public void PlayCue(SoundTitle title)
        {
            SoundEffect effect;
            if (audioDic.TryGetValue(title, out effect))
                effect.Play();
        }

        public Cue GetCue(SoundTitle title)
        {
            SoundEffect effect;
            audioDic.TryGetValue(title, out effect);
            return new Cue(effect);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here


            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }
    }
}