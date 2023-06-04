using Architecture.Architecture.ContextObjects;
using Architecture.Architecture.Repositories;
using UnityEngine;

namespace Architecture.Architecture.Contexts
{
    [CreateAssetMenu(fileName = nameof(ProjectContext), menuName = "Architecture/Contexts/" + nameof(ProjectContext))]
    public class ProjectContext : ScriptableObject
    {
        [HideInInspector] [SerializeField] private string[] _resourcesFolders;

#if UNITY_EDITOR
        public void SetResourcesDirectories(string[] directories) => _resourcesFolders = directories;
#endif

        [RuntimeInitializeOnLoadMethod]
        private static void RegisterObjects()
        {
            ProjectContext projectContext = Resources.Load<ProjectContext>("ProjectContext");

            for (int folderIndex = 0; folderIndex < projectContext._resourcesFolders.Length; folderIndex++)
            {
                ProjectObject[] projectObjects = Resources.LoadAll<ProjectObject>(projectContext._resourcesFolders[folderIndex]);

                for (int objectIndex = 0; objectIndex < projectObjects.Length; objectIndex++)
                {
                    ProjectObjects.Register(projectObjects[objectIndex].GetType(), projectObjects[objectIndex]);
                }
            }
        }
    }
}