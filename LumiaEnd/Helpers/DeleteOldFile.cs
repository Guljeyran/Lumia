namespace LumiaEnd.Helpers
{
    public static class DeleteOldFile
    {
        public static void DeleteOld(this string fileName, string rootPath, string folderName)
        {
            string path = Path.Combine(rootPath, folderName, fileName);
            FileInfo fileInfo = new(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }
    }
}
