

namespace ComponentPacMan.Components
{
    class GhostStateComponent : IComponent
    {
        public enum EGhostState
        {
            Scattering,
            Attacking,
            Frightened,
            Dead
        }

        public ComponentType ComponentType { get { return ComponentType.GhostState; } }

        public EGhostState State { get; set; }
    }
}
