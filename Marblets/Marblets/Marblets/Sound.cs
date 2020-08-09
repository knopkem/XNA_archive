#region File Description
//-----------------------------------------------------------------------------
// Sound.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Audio;
#endregion

namespace Marblets
{
    /// <summary>
    /// An enum for all of the Marblets sounds
    /// </summary>
    public enum SoundEntry
    {
        /// <summary>
        /// Title Screen music
        /// </summary>
        MusicTitle, 
        /// <summary>
        /// In game music
        /// </summary>
        MusicGame,
        /// <summary>
        /// GameOver
        /// </summary>
        MusicGameOver,
        /// <summary>
        /// Board cleared
        /// </summary>
        MusicBoardCleared,
        /// <summary>
        /// Start 3d game
        /// </summary>
        Menu3DStart, 
        /// <summary>
        /// Start 2d game
        /// </summary>
        Menu2DStart,
        /// <summary>
        /// Move cursor
        /// </summary>
        Navigate, 
        /// <summary>
        /// Clear Marbles
        /// </summary>
        ClearMarbles, 
        /// <summary>
        /// Illegal clear less than 2 marbles
        /// </summary>
        ClearIllegal, 
        /// <summary>
        /// Bonus sound for large clear
        /// </summary>
        ClearBonus,
        /// <summary>
        /// Marbles landing after breaking
        /// </summary>
        LandMarbles, 
    }

    /// <summary>
    /// Abstracts away the sounds for a simple interface using the Sounds enum
    /// </summary>
    public static class Sound
    {
        private static Dictionary<string, Cue> soundbank = new Dictionary<string, Cue>();
        private static Dictionary<string, string> soundmapper = new Dictionary<string, string>();

        private static string[] cueNames = new string[]
        {
            "Music_Title", //Title Screen
            "Music_Game", //In-Game Music
            "Music_GameOver", //Game Over
            "Music_BoardCleared", //Clear Board
            "Menu_3DStart", //Menu: 3D select (button press)
            "Menu_2DStart", //Menu: 2D select (button press)
            "Navigate", //In-Game Cursor Move
            "Clear_Marbles", //Clear  marbles (Press A)
            "Clear_Illegal", //Illegal clear (press A w/<2 marbles selected)
            "Clear_Bonus", //Large break bonus
            "Land_Marbles", //Marbles impact sound (after fall)

        };

        /// <summary>
        /// Plays a sound
        /// </summary>
        /// <param name="cueName">Which sound to play</param>
        /// <returns>XACT cue to be used if you want to stop this particular looped 
        /// sound. Can be ignored for one shot sounds</returns>
        public static Cue Play(string cueName)
        {

            Cue returnValue = null; 
            if (soundbank.TryGetValue(cueName, out returnValue))
                returnValue.Play();
            return returnValue;
        }

        /// <summary>
        /// Plays a sound
        /// </summary>
        /// <param name="sound">Which sound to play</param>
        /// <returns>XACT cue to be used if you want to stop this particular looped 
        /// sound. Can be ignored for one shot sounds</returns>
        public static Cue Play(SoundEntry sound)
        {
            return Play(cueNames[(int)sound]);
        }

        /// <summary>
        /// Stops a previously playing cue
        /// </summary>
        /// <param name="cue">The cue to stop that you got returned from Play(sound)
        /// </param>
        public static void Stop(Cue cue)
        {
            if (cue != null)
            {
                cue.Stop();
            }
        }

        /// <summary>
        /// Starts up the sound code
        /// </summary>
        public static void Initialize()
        {
            
            soundmapper["Music_Title"] = "IntroMus";
            soundmapper["Music_Game"] = "MusLoop_Temp1";
            soundmapper["Menu_3DStart"] = "start_3";
            soundmapper["Menu_2DStart"] = "start_1"; 
            soundmapper["Navigate"] = "navigate_1";
            soundmapper["Clear_Marbles"] = "clear_4";
            soundmapper["Clear_Illegal"] = "clear_illegal";
            soundmapper["Clear_Bonus"] = "clear_bonus";
            soundmapper["Land_Marbles"] = "drop1";


            foreach (var name in soundmapper)
            {
                soundbank[name.Key] = new Cue(MarbletsGame.Content.Load<SoundEffect>("Audio/" + name.Value));    
            }
                
                          
            
        }

        /// <summary>
        /// Shuts down the sound code tidily
        /// </summary>
        public static void Shutdown()
        {
        }
    }
}
