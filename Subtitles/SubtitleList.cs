using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Subtitles;

public class SubtitleList : IList<string>
{
    private volatile List<Tuple<DateTime, string>> collection = [];
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

    public List<string> TakeLast(int number)
    {
        return collection
            .Where(element => DateTime.Now >= element.Item1)
            .OrderBy(element => element.Item1)
            .Select(element => element.Item2)
            .TakeLast(number)
            .ToList();
    }

    public string this[int index]
    {
        get { return collection[index].Item2; }
        set { collection[index] = new Tuple<DateTime, string>(DateTime.Now, value); }
    }

    public IEnumerator<string> GetEnumerator()
    {
        return collection.Select(x => x.Item2).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return collection.Select(x => x.Item2).GetEnumerator();
    }

    public void Add(string item)
    {
        collection.Add(new Tuple<DateTime, string>(DateTime.Now, item));
    }

    public void Add(string item, float seconds)
    {
        collection.Add(new Tuple<DateTime, string>(DateTime.Now.AddSeconds(seconds), item));
    }

    public int Count => collection.Count;

    public bool IsSynchronized => false;

    public bool IsReadOnly => false;

    public void CopyTo(string[] array, int index)
    {
        for (int i = 0; i < collection.Count; i++)
        {
            array[i + index] = collection[i].Item2;
        }
    }

    public bool Remove(string item)
    {
        bool contained = Contains(item);

        for (int i = collection.Count - 1; i >= 0; i--)
        {
            if (collection[i].Item2 == item)
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

    public bool Contains(string item)
    {
        for (int i = 0; i < collection.Count; i++)
        {
            if (collection[i].Item2 == item)
            {
                return true;
            }
        }

        return false;
    }

    public void Insert(int index, string item)
    {
        collection.Insert(index, new Tuple<DateTime, string>(DateTime.Now, item));
    }

    public int IndexOf(string item)
    {
        for (int i = 0; i < collection.Count; i++)
        {
            if (collection[i].Item2 == item)
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
