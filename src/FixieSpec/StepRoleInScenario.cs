﻿// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec
{
    /// <summary>
    /// Describes the role a specification step has within a scenario.
    /// </summary>
    public enum StepRoleInScenario
    {
        /// <summary>
        /// The role of the step is not defined, it is even not a step.
        /// </summary>
        Undefined,

        /// <summary>
        /// The step is a setup step that sets up scenario specific context.
        /// </summary>
        Setup,

        /// <summary>
        /// The step is a transition step that exercises the SUT to produce
        /// a testable outcome.
        /// </summary>
        Transition,

        /// <summary>
        /// The step is an assertion step that verifies testable outcome.
        /// </summary>
        Assertion
    }
}
