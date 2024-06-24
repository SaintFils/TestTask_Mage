using UnityEngine;
using UnityEngine.UI;

namespace Client.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image image;

        public void SetValue(float current, float max) => image.fillAmount = current / max;
    }
}