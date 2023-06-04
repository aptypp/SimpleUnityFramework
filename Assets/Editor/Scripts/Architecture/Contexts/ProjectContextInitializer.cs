using System.IO;
using Architecture.Architecture.Contexts;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Editor.Editor.Scripts.Architecture.Contexts
{
    public class ProjectContextInitializer
    {
        [RuntimeInitializeOnLoadMethod]
        private static void LoadResourcesFoldersByStartPlayingMode()
        {
            ProjectContext projectContext = Resources.Load<ProjectContext>(nameof(ProjectContext));

            projectContext.SetResourcesDirectories(GetResourcesDirectories());
        }

        [PostProcessBuild]
        private static void LoadResourcesFoldersByStartBuild(BuildTarget target, string pathToBuiltProject)
        {
            ProjectContext projectContext = Resources.Load<ProjectContext>(nameof(ProjectContext));

            projectContext.SetResourcesDirectories(GetResourcesDirectories());
        }

        private static string[] GetResourcesDirectories()
        {
            string resourcesPath = $"{Application.dataPath}/Resources";

            string[] fullDirectories = Directory.GetDirectories(resourcesPath, "*", SearchOption.AllDirectories);
            string[] resultDirectories = new string[fullDirectories.Length + 1];

            for (int directoryIndex = 0; directoryIndex < fullDirectories.Length; directoryIndex++)
            {
                resultDirectories[directoryIndex] = fullDirectories[directoryIndex].Substring(resourcesPath.Length + 1);
            }

            resultDirectories[^1] = string.Empty;

            return resultDirectories;
        }
    }
}