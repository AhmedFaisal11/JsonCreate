//using System;
//using System.Data.SqlClient;
//using Newtonsoft.Json;
//using jsonCreate.com;
//using System.IO;
//using System.Collections.Generic;
//using System.Linq;


//namespace jsonCreate
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //employee emp = new employee();

//            /* student std = new student();*/

//            // database connection 

//            string Connection = @"Data Source=DESKTOP-2K2N69V;Initial Catalog=CSVImport;Integrated Security=True";

//            string Product, ProductCode , Products;
//            decimal Price;

//            try
//            {
//                using (SqlConnection conn = new SqlConnection(Connection))
//                {
//                    string sql = @"SELECT TOP (1000) [Product],[ProductCode],[Price]
//                                    FROM [CSVImport].[dbo].[Products]";

//                    SqlCommand cmd = new SqlCommand(sql, conn);

//                    conn.Open();



//                    SqlDataReader reader = cmd.ExecuteReader();

//                    Console.WriteLine(Environment.NewLine + "Retriveing Data ..." + Environment.NewLine);

//                    Console.WriteLine("Retrived Reords .....");

//                    if (reader.HasRows)
//                    {
//                        while (reader.Read())
//                        {
//                            Product = reader.GetString(0);
//                            ProductCode = reader.GetString(1);
//                            Price = reader.GetDecimal(2);

//                            //Console.WriteLine("{0} , {1} , {2}", Product, ProductCode, Price);

//                            DataContextDataContext ob = new DataContextDataContext();
//                            //Console.WriteLine(JsonConvert.SerializeObject(Product));



//                            string path = @"D:\c# learning\jsoncreate\jsonfiles\sql.json";


//                            if (File.Exists(path))
//                            {
//                                File.Delete(path);


//                                using (var tw = new StreamWriter(path, true))
//                                {


//                                        tw.WriteLine(Json1.ToString());
//                                        tw.WriteLine(Json2.ToString());
//                                        tw.WriteLine(Json3.ToString());
//                                        tw.Close();


//                                }


//                            }
//                            else if (!File.Exists(path))
//                            {
//                                using (var tw = new StreamWriter(path, true))
//                                {
//                                    tw.WriteLine(Json1.ToString());
//                                    tw.WriteLine(Json2.ToString());
//                                    tw.WriteLine(Json3.ToString());
//                                    tw.Close();
//                                }
//                            }
//                        }
//                    }
//                    else
//                    {
//                        Console.WriteLine("No Data Found ...");
//                    }





//                    reader.Close();

//                    conn.Close();
//                }

//            }
//            catch (Exception err)
//            {

//                Console.WriteLine("Exception : " + err.Message);
//            }
















//        }
//    }
//}

using System;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;

namespace jsonCreate
{
    class Program
    {
       public static void Main(String[] args)
        {
            string conn = @"Data Source=DESKTOP-2K2N69V;Initial Catalog=CSVImport;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    string sql = @"SELECT TOP (1000) [Product],[ProductCode],[Price]
                                    FROM [CSVImport].[dbo].[Products]";

                    SqlCommand cmd = new SqlCommand(sql, connection);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        string Product = reader.GetString(0).Trim();
                        string productCode = reader.GetString(1).Trim() ;
                        decimal price = reader.GetDecimal(2);

                        string json = JsonConvert.SerializeObject(Product , Formatting.Indented);
                        string json2 = JsonConvert.SerializeObject(productCode, Formatting.Indented);
                        string json3 = JsonConvert.SerializeObject(price , Formatting.Indented);

                        string path = @"D:\c# learning\jsoncreate\jsonfiles\sql.json";



                        using (var tw = new StreamWriter(path ,true))
                        {
                                tw.WriteLine(json.ToString().Trim());
                                tw.WriteLine(json2.ToString().Trim());
                                tw.WriteLine(json3.ToString());
                                tw.Close(); 
                            
                        }

                        
                    }

                    Console.WriteLine($"writed succefully ....... ");

                    connection.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        
        
        }
    }

    
}



