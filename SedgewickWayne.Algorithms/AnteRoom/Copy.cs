
public class Copy
{


    public Copy()
    {
    }


    /**/
    public static void main(string[] strarr)
    {
        while (!BinaryStdIn.IsEmpty)
        {
            int ch = (int)BinaryStdIn.readChar();
            BinaryStdOut.write((char)ch);
        }
        BinaryStdOut.flush();
    }
}