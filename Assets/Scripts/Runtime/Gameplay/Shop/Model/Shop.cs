using System;
using System.Collections.Generic;

namespace HumansVsAliens.Gameplay
{
    public class Shop : IShop
    {
        private readonly IDictionary<IGood, IGoodData> _goods;
        
        public Shop()
        {
            _goods = new Dictionary<IGood, IGoodData>();
        }

        public IGoodViewData GetData(IGood good)
        {
            return _goods[good];
        }

        public int CalculatePrice(IGood good)
        {
            return _goods[good].Price;
        }

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