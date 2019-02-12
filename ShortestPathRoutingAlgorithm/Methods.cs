using System;
class Methods
{
    private string[] objectValues;
    private ShortestPathNode[] objectStorage;
    // Creats objects(nodes) of the graph
    public void CreatingObjects()
    {
        Console.Write("Enter the number of nodes to be present in the graph:");
        int number = Int32.Parse(Console.ReadLine());
        objectValues = new string[number];
        objectStorage = new ShortestPathNode[number];
        Console.WriteLine("\nEnter the nodes:");
        for (int i = 0; i < number; i++)
        {
            objectValues[i] = Console.ReadLine();
            objectStorage[i] = new ShortestPathNode(objectValues[i]);
        }
        for (int i = 0; i < number; i++)
        {
            Console.Write("\nEnter the number of links for " + objectStorage[i].value + " : ");
            int linkNumber = Int32.Parse(Console.ReadLine());
            ShortestPathNode[] links = new ShortestPathNode[linkNumber];
            string[] weights = new string[linkNumber];
            for (int j = 0; j < linkNumber; j++)
            {
                Console.Write("\nEnter the {0} links for {1} : ", linkNumber, objectStorage[i].value);
                string objectnumber = Console.ReadLine();
                for (int k = 0; k < number; k++)
                {
                    if (objectnumber == objectValues[k])
                    {
                        links[j] = objectStorage[k];
                    }
                }
                Console.Write("\nEnter the weight between {0} and {1} : ", objectStorage[i].value, objectnumber);
                weights[j] = Console.ReadLine();
            }
            objectStorage[i].links = links;
            objectStorage[i].weights = weights;
        }
    }
    //  Takes source and destination nodes as inputs
    public void SourceAndDestination()
    {
        string choice = "y";
        while ((choice == "y") || (choice == "Y"))
        {
            Console.Write("\n\nEnter the Source Node:");
            string source = Console.ReadLine();
            Console.Write("\nEnter the Destination Node:");
            string destination = Console.ReadLine();
            ShortestPathNode head = null;
            int weight = Int32.MaxValue;
            string final = "";
            int number = objectValues.Length;
            for (int i = 0; i < number; i++)
            {
                if (source == objectValues[i])
                {
                    head = objectStorage[i];
                    break;
                }
            }
            Finder("", destination, ref head, head.links.Length - 1, 0, 0, ref weight, ref final);
            Console.WriteLine("PATH   : " + final + "\nWEIGHT : " + weight + "\n\n");
            Console.Write("TO CHANGE SOURCE AND DESTINATION, PRESS(Y)\nANY OTHER KEY TO EXIT : ");
            choice = Console.ReadLine();
        }
    }
    //  Finds the shortest path
    public string Finder(string path, string destination, ref ShortestPathNode head, int count, int presentWeight, int previousWeight, ref int weight, ref string final)
    {
        string[] check = path.Split("->");
        for (int i = 0; i < check.Length; i++)
        {
            if (check[i].Equals(head.value))
            {
                return path;
            }
        }
        if (head.value == destination)
        {
            path += head.value;
            presentWeight += previousWeight;
            previousWeight = Int32.Parse(head.weights[count]);
            if (weight > presentWeight)
            {
                final = path;
                weight = presentWeight;
            }
            count--;
            return final;
        }
        while (count > -1)
        {
            path += head.value + "->";
            presentWeight += previousWeight;
            previousWeight = Int32.Parse(head.weights[count]);
            Finder(path, destination, ref head.links[count], head.links[count].links.Length - 1, presentWeight, previousWeight, ref weight, ref final);
            path = path.Substring(0, path.Length - 3);
            presentWeight -= Int32.Parse(head.weights[count]);
            count--;
        }
        return path;
    }
}