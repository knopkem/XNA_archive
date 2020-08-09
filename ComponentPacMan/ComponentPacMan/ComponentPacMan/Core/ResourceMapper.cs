using System.Collections.Generic;

namespace ComponentPacMan.Core
{
    public enum ESprites{
        Board,
        BoardFlash,
        Crump,
        DyingSheetNew,
        ExtraLife,
        GhostBase,
        GhostBase2,
        GhostChased,
        GhostEyes,
        GhostEyesCenter,
        PacManEating1,
        PacManEating2,
        PacManEating3,
        PacManEating4,
        PacManEating5,
        PacManEating6,
        PacManEating7,
        PacManEating8,
        PacManEating9,
        PowerPill,
        Selection,
        Title
    }

    public enum EBonusSprites{
        Apple,
        Banana,
        Bell,
        Cherry,
        Key,
        Orange,
        Pear,
        Pretzel,
        Strawberry
    }

    public static class ResourceMapper
    {
        private static Dictionary<EBonusSprites, string> _bonus = new Dictionary<EBonusSprites, string>();
        private static Dictionary<ESprites, string> _sprites = new Dictionary<ESprites, string>();

        static ResourceMapper()
        {
            // init sprites
            string spriteFolder = "Sprites/";
            _sprites.Add(ESprites.Board, spriteFolder + "Board");
            _sprites.Add(ESprites.BoardFlash, spriteFolder + "BoardFlash");
            _sprites.Add(ESprites.Crump, spriteFolder + "Crump");
            _sprites.Add(ESprites.DyingSheetNew, spriteFolder + "DyingSheetNew");
            _sprites.Add(ESprites.ExtraLife, spriteFolder + "ExtraLife");
            _sprites.Add(ESprites.GhostBase, spriteFolder + "GhostBase");
            _sprites.Add(ESprites.GhostBase2, spriteFolder + "GhostBase2");
            _sprites.Add(ESprites.GhostChased, spriteFolder + "GhostChased");
            _sprites.Add(ESprites.GhostEyes, spriteFolder + "GhostEyes");
            _sprites.Add(ESprites.GhostEyesCenter, spriteFolder + "GhostEyesCenter");
            _sprites.Add(ESprites.PacManEating1, spriteFolder + "PacManEating1");
            _sprites.Add(ESprites.PacManEating2, spriteFolder + "PacManEating2");
            _sprites.Add(ESprites.PacManEating3, spriteFolder + "PacManEating3");
            _sprites.Add(ESprites.PacManEating4, spriteFolder + "PacManEating4");
            _sprites.Add(ESprites.PacManEating5, spriteFolder + "PacManEating5");
            _sprites.Add(ESprites.PacManEating6, spriteFolder + "PacManEating6");
            _sprites.Add(ESprites.PacManEating7, spriteFolder + "PacManEating7");
            _sprites.Add(ESprites.PacManEating8, spriteFolder + "PacManEating8");
            _sprites.Add(ESprites.PacManEating9, spriteFolder + "PacManEating9");
            _sprites.Add(ESprites.PowerPill, spriteFolder + "PowerPill");
            _sprites.Add(ESprites.Selection, spriteFolder + "Selection");
            _sprites.Add(ESprites.Title, spriteFolder + "Title");

            string bonusFolder = "Bonus/";
            _bonus.Add(EBonusSprites.Apple, bonusFolder + "Apple");
            _bonus.Add(EBonusSprites.Banana, bonusFolder + "Banana");
            _bonus.Add(EBonusSprites.Bell, bonusFolder + "Bell");
            _bonus.Add(EBonusSprites.Cherry, bonusFolder + "Cherry");
            _bonus.Add(EBonusSprites.Key, bonusFolder + "Key");
            _bonus.Add(EBonusSprites.Orange, bonusFolder + "Orange");
            _bonus.Add(EBonusSprites.Pear, bonusFolder + "Pear");
            _bonus.Add(EBonusSprites.Pretzel, bonusFolder + "Pretzel");
            _bonus.Add(EBonusSprites.Strawberry, bonusFolder + "Strawberry");
        }

        public static string SpriteName(ESprites sprite)
        {
            string name;
            _sprites.TryGetValue(sprite, out name);
            return name;
        }

        public static string BonusSpriteName(EBonusSprites bonus)
        {
            string name;
            _bonus.TryGetValue(bonus, out name);
            return name;
        }
    }
}
