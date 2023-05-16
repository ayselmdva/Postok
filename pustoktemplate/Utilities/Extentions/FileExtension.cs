namespace pustoktemplate.Utilities.Extentions
{
    public static class FileExtension
    {
        public static bool CheckFiletype(this IFormFile file,string type)
        {
           return  file.ContentType.Contains(type);
        }
        public static bool CheckFileSize(this IFormFile file, int size)
        {
            return file.Length / 1024 > size;
        }
        public static async Task<string> SaveFileAsync(this IFormFile file, string root, string mainpath)
        {
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string path = Path.Combine(root,  "image", mainpath, uniqueFileName);
            FileStream stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            return uniqueFileName;

        }
        public static void DeleteFile(this IFormFile file, string root, string mainPath, string fileName)
        {
            string path = Path.Combine(root, "assets", "imgs", mainPath, fileName);
            using FileStream stream = new FileStream(path, FileMode.Open);
            if (File.Exists(path))
            {
                stream.Close();
                File.Delete(path);
            }
        }
    }
}
