using System.Threading.Tasks;
using UnityEngine;

namespace HumansVsAliens.View
{
    public interface IBladedWeaponView : IBladedWeaponActivityView
    {
        Task Hit();
     
        Vector3 Position { get; }
    }
}