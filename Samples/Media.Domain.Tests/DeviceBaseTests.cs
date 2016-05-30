﻿// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Domain.Tests
{
    using System;

    using Shouldly;

    public abstract class DeviceBaseTests<T> where T : DeviceBase
    {
        public void ShouldFailWhenConstructedUsingNullDeviceId()
        {
            Action act = () => CreateDevice(null);

            act.ShouldThrow<ArgumentNullException>();
        }

        public void ShouldBeAvailableWhenConstructed()
        {
            var device = CreateDevice(new DeviceId());

            device.IsAvailable().ShouldBeTrue();
        }

        protected abstract T CreateDevice(DeviceId id);
    }
}
