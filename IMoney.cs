namespace MoneySumm
{
    public interface IMoney
    {
        double Sum { get; set; }
        string CodVal { get; set; }
        double CursUsd { get; set; }
   
        Money Add(Money money1);
        Money Calculate(Money money);        
    }
}
