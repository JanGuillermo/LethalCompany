using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Subtitles;

public class SubtitleList : IList<Subtitle>
{
    private volatile List<Tuple<DateTime, Subtitle>> collection = [];
    private readonly Timer timer;
    private readonly TimeSpan expiration;

    public SubtitleList()
    {
        timer = new Timer
        {
            Interval = 1000
        };
        timer.Elapsed += new ElapsedEventHandler(RemoveExpiredElements);
        timer.Start();

        expiration = TimeSpan.FromMilliseconds(Constants.DefaultExpireSubtitleTimeMs);
    }

    private void RemoveExpiredElements(object sender, EventArgs e)
    {
        for (int i = collection.Count - 1; i >= 0; i--)
        {
            if ((DateTime.Now - collection[i].Item1) >= expiration)
            {
                collection.RemoveAt(i);
            }
        }
    }

    public Subtitle this[int index]
    {
        get { return collection[index].Item2; }
        set { collection[index] = new Tuple<DateTime, Subtitle>(DateTime.Now, value); }
    }

    public IEnumerator<Subtitle> GetEnumerator()
    {
        return collection.Select(x => x.Item2).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return collection.Select(x => x.Item2).GetEnumerator();
    }

    public void Add(Subtitle item)
    {
        collection.Add(new Tuple<DateTime, Subtitle>(DateTime.Now, item));
    }

    public int Count => collection.Count;

    public bool IsSynchronized => false;

    public bool IsReadOnly => false;

    public void CopyTo(Subtitle[] array, int index)
    {
        for (int i = 0; i < collection.Count; i++)
        {
            array[i + index] = collection[i].Item2;
        }
    }

    public bool Remove(Subtitle item)
    {
        bool contained = Contains(item);

        for (int i = collection.Count - 1; i >= 0; i--)
        {
            if ((object)collection[i].Item2 == (object)item)
            {
                collection.RemoveAt(i);
            }
        }

        return contained;
    }

    public void RemoveAt(int i)
    {
        collection.RemoveAt(i);
    }

    public bool Contains(Subtitle item)
    {
        for (int i = 0; i < collection.Count; i++)
        {
            if ((object)collection[i].Item2 == (object)item)
            {
                return true;
            }
        }

        return false;
    }

    public void Insert(int index, Subtitle item)
    {
        collection.Insert(index, new Tuple<DateTime, Subtitle>(DateTime.Now, item));
    }

    public int IndexOf(Subtitle item)
    {
        for (int i = 0; i < collection.Count; i++)
        {
            if ((object)collection[i].Item2 == (object)item)
            {
                return i;
            }
        }

        return -1;
    }

    public void Clear()
    {
        collection.Clear();
    }
}
