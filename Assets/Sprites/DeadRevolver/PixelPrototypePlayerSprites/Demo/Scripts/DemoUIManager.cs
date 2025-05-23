using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DeadRevolver.PixelPrototypePlayer
{
    public class DemoUIManager : MonoBehaviour
    {
        public TextMeshProUGUI label;
        public TextMeshProUGUI indexLabel;

        public void OnAnimationChanged(
            PlayerPreviewAnimation animation,
            int currentAnimation,
            List<PlayerPreviewAnimation> animations
        )
        {
            label.text = animation.name.ToUpper();
            indexLabel.text = (currentAnimation + 1) + " / " + animations.Count;
        }
    }
}
