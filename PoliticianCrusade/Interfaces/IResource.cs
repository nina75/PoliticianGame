namespace PoliticianCrusade
{
    public interface IResource
    {

        int CoordXOnScreen { get; }
        int CoordYOnScreen { get; }
        int RemainingPower { get; }
    }
}
