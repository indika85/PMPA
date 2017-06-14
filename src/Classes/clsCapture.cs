using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DirectX.Capture;
using System.Windows.Forms;
using System.IO;

namespace PMPA.Classes
{
    class clsCapture
    {
        static Capture capture = null;
        static Filters filters = null;
        private static Panel previewPanel;

        public static void initialiseFilters()
        {
            filters = new Filters();
            if (filters.VideoInputDevices.Count <= 0 || filters.AudioInputDevices.Count <= 0)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "No Audio or Video device detected.");
                return;
            }
            capture = new Capture(filters.VideoInputDevices[0], filters.AudioInputDevices[0]);

        }
        public static void setPreviewPanel(Panel panel)
        {
            previewPanel = panel;

        }

        public static void preview(int deviceNo)
        {
            capture.PreviewWindow = previewPanel;
            if (filters.VideoInputDevices == null)
            {
                MessageBox.Show("No video device connected to your PC!");
                return;
            }
            else if (capture.PreviewWindow == null)
            {
                clsMessages.showMessage(clsMessages.msgType.error, "No preview panel defined.");
                return;

            }
            if (capture != null)
            {
                capture.Dispose();
                capture.Stop();
                capture.PreviewWindow = null;
            }
            capture = new Capture(filters.VideoInputDevices[deviceNo], filters.AudioInputDevices[0]);
            capture.PreviewWindow = previewPanel;
        }


        internal static FilterCollection getCaptureDevices()
        {
            return filters.VideoInputDevices;

        }
        public static void startCapture()
        {
            if (!capture.Capturing)
            {
                capture.Cue();
                capture.Start();
            }
        }
        public static void stopCapture()
        {
            if(capture.Capturing)
                capture.Stop();
            
            //MessageBox.Show(capture.Filename);
        }

        public static void setSaveFileName(string path)
        {
            if (!capture.Cued)
                capture.Filename = clsMatch.currentMatch.savePath.Substring(0,clsMatch.currentMatch.savePath.LastIndexOf("\\")+1)+ path;
        }

        internal static FilterCollection getEncorders()
        {
            return filters.VideoCompressors;
        }
        public static void setEncorder(int encNo)
        {
            capture.VideoCompressor = filters.VideoCompressors[encNo];
        }
    }
}
