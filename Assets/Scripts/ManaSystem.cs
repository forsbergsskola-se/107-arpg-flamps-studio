public class ManaSystem
{
    private int manaCurrent;

    public ManaSystem(int manaCurrent)
    {
        this.manaCurrent = manaCurrent;
    }

    public int GetMana()
    {
        return manaCurrent;
    }

    public void manaUsed(int manaCost)
    {
        manaCurrent -= manaCost;
    }

    public void manaRefill(int manaTopUp)
    {
        manaCurrent += manaTopUp;
    }
}
