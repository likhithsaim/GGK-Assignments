using System;
class Methods
{
    private Node head = null;
    //  Operations provided to the user to choose
    public void Choice()
    {
        Console.Write("BINARY SEARCH TREE");
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("\n1.Insert\n2.Search\n3.Increasing order\n4.Decreasing oredr\n5.exit");
            Console.Write("\nSelect an option : ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Write("\nEnter the value to be inserted : ");
                    Insert(Console.ReadLine());
                    Console.Write("\nvalue is inserted.");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Write("\nEnter the value to be searched : ");
                    if (Search(Console.ReadLine()))
                    {
                        Console.WriteLine("Value found.");
                    }
                    else
                    {
                        Console.WriteLine("Value not found.");
                    }
                    Console.Read();
                    break;
                case "3":
                    Node head = GetRoot();
                    IncreasingOrder(ref head);
                    Console.ReadLine();
                    break;
                case "4":
                    head = GetRoot();
                    DecreasingOrder(ref head);
                    Console.ReadLine();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Write("\nChoose a correct option : ");
                    break;
            }
        }
    }
    //  Returns Root node of the tree
    public Node GetRoot()
    {
        return head;
    }
    //  Inserts node in the tree
    void Insert(string input)
    {
        if (head == null)
        {
            head = new Node(input);
        }
        else
        {
            Node dummy = head;
            while (true)
            {
                if (Int32.Parse(input) > Int32.Parse(dummy.data))
                {
                    if (dummy.right == null)
                    {
                        dummy.right = new Node(input);
                        break;
                    }
                    dummy = dummy.right;
                }
                else
                {
                    if (dummy.left == null)
                    {
                        dummy.left = new Node(input);
                        break;
                    }
                    dummy = dummy.left;
                }
            }
        }
    }
    //  Searches for a node in the tree
    bool Search(string key)
    {
        Node dummy = head;
        while (dummy != null)
        {
            if ((dummy.data).Equals(key))
            {
                return true;
            }
            else
            {
                if (Int32.Parse(key) > Int32.Parse(dummy.data))
                {
                    dummy = dummy.right;
                }
                else
                {
                    dummy = dummy.left;
                }
            }
        }
        return false;
    }
    //  Displays nodes in the tree in increasing order
    void IncreasingOrder(ref Node dummy)
    {
        if (dummy == null)
        {
            return;
        }
        IncreasingOrder(ref dummy.left);
        Console.Write(dummy.data + " ");
        IncreasingOrder(ref dummy.right);
    }
    //  Displays nodes in the tree in decreasing order
    void DecreasingOrder(ref Node dummy)
    {
        if (dummy == null)
        {
            return;
        }
        DecreasingOrder(ref dummy.right);
        Console.Write(dummy.data + " ");
        DecreasingOrder(ref dummy.left);
    }
}