using Demo1;

public class DataConversion
{
    public static void Main(string[] args)
    {
        //1.value to value
        int x = 100;
        long l = x;//implicit
        Console.WriteLine(int.MaxValue);

        int y = (int) l;//Explicit , chance  of  of data loss
        Console.WriteLine($"long: {l}\t int :{y}");

        //2. VALUE TO REFERENCE
        int a = 100;
        object o = a; //boxing, implicit

        //3.Reference to value
        int b = (int)o;//unboxing ,explicit

        //4.Reference to reference
        Parent p = new Parent();    
        Child ch = new Child();

        Parent p2 = new Child();//implict

        Arrays obj=new Arrays();
        obj.arr();

        ConvertMethod cm = new ConvertMethod();
        cm.Demo();


    }
}
class Parent
{
    //todo
}
class Child : Parent
{
    //hello
}

