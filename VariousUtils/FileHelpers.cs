using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using LogUtils.Net;

namespace VariousUtils.Net {

    public static class FileHelpers {

        #region Data

        //private readonly static ClassLog log = new ("FileHelpers");

        #endregion


        /// <summary>Flip all slashes back or forth for cross-platform compatibility</summary>
        /// <param name="pathString">The path string to convert</param>
        /// <returns>The converted string</returns>
        public static string ConvertSlashes(string pathString) {
            WrapErr.ChkTrue(pathString.Length > 0, 9999, "Empty path string not allowed");
            return WrapErr.ToErrorReportException(9999, "Failed to flip slashes", () => {
                // Cover all bases by converting forward or back slashes to OS specific
                string tmp = pathString.Replace('\\', Path.DirectorySeparatorChar);
                return tmp.Replace('/', Path.DirectorySeparatorChar);
            });
        }


        /// <summary>Remove any leading or trailing '/' or '\' from path string</summary>
        /// <remarks>Path.Combine needs these off before combining</remarks>
        /// <param name="pathString">The path string to clean</param>
        /// <returns>The cleaned path string</returns>
        public static string CleanLeadAndTrailingSlashes(string pathString) {
            string tmp = pathString;
            if (tmp.StartsWith(Path.PathSeparator.ToString())) {
                tmp = tmp.Remove(0, 1);
                WrapErr.ChkTrue(tmp.Length > 0, 9999, () => string.Format("Empty path '{0}'", pathString));
            }
            if (tmp.EndsWith(Path.PathSeparator.ToString())) {
                tmp = tmp.Remove(tmp.Length - 1, 1);
                WrapErr.ChkTrue(tmp.Length > 0, 9999, () => string.Format("Empty path '{0}'", pathString));
            }
            return tmp;
        }


        /// <summary>Combine full path and file name</summary>
        /// <param name="fileName">The file name to add</param>
        /// <returns>The full file name including path</returns>
        public static string GetFullFileName(string path, string fileName) {
            return Path.Combine(path, fileName);
        }



        /// <summary>Delete named file</summary>
        /// <param name="filename">The full path and file name to delete</param>
        /// <returns>true on success, otherwise false</returns>
        public static bool DeleteFile(string fullFileName) {
            WrapErr.ToErrReport(out ErrReport report, 9999,
                () => string.Format("Failed to delete: {0}", fullFileName),
                () => {
                    if (File.Exists(fullFileName)) {
                        File.Delete(fullFileName);
                    }
                });
            return report.Code == 0;
        }


        /// <summary>Delete file</summary>
        /// <param name="path">File path</param>
        /// <param name="fileName">File name</param>
        /// <returns>true on success, otherwise false</returns>
        public static bool DeleteFile(string path, string fileName) {
            return FileHelpers.DeleteFile(GetFullFileName(path, fileName));
        }


        /// <summary>Delete files in the directory according to the pattern</summary>
        /// <param name="path">The path of the directory which contains the file to delete</param>
        /// <param name="pattern">The pattern such as '*.txt' to delete</param>
        /// <returns>true on success, otherwise false</returns>
        public static bool DeleteFiles(string path, string pattern) {
            WrapErr.ToErrReport(out ErrReport report, 9999,
                () => string.Format("Failed to delete files in {0} with pattern '{1}'", path, pattern),
                () => {
                    if (Directory.Exists(path)) {
                        foreach (string file in Directory.GetFiles(path, pattern)) {
                            File.Delete(Path.Combine(path, file));
                        }
                    }
                });
            return report.Code == 0;
        }


        public static List<string> GetFileList(string dir, bool includePath = false) {
            List<string> results = new ();
            WrapErr.ToErrReport(out ErrReport report, 9999,
                () => string.Format("Failed to get file list from '{0}'", dir),
                () => {
                    if (Directory.Exists(dir)) {
                        foreach (string file in Directory.GetFiles(dir)) {
                            if (includePath) {
                                results.Add(file);
                            }
                            else {
                                results.Add(Path.GetFileName(file));
                            }
                        }
                    }
                });
            return results;
        }


    }
}
