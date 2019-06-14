using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum OperationCode:byte//区分请求和响应的类型
    {
        Login,
        Register,
        Default,
        SyncPostion,
        SyncPlayer
    }
}
