namespace PoliticianCrusade
{
    public interface IWeapon
    {
        int RemainingPower { get; set; }
        int WearPerUse { get; }
        int Damage { get; }
    }
}
