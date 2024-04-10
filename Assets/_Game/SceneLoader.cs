using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Game
{
    public class SceneLoader
    {
        public void ReloadCurrentScene()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        
        public async Task<Scene> LoadResultsScene()
            => await LoadSceneSingle(GlobalSettings.ResultsSceneName);
        
        private async Task<Scene> LoadSceneAdditive(string scenePath)
        {
            await SceneManager.LoadSceneAsync(scenePath, LoadSceneMode.Additive);
            Scene scene = SceneManager.GetSceneByPath(scenePath);
            SceneManager.SetActiveScene(scene);
            return scene;
        }

        private async Task<Scene> LoadSceneSingle(string scenePath)
        {
            await SceneManager.LoadSceneAsync(scenePath, LoadSceneMode.Single);
            return SceneManager.GetSceneByPath(scenePath);
        }

        private async Task UnloadScene(string scenePath)
        {
            await SceneManager.UnloadSceneAsync(scenePath);
        }
    }
}

