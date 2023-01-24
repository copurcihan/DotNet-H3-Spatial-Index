using DotNetH3.Utils;
using H3;
using H3.Extensions;

namespace DotNetH3;

public static partial class H3
{
    public static int GetResolution(string h3Index)
    {
        return h3Index.GetResolution();
    }

    public static int GetBaseCellNumber(string h3Index)
    {
        try
        {
            return new H3Index(h3Index).BaseCellNumber;
        }
        catch (Exception)
        {
            // ignored
        }

        return -1;
    }

    public static H3Index? StringToH3(string h3Index)
    {
        try
        {
            return new H3Index(h3Index);
        }
        catch (Exception)
        {
            // ignored
        }

        return null;
    }

    public static string H3ToString(H3Index h3Index)
    {
        try
        {
            return h3Index.ToString();
        }
        catch (Exception)
        {
            // ignored
        }

        return "";
    }

    public static bool IsValidCell(string h3Index)
    {
        return new H3Index(h3Index).IsValidCell;
    }

    public static bool IsPentagon(string h3Index)
    {
        var a = new H3Index(h3Index).GetFaces();
        return new H3Index(h3Index).IsPentagon;
    }

    public static int[] GetIcosahedronFaces(string h3Index)
    {
        return new H3Index(h3Index).GetFaces();
    }
}