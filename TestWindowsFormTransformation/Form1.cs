using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsFormTransformation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ReadWriteXml rwXml = new ReadWriteXml();
            string fileRoot = AppDomain.CurrentDomain.BaseDirectory + "camera.xml";
            rwXml.ReadXml(fileRoot);
            lcUserA = ReadWriteXml.LcCameraUserA;
        }

        public  void DeleteFile(string directory, int intervalDay, string filename)
        {
            try
            {
                foreach (var file in Directory.GetFiles(directory))
                {
                    FileInfo fi = new FileInfo(file);
                    DateTime time = fi.CreationTime;
                    if (fi.Name == filename && DateTime.Now.Day - time.Day >= intervalDay)
                    {
                        File.Delete(file);
                        break;
                    }
                }
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
        }
        /// <summary>
        /// 查询上传数据
        /// </summary>
        /// <returns></returns>
        private DataTable QueryUploadData()
        {
            string sql = "select id from t_coal_distribute_abnormal where create_dt between @time1 and @time2 and vehicle_no= @vehicle_no and s_status=0";
            SqlParameter[] pms = new SqlParameter[]
                        {
                                        new SqlParameter("@time1",SqlDbType.DateTime){Value = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")},
                                        new SqlParameter("@time2",SqlDbType.DateTime){Value = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")},
                                        new SqlParameter("@vehicle_no",SqlDbType.VarChar,50){Value = "晋A5L128"},
                        };
            int cId = 0;
            object ob1 = SqlHelper.GetSingle(sql, pms);
            if (ob1 != null)
            {
                cId = Convert.ToInt32(ob1);
            }
                StringBuilder sbd = new StringBuilder();
            sbd.Append("select c.s_status, c.org_id,c.city_org_id,c.abnormal_type,c.distribute_no,c.vehicle_no,c.arrival_time,c.arrival_weight_time,c.out_time,");
            sbd.Append("out_weight_time,c.arrival_image,c.arrival_weight_image,c.out_image,c.out_weight_image,c.id from t_coal_distribute_abnormal c ");
            sbd.Append("right join t_snap_info s on s.vehicle_no=c.vehicle_no where s.snap_node = '88' and s.snap_time between @time1 and @time2 ");
            sbd.Append(" and c.create_dt between @time3 and @time4 and (c.s_status =0 or c.s_status =2)");
            pms = new SqlParameter[]
                                    {
                                        new SqlParameter("@time1",SqlDbType.DateTime,4){Value = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss")},
                                        new SqlParameter("@time2",SqlDbType.DateTime){Value = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss")},
                                        new SqlParameter("@time3",SqlDbType.DateTime){Value = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss")},
                                        new SqlParameter("@time4",SqlDbType.DateTime){Value = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss")},
                                    };
            sql = sbd.ToString();
            DataTable dt = SqlHelper.ExecuteDataTable(sql, pms);
            return dt;
        }

        private string testparameter(string s)
        {
            string d = s;
            return d;
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dts = new DateTime(2022, 1, 6, 10, 32, 00);
            for(int i=0;i<8;i++)
            {
                if(i>3)
                {
                    if(i==4)
                    {
                        return;
                    }
                    if (i == 4)
                    {
                        continue;
                    }
                    MessageBox.Show(i.ToString());
                }
                
            }
            List<int> dd = new List<int>();
            string[] picArr = { "123", "456", "789", "aaa" };
            return;
            string j1 = picArr[1];
            string j3 = picArr[3];
            string abs = testparameter("@jiioo");
            if(abs== "@jiioo")
            {
                string jj = "";
            }
            Predicate<int> t = (x) => { return x > 60; };
            int[] aa ={ 13, 45, 26,45, 98, 3,45, 56, 72, 24 };
            int first = Array.Find(aa, t);
            int[] group = Array.FindAll(aa, t);
            List<int> lt = new List<int>();
            lt.AddRange(aa);
            lt.ForEach(x =>
            {
                if(x==45)
                {
                    int r1 = x;
                }
            });
            DeleteFile(@"./", 0, "log.txt");
            DataTable dt = QueryUploadData();
            int row = dt.Rows.Count;
            if (row > 0)
            {
                for (int i = 0; i < row; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[i]["abnormal_type"].ToString()))
                    {
                        if (string.IsNullOrEmpty(dt.Rows[i]["arrival_weight_time"].ToString()) || string.IsNullOrEmpty(dt.Rows[i]["out_weight_time"].ToString()))
                        {
                            int id = Convert.ToInt32(dt.Rows[i]["id"]);
                            string sql1 = "update t_coal_distribute_abnormal set abnormal_type = 1 where id =@id";
                            SqlParameter[] pms1 = new SqlParameter[]
                            {
                                new SqlParameter("@id",SqlDbType.Int){Value=id}
                            };
                            if(SqlHelper.ExecuteSql(sql1,pms1) > 0)
                            {
                                MessageBox.Show("更新成功！");
                            }
                        }
                        
                    }
                }
                dt = QueryUploadData();
                string s = "";

            }
            string a1 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss");
            string a2 = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
            string a3 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string a = "12345";
            string b = a.Substring(1);
            string c = a.Substring(0, 1);
            string spath= AppDomain.CurrentDomain.BaseDirectory + "camera.xml";
            if (File.Exists(spath))
            {

            }
            else
            {
                MessageBox.Show("没有此文件会造成程序严重错误，请联系技术员！", "严重警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            this.Close();
        }
        private List<cCameraUserA> lcUserA = new List<cCameraUserA>();

        private void button2_Click(object sender, EventArgs e)
        {
            lcUserA.ForEach((x) =>
            {
                MessageBox.Show(x.DVRNode);
            });
        }
    
        /// <summary>
        /// 设置程序开机启动
        /// </summary>
        /// <param name="strAppPath">应用程序exe所在文件夹</param>
        /// <param name="strAppName">应用程序exe名称</param>
        /// <param name="bIsAutoRun">自动运行状态</param>  
        public void SetAutoRun(string strAppPath, string strAppName, bool bIsAutoRun)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strAppPath)
                    || string.IsNullOrWhiteSpace(strAppName))
                {
                    throw new Exception("应用程序路径或名称为空！");
                }


                RegistryKey reg = Registry.CurrentUser;
                RegistryKey run = reg.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", RegistryKeyPermissionCheck.ReadWriteSubTree);

                if (bIsAutoRun)
                {
                    run.SetValue(strAppName, strAppPath);
                }
                else
                {
                    if (null != run.GetValue(strAppName))
                    {
                        run.DeleteValue(strAppName);
                    }
                }

                run.Close();
                reg.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private  void EditRegeditPermission()
        {
            string regpath = @"SOFTWARE\Microsoft\Windows\CurrentVersion";
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(regpath, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);
            RegistrySecurity rs = new RegistrySecurity();
            RegistryAccessRule rar = new RegistryAccessRule("everyone", RegistryRights.FullControl, AccessControlType.Allow);
            rs.AddAccessRule(rar);
            rk.SetAccessControl(rs);
            rk.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string dd3 = "aa";
            string dd4 = "aa";
            string dd5 = "77";
            string dd6 = "77";
            if (dd3 == dd4 && dd5 == dd6)
            {
                return;
                var sss = "ddd";
            }
            var dd1 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss");
            var dd2 = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
            string strFilePath = Application.ExecutablePath;
            string strFileName = System.IO.Path.GetFileName(strFilePath);
            try
            {
                //SetAutoRun(strFilePath, strFileName, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool aa = JudgeGangueVehicle("晋A94P03");
        }

        /// <summary>
        /// 判断传入的车辆是不是矸石车，如果是真返回true,不是返回false
        /// </summary>
        /// <param name="vehicle">车号</param>
        /// <returns>true或false</returns>
        public bool JudgeGangueVehicle(string vehicle)
        {
            StringBuilder sbd = new StringBuilder();
            sbd.Append("select vehicle_no from [dbo].[t_gangue_weight]  where  (tare_date=convert(varchar(10),GETDATE(),120) ");
            sbd.Append("or weight_date=convert(varchar(10),GETDATE(),120)) and vehicle_no=@vehicle_no and (state=0 or state=1 or state=3)");
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@vehicle_no",SqlDbType.VarChar,32){Value=vehicle}
            };
            string sql = sbd.ToString();
            object ob1 = SqlHelper.GetSingle(sql, pms);
            if (ob1 != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
