
public interface DrawListener
{
    void mousePressed(double d1, double d2);
    void mouseReleased(double d1, double d2);
    void mouseDragged(double d1, double d2);
    void keyTyped(char ch);
}

using java.awt.@event;
using java.awt.geom;
using java.awt.image;
using javax.imageio;
using javax.swing;


/*[Implements(new string[]
{
	"java.awt.event.ActionListener",
	"java.awt.event.MouseListener",
	"java.awt.event.MouseMotionListener",
	"java.awt.event.KeyListener"
})]*/
public sealed class Draw, ActionListener, EventListener, MouseListener, MouseMotionListener, KeyListener
{
	internal static Color __BLACK;
internal static Color __BLUE;
internal static Color __CYAN;
internal static Color __DARK_GRAY;
internal static Color __GRAY;
internal static Color __GREEN;
internal static Color __LIGHT_GRAY;
internal static Color __MAGENTA;
internal static Color __ORANGE;
internal static Color __PINK;
internal static Color __RED;
internal static Color __WHITE;
internal static Color __YELLOW;
internal static Color __BOOK_BLUE;
internal static Color __BOOK_RED;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
private static Color DEFAULT_PEN_COLOR;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
private static Color DEFAULT_CLEAR_COLOR;
private const double BORDER = 0.05;
private const double DEFAULT_XMIN = 0.0;
private const double DEFAULT_XMAX = 1.0;
private const double DEFAULT_YMIN = 0.0;
private const double DEFAULT_YMAX = 1.0;
private const int DEFAULT_SIZE = 512;
private const double DEFAULT_PEN_RADIUS = 0.002;
//[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
private static Font DEFAULT_FONT;
private Color penColor;
private int width;
private int height;
private double penRadius;
private bool defer;
private double xmin;
private double ymin;
private double xmax;
private double ymax;
private string name;
private object mouseLock;
private object keyLock;
private Font font;
private BufferedImage offscreenImage;
private BufferedImage onscreenImage;
private Graphics2D offscreen;
private Graphics2D onscreen;
private JFrame frame;
private bool mousePressed;
private double mouseX;
private double mouseY;
//[Signature("Ljava/util/LinkedList<Ljava/lang/Character;>;")]
private LinkedList keysTyped;
//[Signature("Ljava/util/TreeSet<Ljava/lang/Integer;>;")]
private TreeSet keysDown;
//[Signature("Ljava/util/ArrayList<LDrawListener;>;")]
private ArrayList listeners;
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Color BLACK
{

    get
    {
        return Draw.__BLACK;
    }
}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Color BLUE
{

    get
    {
        return Draw.__BLUE;
    }
}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Color CYAN
{

    get
    {
        return Draw.__CYAN;
    }
}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Color DARK_GRAY
{

    get
    {
        return Draw.__DARK_GRAY;
    }
}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Color GRAY
{

    get
    {
        return Draw.__GRAY;
    }
}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Color GREEN
{

    get
    {
        return Draw.__GREEN;
    }
}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Color LIGHT_GRAY
{

    get
    {
        return Draw.__LIGHT_GRAY;
    }
}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Color MAGENTA
{

    get
    {
        return Draw.__MAGENTA;
    }
}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Color ORANGE
{

    get
    {
        return Draw.__ORANGE;
    }
}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Color PINK
{

    get
    {
        return Draw.__PINK;
    }
}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Color RED
{

    get
    {
        return Draw.__RED;
    }
}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Color WHITE
{

    get
    {
        return Draw.__WHITE;
    }
}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Color YELLOW
{

    get
    {
        return Draw.__YELLOW;
    }
}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Color BOOK_BLUE
{

    get
    {
        return Draw.__BOOK_BLUE;
    }
}
//[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
public static Color BOOK_RED
{

    get
    {
        return Draw.__BOOK_RED;
    }
}




private void init()
{
    if (this.frame != null)
    {
        this.frame.setVisible(false);
    }
    this.frame = new JFrame();
    BufferedImage.__<clinit>();
    this.offscreenImage = new BufferedImage(this.width, this.height, 2);
    BufferedImage.__<clinit>();
    this.onscreenImage = new BufferedImage(this.width, this.height, 2);
    this.offscreen = this.offscreenImage.createGraphics();
    this.onscreen = this.onscreenImage.createGraphics();
    this.setXscale();
    this.setYscale();
    this.offscreen.setColor(Draw.DEFAULT_CLEAR_COLOR);
    this.offscreen.fillRect(0, 0, this.width, this.height);
    this.setPenColor();
    this.setPenRadius();
    this.setFont();
    this.clear();
    RenderingHints.__<clinit>();
    RenderingHints renderingHints = new RenderingHints(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
    renderingHints.put(RenderingHints.KEY_RENDERING, RenderingHints.VALUE_RENDER_QUALITY);
    this.offscreen.addRenderingHints(renderingHints);
    ImageIcon.__<clinit>();
    ImageIcon image = new ImageIcon(this.onscreenImage);
    JLabel jLabel = new JLabel(image);
    jLabel.addMouseListener(this);
    jLabel.addMouseMotionListener(this);
    this.frame.setContentPane(jLabel);
    this.frame.addKeyListener(this);
    this.frame.setResizable(false);
    this.frame.setDefaultCloseOperation(2);
    this.frame.setTitle(this.name);
    this.frame.setJMenuBar(this.createMenuBar());
    this.frame.pack();
    this.frame.requestFocusInWindow();
    this.frame.setVisible(true);
}


public virtual void setXscale()
{
    this.setXscale((double)0f, (double)1f);
}


public virtual void setYscale()
{
    this.setYscale((double)0f, (double)1f);
}


public virtual void setPenColor()
{
    this.setPenColor(Draw.DEFAULT_PEN_COLOR);
}


public virtual void setPenRadius()
{
    this.setPenRadius(0.002);
}


public virtual void setFont()
{
    this.setFont(Draw.DEFAULT_FONT);
}


public virtual void clear()
{
    this.clear(Draw.DEFAULT_CLEAR_COLOR);
}


private JMenuBar createMenuBar()
{
    JMenuBar jMenuBar = new JMenuBar();
    JMenu jMenu = new JMenu("File");
    jMenuBar.add(jMenu);
    JMenuItem jMenuItem = new JMenuItem(" Save...   ");
    jMenuItem.addActionListener(this);
    jMenuItem.setAccelerator(KeyStroke.getKeyStroke(83, Toolkit.getDefaultToolkit().getMenuShortcutKeyMask()));
    jMenu.add(jMenuItem);
    return jMenuBar;
}
public virtual void setXscale(double d1, double d2)
{
    double num = d2 - d1;
    this.xmin = d1 - 0.05 * num;
    this.xmax = d2 + 0.05 * num;
}
public virtual void setYscale(double d1, double d2)
{
    double num = d2 - d1;
    this.ymin = d1 - 0.05 * num;
    this.ymax = d2 + 0.05 * num;
}


public virtual void clear(Color c)
{
    this.offscreen.setColor(c);
    this.offscreen.fillRect(0, 0, this.width, this.height);
    this.offscreen.setColor(this.penColor);
    this.draw();
}


private void draw()
{
    if (this.defer)
    {
        return;
    }
    this.onscreen.drawImage(this.offscreenImage, 0, 0, null);
    this.frame.repaint();
}


public virtual void setPenRadius(double d)
{
    if (d < (double)0f)
    {
        string arg_13_0 = "pen radius must be positive";

        throw new RuntimeException(arg_13_0);
    }
    this.penRadius = d * 512.0;
    BasicStroke stroke = new BasicStroke((float)this.penRadius, 1, 1);
    this.offscreen.setStroke(stroke);
}


public virtual void setPenColor(Color c)
{
    this.penColor = c;
    this.offscreen.setColor(this.penColor);
}
public virtual void setFont(Font f)
{
    this.font = f;
}
private double scaleX(double num)
{
    return (double)this.width * (num - this.xmin) / (this.xmax - this.xmin);
}
private double scaleY(double num)
{
    return (double)this.height * (this.ymax - num) / (this.ymax - this.ymin);
}


private void pixel(double num, double num2)
{
    this.offscreen.fillRect((int)java.lang.Math.round(this.scaleX(num)), (int)java.lang.Math.round(this.scaleY(num2)), 1, 1);
}


private double factorX(double num)
{
    return num * (double)this.width / java.lang.Math.abs(this.xmax - this.xmin);
}


private double factorY(double num)
{
    return num * (double)this.height / java.lang.Math.abs(this.ymax - this.ymin);
}


private Image getImage(string text)
{
    ImageIcon imageIcon = new ImageIcon(text);
    if (imageIcon != null)
    {
        if (imageIcon.getImageLoadStatus() == 8)
        {
            goto IL_39;
        }
    }
    try
    {
        URL uRL = new URL(text);
        imageIcon = new ImageIcon(uRL);
    }
    catch (System.Exception arg_26_0)
    {
        if (ByteCodeHelper.MapException<java.lang.Exception>(arg_26_0, ByteCodeHelper.MapFlags.Unused) == null)
        {
            throw;
        }
    }
    IL_39:
    if (imageIcon == null || imageIcon.getImageLoadStatus() != 8)
    {
        URL uRL = ClassLiteral<Draw>.Value.getResource(text);
        if (uRL == null)
        {
            string arg_7D_0 = new StringBuilder().append("image ").append(text).append(" not found").toString();

            throw new RuntimeException(arg_7D_0);
        }
        imageIcon = new ImageIcon(uRL);
    }
    return imageIcon.getImage();
}


public virtual void text(double d1, double d2, string str)
{
    this.offscreen.setFont(this.font);
    FontMetrics fontMetrics = this.offscreen.getFontMetrics();
    double num = this.scaleX(d1);
    double num2 = this.scaleY(d2);
    int num3 = fontMetrics.stringWidth(str);
    int descent = fontMetrics.getDescent();
    this.offscreen.drawString(str, (float)(num - (double)num3 / 2.0), (float)(num2 + (double)descent));
    this.draw();
}


public virtual void show()
{
    this.defer = false;
    this.draw();
}


public virtual void save(string str)
{
    File output = new File(str);
    string text = java.lang.String.instancehelper_substring(str, java.lang.String.instancehelper_lastIndexOf(str, 46) + 1);
    if (java.lang.String.instancehelper_equals(java.lang.String.instancehelper_toLowerCase(text), "png"))
    {
        IOException ex;
        try
        {
            ImageIO.write(this.offscreenImage, text, output);
        }
        catch (IOException arg_3D_0)
        {
            ex = ByteCodeHelper.MapException<IOException>(arg_3D_0, ByteCodeHelper.MapFlags.NoRemapping);
            goto IL_47;
        }
        return;
        IL_47:
        IOException this2 = ex;
        Throwable.instancehelper_printStackTrace(this2);
    }
    else if (java.lang.String.instancehelper_equals(java.lang.String.instancehelper_toLowerCase(text), "jpg"))
    {
        WritableRaster raster = this.offscreenImage.getRaster();
        WritableRaster raster2 = raster.createWritableChild(0, 0, this.width, this.height, 0, 0, new int[]
        {
                0,
                1,
                2
        });
        DirectColorModel directColorModel = (DirectColorModel)this.offscreenImage.getColorModel();
        DirectColorModel.__<clinit>();
        DirectColorModel cm = new DirectColorModel(directColorModel.getPixelSize(), directColorModel.getRedMask(), directColorModel.getGreenMask(), directColorModel.getBlueMask());
        BufferedImage im = new BufferedImage(cm, raster2, false, null);
        IOException ex2;
        try
        {
            ImageIO.write(im, text, output);
        }
        catch (IOException arg_FE_0)
        {
            ex2 = ByteCodeHelper.MapException<IOException>(arg_FE_0, ByteCodeHelper.MapFlags.NoRemapping);
            goto IL_109;
        }
        goto IL_118;
        IL_109:
        IOException this3 = ex2;
        Throwable.instancehelper_printStackTrace(this3);
        IL_118:;
    }
    else
    {
        System.@out.println(new StringBuilder().append("Invalid image file type: ").append(text).toString());
    }
}
private double userX(double num)
{
    return this.xmin + num * (this.xmax - this.xmin) / (double)this.width;
}
private double userY(double num)
{
    return this.ymax - num * (this.ymax - this.ymin) / (double)this.height;
}


public Draw(string str)
{
    this.width = 512;
    this.height = 512;
    this.defer = false;
    this.name = "Draw";
    this.mouseLock = new java.lang.Object();
    this.keyLock = new java.lang.Object();
    this.frame = new JFrame();
    this.mousePressed = false;
    this.mouseX = (double)0f;
    this.mouseY = (double)0f;
    this.keysTyped = new LinkedList();
    this.keysDown = new TreeSet();
    this.listeners = new ArrayList();
    this.name = str;
    this.init();
}


public virtual void square(double d1, double d2, double d3)
{
    if (d3 < (double)0f)
    {
        string arg_13_0 = "square side length can't be negative";

        throw new RuntimeException(arg_13_0);
    }
    double num = this.scaleX(d1);
    double num2 = this.scaleY(d2);
    double num3 = this.factorX(2.0 * d3);
    double num4 = this.factorY(2.0 * d3);
    if (num3 <= (double)1f && num4 <= (double)1f)
    {
        this.pixel(d1, d2);
    }
    else
    {
        this.offscreen.draw(new Rectangle2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
    }
    this.draw();
}


public virtual void filledSquare(double d1, double d2, double d3)
{
    if (d3 < (double)0f)
    {
        string arg_13_0 = "square side length can't be negative";

        throw new RuntimeException(arg_13_0);
    }
    double num = this.scaleX(d1);
    double num2 = this.scaleY(d2);
    double num3 = this.factorX(2.0 * d3);
    double num4 = this.factorY(2.0 * d3);
    if (num3 <= (double)1f && num4 <= (double)1f)
    {
        this.pixel(d1, d2);
    }
    else
    {
        this.offscreen.fill(new Rectangle2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
    }
    this.draw();
}


public virtual void circle(double d1, double d2, double d3)
{
    if (d3 < (double)0f)
    {
        string arg_13_0 = "circle radius can't be negative";

        throw new RuntimeException(arg_13_0);
    }
    double num = this.scaleX(d1);
    double num2 = this.scaleY(d2);
    double num3 = this.factorX(2.0 * d3);
    double num4 = this.factorY(2.0 * d3);
    if (num3 <= (double)1f && num4 <= (double)1f)
    {
        this.pixel(d1, d2);
    }
    else
    {
        this.offscreen.draw(new Ellipse2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
    }
    this.draw();
}


public virtual void arc(double d1, double d2, double d3, double d4, double d5)
{
    if (d3 < (double)0f)
    {
        string arg_13_0 = "arc radius can't be negative";

        throw new RuntimeException(arg_13_0);
    }
    while (d5 < d4)
    {
        d5 += 360.0;
    }
    double num = this.scaleX(d1);
    double num2 = this.scaleY(d2);
    double num3 = this.factorX(2.0 * d3);
    double num4 = this.factorY(2.0 * d3);
    if (num3 <= (double)1f && num4 <= (double)1f)
    {
        this.pixel(d1, d2);
    }
    else
    {
        this.offscreen.draw(new Arc2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4, d4, d5 - d4, 0));
    }
    this.draw();
}


public virtual void setCanvasSize(int i1, int i2)
{
    if (i1 < 1 || i2 < 1)
    {
        string arg_12_0 = "width and height must be positive";

        throw new RuntimeException(arg_12_0);
    }
    this.width = i1;
    this.height = i2;
    this.init();
}


public virtual void filledPolygon(double[] darr1, double[] darr2)
{
    int num = darr1.Length;
    GeneralPath generalPath = new GeneralPath();
    generalPath.moveTo((float)this.scaleX(darr1[0]), (float)this.scaleY(darr2[0]));
    for (int i = 0; i < num; i++)
    {
        generalPath.lineTo((float)this.scaleX(darr1[i]), (float)this.scaleY(darr2[i]));
    }
    generalPath.closePath();
    this.offscreen.fill(generalPath);
    this.draw();
}


public Draw()
{
    this.width = 512;
    this.height = 512;
    this.defer = false;
    this.name = "Draw";
    this.mouseLock = new java.lang.Object();
    this.keyLock = new java.lang.Object();
    this.frame = new JFrame();
    this.mousePressed = false;
    this.mouseX = (double)0f;
    this.mouseY = (double)0f;
    this.keysTyped = new LinkedList();
    this.keysDown = new TreeSet();
    this.listeners = new ArrayList();
    this.init();
}


public virtual void setLocationOnScreen(int i1, int i2)
{
    this.frame.setLocation(i1, i2);
}
public virtual double getPenRadius()
{
    return this.penRadius;
}
public virtual Color getPenColor()
{
    return this.penColor;
}


public virtual void setPenColor(int i1, int i2, int i3)
{
    if (i1 < 0 || i1 >= 256)
    {
        string arg_16_0 = "amount of red must be between 0 and 255";

        throw new ArgumentException(arg_16_0);
    }
    if (i2 < 0 || i2 >= 256)
    {
        string arg_32_0 = "amount of red must be between 0 and 255";

        throw new ArgumentException(arg_32_0);
    }
    if (i3 < 0 || i3 >= 256)
    {
        string arg_4E_0 = "amount of red must be between 0 and 255";

        throw new ArgumentException(arg_4E_0);
    }
    this.setPenColor(new Color(i1, i2, i3));
}


public virtual void xorOn()
{
    this.offscreen.setXORMode(Draw.DEFAULT_CLEAR_COLOR);
}


public virtual void xorOff()
{
    this.offscreen.setPaintMode();
}
public virtual Font getFont()
{
    return this.font;
}


public virtual void line(double d1, double d2, double d3, double d4)
{
    this.offscreen.draw(new Line2D.Double(this.scaleX(d1), this.scaleY(d2), this.scaleX(d3), this.scaleY(d4)));
    this.draw();
}


public virtual void point(double d1, double d2)
{
    double num = this.scaleX(d1);
    double num2 = this.scaleY(d2);
    double num3 = this.penRadius;
    if (num3 <= (double)1f)
    {
        this.pixel(d1, d2);
    }
    else
    {
        this.offscreen.fill(new Ellipse2D.Double(num - num3 / 2.0, num2 - num3 / 2.0, num3, num3));
    }
    this.draw();
}


public virtual void filledCircle(double d1, double d2, double d3)
{
    if (d3 < (double)0f)
    {
        string arg_13_0 = "circle radius can't be negative";

        throw new RuntimeException(arg_13_0);
    }
    double num = this.scaleX(d1);
    double num2 = this.scaleY(d2);
    double num3 = this.factorX(2.0 * d3);
    double num4 = this.factorY(2.0 * d3);
    if (num3 <= (double)1f && num4 <= (double)1f)
    {
        this.pixel(d1, d2);
    }
    else
    {
        this.offscreen.fill(new Ellipse2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
    }
    this.draw();
}


public virtual void ellipse(double d1, double d2, double d3, double d4)
{
    if (d3 < (double)0f)
    {
        string arg_13_0 = "ellipse semimajor axis can't be negative";

        throw new RuntimeException(arg_13_0);
    }
    if (d4 < (double)0f)
    {
        string arg_2D_0 = "ellipse semiminor axis can't be negative";

        throw new RuntimeException(arg_2D_0);
    }
    double num = this.scaleX(d1);
    double num2 = this.scaleY(d2);
    double num3 = this.factorX(2.0 * d3);
    double num4 = this.factorY(2.0 * d4);
    if (num3 <= (double)1f && num4 <= (double)1f)
    {
        this.pixel(d1, d2);
    }
    else
    {
        this.offscreen.draw(new Ellipse2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
    }
    this.draw();
}


public virtual void filledEllipse(double d1, double d2, double d3, double d4)
{
    if (d3 < (double)0f)
    {
        string arg_13_0 = "ellipse semimajor axis can't be negative";

        throw new RuntimeException(arg_13_0);
    }
    if (d4 < (double)0f)
    {
        string arg_2D_0 = "ellipse semiminor axis can't be negative";

        throw new RuntimeException(arg_2D_0);
    }
    double num = this.scaleX(d1);
    double num2 = this.scaleY(d2);
    double num3 = this.factorX(2.0 * d3);
    double num4 = this.factorY(2.0 * d4);
    if (num3 <= (double)1f && num4 <= (double)1f)
    {
        this.pixel(d1, d2);
    }
    else
    {
        this.offscreen.fill(new Ellipse2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
    }
    this.draw();
}


public virtual void rectangle(double d1, double d2, double d3, double d4)
{
    if (d3 < (double)0f)
    {
        string arg_13_0 = "half width can't be negative";

        throw new RuntimeException(arg_13_0);
    }
    if (d4 < (double)0f)
    {
        string arg_2D_0 = "half height can't be negative";

        throw new RuntimeException(arg_2D_0);
    }
    double num = this.scaleX(d1);
    double num2 = this.scaleY(d2);
    double num3 = this.factorX(2.0 * d3);
    double num4 = this.factorY(2.0 * d4);
    if (num3 <= (double)1f && num4 <= (double)1f)
    {
        this.pixel(d1, d2);
    }
    else
    {
        this.offscreen.draw(new Rectangle2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
    }
    this.draw();
}


public virtual void filledRectangle(double d1, double d2, double d3, double d4)
{
    if (d3 < (double)0f)
    {
        string arg_13_0 = "half width can't be negative";

        throw new RuntimeException(arg_13_0);
    }
    if (d4 < (double)0f)
    {
        string arg_2D_0 = "half height can't be negative";

        throw new RuntimeException(arg_2D_0);
    }
    double num = this.scaleX(d1);
    double num2 = this.scaleY(d2);
    double num3 = this.factorX(2.0 * d3);
    double num4 = this.factorY(2.0 * d4);
    if (num3 <= (double)1f && num4 <= (double)1f)
    {
        this.pixel(d1, d2);
    }
    else
    {
        this.offscreen.fill(new Rectangle2D.Double(num - num3 / 2.0, num2 - num4 / 2.0, num3, num4));
    }
    this.draw();
}


public virtual void polygon(double[] darr1, double[] darr2)
{
    int num = darr1.Length;
    GeneralPath generalPath = new GeneralPath();
    generalPath.moveTo((float)this.scaleX(darr1[0]), (float)this.scaleY(darr2[0]));
    for (int i = 0; i < num; i++)
    {
        generalPath.lineTo((float)this.scaleX(darr1[i]), (float)this.scaleY(darr2[i]));
    }
    generalPath.closePath();
    this.offscreen.draw(generalPath);
    this.draw();
}


public virtual void picture(double d1, double d2, string str)
{
    Image image = this.getImage(str);
    double num = this.scaleX(d1);
    double num2 = this.scaleY(d2);
    int num3 = image.getWidth(null);
    int num4 = image.getHeight(null);
    if (num3 < 0 || num4 < 0)
    {
        string arg_5F_0 = new StringBuilder().append("image ").append(str).append(" is corrupt").toString();

        throw new RuntimeException(arg_5F_0);
    }
    this.offscreen.drawImage(image, (int)java.lang.Math.round(num - (double)num3 / 2.0), (int)java.lang.Math.round(num2 - (double)num4 / 2.0), null);
    this.draw();
}


public virtual void picture(double d1, double d2, string str, double d3)
{
    Image image = this.getImage(str);
    double num = this.scaleX(d1);
    double num2 = this.scaleY(d2);
    int num3 = image.getWidth(null);
    int num4 = image.getHeight(null);
    if (num3 < 0 || num4 < 0)
    {
        string arg_5F_0 = new StringBuilder().append("image ").append(str).append(" is corrupt").toString();

        throw new RuntimeException(arg_5F_0);
    }
    this.offscreen.rotate(java.lang.Math.toRadians(-d3), num, num2);
    this.offscreen.drawImage(image, (int)java.lang.Math.round(num - (double)num3 / 2.0), (int)java.lang.Math.round(num2 - (double)num4 / 2.0), null);
    this.offscreen.rotate(java.lang.Math.toRadians(d3), num, num2);
    this.draw();
}


public virtual void picture(double d1, double d2, string str, double d3, double d4)
{
    Image image = this.getImage(str);
    double num = this.scaleX(d1);
    double num2 = this.scaleY(d2);
    double num3 = this.factorX(d3);
    double num4 = this.factorY(d4);
    if (num3 < (double)0f || num4 < (double)0f)
    {
        string arg_6D_0 = new StringBuilder().append("image ").append(str).append(" is corrupt").toString();

        throw new RuntimeException(arg_6D_0);
    }
    if (num3 <= (double)1f && num4 <= (double)1f)
    {
        this.pixel(d1, d2);
    }
    else
    {
        this.offscreen.drawImage(image, (int)java.lang.Math.round(num - num3 / 2.0), (int)java.lang.Math.round(num2 - num4 / 2.0), (int)java.lang.Math.round(num3), (int)java.lang.Math.round(num4), null);
    }
    this.draw();
}


public virtual void picture(double d1, double d2, string str, double d3, double d4, double d5)
{
    Image image = this.getImage(str);
    double num = this.scaleX(d1);
    double num2 = this.scaleY(d2);
    double num3 = this.factorX(d3);
    double num4 = this.factorY(d4);
    if (num3 < (double)0f || num4 < (double)0f)
    {
        string arg_6D_0 = new StringBuilder().append("image ").append(str).append(" is corrupt").toString();

        throw new RuntimeException(arg_6D_0);
    }
    if (num3 <= (double)1f && num4 <= (double)1f)
    {
        this.pixel(d1, d2);
    }
    this.offscreen.rotate(java.lang.Math.toRadians(-d5), num, num2);
    this.offscreen.drawImage(image, (int)java.lang.Math.round(num - num3 / 2.0), (int)java.lang.Math.round(num2 - num4 / 2.0), (int)java.lang.Math.round(num3), (int)java.lang.Math.round(num4), null);
    this.offscreen.rotate(java.lang.Math.toRadians(d5), num, num2);
    this.draw();
}


public virtual void text(double d1, double d2, string str, double d3)
{
    double d4 = this.scaleX(d1);
    double d5 = this.scaleY(d2);
    this.offscreen.rotate(java.lang.Math.toRadians(-d3), d4, d5);
    this.text(d1, d2, str);
    this.offscreen.rotate(java.lang.Math.toRadians(d3), d4, d5);
}


public virtual void textLeft(double d1, double d2, string str)
{
    this.offscreen.setFont(this.font);
    FontMetrics fontMetrics = this.offscreen.getFontMetrics();
    double num = this.scaleX(d1);
    double num2 = this.scaleY(d2);
    int descent = fontMetrics.getDescent();
    this.offscreen.drawString(str, (float)num, (float)(num2 + (double)descent));
    this.show();
}


public virtual void show(int i)
{
    this.defer = false;
    this.draw();
    try
    {
        Thread.sleep((long)i);
    }
    catch (InterruptedException arg_18_0)
    {
        goto IL_1C;
    }
    goto IL_31;
    IL_1C:
    System.@out.println("Error sleeping");
    IL_31:
    this.defer = true;
}


public virtual void actionPerformed(ActionEvent ae)
{
    FileDialog.__<clinit>();
    FileDialog fileDialog = new FileDialog(this.frame, "Use a .png or .jpg extension", 1);
    fileDialog.setVisible(true);
    string file = fileDialog.getFile();
    if (file != null)
    {
        this.save(new StringBuilder().append(fileDialog.getDirectory()).append(File.separator).append(fileDialog.getFile()).toString());
    }
}


public virtual void addListener(DrawListener dl)
{
    this.show();
    this.listeners.add(dl);
    this.frame.addKeyListener(this);
    this.frame.addMouseListener(this);
    this.frame.addMouseMotionListener(this);
    this.frame.setFocusable(true);
}

public virtual bool mousePressed()
{
    int result;
    lock (this.mouseLock)
    {
        result = (this.mousePressed ? 1 : 0);
    }
    return result != 0;
}

public virtual double mouseX()
{
    double result;
    lock (this.mouseLock)
    {
        result = this.mouseX;
    }
    return result;
}

public virtual double mouseY()
{
    double result;
    lock (this.mouseLock)
    {
        result = this.mouseY;
    }
    return result;
}
public virtual void mouseClicked(MouseEvent me)
{
}
public virtual void mouseEntered(MouseEvent me)
{
}
public virtual void mouseExited(MouseEvent me)
{
}


public virtual void mousePressed(MouseEvent me)
{
    lock (this.mouseLock)
    {
        this.mouseX = this.userX((double)me.getX());
        this.mouseY = this.userY((double)me.getY());
        this.mousePressed = true;
    }
    if (me.getButton() == 1)
    {
        Iterator iterator = this.listeners.iterator();
        while (iterator.hasNext())
        {
            DrawListener drawListener = (DrawListener)iterator.next();
            drawListener.mousePressed(this.userX((double)me.getX()), this.userY((double)me.getY()));
        }
    }
}


public virtual void mouseReleased(MouseEvent me)
{
    lock (this.mouseLock)
    {
        this.mousePressed = false;
    }
    if (me.getButton() == 1)
    {
        Iterator iterator = this.listeners.iterator();
        while (iterator.hasNext())
        {
            DrawListener drawListener = (DrawListener)iterator.next();
            drawListener.mouseReleased(this.userX((double)me.getX()), this.userY((double)me.getY()));
        }
    }
}


public virtual void mouseDragged(MouseEvent me)
{
    lock (this.mouseLock)
    {
        this.mouseX = this.userX((double)me.getX());
        this.mouseY = this.userY((double)me.getY());
    }
    Iterator iterator = this.listeners.iterator();
    while (iterator.hasNext())
    {
        DrawListener drawListener = (DrawListener)iterator.next();
        drawListener.mouseDragged(this.userX((double)me.getX()), this.userY((double)me.getY()));
    }
}


public virtual void mouseMoved(MouseEvent me)
{
    lock (this.mouseLock)
    {
        this.mouseX = this.userX((double)me.getX());
        this.mouseY = this.userY((double)me.getY());
    }
}


public virtual bool hasNextKeyTyped()
{
    int result;
    lock (this.keyLock)
    {
        result = (this.keysTyped.IsEmpty ? 0 : 1);
    }
    return result != 0;
}


public virtual char nextKeyTyped()
{
    int result;
    lock (this.keyLock)
    {
        result = (int)((Character)this.keysTyped.removeLast()).charValue();
    }
    return (char)result;
}


public virtual bool isKeyPressed(int i)
{
    int result;
    lock (this.keyLock)
    {
        result = (this.keysDown.contains(Integer.valueOf(i)) ? 1 : 0);
    }
    return result != 0;
}


public virtual void keyTyped(KeyEvent ke)
{
    lock (this.keyLock)
    {
        this.keysTyped.addFirst(Character.valueOf(ke.getKeyChar()));
    }
    Iterator iterator = this.listeners.iterator();
    while (iterator.hasNext())
    {
        DrawListener drawListener = (DrawListener)iterator.next();
        drawListener.keyTyped(ke.getKeyChar());
    }
}


public virtual void keyPressed(KeyEvent ke)
{
    lock (this.keyLock)
    {
        this.keysDown.add(Integer.valueOf(ke.getKeyCode()));
    }
}


public virtual void keyReleased(KeyEvent ke)
{
    lock (this.keyLock)
    {
        this.keysDown.remove(Integer.valueOf(ke.getKeyCode()));
    }
}


/**/
public static void main(string[] strarr)
{
    Draw draw = new Draw("Test client 1");
    draw.square(0.2, 0.8, 0.1);
    draw.filledSquare(0.8, 0.8, 0.2);
    draw.circle(0.8, 0.2, 0.2);
    draw.setPenColor(Draw.__MAGENTA);
    draw.setPenRadius(0.02);
    draw.arc(0.8, 0.2, 0.1, 200.0, 45.0);
    Draw draw2 = new Draw("Test client 2");
    draw2.setCanvasSize(900, 200);
    draw2.setPenRadius();
    draw2.setPenColor(Draw.__BLUE);
    double[] darr = new double[]
    {
            0.1,
            0.2,
            0.3,
            0.2
    };
    double[] darr2 = new double[]
    {
            0.2,
            0.3,
            0.2,
            0.1
    };
    draw2.filledPolygon(darr, darr2);
    draw2.setPenColor(Draw.__BLACK);
    draw2.text(0.2, 0.5, "bdfdfdfdlack text");
    draw2.setPenColor(Draw.__WHITE);
    draw2.text(0.8, 0.8, "white text");
}

static Draw()
{
    Draw.__BLACK = Color.BLACK;
    Draw.__BLUE = Color.BLUE;
    Draw.__CYAN = Color.CYAN;
    Draw.__DARK_GRAY = Color.DARK_GRAY;
    Draw.__GRAY = Color.GRAY;
    Draw.__GREEN = Color.GREEN;
    Draw.__LIGHT_GRAY = Color.LIGHT_GRAY;
    Draw.__MAGENTA = Color.MAGENTA;
    Draw.__ORANGE = Color.ORANGE;
    Draw.__PINK = Color.PINK;
    Draw.__RED = Color.RED;
    Draw.__WHITE = Color.WHITE;
    Draw.__YELLOW = Color.YELLOW;
    Draw.__BOOK_BLUE = new Color(9, 90, 166);
    Draw.__BOOK_RED = new Color(173, 32, 24);
    Draw.DEFAULT_PEN_COLOR = Draw.__BLACK;
    Draw.DEFAULT_CLEAR_COLOR = Draw.__WHITE;
    Draw.DEFAULT_FONT = new Font("SansSerif", 0, 16);
}
}