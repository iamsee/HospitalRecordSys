using System;
using System.Security.Cryptography;//导入操作md5的命名空间
using System.Text;
/// <summary>
///PublicClass 的摘要说明
/// </summary>
public class PublicClass
{
	public PublicClass()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 获取一个字符串经md5加密后的结果字符串
    /// </summary>
    /// <param name="input">要加密的字符串</param>
    /// <returns>返回经md5加密后的结果字符串</returns>
    public static string getMd5Hash(string input)
    {
        
        MD5 md5Hasher = MD5.Create();
        byte[] data = md5Hasher.ComputeHash(System.Text.Encoding.Default.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }
    /// <summary>
    /// 处理字符串中的html字符和换行的问题
    /// </summary>
    /// <param name="str">处理的字符串</param>
    /// <returns>返回处理字符串中的html字符和换行的问题后的结果字符串</returns>
    public static string GetHtmlEncode(string str)
    {
        str = str.Replace("<", "&lt;");
        str = str.Replace(">", "&gt;");
        str = str.Replace(" ", "&nbsp;");
        str = str.Replace("\n", "<br>");
        return str;
    }
    /// <summary>
    /// 获取当前日期的中文格式
    /// </summary>
    /// <returns></returns>
    public static string GetCHDate()
    {
        string str = string.Empty;
        str += DateTime.Now.Year.ToString() + "年";
        str += DateTime.Now.Month.ToString() + "月";
        str += DateTime.Now.Day.ToString() + "日 ";
        str += DateTime.Now.DayOfWeek.ToString();
        return str;
    }
    /// <summary>
    /// 更具时间构造一个字符串作为上传的文件名称
    /// </summary>
    /// <returns></returns>
    public static string GetFilename()
    {
        Random rnd = new Random();
        int a = 1000;
        int b = 9999;
        string str = string.Empty;
        //Year
        str += DateTime.Now.Year.ToString();
        //Month
        if (DateTime.Now.Month < 10)
        {
            str += "0" + DateTime.Now.Month.ToString();
        }
        else
        {
            str += DateTime.Now.Month.ToString();
        }
        //Day
        if (DateTime.Now.Day < 10)
        {
            str += "0" + DateTime.Now.Day.ToString();
        }
        else
        {
            str += DateTime.Now.Day.ToString();
        }
        //Hour
        if (DateTime.Now.Hour < 10)
        {
            str += "0" + DateTime.Now.Hour.ToString();
        }
        else
        {
            str += DateTime.Now.Hour.ToString();
        }
        //Minute
        if (DateTime.Now.Minute < 10)
        {
            str += "0" + DateTime.Now.Minute.ToString();
        }
        else
        {
            str += DateTime.Now.Minute.ToString();
        }
        //Second
        if (DateTime.Now.Second < 10)
        {
            str += "0" + DateTime.Now.Second.ToString();
        }
        else
        {
            str += DateTime.Now.Second.ToString();
        }
        //获取[a,b]之间的随机数
        str += rnd.Next(a, b).ToString();
        return str;
    }
    /// <summary>
    /// 处理字符串截取功能
    /// </summary>
    /// <param name="str">要截取的字符串</param>
    /// <param name="n">从开始位置截取的字符个数</param>
    /// <returns>返回要截取的字符串</returns>
    public static string SubStr(string str,int n)
    {
        if (str.Length > n)
        {
            return str.Substring(0, n)+"...";
        }
        else
        {
            return str;
        }
    }


}
