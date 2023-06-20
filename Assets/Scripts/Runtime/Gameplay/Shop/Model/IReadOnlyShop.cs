using System.Collections.Generic;

namespace HumansVsAliens.Gameplay
{
    public interface IReadOnlyShop
    {
        IReadOnlyList<IGood> Goods { get; }

        IGoodViewData GetData(IGood good);

        int CalculatePrice(IGood good);
    }
}