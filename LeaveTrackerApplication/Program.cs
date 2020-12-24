using System;
using System.IO;

namespace LeaveTracker
{
    public class Program
    {
        static string path = "";

        public bool PathGetter(){
            try{
                    p:
                        Console.WriteLine("Enter Path to csv file : ");
                        path=Console.ReadLine();  
                    FileInfo fi = new FileInfo(path);  
        
                    // Get File Name  
                    string FileName = fi.Name;  
                    
                    string extn = fi.Extension;
                    //Console.WriteLine("File Extension: {0}", extn);
                    if(extn!=".csv"){
                        Console.WriteLine("Invalid Extension");
                        goto p;
                    }
                    return true;
                }
                catch(Exception ){
                    Console.WriteLine("Invalid Path");
                    return false;
                }
        }
        
        
        static void Main(string[] args)
        {
            int id;
            int choice;
            
            
            do{
                
                Console.WriteLine("Enter the Employee ID : ");
                id=Convert.ToInt32(Console.ReadLine());
                
            }while(id<100 && id>=110);


            
            Program p=new Program();
            p.PathGetter();
            Writer w=new Writer(path);

            do{
                Console.WriteLine("Menu : 1.Create Leave\t2.List Of Leaves\t3.Update Leave\t4.Search Leave\n");
                Console.WriteLine("Please Enter your choice : ");
                choice=Convert.ToInt32(Console.ReadLine());
                switch(choice){
                    case 1 :{
                        //call to create leave
                        CreateLeave cl=new CreateLeave();
                        cl.Leave(w,id,path);
                        break;
                    }
                    case 2 :{
                        //call to List of leave
                        ListLeaves list= new ListLeaves();
                        list.List(id, path);
                        break;
                    }
                    case 3 :{
                        //call to Update leave
                        UpdateLeaves ul= new UpdateLeaves();
                        ul.Update(id, path);
                        break;
                    }
                    case 4 :{
                        //call to Search leave
                        int ch;
                        Console.WriteLine("Search By\n1.Title\n2.Status\n");
                        Console.WriteLine("Please Enter Your choice : ");
                        ch=Convert.ToInt32(Console.ReadLine());
                        switch(ch){
                            case 1 :{
                                //search by title
                                SearchLeaves sl= new SearchLeaves();
                                sl.SearchByTitle(id, path);
                                break;
                            }
                            case 2 :{
                                //search by status
                                SearchLeaves sl= new SearchLeaves();
                                sl.SearchByStatus(id, path);
                                break;
                                
                            }
                            default :
                                Console.WriteLine("Invalid choice\n");
                                break;
                        }
                        break;
                    }
                    case 0 :{
                        return;
                        
                    }
                    default:
                        Console.WriteLine("Invalid choice\n");
                        break;


                }
            }while(choice!=0);


            
        }
    }
}
