using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.Util;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;

namespace WordsOpr
{
    class ExcelHelper
    {
        private IWorkbook workbook;
        public Words TxtWriteLineToWord(string strLine,int lessonNo)
        {
            Words wordLine = new Words();
            int leftWord = -1;//括号
            int leftType = -1;
            int rightWord = -1;
            int rightType = -1;
            leftWord = strLine.IndexOf("(");
            if(leftWord<0)
            {
                leftType = strLine.IndexOf("[");

                if(leftType<0)
                {
                    wordLine.Lesson=lessonNo;
                    wordLine.Word = strLine;
                    return wordLine;
                }
                else
                {
                    rightType = strLine.IndexOf("]");
                    wordLine.Lesson = lessonNo;
                    wordLine.Tone = 0;
                    wordLine.Category = "";
                    wordLine.Freq = 0;
                    wordLine.Holorfic = false;
                    wordLine.RightCount = 0;
                    wordLine.ErrorCount = 0;
                    wordLine.Word = strLine.Substring(0, leftType);
                    wordLine.Kana = strLine.Substring(0, leftType);
                    wordLine.Meaning = strLine.Substring(rightType + 1, strLine.Length - rightType - 1);
                    wordLine.Nature = strLine.Substring(leftType + 1, rightType - leftType - 1);
                    return wordLine;
                }
            }
            else
            {
                leftType = strLine.IndexOf("[");

                if (leftType < 0)
                {
                    rightWord = strLine.IndexOf(")");
                    wordLine.Lesson = lessonNo;
                    wordLine.Tone = 0;
                    wordLine.Category = "";
                    wordLine.Freq = 0;
                    wordLine.Holorfic = false;
                    wordLine.RightCount = 0;
                    wordLine.ErrorCount = 0;
                    wordLine.Word = strLine.Substring(leftWord+1, rightWord-leftWord-1);
                    wordLine.Kana = strLine.Substring(0, leftWord);
                    wordLine.Meaning = strLine.Substring(rightWord + 1, strLine.Length - rightWord- 1);
                    wordLine.Nature = "";
                    return wordLine;
                }
                else
                {
                    rightType = strLine.IndexOf("]");
                    rightWord = strLine.IndexOf(")");
                    wordLine.Lesson = lessonNo;
                    wordLine.Tone = 0;
                    wordLine.Category = "";
                    wordLine.Freq = 0;
                    wordLine.Holorfic = false;
                    wordLine.RightCount = 0;
                    wordLine.ErrorCount = 0;
                    wordLine.Kana = strLine.Substring(0, leftWord);
                    wordLine.Word = strLine.Substring(leftWord+1, rightWord-leftWord-1);
                    wordLine.Meaning = strLine.Substring(rightType + 1, strLine.Length - rightType - 1);
                    wordLine.Nature = strLine.Substring(leftType + 1, rightType - leftType - 1);
                    return wordLine;
                }
            }
        }
        public Phrase TxtWriteLineToPhrase(string strLine)
        {
            Phrase phraseLine = new Phrase();
            int leftWord = -1;
            int rightWord = -1; //括号 是单词
            leftWord = strLine.IndexOf("(");
            if (leftWord < 0)
            {
                string[] spiltLine = strLine.TrimEnd().TrimStart().Split(' ');
                phraseLine.Sentence = spiltLine[0];
                phraseLine.Kana = spiltLine[0];
                if (spiltLine.Length > 1)
                {
                    phraseLine.Meaning = spiltLine[1];
                }
                return phraseLine;
                  
            }
            else
            {
                rightWord = strLine.IndexOf(")");
                phraseLine.Kana = strLine.Substring(0, leftWord);
                phraseLine.Sentence = strLine.Substring(leftWord + 1, rightWord - leftWord - 1);
                phraseLine.Meaning = strLine.Substring(rightWord + 1, strLine.Length - rightWord - 1);
                return phraseLine;
            }
        }

        public bool WriteDataToExcel(string strFileName,DataTable dt,string sheetType)
        {
            // Read the exist excel
            FileStream fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
           if(strFileName.IndexOf(".xlsx")>0)
           {
               workbook=new XSSFWorkbook(fs);
           }
           else
           {
               workbook=new HSSFWorkbook(fs);
           }
            fs.Close();
            
            //open the exist sheet
            ISheet sheet = workbook.GetSheet("Sheet1");
            if (sheetType == "Phrase")
            {
                sheet = workbook.GetSheet("Sheet2");
            }

            //header
            IRow dataRow; //sheet.CreateRow(0);
            int dataRowCount = sheet.PhysicalNumberOfRows;
            //Data
            for(int i=0;i<dt.Rows.Count;i++)
            {
                dataRow = sheet.CreateRow(dataRowCount+i + 1);
                for(int j=0;j<dt.Columns.Count;j++)
                {
                    dataRow.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                }
            }
            try
            {
                using(FileStream ws = new FileStream(strFileName, FileMode.Open, FileAccess.Write))
                {
                    workbook.Write(ws);
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
