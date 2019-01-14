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
        public static void Run()
        {
            VideoFrameGenerator vfGenProj1 = new VideoFrameGenerator(null, null, null);
            //vfGenProj1.LoadFrameInfos();
            //vfGenProj1.RunOperation();
        }
    }

    class VideoFrameGenerator
    {
        FrameInfo[] frameInfos;

        FileInfo configFileInfo;
        DirectoryInfo sourceFolderInfo;
        DirectoryInfo targetFolderInfo;

        TimeSpan videoDuration;
        double framesPerSecond;
        TimeSpan milliSecondsPerFrame;


        public VideoFrameGenerator(FileInfo configFileInfo, DirectoryInfo sourceFolderInfo, DirectoryInfo targetFolderInfo)
        {
            this.configFileInfo = configFileInfo;
            this.sourceFolderInfo = sourceFolderInfo;
            this.targetFolderInfo = targetFolderInfo;
        }

        public void LoadFrameInfos()
        {

        }

        public void RunOperation()
        {
            //frameInfo CreateFrames
            foreach (FrameInfo frameInfo in frameInfos)
            {
                //frameInfo CreateFrames
            }
        }

        public void CreateFrames()
        {

        }
    }

    class FrameInfo
    {
        FilterInfo[] referredFilterInfos;

        TimeSpan frameDuration;
        DateTime startTime;
        DateTime endTime;

        VideoFrameGenerator parent;
        public FrameInfo(VideoFrameGenerator parent)
        {
            this.parent = parent;
        }

        public void Create()
        {

        }
    }

    class FilterInfo
    {
        FileInfo defaultFileInfo;

        FrameInfo parentFrameInfo;

        private FilterInfo() { }
        public FilterInfo(FrameInfo parentFrameInfo, FileInfo defaultFileInfo)
        {

            this.parentFrameInfo = parentFrameInfo;
            this.defaultFileInfo = defaultFileInfo;
        }

        static FilterInfo() { Empty = new FilterInfo(); }
        public static FilterInfo Empty { get; private set; }
    }
}
