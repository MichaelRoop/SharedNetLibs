using ChkUtils.Net.ErrObjects;
using ChkUtils.Net.Interfaces;
using System.Diagnostics;
using System.Reflection;

namespace ChkUtils.Net {

    /// <summary>Common Methods to work through an exception stack frame</summary>
    /// <author>Michael Roop</author>
    /// <copyright>July 2020 Michael Roop Used by permission</copyright>
    /// <remarks>Not compiled in PCL, only OS specific</remarks>
    public class StackTools : IStackTools {

        #region Data

        private static readonly string CLASS = typeof(StackTools).Name;
        private static readonly string errReportExceptionClass = typeof(ErrReportException).Name;
        private static readonly string chkExceptionClass = typeof(ErrReportExceptionFromChk).Name;
        private static readonly string chkErrReportClass = typeof(ErrReport).Name;

        #endregion

        #region IStackTools Implementations

        /// <summary>Get the file name</summary>
        /// <param name="frame">the stack frame</param>
        /// <returns>NoFileName on failure, or the file name</returns>
        public static string FileName(StackFrame? frame) {
            return frame == null ? "NoFileName" : FileNameInternal(frame);
        }


        /// <summary>Safe call to get method name from frame</summary>
        /// <param name="frame">The frame with the information</param>
        /// <returns>The method name</returns>
        public static string MethodName(StackFrame? frame) {
            return frame == null ? "NoMethodName" : MethodNameInternal(frame);
        }


        /// <summary>Get the line number from the stack frame</summary>
        /// <param name="frame">The frame with the information</param>
        /// <returns>0 if not found, or the line number</returns>
        public static int Line(StackFrame? frame) {
            return frame == null ? 0 : LineInternal(frame);
        }


        /// <summary>Get the column number</summary>
        /// <param name="frame">The stack frame</param>
        /// <returns>0 on failure or the column number in the stack</returns>
        public static int Column(StackFrame? frame) {
            return frame == null ? 0 : ColumnInternal(frame);
        }


        /// <summary>Allow safe call from outside</summary>
        /// <param name="frame">The stack frame</param>
        /// <returns>Empty string if null or class name in frame</returns>
        public static string ClassName(StackFrame? frame) {
            return frame == null ? "NoClassName" : ClassNameInternal(frame);
        }


        /// <summary>
        /// Walk through stack until you encounter the first class that is not to be ignored and
        /// whose method does not have the <>
        /// </summary>
        /// <param name="typeToIgnore">Type to ignore as you travel the stack</param>
        /// <returns>The class containing class and method information</returns>
        public ErrorLocation FirstNonWrappedMethod(Type typeToIgnore) {
#if WINDOWS_UWP
            // remove if when Windows universal implements the default constructor on StackTrace
            return new ErrorLocation();
#else
            // Go at least one up to ignore this method.
            int index = 1;
            StackTrace st = new();

            MethodBase? mb = st.GetFrame(index)?.GetMethod();
            if (mb != null) {
                while (true) {
                    Type? declaringType = mb.DeclaringType;
                    if (declaringType == null) {
                        return new ErrorLocation();
                    }

                    if ((typeToIgnore == null) || 
                        (declaringType.Name != typeToIgnore.Name && !IsInternalClass(declaringType.Name)) && !mb.Name.Contains('<')) {
                        return new ErrorLocation(declaringType.Name, mb.Name);
                    }

                    ++index;
                    StackFrame? sf = st.GetFrame(index);
                    if (sf == null) {
                        return new ErrorLocation(declaringType.Name, mb.Name);
                    }

                    MethodBase? tmp = sf.GetMethod();
                    if (tmp == null) {
                        return new ErrorLocation(declaringType.Name, mb.Name);
                    }
                    mb = tmp;
                }
            }
            else {
                return new ErrorLocation();
            }
#endif
        }


        /// <summary>
        /// Walk through stack until you encounter the first class that is not to be ignored and
        /// whose method does not have the 
        /// </summary>
        /// <param name="typeToIgnore">Type to ignore as you travel the stack</param>
        /// <returns>The class containing class and method information</returns>
        public ErrorLocation FirstNonWrappedMethod(Type[] typesToIgnore) {
#if WINDOWS_UWP
            return new ErrorLocation();
#else
            // Go at least one up to ignore this method.
            int index = 1;
            StackTrace st = new();

            MethodBase? mb = st.GetFrame(index)?.GetMethod();
            if (mb != null) {
                while (true) {
                    Type? declaringType = mb.DeclaringType;
                    if (declaringType == null) {
                        return new ErrorLocation();
                    }

                    if ((typesToIgnore == null)) {
                        return new ErrorLocation(declaringType.Name, mb.Name);
                    }

                    // It must not be equal to any of the ignore types to be the correct level
                    bool matchAny = false;
                    foreach (Type t in typesToIgnore) {
                        if (declaringType.Name == t.Name || mb.Name.Contains('<')) {
                            matchAny = true;
                            break;
                        }
                    }

                    if (!matchAny) {
                        return new ErrorLocation(declaringType.Name, mb.Name);
                    }

                    ++index;
                    StackFrame? sf = st.GetFrame(index);
                    if (sf == null) {
                        return new ErrorLocation(declaringType.Name, mb.Name);
                    }

                    MethodBase? tmp = sf.GetMethod();
                    if (tmp == null) {
                        return new ErrorLocation(declaringType.Name, mb.Name);
                    }
                    mb = tmp;
                }
            }
            else {
                return new ErrorLocation();
            }
#endif
        }


        /// <summary>
        /// Returns a list with the stack trace except the leading entries which are to be ignored
        /// </summary>
        /// <param name="typeToIgnore">The type to ignore on first entries</param>
        /// <param name="trace">The stack trace</param>
        /// <returns>A list with entries past the initial wraping type class</returns>
        public List<string> FirstNonWrappedTraceStack(Type typeToIgnore, int fromLevel) {
#if WINDOWS_UWP
            List<string> stackFrames = new List<string>();
            stackFrames.Add(Environment.StackTrace);
            return stackFrames;
#else
            StackTrace trace = new(fromLevel, true);
            bool firstNonWrapErr = false;
            string ignoreTypeName = typeToIgnore.Name;

            List<string> stackFrames = new();
            for (int i = 0; i < trace.FrameCount; i++) {
                StackFrame? sf = trace.GetFrame(i);
                if (sf == null) { 
                    return stackFrames;
                }

                // Skip over all entries until you hit the first not to ignore
                string frameClass = ClassNameInternal(sf);
                if (!firstNonWrapErr) {
                    if (frameClass != ignoreTypeName && !IsInternalClass(frameClass)) {
                        firstNonWrapErr = true;
                    }
                    else {
                        continue;
                    }
                }

                if (frameClass != ignoreTypeName && !IsInternalClass(frameClass)) {
                    stackFrames.Add(
                    // Also ignore all instances of type to ignore
                    String.Format("     {0} : LineInternal:{1} - {2}.{3}",
                        FileNameInternal(sf),
                        LineInternal(sf),
                        frameClass,
                        MethodNameInternal(sf)));
                }
            }
            return stackFrames;
#endif
        }


        public List<string> FirstNonWrappedTraceStack(Type typeToIgnore, Exception ex, int fromLevel) {
#if WINDOWS_UWP
            List<string> stackFrames = new List<string>();
            stackFrames.Add(Environment.StackTrace);
            return stackFrames;
#else
            try {
                List<string> stackFrames = new();
                StackTrace trace = new(ex, fromLevel, true);
                bool firstNonWrapErr = false;
                string ignoreTypeName = typeToIgnore.Name;

                for (int i = 0; i < trace.FrameCount; i++) {
                    StackFrame? sf = trace.GetFrame(i);
                    if (sf == null) {
                        return stackFrames;
                    }
                    string frameClass = ClassNameInternal(sf);

                    // Skip over all entries until you hit the first not to ignore
                    if (!firstNonWrapErr) {
                        if (frameClass != ignoreTypeName && !IsInternalClass(frameClass)) {
                            firstNonWrapErr = true;
                        }
                        else {
                            continue;
                        }
                    }

                    if (frameClass != ignoreTypeName && !IsInternalClass(frameClass)) {
                        stackFrames.Add(
                        // Also ignore all instances of type to ignore
                        String.Format("     {0} : LineInternal:{1} - {2}.{3}",
                            FileNameInternal(sf),
                            LineInternal(sf),
                            frameClass,
                            MethodNameInternal(sf)));
                    }
                }
                return stackFrames;
            }
            catch (Exception) {
                List<string> stackFrames = new();
                stackFrames.Add("BLAH");
                return stackFrames;
            }
#endif
        }


        /// <summary>Drill down through inner exceptions to find inner Exception type T</summary>
        /// <typeparam name="T">The exception type to find</typeparam>
        /// <param name="e">The top level exception</param>
        /// <param name="onComplete">
        /// invoked when drill down is complete. If found the first parameter will be set true and the second 
        /// parameter will be the exception
        /// </param>
        public void FindNestedExceptionType<T>(Exception e, Action<bool, T?> onComplete) where T : Exception {
            WrapErr.ToErrReport(22000, () => {
                if (e.InnerException != null) {
                    if (e.InnerException is T innerEx) {
                        WrapErr.ToErrReport(22001, "User thrown exception within onFoundFunction delegate", () => {
                            onComplete.Invoke(true, innerEx);
                        });
                    }
                    else {
                        this.FindNestedExceptionType(e.InnerException, onComplete);
                    }
                }
                else {
                    onComplete.Invoke(false, null);
                }
            });
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Get the file name with the path stripped off from the stack frame
        /// </summary>
        /// <param name="frame">The frame with the information</param>
        /// <returns>The file name</returns>
        private static string FileNameInternal(StackFrame frame) {
            if (frame == null) {
                //Debug.WriteLine("StackFrameTools.GetFileName : Null frame");
                return "NoFileName";
            }

            string? name = frame.GetFileName();
            if (name == null) {
                //Debug.WriteLine("StackFrameTools.GetFileName : Null name in frame");
                return "NoFileName";
            }

            // Strip off the path
            if (name.Length > 0) {
                int pos = name.LastIndexOf('\\');
                if (name.Length > 0 && pos != -1 && pos < (name.Length - 1)) {
                    name = name[(pos + 1)..];
                }
            }
            return name;
        }


        /// <summary>
        /// Get the method name from the stack frame
        /// </summary>
        /// <param name="frame">The frame with the information</param>
        /// <returns>The method name</returns>
        private static string MethodNameInternal(StackFrame frame) {
            try {
                MethodBase? mb = frame.GetMethod();
                if (mb != null) {
                    return mb.Name;
                }
                return "NA";
            }
            catch (Exception e) {
                Debug.WriteLine(String.Format("WrapErr.GetMethodName : Exception {0} getting method name:{1}", e.GetType().Name, e.Message));
                return "NoMethodName";
            }
        }


        /// <summary>Get the line number from the stack frame</summary>
        /// <param name="frame">The frame with the information</param>
        /// <returns>0 if not found, or the line number</returns>
        private static int LineInternal(StackFrame frame) {
            try {
                return frame.GetFileLineNumber();
            }
            catch (Exception e) {
                Debug.WriteLine(String.Format("WrapErr.GetLine : Exception {0} getting line number:{1}", e.GetType().Name, e.Message));
                return 0;
            }
        }


        /// <summary>Get the column number from the stack frame</summary>
        /// <param name="frame">The frame with the information</param>
        /// <returns>0 if not found, or the column number</returns>
        private static int ColumnInternal(StackFrame frame) {
            try {
                return frame.GetFileColumnNumber();
            }
            catch (Exception e) {
                Debug.WriteLine(String.Format("WrapErr.GetLine : Exception {0} getting column number:{1}", e.GetType().Name, e.Message));
                return 0;
            }
        }


        /// <summary>
        /// Get the class name from the stack frame
        /// </summary>
        /// <param name="frame">The frame with the information</param>
        /// <returns>The class name</returns>
        private static string ClassNameInternal(StackFrame frame) {
            try {
                MethodBase? mb = frame.GetMethod();
                if (mb != null && mb.DeclaringType != null) {
                    return mb.DeclaringType.Name;
                }
                return "NA";
            }
            catch (Exception e) {
                Debug.WriteLine(String.Format("WrapErr.GetClassName : Exception {0} getting class name:{1}", e.GetType().Name, e.Message));
                return "NoClassName";
            }
        }


        /// <summary>Filter out internal classes from the stack</summary>
        /// <param name="className">The current stack class name to evaluate</param>
        /// <returns>true if an internal class that can be ignored</returns>
        /// <remarks>At this point an exception has occured so efficiency is not a concern</remarks>
        private static bool IsInternalClass(string className) {
            return className == CLASS ||
                className == errReportExceptionClass ||
                className == chkExceptionClass ||
                className == chkErrReportClass ||
                className == "ThreadStart" ||
                className == "ThreadHelper" ||
                // From this point it is classes found in NUnit which just get in the way
                className == "TestMethod" ||
                className == "NUnitTestMethod" ||
                className == "TestFixture" ||
                className == "TestSuite" ||
                className == "TestRunnerThread" ||
                className == "ExecutionContext" ||
                className == "RuntimeMethodHandle" ||
                className == "Reflect" ||
                className == "RuntimeMethodInfo" ||
                className == "SimpleTestRunner";
        }

        #endregion

    }
}
