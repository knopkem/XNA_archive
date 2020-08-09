

namespace ComponentPacMan.Components
{
    public enum ComponentType
    {
        Position,
        Movement,
        Sprite,
        SpriteComposition,
        SpriteAnimationComponent,
        Collison,
        GhostState,
        Grid,
        Path
    }

    interface IComponent
    {
        ComponentType ComponentType { get; }
    }
}
