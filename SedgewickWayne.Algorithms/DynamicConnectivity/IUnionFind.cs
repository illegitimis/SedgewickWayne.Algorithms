
namespace SedgewickWayne.Algorithms
{
    /// <summary>
    /// Represents the union–find data type, aka disjoint sets data.
    /// 
    /// It supports the union and find operations, 
    /// along with aconnected operation for determining whether two sites are in the same component 
    /// and a count operation that returns the total number of components.
    /// 
    /// The union–find data type models connectivity among a set of n sites, named 0 through n–1.
    /// 
    /// Both sites and components are identified with integers between 0 and n–1. 
    /// Initially, there are n components, with each site in its own component.
    /// The component identifier of a component (also known as the root, canonical element, leader, or set representative) is one of the sites in the component:
    /// two sites have the same component identifier if and only if they are in the same component.
    /// </summary>
    public interface IUnionFind
    {
    /// <summary>
    /// number of components.
    /// </summary>
    int Count { get; }

    /// <summary>
    /// The is-connected-to relation must be an equivalence relation:
    /// Reflexive: p is connected to p.
    /// Symmetric: If p is connected to q, then q is connected to p.
    /// Transitive: If p is connected to q and q is connected to r, then p is connected to r.
    /// 
    /// An equivalence relation partitions the sites into equivalence classes (or components). 
    /// In this case, two sites are in the same component if and only if they are connected.
    /// </summary>
    /// <param name="p"></param>
    /// <param name="q"></param>
    /// <returns>returns true if both p and q are in the same component, and false otherwise.</returns>
    bool Connected(int p, int q);

    /// <summary>
    ///   union(p, q) adds a connection between the two sites p and q. 
    ///   If p and q are in different components, then it replaces these two components with a new component that is the union of the two.
    ///   The component identifier of a component can change only when the component itself changes during a call to union.
    /// </summary>
    /// <param name="p"></param>
    /// <param name="q"></param>
    void Union(int p, int q);

    /// <summary>
    /// returns the component identifier of the component containing <paramref name="i"/>.
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
        int Find(int i);
    }
}
