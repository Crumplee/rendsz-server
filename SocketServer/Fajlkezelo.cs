using System;
using System.Collections.Generic;
using Communication;
using System.Linq;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml.Serialization;


public class Fajlkezelo
{
    private static Fajlkezelo instance = new Fajlkezelo();

    private Fajlkezelo()
    {
    }

    public static Fajlkezelo Instance()
    {
        if (instance == null)
        {
            instance = new Fajlkezelo();
        }
        return instance;
    }

    public void saveTermekek(List<Termek> termekek)
    {
        XmlSerializer xmlSer = new XmlSerializer(typeof(List<Termek>));
        Stream stream = File.OpenWrite("termekeklista.xml");

        xmlSer.Serialize(stream, termekek);
        stream.Close();
        
    }

    public List<Termek> loadTermekek()
    {
        List<Termek> termekek = new List<Termek>();
        
        XmlSerializer deserializer = new XmlSerializer(typeof(List<Termek>));
        TextReader reader = new StreamReader("termekeklista.xml");
        object obj = deserializer.Deserialize(reader);
        termekek = (List<Termek>)obj;
        reader.Close();

        return termekek;
    }

    public void saveMunkarendek(List<Munkarend> munkarendek)
    {
        XmlSerializer xmlSer = new XmlSerializer(typeof(List<Munkarend>));
        Stream stream = File.OpenWrite("munkarendeklista.xml");

        xmlSer.Serialize(stream, munkarendek);
        stream.Close();
    }

    public List<Munkarend> loadMunkarendek()
    {
        List<Munkarend> munkarendek = new List<Munkarend>();
        
        XmlSerializer deserializer = new XmlSerializer(typeof(List<Munkarend>));
        TextReader reader = new StreamReader("munkarendeklista.xml");
        object obj = deserializer.Deserialize(reader);
        munkarendek = (List<Munkarend>)obj;
        reader.Close();

        return munkarendek;
    }

    public void saveTerminalBeosztasok(List<TerminalBeosztas> terminalbeosztasok)
    {
        XmlSerializer xmlSer = new XmlSerializer(typeof(List<TerminalBeosztas>));
        Stream stream = File.OpenWrite("terminalbeosztasoklista.xml");

        xmlSer.Serialize(stream, terminalbeosztasok);
        stream.Close();
    }
    public List<TerminalBeosztas> loadTerminalBeosztasok()
    {
        List<TerminalBeosztas> terminalbeosztasok = new List<TerminalBeosztas>();

        XmlSerializer deserializer = new XmlSerializer(typeof(List<TerminalBeosztas>));
        TextReader reader = new StreamReader("munkarendeklista.xml");
        object obj = deserializer.Deserialize(reader);
        terminalbeosztasok = (List<TerminalBeosztas>)obj;
        reader.Close();

        return terminalbeosztasok;
    }
}
