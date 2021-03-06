﻿// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace FixieSpec.Specifications.Execution.Inconclusive
{
    using Shouldly;

    public sealed class AssertionStep : ExecutionSpecificationBase
    {
        SpecificationExecutionResult inconclusiveExecutionResult;

        public void When_executing_an_inconclusive_assertion_step()
        {
            inconclusiveExecutionResult = Execute<InconclusiveAssertionStepSpecification>();
        }

        public void Then_the_inconclusive_assertion_step_should_not_be_executed()
        {
            inconclusiveExecutionResult.ShouldHaveExecutedSteps(
                "When_exercising_the_system_under_test",
                "And_then_another_result_can_be_verified");
        }

        public void And_then_all_assertion_steps_should_be_recognized()
        {
            inconclusiveExecutionResult.Total.ShouldBe(2);
        }

        public void And_then_the_assertion_step_should_be_inconclusive()
        {
            inconclusiveExecutionResult.Skipped.ShouldBe(1);
        }

        public void And_then_successful_assertion_steps_should_be_recognized()
        {
            inconclusiveExecutionResult.Passed.ShouldBe(1);
        }

        public void And_then_there_should_be_no_failed_assertion_steps()
        {
            inconclusiveExecutionResult.Failed.ShouldBe(0);
        }

        class InconclusiveAssertionStepSpecification
        {
            public void When_exercising_the_system_under_test()
            {
                RecordStep();
            }

            [Inconclusive]
            public void Then_an_inconclusive_result_is_skipped()
            {
                RecordStep();
                throw new ShouldBeUnreachableException();
            }

            public void And_then_another_result_can_be_verified()
            {
                RecordStep();
            }
        }
    }
}
