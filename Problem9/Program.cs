int numberOfRectangles, numberOfIntersectionChecks;

String[] numb = Console.ReadLine().Split(' ');

numberOfRectangles = int.Parse(numb[0]);
numberOfIntersectionChecks = int.Parse(numb[1]);
 
List<Rectangle> rectangles = new List<Rectangle>();

for (int i = 0; i < numberOfRectangles; i++)
{
    String[] rectangle = Console.ReadLine().Split(' ');
    Rectangle rest = new Rectangle(rectangle[0], int.Parse(rectangle[1]), int.Parse(rectangle[2]), int.Parse(rectangle[3]), int.Parse(rectangle[4]));
    rectangles.Add(rest);
}

for (int i = 0; i < numberOfIntersectionChecks; i++)
{ 
    String[] idRectangle= Console.ReadLine().Split(' ');
    Rectangle firstRectangle = rectangles.Where(r => r.ID == idRectangle[0]).FirstOrDefault();
    Rectangle secondRectangle = rectangles.Where(r => r.ID == idRectangle[1]).FirstOrDefault();
    if (CheckRectanglesIntersect(firstRectangle, secondRectangle)) Console.WriteLine("true");
    else Console.WriteLine("false");
}

bool CheckRectanglesIntersect(Rectangle firstRectangle,Rectangle secondRectangle)
{
    bool intersect = true;
    while (numberOfIntersectionChecks > 0)
    {
        intersect = secondRectangle.CoorX + secondRectangle.Width >= firstRectangle.CoorX && secondRectangle.CoorX <= firstRectangle.CoorX + firstRectangle.Width &&
                    secondRectangle.CoorY - secondRectangle.Height <= firstRectangle.CoorY && secondRectangle.CoorY >= firstRectangle.CoorY - firstRectangle.Height;

        numberOfIntersectionChecks--;
    }

    return intersect;
}

public class Rectangle
{
    private string id;
    private int height;
    private int width;
    private int coorX;
    private int coorY;
    public string ID { get { return id; } set { id = value; } }
    public int Height { get { return height; } set { height = value; } }
    public int Width { get { return width; } set { width = value; } }
    public int CoorX { get { return coorX; } set { coorX = value; } }
    public int CoorY { get { return coorY; } set { coorY = value; } }
    public Rectangle(string id, int width, int height, int coorX, int coorY)
    {
        ID = id;
        Height = width;
        Width = height;
        CoorX = coorX;
        CoorY = coorY;
    }
    
}