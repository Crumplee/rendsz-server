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
        TextReader reader = new StreamReader("terminalbeosztasoklista.xml");
        object obj = deserializer.Deserialize(reader);
        terminalbeosztasok = (List<TerminalBeosztas>)obj;
        reader.Close();

        return terminalbeosztasok;
    }

    public void saveDolgozok(List<Dolgozo> dolgozok)
    {
        XmlSerializer xmlSer = new XmlSerializer(typeof(List<Dolgozo>));
        Stream stream = File.OpenWrite("dolgozoklista.xml");

        xmlSer.Serialize(stream, dolgozok);
        stream.Close();
    }

    public List<Dolgozo> loadDolgozok()
    {
        List<Dolgozo> dolgozok = new List<Dolgozo>();

        XmlSerializer deserializer = new XmlSerializer(typeof(List<Dolgozo>));
        TextReader reader = new StreamReader("dolgozoklista.xml");
        object obj = deserializer.Deserialize(reader);
        dolgozok = (List<Dolgozo>)obj;
        reader.Close();

        return dolgozok;
    }    public List<Raklaphely> loadRaklaphelyek()
    {
        List<Raklaphely> raklaphelyek = new List<Raklaphely>();

        XmlSerializer deserializer = new XmlSerializer(typeof(List<Raklaphely>));
        TextReader reader = new StreamReader("raklaphelyeklista.xml");
        object obj = deserializer.Deserialize(reader);
        raklaphelyek = (List<Raklaphely>)obj;
        reader.Close();

        return raklaphelyek;
    }    public void saveRaklaphelyek(List<Raklaphely> raklaphelyek)
    {
        XmlSerializer xmlSer = new XmlSerializer(typeof(List<Raklaphely>));
        Stream stream = File.OpenWrite("terminaloklista.xml");

        xmlSer.Serialize(stream, raklaphelyek);
        stream.Close();
    }

   
     public List<Terminal> loadTerminalok()
    {
        List<Terminal> terminalok = new List<Terminal>();

        XmlSerializer deserializer = new XmlSerializer(typeof(List<Terminal>));
        TextReader reader = new StreamReader("terminaloklista.xml");
        object obj = deserializer.Deserialize(reader);
        terminalok = (List<Terminal>)obj;
        reader.Close();

        return terminalok;
    }
}
