using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitJson;

namespace Json操作 {
    class Program {
        static void Main(string[] args) {
            List<Skill> skilllsList = new List<Skill>();
            //使用Litjson解析json
            //两种引入方式
            //1.下载litjson.dll  然后添加引用
            //2.右键引用，打开netget程序包，在联机中搜索litjson并安装

            //解析json的方法

            #region 方法一
            //用jsonMapper解析文本
            //jsondata 代表一个数组或一个对象
            //这里JsonData代表一个数组

            JsonData jsonData = JsonMapper.ToObject(File.ReadAllText("Json数据.txt"));


            //这里JsonData代表一个对象
            foreach (JsonData temp in jsonData) {
                Skill skill = new Skill();
                JsonData idvalue = temp["id"]; //通过字符串索引器可以取得对应的值
                JsonData nameValue = temp["name"];
                JsonData dameagevalue = temp["damage"];
                int id = Int32.Parse(idvalue.ToString());
                int damage = Int32.Parse(dameagevalue.ToString());
                skill.id = id;
                skill.damage = damage;
                skill.name = nameValue.ToString();

                skilllsList.Add(skill);
                // Console.WriteLine(id+nameValue.ToString()+damage);
            }

            foreach (Skill tmp in skilllsList) {
                Console.WriteLine(tmp);
            }
            Console.ReadKey();
            #endregion


            /*********************************************************************************/
            #region 方法二
            //方法二
            //使用泛型解析json
            //注意事项： skill 类里面的属性值  要与文档中的属性值保持一样


            Skill[] skillArry = JsonMapper.ToObject<Skill[]>(File.ReadAllText("Json数据.txt"));

            foreach (var temp in skillArry) {
                Console.WriteLine(temp);
            }

            /***********************************************************************************/
            skilllsList = JsonMapper.ToObject<List<Skill>>(File.ReadAllText("Json数据.txt"));

            foreach (var temp in skilllsList) {
                Console.WriteLine(temp);
            }
            Console.ReadKey();

            #endregion


            #region 解析对象

            Player p = JsonMapper.ToObject<Player>(File.ReadAllText("主角信息.txt"));
            Console.WriteLine(p);
            foreach (var temp in p.skillList)
            {
                Console.WriteLine(temp);
            }
            Console.ReadKey();

            #endregion

            #region 将json转化为json
            //将对象转换为json
            Player player = new Player();
            player.name = "an77";
            player.level = 100;
            player.age = 18;
            string json = JsonMapper.ToJson(player);
            Console.WriteLine(json);
            Console.ReadKey();
            #endregion
           

        }



    }
}
