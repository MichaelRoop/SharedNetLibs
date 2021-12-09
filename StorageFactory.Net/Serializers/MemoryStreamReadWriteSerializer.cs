using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using StorageFactory.Net.interfaces;

namespace StorageFactory.Net.Serializers {

    /// <summary>
    /// Useful if you want to write objects, like image files that can be converted 
    /// into a byte array to a file
    /// /// </summary>
    public class MemoryStreamReadWriteSerializer : IReadWriteSerializer<MemoryStream> {


        /// <summary>Get the value in the inputStream and store it to a MemoryStream</summary>
        /// <remarks>The caller is responsible to dispose the MemoryStream returned</remarks>
        /// <param name="inputStream">The input stream read in fromm file</param>
        /// <returns>The built MemoryStream with contents of the input stream</returns>
        public MemoryStream Deserialize(Stream inputStream) {
            MemoryStream result = WrapErr.ToErrReport(out ErrReport report, 9999,
                () => string.Format("Failed to copy inputStream to MemoryStream"),
                () => {
                    // Pass ownership to the caller
                    MemoryStream memStream = new ((int)inputStream.Length);
                    inputStream.CopyTo(memStream);
                    return memStream;
                });
            return report.Code == 0 ? result : new MemoryStream();
        }


        /// <summary>Copy the contents of the input Memory Stream to the file output stream</summary>
        /// <param name="inputMemStream">The input stream to write out</param>
        /// <param name="outputStream">The stream that returns the output</param>
        /// <returns>true on success, otherwise false</returns>
        public bool Serialize(MemoryStream inputMemStream, Stream outputStream) {
            WrapErr.ToErrReport(out ErrReport report, 9999,
                () => string.Format("Failed to serialize MemoryStream to outputStream"),
                () => {
                    inputMemStream.WriteTo(outputStream);
                });
            return report.Code == 0;
        }
    }
}
