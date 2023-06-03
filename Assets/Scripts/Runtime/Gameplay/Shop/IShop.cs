using System.Collections.Generic;

namespace HumansVsAliens.Gameplay
{
    public interface IShop
    {
        IReadOnlyDictionary<IGood, IGoodData> Goods { get; }
    }
}