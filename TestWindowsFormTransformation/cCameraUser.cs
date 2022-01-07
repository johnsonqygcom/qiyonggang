using System;
using System.Collections.Generic;
using System.Text;

namespace TestWindowsFormTransformation
{
    public class cCameraUser
    {
        public string Name { get; set; }
        public string DVRIPAddress { get; set; }
        public string DVRPortNumber { get; set; }
        public string DVRUserName { get; set; }
        public string DVRPassword { get; set; }
    }

    public class cCameraUserA
    {
        public string Name { get; set; }
        public string DVRIPAddress { get; set; }
        public string DVRPortNumber { get; set; }
        public string DVRUserName { get; set; }
        public string DVRPassword { get; set; }
        /// <summary>
        /// 摄像头节点
        /// </summary>
        public string DVRNode { get; set; }
    }


}
