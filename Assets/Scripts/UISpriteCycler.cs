using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PS2k.DemoDLCAssets {
    public class UISpriteCycler : MonoBehaviour {
        [SerializeField] private Image target;

        [Min(0.01f)]
        [SerializeField] private float interval = 0.2f;

        [SerializeField] private List<Sprite> sprites = new List<Sprite>();

        private int index = 0;

        #region Unity Messages
        private void Reset() {
            target = GetComponent<Image>();
        }

        private void OnEnable() {
            index = 0;
            StartCoroutine(SpriteCycle());
        }
        #endregion

        public void SetSprites(IEnumerable<Sprite> sprites) {
            this.sprites = sprites == null ? new List<Sprite>() : new List<Sprite>(sprites);
            index = 0;
        }

        private IEnumerator SpriteCycle() {
            float interval = this.interval;
            YieldInstruction wait = new WaitForSeconds(interval);

            while (isActiveAndEnabled) {
                Sprite next = null;
                if (sprites.Count > 0) {
                    next = sprites[index];
                    index = (index + 1) % sprites.Count;
                }
                if (target != null)
                    target.sprite = next;

                if (interval != this.interval) {
                    interval = this.interval;
                    wait = new WaitForSeconds(interval);
                }
                yield return wait;
            }
        }
    }
}
