using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace BIMFM.Web.Models
{
    public class ModelVersion
    {
        public int Id { get; set; }
        public string VersionUid { get; set; }
        public string FileName { get; set; }
        public string FileExt { get; set; }
        public int FileSize { get; set; }
        public string FileHash { get; set; }
        public string SpUrl { get; set; }
        public string OssFileName { get; set; }
        public string OssUrn { get; set; }
        public string UploadSession { get; set; }
        public int IsUploaded { get; set; }
        public int IsTranslated { get; set; }
        public int IsDownloaded { get; set; }
        public int IsLastVersion { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int IsDel { get; set; }
        public string SvfUrn { get; set; }
        public int IsOnOss { get; set; }
    }
    public class ObjAsset
    {
        public string id { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class Utility
    {
        public static string GetFileSha1Hash(FileStream stream)
        {
            System.Security.Cryptography.SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] retVal = sha1.ComputeHash(stream);
            string sha1Code = BitConverter.ToString(retVal).Replace("-", string.Empty);
            return sha1Code;
        }
        public static List<T[]> SplitArray<T>(T[] data, int size)
        {
            List<T[]> list = new List<T[]>();
            for (int i = 0; i < data.Length / size; i++)
            {
                T[] r = new T[size];
                Array.Copy(data, i * size, r, 0, size);
                list.Add(r);
            }
            if (data.Length % size != 0)
            {
                T[] r = new T[data.Length % size];
                Array.Copy(data, data.Length - data.Length % size, r, 0, data.Length % size);
                list.Add(r);
            }
            return list;
        }



        public static void CopyDirectory(string sourceDirName, string destDirName)
        {
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
                File.SetAttributes(destDirName, File.GetAttributes(sourceDirName));

            }

            if (destDirName[destDirName.Length - 1] != Path.DirectorySeparatorChar)
                destDirName = destDirName + Path.DirectorySeparatorChar;

            string[] files = Directory.GetFiles(sourceDirName);
            foreach (string file in files)
            {
                if (File.Exists(destDirName + Path.GetFileName(file)))
                    continue;
                File.Copy(file, destDirName + Path.GetFileName(file), true);
                File.SetAttributes(destDirName + Path.GetFileName(file), FileAttributes.Normal);
                //total++;
            }

            string[] dirs = Directory.GetDirectories(sourceDirName);
            foreach (string dir in dirs)
            {
                CopyDirectory(dir, destDirName + Path.GetFileName(dir));
            }

        }
    }
}