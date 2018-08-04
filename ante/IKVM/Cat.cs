
public class Cat
{


    private Cat()
    {
    }


    /**/
    public static void main(string[] strarr)
    {
        Out.__<clinit>();
        Out @out = new Out(strarr[strarr.Length - 1]);
        for (int i = 0; i < strarr.Length - 1; i++)
        {

            In @in = new In(strarr[i]);
            string obj = @in.readAll();
            @out.println(obj);
            @in.close();
        }
        @out.close();
    }
}