using System;
using System.IO;
using RemObjects.InternetPack;

namespace RemObjects.InternetPack.Ftp.VirtualFtp
{
	/// <summary>
	/// Summary description for DiscFile.
	/// </summary>
	public class DiscFile : FtpFile
	{
    public DiscFile(IFtpFolder aParent, string aName, string aLocalPath) : base(aParent, aName)
    {
      fLocalPath = aLocalPath;
      WorldRead = true;
    }

    private string fLocalPath;

    public override DateTime Date 
    const int BUFFER_SIZE = 64*1024;

    public override void GetFile(Stream aToStream)
        throw new Exception("Error retrieving file from disk: file does not exist.");
      
      Stream lStream = new FileStream(LocalPath, FileMode.Open, FileAccess.Read, FileShare.Read); 
      try
      {
        byte[] lBuffer = new byte[BUFFER_SIZE];
        
        int lBytesRead = lStream.Read(lBuffer, 0, BUFFER_SIZE);
        while (lBytesRead > 0)
        }
      }
      finally
      {
        lStream.Close();
      }
    }
        throw new Exception("Error savinf file to disk: file already exist.");
      
      Stream lStream = new FileStream(LocalPath, FileMode.CreateNew, FileAccess.Write, FileShare.None);
      try
      {

        byte[] lBuffer = new byte[BUFFER_SIZE];
        
        int lBytesRead = aStream.Read(lBuffer, 0, BUFFER_SIZE);
        while (lBytesRead > 0)
        }
        /* ToDo: eliminate one call to receive by checking for lBytesRead == BUFFER_SIZE? */
        lStream.Close();
        Complete = true;
      }
      catch (ConnectionClosedException)
      {
        lStream.Close();
        Complete = true;
      }
      catch (Exception)
      {
        lStream.Close();
        File.Delete(LocalPath);
        throw;
      }

    }
	}
}