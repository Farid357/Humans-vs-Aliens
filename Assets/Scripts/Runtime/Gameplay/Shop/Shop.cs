using System;
using System.Collections.Generic;

namespace HumansVsAliens.Gameplay
{
    public class Shop : IShop
    {
        private readonly Dictionary<IGood, IGoodData> _goods;

        public Shop(Dictionary<IGood, IGoodData> goods)
        {
            _goods = goods ?? throw new ArgumentNullException(nameof(goods));
        }

        public Shop() : this(new Dictionary<IGood, IGoodData>())
        {
            
        }

        public IReadOnlyDictionary<IGood, IGoodData> Goods => _goods;

        public void Add(IGood good, IGoodData data)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (data == null)
                throw new ArgumentNullException(nameof(data));

            _goods.Add(good, data);
        }
    }
}