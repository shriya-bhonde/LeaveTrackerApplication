using System;
using System.IO;
using System.Linq;


namespace LeaveTracker
{
    public class Writer
    {
        //string file_path=@"C:\Users\mrudulap\projects\Leaves.csv";

        public Writer(string file_path)
        {
            if(!(File.Exists(file_path))){   
                string headings = "Id,Creator,Manager,Title,Description,Start Date,End Date,Status" + Environment.NewLine;
                File.WriteAllText(file_path,headings);
            }
        }


        public void WriteToCSV(int id, string creatorName, string managerName, string title, string description, string startDate, string endDate, string status, string file_path)
        {
            string text = id +","+creatorName+","+managerName+","+title +","+description+","+startDate +","+ endDate+","+status;
            File.AppendAllText(file_path,text);
            //File.Replace(file_path);
            File.AppendAllText(file_path, "\n");
            
        }
    }
}