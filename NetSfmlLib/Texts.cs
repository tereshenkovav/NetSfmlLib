using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace NetSfmlLib
{
    public class Texts
    {
        private Dictionary<String, String> texts;

        public Texts()
        {
            texts = new Dictionary<string, string>();
        }
        public void addText(String key, String text)
	{
	    texts.Add(key,text) ;
	}
        public void loadFromFile(String filename)
        {
            String langfile = ObjModule.opt.getFilenameByLanguageIfExist(filename);
            texts = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(langfile));
        }
        public String getText(string key)
        {
            if (texts.ContainsKey(key)) return texts[key]; else return "???";
        }        
    }
}
