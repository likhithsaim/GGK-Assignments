public class ShortestPathNode
{
    public string value;
    public string[] weights;
    public ShortestPathNode[] links;
    public ShortestPathNode(string value)
    {
        this.value = value;
    }
}