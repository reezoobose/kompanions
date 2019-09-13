using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Script
{
    public class Restart : MonoBehaviour
    {
        public void LoadScene()
        {
            var currentSceneIndex = SceneManager.sceneCount - 1;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
