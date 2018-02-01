using CsgoAPI.Data;
using HtmlAgilityPack;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            #region CAPTURA DE ELEMENTOS HTML E VALORES
            // https : //csgolounge.com/search
            var chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://csgolounge.com/search");
            var contexto = new DATAbase();
         //   var tudo = contexto.Item.ToList();
         //   contexto.Item.RemoveRange(tudo);
            var documento = new HtmlDocument();
            for (int i = 0; i <= 141; i++)
            {
                var function_script = $"setSubCat('Cs',1,1,{i})";
                chrome.ExecuteScript(function_script);
                documento.LoadHtml(chrome.PageSource);
                var itemNodes = documento.DocumentNode.SelectNodes(@"//div[@id = 'itemlist']/div[@class = 'oitm']");

                foreach (var elemento in itemNodes)
                {
                    //pega o conteudo literal de um elemento de texto.
                    var nome = elemento.SelectSingleNode(@"//div[@class= 'name']/b").InnerText;
                    //pega o atributo do elemento
                    string rdef = elemento.SelectSingleNode(@"//div[@class= 'name']/a[3]").GetAttributeValue("href", "error");

                    //CATALOGANDO MAROTAMENTE  //refina o URL para pegar o valor do elemento no loop,
                    rdef = rdef.Split( new [] { "rdef_index[]=" }, StringSplitOptions.None)[1].Split('&')[0];
 
                    var item = new CsgoItem
                    {
                        Name = nome,
                        Rdef = int.Parse(rdef)
                    };
                    Console.WriteLine($"\n\nadd :  { item.Name}  \nId: {item.Rdef} ");
                    contexto.Item.Add(item);
                }
                contexto.SaveChanges();
            }
            #endregion
        }
    }
}
