using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestWindowsFormTransformation
{
    /// <summary>
    /// 读写Xml类
    /// </summary>
    public class ReadWriteXml
    {
        /// <summary>
        /// 保存camera.xml文件里的cCameraUserA对象
        /// </summary>
        public static List<cCameraUserA> LcCameraUserA = new List<cCameraUserA>();
        /// <summary>
        /// 把xml里的配置文件取到LcCameraUserA对象
        /// </summary>
        /// <param name="fullpath">文件的完整路径</param>
        public void ReadXml(string fullpath)
        {
            if (File.Exists(fullpath))
            {
                XDocument xml = new XDocument();
                xml = XDocument.Load(fullpath);
                XElement root = xml.Root;
                foreach (XElement childElement in root.Elements())
                {
                    string name = childElement.Attribute("name").Value.ToString();
                    string ipaddress = childElement.Attribute("ipaddress").Value.ToString();
                    string username = childElement.Attribute("username").Value.ToString();
                    string portnumber = childElement.Attribute("portnumber").Value.ToString();
                    string password = childElement.Attribute("password").Value.ToString();
                    string node = childElement.Attribute("node").Value.ToString();
                    cCameraUserA user = new cCameraUserA();
                    user.Name = name;
                    user.DVRIPAddress = ipaddress;
                    user.DVRPortNumber = portnumber;
                    user.DVRUserName = username;
                    user.DVRPassword = password;
                    user.DVRNode = node;
                    LcCameraUserA.Add(user);
                }
            }
            else
            {
               
            }

        }
    }
}
