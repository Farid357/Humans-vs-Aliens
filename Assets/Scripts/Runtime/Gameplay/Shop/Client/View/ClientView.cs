using TMPro;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class ClientView : MonoBehaviour, IClientView
    {
        [SerializeField] private TMP_Text _goodDescription;
        [SerializeField] private TMP_Text _goodName;
        [SerializeField] private TMP_Text _goodPrice;

        public void BuyGood(IGoodViewData goodData)
        {
            Debug.Log($"Client have bought good {goodData.Name}");
        }

        public void SelectGood(IGoodViewData goodData, int price)
        {
            _goodDescription.text = goodData.Description;
            _goodName.text = goodData.Name;
            _goodPrice.text = price.ToString();
        }
    }
}