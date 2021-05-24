using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace PS2k.DemoDLCAssets {
    public class ConsoleDownloader : MonoBehaviour {
        [SerializeField] private AssetLabelReference sprites;

        #region Unity Messages
        private void Start() {
            Addressables.LoadAssetsAsync<Sprite>(sprites, null).Completed += OnLoadedSprites;
        }
        #endregion

        private void OnLoadedSprites(AsyncOperationHandle<IList<Sprite>> operation) {
            IList<Sprite> sprites = operation.Result;
            if (sprites == null) {
                Debug.LogWarning("No sprites found!");
                return;
            }
            foreach (Sprite s in sprites)
                Debug.Log("Sprite " + s + " found in list!");
        }
    }
}
