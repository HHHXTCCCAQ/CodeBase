using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Xml操作 {
    class Program {
        static void Main(string[] args) {
            List<Skill> skilList = new List<Skill>();
            //XmlDocument 用来解析xml文档
            XmlDocument xmlDoc = new XmlDocument();
            //选择要加载解析的xml文档


            //xmlDoc.Load("info.txt");   
            xmlDoc.LoadXml(File.ReadAllText("info.txt"));//传递一个字符串


            //得到根节点  (xmlnote 用来得到一个节点）
            XmlNode rootNode = xmlDoc.FirstChild;//获取第一个节点 
            //得到根节点下的子节点集合

            XmlNodeList skillNodeList = rootNode.ChildNodes;//用来获取当前节点下的所有节点
            foreach (XmlNode skillNode in skillNodeList) {
                Skill skill = new Skill();
                XmlNodeList fieldNodeList = skillNode.ChildNodes;//获取skill下的所有节点
                foreach (XmlNode fileNode in fieldNodeList) {

                    //通过Name属性获得节点名称
                    if (fileNode.Name == "id") {
                        int id = Int32.Parse(fileNode.InnerText);//获取节点内部文字
                        skill.ID = id;
                    } else if (fileNode.Name == "name") {
                        string name = fileNode.InnerText;
                        skill.Name = name;
                        skill.Lang = fileNode.Attributes[0].Value;
                    } else {
                        skill.Damage = Int32.Parse(fileNode.InnerText);
                    }

                }
                skilList.Add(skill);

            }
            foreach (Skill skil in skilList) {

                Console.WriteLine(skil);

            }
            Console.ReadKey();


        }
    }
}
