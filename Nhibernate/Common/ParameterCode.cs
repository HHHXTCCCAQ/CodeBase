using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum ParameterCode:byte //传送数据参数的类型
    {
        Username,
        Password,
        Position,
        X,Y,Z,
        UsernameList,
        PlayerDataList
    }
}
