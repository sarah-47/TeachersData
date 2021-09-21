using System;
using System.IO;

namespace Project1_TeacherData
{
    class Program
    {

        class TeachersFile {
            string path = @"C:\Users\Lenovo\Desktop\TeachersData.txt";
            StreamWriter tdata;
            public void addData()
            {

                int tID;
                string tName, tClass, tSection;
                tdata = File.AppendText(path);

                if (File.Exists(path))
                {
                    try
                    {
                        Console.WriteLine("Enter the teacher's ID: ");
                        tID = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter the teacher's Name: ");
                        tName = Console.ReadLine();

                        Console.WriteLine("Enter the teacher's Class: ");
                        tClass = Console.ReadLine();

                        Console.WriteLine("Enter the teacher's Section: ");
                        tSection = Console.ReadLine();

                        tdata.WriteLine($"ID: {tID} Name: {tName} Class: {tClass} Section: {tSection}");
                        tdata.Close();

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("The ID should be a number ");

                    }
                }
                else {
                    tdata.WriteLine();
                    addData();

                }
               
            }

            public int updateData(int oldID ,int id,string name,string _class,string section) {

                
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] line = lines[i].Split("-");
                    if (line[0].Contains(oldID.ToString()))
                    {
                        lines[i] = $"ID: {id} Name: {name} class: {_class} section: {section}";
                        File.WriteAllLines(path, lines);
                        return 1;
                    }

                }return 0;
                    
                


            }
            
            public int findData(int id) {
             
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] line = lines[i].Split("-");
                    if (line[0].Contains(id.ToString()))
                    {
                        Console.WriteLine(line[0]);
                        return 1;
                    }

                }
                return 0;
            }

            

            
            public void readFile() {
               string file= File.ReadAllText(path);
                Console.WriteLine(file);

            }

        }
        static void Main(string[] args)
        {
            
            TeachersFile tf = new TeachersFile();
            bool s = true;
            while (s)
            {
                Console.WriteLine("Enter the number of the operaction you want to do:");
                Console.WriteLine("1-Add new teacher data \n2-Update teacher data \n3-Read the teacher file \n4-find teacher data \n5-Exit");

                int? op =null;

                try
                {
                     op = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
              
                    Console.WriteLine("Pleace enter a number");
                }
                switch (op)
                {
                    //ADD
                    case 1:

                        tf.addData();
                        break;

                    //Update
                    case 2:
                        Console.WriteLine("Enter the teacher ID:");
                        int oldID = Convert.ToInt32(Console.ReadLine());
                        int fd = tf.findData(oldID);
                        if (fd==1) {
                            try
                            {
                                Console.WriteLine("Enter new ID");
                                int nID = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter new Name ");
                                string nName = Console.ReadLine();
                                Console.WriteLine("Enter new Class");
                                string nClass = Console.ReadLine();
                                Console.WriteLine("Enter new Section");
                                string nSection = Console.ReadLine();
                                int ud = tf.updateData(oldID, nID, nName, nClass, nSection);
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine("Pleace enter a number");

                            }
                        }
                        else
                            Console.WriteLine("Data not found");
                        break;

                    //Read
                    case 3:
                        tf.readFile();
                        break;

                        //find
                    case 4:
                        Console.WriteLine("Enter the teacher ID:");

                        int iid = Convert.ToInt32(Console.ReadLine());
                        int ftd=tf.findData(iid);
                        if (ftd == 0)
                        {
                            Console.WriteLine("Data not found");
                        }
                        
                        break;

                    //done
                    case 5:
                        Console.WriteLine("Thank you");
                        s = false;

                        break;

                }

            }
            Console.ReadKey();

        }
        } 
}
    

