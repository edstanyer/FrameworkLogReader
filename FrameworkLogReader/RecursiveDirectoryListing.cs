using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace FrameworkLogReader
{

    public class DirectoryLevel
    {
        public string Path = "";
        public List<DirectoryLevel> Directory = new List<DirectoryLevel>(); 
        public List<string> Files = new List<string>();

    }
    
    

    public class RecursiveDirectoryListing
    {

        /*public bool ObjectGetFiles(DirectoryLevel startDirectory)
        {
            if (!string.IsNullOrEmpty(startDirectory.Path) && Directory.Exists(startDirectory.Path))
            {
                startDirectory.Files = Directory.GetFiles(startDirectory.Path).ToList();
                foreach (string dir in Directory.GetDirectories(startDirectory.Path).ToList())
                {
                    
                }

            }   
        }*/

        public bool GetFiles(ref List<String> fileList, string directory = "", bool subDirectories = true )
        {
            if (!string.IsNullOrEmpty(directory) && Directory.Exists(directory))
            {
                if (fileList == null)
                {
                    fileList = new List<string>();
                }

                List<string> l = new List<string>();
                l = Directory.GetFiles(directory).ToList(); //get all files from this dir
                                                            // and chuck 'em into a temp list

                if ( l.Count > 0) //apparently no null ref check require ! who'da thunk it 
                {                 //Check we have something then ....  
                    foreach (string f in l) // feed the result of ^ into the main output list
                    {
                        fileList.Add(f);
                    }
                }
                
                if (!subDirectories)
                {
                    return false; //de-recurse
                }


                List<string> d = new List<string>();
                d = Directory.GetDirectories(directory).ToList();
                if (d.Count == 0)
                {
                    return false; //return false as we have nowhere to go...
                }

                //Achtung baby - now for the groovy bit - start recursion :o)
                foreach (string s in d)
                {
                    this.GetFiles(ref fileList,  s, true); //recurse

                }
            }
            return false;
        }
    }
}