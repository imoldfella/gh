// See https://aka.ms/new-console-template for more information
namespace Dggc;  // datagrove gherkin compiler

using System.Text.RegularExpressions;
using Gherkin;
using System.Reflection;

// each step is part of a class that will get initialized
class StepSet
{
    public Step[] step = new Step[] { };


    public void compile(string s)
    {
        // should use a trie here, this is o(n^2)
        foreach (var st in step)
        {
            if (st.rg.IsMatch(s))
            {

                break;
            }
        }

    }
}

class Context
{

}

class Step
{
    public Regex rg = new Regex(@"");
    public Step(string s)
    {
        this.rg = new Regex(s);
    }

}
public class Compiler
{

    Compiler()
    {

    }

    static string compile(string file)
    {
        var parser = new Parser();
        var doc = parser.Parse("");

        doc.Feature()

        return "";
    }

    // we should also give this a set of assemblies
    public static string compile(string[] files, Assembly prog)
    {
        var steps = loadSteps(prog);


        var all = new List<string>(files.Count());

        Parallel.For(0, files.Count(),
            i =>
            {
                all[i] = compile(files[i]);
            });

        var errors = "";
        foreach (var e in all)
        {
            errors = errors + e;
        }
        return errors;

    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Gherkin compiler 0.0.1");

        // for now just use support internal compiler
        var e = Assembly.GetExecutingAssembly();

        string[] files = Directory.GetFiles(".",
                   "*.feature",
                   SearchOption.AllDirectories);
        Console.Write(Compiler.compile(files, e));

    }
}
