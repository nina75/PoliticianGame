namespace PoliticianCrusade
{
    public interface IResource
    {
        int RemainingPower { get; }

        ResourceType Type { get; }
    }
}
