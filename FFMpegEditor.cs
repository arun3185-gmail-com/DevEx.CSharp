﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFMpegHelper
{
    class FFMpegEditor
    {

    }

    class FrameInfo
    {
        FileInfo frameFileInfo;
        TimeSpan frameDuration;
        DateTime startTime;
        DateTime endTime;

        static double framesPerSecond;
        static TimeSpan milliSecondsPerFrame;


        public FrameInfo()
        {
            
        }
    }
}