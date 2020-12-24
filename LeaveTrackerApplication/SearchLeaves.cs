using System;
using System.Data;
using System.IO;
//using CsvHelper;
using LumenWorks.Framework.IO.Csv;


namespace LeaveTracker
{
    public class SearchLeaves{
        public void SearchByTitle(int id, string path)
        {
            try{
                    var leavesTable=new DataTable();
                    string title="";
                
                    Console.WriteLine("Enter the Title of Leave to Search :");
                    title=Console.ReadLine();
                    using (var csvReader=new CsvReader(new StreamReader(System.IO.File.OpenRead(path)), true))
                    {
                        leavesTable.Load(csvReader);
                        for(int i=0;i<leavesTable.Rows.Count;i++)
                            {
                                if(id.ToString().Equals(leavesTable.Rows[i][0].ToString()) && title.Equals(leavesTable.Rows[i][3].ToString())){   
                                    System.Console.WriteLine("Title, Description, Start Date, End Date, Status : "
                                    +leavesTable.Rows[i][3]+"\t"+leavesTable.Rows[i][4]+"\t"+leavesTable.Rows[i][5]+"\t"+leavesTable.Rows[i][6]+"\t"+leavesTable.Rows[i][7]);
                                }
                            }
                    
                    }
                }
                catch(Exception){
                    Console.WriteLine("Not able to search by Title....Something went wrong...");
                }
        }

        public void SearchByStatus(int id, string path)
        {
            try{
                var leavesTable=new DataTable();
                string status="";

                Console.WriteLine("Enter the Status of Leave to Search :");
                status=Console.ReadLine();
                using (var csvReader=new CsvReader(new StreamReader(System.IO.File.OpenRead(path)), true))
                {
                    leavesTable.Load(csvReader);
                    for(int i=0;i<leavesTable.Rows.Count;i++)
                        {
                            if(id.ToString().Equals(leavesTable.Rows[i][0].ToString()) && status.Equals(leavesTable.Rows[i][7].ToString())){   
                                System.Console.WriteLine("Title, Description, Start Date, End Date, Status : "
                                +leavesTable.Rows[i][3]+"\t"+leavesTable.Rows[i][4]+"\t"+leavesTable.Rows[i][5]+"\t"+leavesTable.Rows[i][6]+"\t"+leavesTable.Rows[i][7]);
                            }
                        }
                
                }
            }
            catch(Exception){
                Console.WriteLine("Not able to search by status...Somthing went wrong....");
            }
            
        }
    }
}