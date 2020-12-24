using System;
using System.Data;
using System.IO;
using LumenWorks.Framework.IO.Csv;


namespace LeaveTracker
{
    public class UpdateLeaves
    {
        public void Update(int id, string leaves_path)
        {
            if(id<100 || id>106)
            {
                System.Console.WriteLine("Sorry! You cannot update the leaves");
            }
            else{
                string employee_path=@"C:\Users\shriyab\Downloads/employees.csv";

                string managername="";
                var csvTable = new DataTable();
                int option;
                
                using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(employee_path)), true))  
                {  
                    int i;
                    
                    csvTable.Load(csvReader);
                    
                    for(i=0;i<csvTable.Rows.Count;i++)
                    {
                        string row=csvTable.Rows[i][0].ToString();
                    
                            if(id.ToString().Equals(csvTable.Rows[i][0].ToString())){
                                managername=csvTable.Rows[i][1].ToString();
                            }
                    }
                }

                string[] lines=File.ReadAllLines(leaves_path);

                string text = "Id" +","+"Creator Name"+","+"Manager Name"+","+"Title" +","+"Description"+","+"Start Date" +","+ "End Date" +","+"Status";
                File.WriteAllText(leaves_path,text);
                File.AppendAllText(leaves_path,"\n");

                for(int i=1; i<lines.Length;i++){
                string line=lines[i];
                if(line.Contains(",")){
                    var split=line.Split(',');
                    Console.WriteLine(split[7]);
                    if((split[2]==managername) && (split[7].Contains("Pending"))){
                        System.Console.WriteLine("\nLeave is as : "+line);

                        System.Console.WriteLine("Do You want to approve or reject?");
                        System.Console.WriteLine("1.Approve\t2.Reject\n");
                        System.Console.Write("Kindly enter your choice : ");
                        option = Convert.ToInt32(Console.ReadLine());
                        switch(option)
                        {
                            case 1:
                                split[7]="Approved";
                                line=string.Join(",", split);
                                File.AppendAllText(leaves_path,line);
                                File.AppendAllText(leaves_path,"\n");
                                Console.WriteLine(line);
                                break;

                            case 2:
                                split[7]="Reject";
                                line=string.Join(",", split);
                                File.AppendAllText(leaves_path,line);
                                File.AppendAllText(leaves_path,"\n");
                                Console.WriteLine(line);
                                break;

                            default:
                                System.Console.WriteLine("Incorrect choice");
                                break;

                        }//end of switch

                    }//end of if
                    else{
                        line=string.Join(",", split);
                        File.AppendAllText(leaves_path,line);
                        File.AppendAllText(leaves_path,"\n");
                    }
                }
                }

                                   
            }//end of else
        }//end of Update()    
    }
}
