namespace PoliticianCrusade
{
    public interface IResource
    {
        int RemainingPower { get; set; }
        int WearPerUse { get; }
        ResourceType Type { get; }
    }
}
