using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace ConAppAssignment6
{
    internal class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        static SqlDataReader srdr;
        public static string c = "server=NAVEEN-BOOK-8C9;Database=ProductInventoryDb;trusted_connection=true";
        static string Query;
        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection(c);
                cmd = new SqlCommand
                {
                    Connection = con,
                };
                con.Open();
                Console.WriteLine("Enter Operation you want to perform \n1.Retrive Data\n2.Add New Product\n3.Update\n4.Remove");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Query = "select * from Products";
                        cmd.CommandText = Query;
                        break;
                    case 2:
                        Query = "insert into Products values (@id,@name,@price,@qt,@mfg,@exp)";
                        cmd.CommandText = Query;
                        Console.WriteLine("Enter Product ID");
                        cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));
                        Console.WriteLine("Enter Product Name");
                        cmd.Parameters.AddWithValue("@name", Console.ReadLine());
                        Console.WriteLine("ENter Product Price");
                        cmd.Parameters.AddWithValue("@price", float.Parse(Console.ReadLine()));
                        Console.WriteLine("Enter Product Quantity");
                        cmd.Parameters.AddWithValue("@qt", int.Parse(Console.ReadLine()));
                        Console.WriteLine("Enter Product Mfg Data");
                        cmd.Parameters.AddWithValue("@mfg", DateTime.Parse(Console.ReadLine()));
                        Console.WriteLine("Enter Product Exp Data");
                        cmd.Parameters.AddWithValue("@exp", DateTime.Parse(Console.ReadLine()));
                        
                        break;
                    case 3:
                        Query = "update Products set ProductName=@name,price=@price,Quantity=@qt,MfDate=@mfg,ExpDate=@exp where ProductId=@id";
                        cmd.CommandText = Query;
                        Console.WriteLine("Enter Product ID Update");
                        cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));
                        Console.WriteLine("Enter Product Name");
                        cmd.Parameters.AddWithValue("@name", Console.ReadLine());
                        Console.WriteLine("ENter Product Price");
                        cmd.Parameters.AddWithValue("@price", float.Parse(Console.ReadLine()));
                        Console.WriteLine("Enter Product Quantity");
                        cmd.Parameters.AddWithValue("@qt", int.Parse(Console.ReadLine()));
                        Console.WriteLine("Enter Product Mfg Data");
                        cmd.Parameters.AddWithValue("@mfg", DateTime.Parse(Console.ReadLine()));
                        Console.WriteLine("Enter Product Exp Data");
                        cmd.Parameters.AddWithValue("@exp", DateTime.Parse(Console.ReadLine()));
                        break;
                    case 4:
                        Query = "delete from Products where ProductId=@id";
                        cmd.CommandText = Query;
                        Console.WriteLine("Enter Product ID");
                        cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));
                        break;
                    default:
                        break;
                } 
                if (option==1)
                {
                    srdr = cmd.ExecuteReader();
                    while (srdr.Read())
                    {
                        Console.WriteLine("ProductId :" + srdr["ProductId"]);
                        Console.WriteLine("ProductName:" + srdr["ProductName"]);
                        Console.WriteLine("price  :" + srdr["price"]);
                        Console.WriteLine("Quantity:" + srdr["Quantity"]);
                        Console.WriteLine("MfDate:" + srdr["MfDate"]);
                        Console.WriteLine("ExpDate:" + srdr["ExpDate"]);
                        Console.WriteLine("*********************************");
                        Console.WriteLine("\n");
                    }
                }
                else if (option==2)
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record Inserted Succesfully !!!");
                }
                else if (option==3)
                {
                    int nop = cmd.ExecuteNonQuery();
                    if (nop > 0)
                    {
                        Console.WriteLine("Record updated succesfully !!!");
                    }
                }
                else
                {
                    int nop = cmd.ExecuteNonQuery();
                    if (nop > 0)
                    {
                        Console.WriteLine("Record deleted succesfully !!!");
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error !!!" + ex.Message);
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }
    }
}
