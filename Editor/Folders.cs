using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;

namespace Wyczyn
{
    public static class Folders
    {
        public static void CreateDirectories(string root, params string[] dir)
        {
            string fullPath = Combine(dataPath, root);
            foreach (string dirName in dir)
            {
                CreateDirectory(Combine(fullPath, dirName));
            }
        }
    }
}
