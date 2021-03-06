﻿// <copyright>
// Copyright (c) Martin Bohring. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Media.Recording.Specifications
{
    using Media.Specifications;

    using Domain;
    using Domain.Recording;

    public sealed class VideoRecordingFailsWithoutCamera
    {
        readonly VideoCamera camera;
        readonly Microphone microphone;

        readonly VideoRecording videoRecording;

        public VideoRecordingFailsWithoutCamera(
            VideoRecording aVideoRecording,
            VideoCamera aCamera,
            Microphone aMicrophone)
        {
            videoRecording = aVideoRecording;
            camera = aCamera;
            microphone = aMicrophone;
        }

        public void Given_a_camera_is_not_available()
        {
            camera.UseForVideoRecording(new ActivityId());
        }

        public void When_a_video_recording_is_started()
        {
            videoRecording.StartRecording(camera, microphone);
        }

        public void Then_the_video_recording_should_be_recording()
        {
            videoRecording.ShouldNotBeRecording();
        }

        public void And_then_the_selected_camera_is_not_used_for_recording()
        {
            camera.ShouldNotBeRecording(videoRecording);
        }
    }
}
