using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace PS2k.DemoDLCAssets {
    public class AssetBundleChecker : MonoBehaviour {
        [TextArea]
        [SerializeField] private string bundleURL = "";

        #region Unity Messages
        private void Start() {
            StartCoroutine(DownloadBundle());
        }
        #endregion

        private IEnumerator DownloadBundle() {
            using (UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(bundleURL)) {
                UnityWebRequestAsyncOperation operation = request.SendWebRequest();
                yield return operation;

                if (request.result != UnityWebRequest.Result.Success) {
                    Debug.LogError(request.error);
                    yield break;
                }

                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
                Debug.Log("bundle = " + bundle);

                string[] assetNames = bundle.GetAllAssetNames();
                Debug.Log("It contains " + assetNames.Length + " assets!");
                for (int i = 0; i < assetNames.Length; i++)
                    Debug.Log("assetNames[" + i + "] = " + assetNames[i]);
            }
        }
    }
}
