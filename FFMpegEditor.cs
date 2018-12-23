using System;
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

    class VideoPackageInfo : ICloneable
    {
        FrameInfo[] frameInfos;
        DirectoryInfo framesFolderInfo;
        DirectoryInfo targetFolderInfo;
        FileInfo videoFileInfo;


        public VideoPackageInfo()
        {

        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public VideoPackageInfo MakeCopy()
        {
            throw new NotImplementedException();
        }

        public void RunOperation()
        {

        }
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
