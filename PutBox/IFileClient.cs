namespace PutBox
{
    public interface IFileClient
    {
        void CreateDirectory(string newDirectory);
        void Delete(string deleteFile);
        string[] DirectoryListDetailed(string directory);
        string[] DirectoryListSimple(string directory);
        void Download(string remoteFile, string localFile);
        string GetFileCreatedDateTime(string fileName);
        string GetFileSize(string fileName);
        void Rename(string currentFileNameAndPath, string newFileName);
        void Upload(string remoteFile, string localFile);
    }
}