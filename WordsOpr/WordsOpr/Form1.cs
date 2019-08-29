using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordsOpr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSourceRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\88882216\Documents\IeeZhai0129\Mine\Language";
            ofd.Title = "Please choose the source txt to read";
            //ofd.Filter = "文本文件|*.*";
            ofd.ShowDialog();
            if (ofd.FileName == "")
            {
                return;
            }
            else
            {
                txtSourceAddr.Text = ofd.FileName;
            }
        }

        private void btnTargetWrite_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\Users\88882216\Documents\IeeZhai0129\Mine\Language";
            sfd.Title = "Please choose the file where you want to save";
            sfd.ShowDialog();
            if(sfd.FileName=="")
            {
                txtTargetAddr.Text = @"C:\Users\88882216\Documents\IeeZhai0129\Mine\Language\Words.xls";
            }
            else
            {
                txtTargetAddr.Text = sfd.FileName;
            }
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            /*1. Read the source txt*/
            using(StreamReader sr=new StreamReader(txtSourceAddr.Text,Encoding.Default))
            {
                string line;
                DataTable dtWords = new DataTable(typeof(Words).Name);
                foreach (PropertyInfo propInfo in typeof(Words).GetProperties())
                {
                    dtWords.Columns.Add(new DataColumn(propInfo.Name, propInfo.PropertyType));
                }
                DataTable dtPhrase= new DataTable(typeof(Phrase).Name);
                foreach (PropertyInfo propInfo in typeof(Phrase).GetProperties())
                {
                    dtPhrase.Columns.Add(new DataColumn(propInfo.Name, propInfo.PropertyType));
                }
                List<Words> wordsList = new List<Words>();
                List<Phrase> phraseList = new List<Phrase>();
                int lessonNo = 0;
                ExcelHelper excelHelper = new ExcelHelper();
                bool phraseStart = false;
                bool phraseEnd = false;
                Regex regLesson=new Regex(@"第\d*课");
                while((line=sr.ReadLine())!=null)
                {
                    if (line.Trim().Length > 0)
                    {
                        line = line.Replace('（', '(').Replace("）", ")").Replace("〔", "[").Replace("［", "[").Replace("〕", "]").Replace("］", "]");

                        if (line.Contains("----"))
                        {
                            phraseStart = true;
                            phraseEnd = false;
                        }
                        else if (regLesson.IsMatch(line))
                        {
                            phraseEnd = true;
                            phraseStart = false;
                            lessonNo = Int32.Parse(line.Trim().Substring(1, line.Length - 2));
                        }
                        if (!phraseStart&&!regLesson.IsMatch(line))
                        {
                            wordsList.Add(excelHelper.TxtWriteLineToWord(line.Replace(" ", "").Replace(" ", ""), lessonNo));
                        }
                        if (phraseStart)
                        {
                            phraseList.Add(excelHelper.TxtWriteLineToPhrase(line));
                        }
                    }
                }
                //the wordslist switch to a datatable
                foreach (Words words in wordsList)
                {
                    DataRow dataRow = dtWords.NewRow();
                    foreach(PropertyInfo propInfo in typeof(Words).GetProperties())
                    {
                        dataRow[propInfo.Name] = propInfo.GetValue(words, null);
                    }
                    dtWords.Rows.Add(dataRow);
                }
                //the phraselist switch to a datatable
                foreach(Phrase phrase in phraseList)
                {
                    DataRow dataRow = dtPhrase.NewRow();
                    foreach(PropertyInfo propInfo in typeof(Phrase).GetProperties())
                    {
                        dataRow[propInfo.Name] = propInfo.GetValue(phrase, null);
                    }
                    dtPhrase.Rows.Add(dataRow);
                }
                //Write the datatable to excel
                bool result = false;
                result = excelHelper.WriteDataToExcel(txtTargetAddr.Text.ToString(), dtWords,"Words");
                result = excelHelper.WriteDataToExcel(txtTargetAddr.Text.ToString(), dtPhrase, "Phrase");
                if(result)
                {
                    MessageBox.Show("Excute successfully");
                }
                else
                {
                    MessageBox.Show("Excute failed");
                }
            }
            /*2. Analysize the text*/
            /*3. write the text to the target exccel*/
        }

       
    }
}
