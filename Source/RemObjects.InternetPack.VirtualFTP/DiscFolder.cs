using System;
using System.IO;
using System.Collections;

namespace RemObjects.InternetPack.Ftp.VirtualFtp
{

  public class DiscFolder : FtpFolder
  {
    public DiscFolder(IFtpFolder aParent, string aName, string aLocalPath) : base(aParent, aName)
    {
      fLocalPath = aLocalPath;
      WorldRead = true;
      WorldWrite = true;
    }

    

    public override IEnumerable SubFolders { get { return null; } }
      foreach (string s in lNames)
      {
        FtpListingItem lListingItem = aListing.Add();
        lListingItem.Directory = true;
        lListingItem.FileName = Path.GetFileName(s);
        lListingItem.FileDate = Directory.GetLastWriteTime(Path.Combine(LocalPath,s));
        lListingItem.Size = 0;
        lListingItem.User = "system";
        lListingItem.Group = "system";
        lListingItem.UserRead = UserRead;
        lListingItem.UserWrite = UserWrite;
        lListingItem.UserExec = UserRead;
        lListingItem.GroupRead = GroupRead;
        lListingItem.GroupWrite = GroupWrite;
        lListingItem.GroupExec = GroupRead;
        lListingItem.OtherRead = WorldRead;
        lListingItem.OtherWrite = WorldWrite;
        lListingItem.OtherExec = WorldRead;
      }

      DirectoryInfo lDirectory = new DirectoryInfo(LocalPath);
      FileInfo[] lFiles = lDirectory.GetFiles();
      foreach (FileInfo fi in lFiles)
      {
        FtpListingItem lListingItem = aListing.Add();
        lListingItem.Directory = false;
        lListingItem.FileName = fi.Name;
        lListingItem.FileDate = fi.LastWriteTime;
        lListingItem.Size = fi.Length;
        lListingItem.User = "system";
        lListingItem.Group = "system";
        lListingItem.UserRead = UserRead;
        lListingItem.UserWrite = UserWrite;
        lListingItem.UserExec = false;
        lListingItem.GroupRead = GroupRead;
        lListingItem.GroupWrite = GroupWrite;
        lListingItem.GroupExec = false;
        lListingItem.OtherRead = WorldRead;
        lListingItem.OtherWrite = WorldWrite;
        lListingItem.OtherExec = false;
      }

      AddListingItems(aListing, SubFolders);
      AddListingItems(aListing, Files);
    }
        throw new FtpException(550, String.Format("Cannot access folder \"{0}\", permission to access items in this folder denied.",aFolderName));
      if (!HasSubfolder(aFolderName))
        throw new FtpException(550, String.Format("A folder named \"{0}\" does not exist.",aFolderName));

      return new DiscFolder(this, aFolderName, Path.Combine(LocalPath,aFolderName));
    }
        throw new FtpException(550, String.Format("Cannot create folder \"{0}\", permission to mkdir in this folder denied.",aFolderName));
        throw new FtpException(550, String.Format("A folder named \"{0}\" already exist.",aFolderName));

        throw new FtpException(550, String.Format("Cannot delete folder \"{0}\", permission to delete from this folder denied.",aFolderName));
        throw new FtpException(550, String.Format("A folder named \"{0}\" does not exist.",aFolderName));

        throw new FtpException(550, String.Format("Cannot retrieve file \"{0}\", permission to get files from this folder denied.",aFilename));
        throw new FtpException(550, String.Format("A file named \"{0}\" does not exist.",aFilename));

        throw new FtpException(550, String.Format("Cannot upload file \"{0}\", permission to upload files to this folder denied.",aFilename));
        throw new FtpException(550, String.Format("A file named \"{0}\" already exist.",aFilename));

    public override void DeleteFile(string aFilename, VirtualFtpSession aSession)
        throw new FtpException(550, String.Format("Cannot delete file \"{0}\", permission to delete from this folder denied.",aFilename));
        throw new FtpException(550, String.Format("A file named \"{0}\" does not exist.",aFilename));

    public override bool Invalid { get { return !Directory.Exists(LocalPath); } }
    
  }

}