namespace DILifetimeApp
{
    public interface IRule
    {
        bool IsActive { get; }
        void Disable();
        void Enable();
    }
}