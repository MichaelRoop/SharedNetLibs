﻿using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System.Diagnostics;

namespace NUnit.Framework {
    public class DebugExplicitAttribute : NUnitAttribute, IApplyToTest {

        private readonly string _reason = String.Empty;

        /// <summary>
        /// Default constructor
        /// </summary>
        public DebugExplicitAttribute() {
        }

        /// <summary>
        /// Constructor with a reason
        /// </summary>
        /// <param name="reason">The reason test is marked explicit</param>
        public DebugExplicitAttribute(string reason) {
            _reason = reason;
        }

        #region IApplyToTest members

        /// <summary>
        /// Modifies a test by marking it as explicit.
        /// </summary>
        /// <param name="test">The test to modify</param>
        public void ApplyToTest(Test test) {
            if (!Debugger.IsAttached) {
                //Skip = "Only running in interactive mode.";
                test.RunState = RunState.Ignored;
                test.Properties.Set(PropertyNames.SkipReason, $"Explicit");
                if (_reason != null)
                    test.Properties.Set(PropertyNames.SkipReason, $"Explicit: {_reason}");
            }

            if (test.RunState != RunState.NotRunnable && test.RunState != RunState.Ignored) {
                test.RunState = RunState.Explicit;
                if (_reason != null)
                    test.Properties.Set(PropertyNames.SkipReason, _reason);
            }
        }

        #endregion
    }
}
