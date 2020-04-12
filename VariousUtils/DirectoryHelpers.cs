using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using LogUtils.Net;
using System.IO;

namespace VariousUtils {

    public static class DirectoryHelpers {

        #region Data

        private static ClassLog log = new ClassLog("DirectoryHelpers");

        #endregion


        public static bool CreateStorageDir(string dir) {
            ErrReport report;
            WrapErr.ToErrReport(out report, 9999,
                () => string.Format("Failed to create directory '{0}'", dir),
                () => {
                    log.Info("CreateStorageDir", () => string.Format("Checking to create:{0}", dir));
                    WrapErr.ChkTrue(dir.Length > 0, 9999, "0 length directory path");
                    if (!Directory.Exists(dir)) {
                        Directory.CreateDirectory(dir);
                    }
                });
            return report.Code == 0;
        }



        /// <summary>Delete the directory and all files that it contains</summary>
        /// <param name="dir">The directory name</param>
        public static bool DeleteDirectory(string dir) {
            ErrReport report;
            WrapErr.ToErrReport(out report, 9999,
                () => string.Format("Failed to delete directory '{0}'", dir), () => {
                    if (Directory.Exists(dir)) {
                        FileHelpers.DeleteFiles(dir, "*.*");
                        Directory.Delete(dir);
                    }
                });
            return report.Code == 0;
        }


    }
}
