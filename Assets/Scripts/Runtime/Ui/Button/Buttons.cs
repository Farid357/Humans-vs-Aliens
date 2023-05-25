using System;
using System.Collections.Generic;

namespace HumansVsAliens.UI
{
    public class Buttons : IButton
    {
        private readonly IReadOnlyList<IButton> _all;

        public Buttons(IReadOnlyList<IButton> all)
        {
            if (all.Count == 0) 
                throw new ArgumentException("Value cannot be an empty collection.", nameof(all));
            
            _all = all;
        }

        public void Press()
        {
            foreach (IButton button in _all)
            {
                button.Press();
            }
        }
    }
}