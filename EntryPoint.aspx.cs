using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace sample
{
    public partial class EntryPoint : System.Web.UI.Page
    {
        ushort[,] PIDs = new ushort[32, 256];
        protected void Page_Load(object sender, EventArgs e)
        {
            ushort temp = 0;
           
            for (int i = 0; i < 32; i++)
                for (int j = 0; j < 256; j++)
                {
                    PIDs[i, j] = temp++;
                }
        }

        protected void mapping_Click(object sender, EventArgs e)
        {
            string fileName = @"G:\Portfolio\Mahesh.txt";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file     
                using (FileStream fs = File.Create(fileName))
                {
                    
                    for (int i = 1; i <= 32; i++) {
                        string headline = "frame "+0+"1-256";
                        Byte[] title = new UTF8Encoding(true).GetBytes(headline);
                        fs.Write(title, 0, title.Length);

                        for (int j = 0; j < 256; j++)
                        {
                           byte[] PIDarray= BitConverter.GetBytes(PIDs[i, j]);
                            //byte[] author = new UTF8Encoding(true).GetBytes("Mahesh Chand");
                            fs.Write(PIDarray, 0, PIDarray.Length);

                        }
                       
                       

                    }
                    // Add some text to file    
                   
                }

                // Open the stream and read it back.    
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}