using System.Reflection;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过以下
// 特性集控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("12306_Helper")]
[assembly: AssemblyDescription(@"
声明：本程序仅供学习和研究C#技术使用

感谢 鱼大的发布平台,以及DNS服务器列表接口.
感谢 木鱼、未来式和其他一些朋友长期以来的鼓励、支持和帮助.

")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("www.alianyone.com")]
[assembly: AssemblyProduct("12306_Helper")]
[assembly: AssemblyCopyright("Copyright © www.alianyone.com")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("c6b8c68e-f8c7-47cf-992b-bc13a4000988")]

// 程序集的版本信息由下面四个值组成:
//
//      主版本
//      次版本 
//      内部版本号
//      修订号
//
// 可以指定所有这些值，也可以使用“内部版本号”和“修订号”的默认值，
// 方法是按如下所示使用“*”:
// [assembly: AssemblyVersion("1.0.*")]

// *.*.*.*  [大版本.小版本.功能增加的累加值.月日]   [3.2.1.36]
[assembly: AssemblyVersion("3.2.1.620")]
[assembly: AssemblyFileVersion("3.2.1.620")]
[assembly: FSLib.App.SimpleUpdater.Updatable2("http://www.fishlee.net/service/update2/51/43/{0} ", "update_c.xml")]
//[assembly: FSLib.App.SimpleUpdater.Updatable2("http://www.fishlee.net/service/update/51/{0}", "update_c.xml")]
//[assembly: FSLib.App.SimpleUpdater.Updatableg2("http://www.alianyone.com/softupdate/{0}", "update_c.xml")]
