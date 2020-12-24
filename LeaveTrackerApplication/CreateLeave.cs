using System;
using System.Data;
using System.IO;
//using CsvHelper;
using LumenWorks.Framework.IO.Csv;

namespace LeaveTracker
{

    public class CreateLeave
    {
        //Writer w=new Writer();
        public void Leave(Writer w, int id, string path)
        {   
            string title="";
            string description ="";
            string startDate="";
            string endDate="";
            string status="Pending";
            
            System.Console.Write("Please enter Title : ");
            title=Console.ReadLine();

            System.Console.Write("Please enter Description : ");
            description=Console.ReadLine();

            System.Console.Write("Please enter Start Date : ");
            startDate=Console.ReadLine();

            System.Console.Write("Please enter End Date : ");
            endDate=Console.ReadLine();

            ReadData(w, id, title, description, startDate, endDate, status, path);

        }

        private void ReadData(Writer w, int id, string title, string description, string startDate, string endDate, string status, string path1)
        {
            try{
                var csvTable = new DataTable();
                
                string path=@"C:\Users\shriyab\Downloads/employees.csv";
                

                using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(path)), true))  
                {  
                    int i;
                    string creatorName="";
                    string managerName="";
                    string managerId="";
                    
                    csvTable.Load(csvReader);
                    for(i=0;i<csvTable.Rows.Count;i++)
                    {
                        string row=csvTable.Rows[i][0].ToString();
                        
                            if(id.ToString().Equals(csvTable.Rows[i][0].ToString())){
                                creatorName=csvTable.Rows[i][1].ToString();
                                managerId=csvTable.Rows[i][2].ToString();                                
                            }
                        
                    }

                    for(i=0;i<csvTable.Rows.Count;i++){
                        if(managerId.Equals(csvTable.Rows[i][0].ToString())){
                            managerName=csvTable.Rows[i][1].ToString();
                        }
                    }

                    w.WriteToCSV(id, creatorName,managerName, title, description, startDate, endDate, status, path1);

                    
                }
            }
            catch(Exception){
                Console.WriteLine("Not able to read and write data properly.... Something went wrong");
            } 
             
        }
    }


}