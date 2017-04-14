using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{

    public class PictureDump
    {


        public PictureDump()
        {
        }


        /**/
        public static void main(string[] strarr)
        {
            int num = Integer.parseInt(strarr[0]);
            int num2 = Integer.parseInt(strarr[1]);
            Picture picture = new Picture(num, num2);
            int num3 = 0;
            for (int i = 0; i < num2; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    picture.set(j, i, Color.RED);
                    if (!BinaryStdIn.IsEmpty)
                    {
                        num3++;
                        int num4 = BinaryStdIn.readBoolean() ? 1 : 0;
                        if (num4 != 0)
                        {
                            picture.set(j, i, Color.BLACK);
                        }
                        else
                        {
                            picture.set(j, i, Color.WHITE);
                        }
                    }
                }
            }
            picture.show();
            StdOut.println(new StringBuilder().append(num3).append(" bits").toString());
        }
    }

    using java.awt.@event;
    using java.awt.image;




    using javax.imageio;
    using javax.swing;


    /*[Implements(new string[]
    {
        "java.awt.event.ActionListener"
    })]*/
    public sealed class Picture, ActionListener, EventListener
{
	private BufferedImage image;
    private JFrame frame;
    private string filename;
    private bool isOriginUpperLeft;
    //[Modifiers(Modifiers.Private | Modifiers.Final)]
    private int width;
    //[Modifiers(Modifiers.Private | Modifiers.Final)]
    private int height;


    public Picture(int i1, int i2)
    {
        this.isOriginUpperLeft = true;
        if (i1 < 0)
        {
            string arg_1D_0 = "width must be nonnegative";

            throw new ArgumentException(arg_1D_0);
        }
        if (i2 < 0)
        {
            string arg_31_0 = "height must be nonnegative";

            throw new ArgumentException(arg_31_0);
        }
        this.width = i1;
        this.height = i2;
        this.image = new BufferedImage(i1, i2, 1);
        this.filename = new StringBuilder().append(i1).append("-by-").append(i2).toString();
    }


    public virtual void set(int i1, int i2, Color c)
    {
        if (i1 < 0 || i1 >= this.width())
        {
            string arg_33_0 = new StringBuilder().append("x must be between 0 and ").append(this.width() - 1).toString();

            throw new IndexOutOfRangeException(arg_33_0);
        }
        if (i2 < 0 || i2 >= this.height())
        {
            string arg_6C_0 = new StringBuilder().append("y must be between 0 and ").append(this.height() - 1).toString();

            throw new IndexOutOfRangeException(arg_6C_0);
        }
        if (c == null)
        {
            string arg_7F_0 = "can't set Color to null";

            throw new NullPointerException(arg_7F_0);
        }
        if (this.isOriginUpperLeft)
        {
            this.image.setRGB(i1, i2, c.getRGB());
        }
        else
        {
            this.image.setRGB(i1, this.height - i2 - 1, c.getRGB());
        }
    }


    public virtual void show()
    {
        if (this.frame == null)
        {
            this.frame = new JFrame();
            JMenuBar jMenuBar = new JMenuBar();
            JMenu jMenu = new JMenu("File");
            jMenuBar.add(jMenu);
            JMenuItem jMenuItem = new JMenuItem(" Save...   ");
            jMenuItem.addActionListener(this);
            jMenuItem.setAccelerator(KeyStroke.getKeyStroke(83, Toolkit.getDefaultToolkit().getMenuShortcutKeyMask()));
            jMenu.add(jMenuItem);
            this.frame.setJMenuBar(jMenuBar);
            this.frame.setContentPane(this.getJLabel());
            this.frame.setDefaultCloseOperation(2);
            this.frame.setTitle(this.filename);
            this.frame.setResizable(false);
            this.frame.pack();
            this.frame.setVisible(true);
        }
        this.frame.repaint();
    }
    public virtual int width()
    {
        return this.width;
    }
    public virtual int height()
    {
        return this.height;
    }


    public virtual Color get(int i1, int i2)
    {
        if (i1 < 0 || i1 >= this.width())
        {
            string arg_33_0 = new StringBuilder().append("x must be between 0 and ").append(this.width() - 1).toString();

            throw new IndexOutOfRangeException(arg_33_0);
        }
        if (i2 < 0 || i2 >= this.height())
        {
            string arg_6C_0 = new StringBuilder().append("y must be between 0 and ").append(this.height() - 1).toString();

            throw new IndexOutOfRangeException(arg_6C_0);
        }
        if (this.isOriginUpperLeft)
        {
            Color.__<clinit>();
            return new Color(this.image.getRGB(i1, i2));
        }
        Color.__<clinit>();
        return new Color(this.image.getRGB(i1, this.height - i2 - 1));
    }


    public virtual JLabel getJLabel()
    {
        if (this.image == null)
        {
            return null;
        }
        ImageIcon.__<clinit>();
        ImageIcon imageIcon = new ImageIcon(this.image);
        return new JLabel(imageIcon);
    }


    public virtual void save(File f)
    {
        this.filename = f.getName();
        if (this.frame != null)
        {
            this.frame.setTitle(this.filename);
        }
        string text = java.lang.String.instancehelper_substring(this.filename, java.lang.String.instancehelper_lastIndexOf(this.filename, 46) + 1);
        text = java.lang.String.instancehelper_toLowerCase(text);
        if (!java.lang.String.instancehelper_equals(text, "jpg"))
        {
            if (!java.lang.String.instancehelper_equals(text, "png"))
            {
                System.@out.println("Error: filename must end in .jpg or .png");
                return;
            }
        }
        IOException ex;
        try
        {
            ImageIO.write(this.image, text, f);
        }
        catch (IOException arg_74_0)
        {
            ex = ByteCodeHelper.MapException<IOException>(arg_74_0, ByteCodeHelper.MapFlags.NoRemapping);
            goto IL_7E;
        }
        return;
        IL_7E:
        IOException this2 = ex;
        Throwable.instancehelper_printStackTrace(this2);
    }


    public virtual void save(string str)
    {
        this.save(new File(str));
    }


    public Picture(string str)
    {
        this.isOriginUpperLeft = true;
        this.filename = str;
        try
        {
            File file = new File(str);
            if (file.isFile())
            {
                this.image = ImageIO.read(file);
            }
            else
            {
                URL uRL = java.lang.Object.instancehelper_getClass(this).getResource(str);
                if (uRL == null)
                {
                    uRL = new URL(str);
                }
                this.image = ImageIO.read(uRL);
            }
            this.width = this.image.getWidth(null);
            this.height = this.image.getHeight(null);
        }
        catch (IOException arg_7E_0)
        {
            goto IL_82;
        }
        return;
        IL_82:
        string arg_A7_0 = new StringBuilder().append("Could not open file: ").append(str).toString();

        throw new RuntimeException(arg_A7_0);
    }


    public Picture(Picture p)
    {
        this.isOriginUpperLeft = true;
        this.width = p.width();
        this.height = p.height();
        BufferedImage.__<clinit>();
        this.image = new BufferedImage(this.width, this.height, 1);
        this.filename = p.filename;
        for (int i = 0; i < this.width(); i++)
        {
            for (int j = 0; j < this.height(); j++)
            {
                this.image.setRGB(i, j, p.get(i, j).getRGB());
            }
        }
    }


    public Picture(File f)
    {
        this.isOriginUpperLeft = true;
        IOException ex;
        try
        {
            this.image = ImageIO.read(f);
        }
        catch (IOException arg_20_0)
        {
            ex = ByteCodeHelper.MapException<IOException>(arg_20_0, ByteCodeHelper.MapFlags.NoRemapping);
            goto IL_2A;
        }
        if (this.image == null)
        {
            string arg_82_0 = new StringBuilder().append("Invalid image file: ").append(f).toString();

            throw new RuntimeException(arg_82_0);
        }
        this.width = this.image.getWidth(null);
        this.height = this.image.getHeight(null);
        this.filename = f.getName();
        return;
        IL_2A:
        IOException this2 = ex;
        Throwable.instancehelper_printStackTrace(this2);
        string arg_55_0 = new StringBuilder().append("Could not open file: ").append(f).toString();

        throw new RuntimeException(arg_55_0);
    }
    public virtual void setOriginUpperLeft()
    {
        this.isOriginUpperLeft = true;
    }
    public virtual void setOriginLowerLeft()
    {
        this.isOriginUpperLeft = false;
    }


    public override bool equals(object obj)
    {
        if (obj == this)
        {
            return true;
        }
        if (obj == null)
        {
            return false;
        }
        if (obj.GetType() != this.GetType())
        {
            return false;
        }
        Picture picture = (Picture)obj;
        if (this.width() != picture.width())
        {
            return false;
        }
        if (this.height() != picture.height())
        {
            return false;
        }
        for (int i = 0; i < this.width(); i++)
        {
            for (int j = 0; j < this.height(); j++)
            {
                if (!this.get(i, j).Equals(picture.get(i, j)))
                {
                    return false;
                }
            }
        }
        return true;
    }


    public virtual void actionPerformed(ActionEvent ae)
    {
        FileDialog.__<clinit>();
        FileDialog fileDialog = new FileDialog(this.frame, "Use a .png or .jpg extension", 1);
        fileDialog.setVisible(true);
        if (fileDialog.getFile() != null)
        {
            this.save(new StringBuilder().append(fileDialog.getDirectory()).append(File.separator).append(fileDialog.getFile()).toString());
        }
    }


    /**/
    public static void main(string[] strarr)
    {
        Picture picture = new Picture(strarr[0]);
        System.@out.printf("%d-by-%d\n", new object[]
        {
            Integer.valueOf(picture.width()),
            Integer.valueOf(picture.height())
        });
        picture.show();
    }
}

}
