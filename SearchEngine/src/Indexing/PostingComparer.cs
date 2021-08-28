using System;
using System.Collections.Generic;

namespace Indexing
{
    public class PostingComparer : IComparer<Posting>
    {
        int IComparer<Posting>.Compare(Posting x, Posting y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal.
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater.
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the document ID
                    return x.DocumentID.CompareTo(y.DocumentID);
                }
            }
        }
    }
}
