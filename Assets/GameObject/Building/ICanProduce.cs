using System.Collections.Generic;

public interface ICanProduce
{
    void Produce(UnitSO unit);
    ProduceBuildingSO GetProduceSO();
}
