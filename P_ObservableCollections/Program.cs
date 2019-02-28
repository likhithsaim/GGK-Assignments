using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

public class Example
{
    public static void Main()
    {
        ObservableCollection<string> names = new ObservableCollection<string>();
        names.CollectionChanged += (new Example()).names_CollectionChanged;
        names.Add("Adam");
        names.Add("Eve");
        names.Remove("Adam");
        names.Add("John");
        names.Add("Peter");
        names.Clear();
        Console.Read();
    }

    void names_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            Console.WriteLine("Items added: ");
            foreach (var item in e.NewItems)
            {
                Console.WriteLine(item);
            }
        }

        if (e.OldItems != null)
        {
            Console.WriteLine("Items removed: ");
            foreach (var item in e.OldItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}