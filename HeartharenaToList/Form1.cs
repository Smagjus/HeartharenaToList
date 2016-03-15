using System;
using System.Net;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace HeartharenaToList
{
    public partial class Form1 : Form
    {
        //private const string DraftUrl = @"http://google.com";
        private string DraftUrl = @"http://www.heartharena.com/arena-run/nb5i3y";

        public Form1()
        {
            InitializeComponent();
            var conf = new Config();
            ConfigClass.CreateNew(conf);
            //Execute();

        }

        public void Execute()
        {
            try
            {
                var doc = GetDocument();
                Parse(doc);
            }
            catch (System.Net.WebException e)
            {
                ShowError(e, "Please verify that the URL exists.");
            }
            catch (Exception e)
            {
                ShowError(e,"Please verify that the URL points to the Heartharena draft (e.g. www.heartharena.com/arena-run/nb5i3y). If you are sure the URL is correct then the Website might have changed and this program can no longer work.");
            }
        }

        public void Parse(HtmlAgilityPack.HtmlDocument doc)
        {
            int i = 1;
            richTextBox1.Clear();

            foreach (var outerNode in doc.DocumentNode.SelectNodes("//ul[@class='deckList']/li"))
            {
                string name = outerNode.SelectSingleNode("child::span[@class='name']").InnerText;
                //string mana = outerNode.SelectSingleNode("child::span[@class='mana']").InnerText;
                string quantity = outerNode.SelectSingleNode("child::span[@class='quantity']").InnerText;

                //Console.WriteLine("{0}. {1}x {2}",i++, quantity, name);
                ShowMessage(String.Format("- {1}x {2}", i++, quantity, name));
            }
        }

        public HtmlAgilityPack.HtmlDocument GetDocument()
        {
            var webget = new HtmlWeb();
            webget.PreRequest += request =>
            {
                request.CookieContainer = new System.Net.CookieContainer();
                return true;
            };
            var doc = webget.Load(DraftUrl);
            return doc;

        }

        private void ShowError(Exception e, string longError)
        {
            string message = longError
                                + Environment.NewLine
                                + Environment.NewLine
                                + e.ToString();
            richTextBox1.Text = longError;
            Console.WriteLine(message);
        }

        private void ShowMessage(string contents)
        {
            richTextBox1.Text += contents+ Environment.NewLine;
            Console.WriteLine(contents);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DraftUrl = textBox1.Text;
            
            Execute();
        }
    }
}
