using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;
  }


  public class FA1
  {
    public static State init = new State()
    {
        Name = "init",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public static State one0 = new State()
    {
        Name = "one 0",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public static State one1 = new State()
    {
        Name = "one 1",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public static State ones = new State()
    {
        Name = "ones",
        IsAcceptState = true,
        Transitions = new Dictionary<char, State>()
    };
    public static State fault = new State()
    {
        Name = "fault",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public FA1()
    {
        init.Transactions['0'] = one0;
        init.Transactions['1'] = one1;
        one0.Transactions['0'] = fault;
        one0.Transactions['1'] = ones;
        one1.Transactions['0'] = ones;
        one1.Transactions['1'] = one1;
        ones.Transactions['0'] = fault;
        ones.Transactions['1'] = ones;
        fault.Transactions['0'] = fault;
        fault.Transactions['1'] = fault;
        
    }
    state Init = a;
    public bool? Run(IEnumerable<char> s)
    {
       State current = Init;
       foreach (var c in s) 
       {
           current = current.Transitions[c]; 
           if (current == null)             
               return null;
       }
       return current.IsAcceptState;
    }
  }

  public class FA2
  {
    public bool? Run(IEnumerable<char> s)
    {
      return false;
    }
  }
  
  public class FA3
  {
    public bool? Run(IEnumerable<char> s)
    {
      return false;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      String s = "01111";
      FA1 fa1 = new FA1();
      bool? result1 = fa1.Run(s);
      Console.WriteLine(result1);
      FA2 fa2 = new FA2();
      bool? result2 = fa2.Run(s);
      Console.WriteLine(result2);
      FA3 fa3 = new FA3();
      bool? result3 = fa3.Run(s);
      Console.WriteLine(result3);
    }
  }
}
