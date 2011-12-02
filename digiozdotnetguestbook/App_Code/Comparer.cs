using System.Collections;

public class Comparer : IComparer
{
    public int Compare(object poObject1, object poObject2)
    {
        int liValue1 = (int)poObject1;
        int liValue2 = (int)poObject2;

        if ((liValue1 < liValue2))
        {
            return -1;
        }

        if ((liValue1 > liValue2))
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}