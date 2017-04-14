// https://www.codeproject.com/tips/772779/kruskal-algorithm-in-csharp
// https://www.codeproject.com/articles/163618/kruskal-algorithm
// https://www.programmingalgorithms.com/algorithm/kruskal's-algorithm
// something good above
// http://www.technical-recipes.com/2011/implementing-kruskals-algorithm-in-c/

namespace Graph.CodeProject
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class KEdge
  {
    public KVertex V1 { get; set; }
    public KVertex V2 { get; set; }
    public double Weight { get; set; }
    
    public KEdge (KVertex src, KVertex dest, int wt)
    {
      V1 = src;
      V2 = dest;
      Weight = wt;
    }
    
    public KEdge (int v1, int v2, double weight)
    {
      this.V1 = new KVertex(v1);
      this.V2 = new KVertex(v2);
      this.Weight = weight;
    }

    public override string ToString ( ) { return String.Format("{0}<->{1}={2}", V1, V2, Weight); }
  }

  public class KVertex
  {
    public KVertex (int v1)
    {
      this.Id = v1;
      this.Label = v1.ToString();
    }

    //public KVertex this[int index]
    //{
    //    get { return Vertices[index]; }
    //    set { Vertices[index] = value; }
    //}
    public int Id { get; set; }
    public string Label { get; set; }

    public override string ToString ( ) { return Label; }
  }

  public class KGraph
  {
    public List<KEdge> EdgeList = null;
    public KVertex[] Vertices = null;
    
    //public KEdge this[KVertex v]
    //{
    //    get { return EdgeList[v]; }
    //    set { EdgeList[v] = value; }
    //}


    public KGraph (int size)
    {
      Vertices = new KVertex[size];
      for (int i = 0; i < size; i++)
      {
        Vertices[i] = new KVertex(i);
      }
      if (EdgeList == null)
        EdgeList = new List<KEdge>();
    }

    public void Add (int v1, int v2, double weight, bool orderByWeight = false)
    {
      EdgeList.Add(new KEdge(v1, v2, weight));
      if (orderByWeight)
        EdgeList = EdgeList.OrderBy(p => p.Weight).ToList();
    }
  }

  class KSubsets
  {
    public KVertex parent { get; set; }
    public int rank { get; set; }
  }

  /// <summary>
  ///  Kruskal's algorithm processes the edges in order of their weight values (smallest to largest), 
  ///  taking for the MST each edge that does not form a cycle with edges previously added, stopping after adding V-1 edges. 
  ///  The edges form a forest of trees that evolves gradually into a single tree, the MST.
  ///  Kruskal’s Algorithm is based directly on the generic algorithm. We make different choices of cuts.
  ///  Initially, trees of the forest are the vertices (no edges). 
  ///  In each step, add the cheapest edge that does not create a cycle. 
  /// </summary>
  public static class Kruskal
  {
    static void Main (string[] args)
    {
      // build graph
      int k = 1;
      int vert = 7;
      
      KGraph kGraph = new KGraph(vert);
      KVertex[] vertcoll = kGraph.Vertices;
      
      var edges = new List<KEdge>();
      for (int i = 0; i < vert; i++)
      {
        for (int j = i; j < vert; j++)
        {
          if (i != j)
          {
            Console.WriteLine("KEdge weight from src{0} to destn{1}", i, j);
            int wt = int.Parse(Console.ReadLine());
            if (wt == 0) continue;

            edges.Add(new KEdge(vertcoll[i], vertcoll[j], wt));
            k++;
          }
        }
      }

      kGraph.EdgeList = edges.OrderBy(p => p.Weight).ToList();
    }

    public static KEdge[] Run (KGraph kGraph)
    {
      int vert = kGraph.Vertices.Length;
      int e = 0,  k = 0;
            
      KSubsets[] sub = new KSubsets[vert];
      for (int i = 0; i < vert; i++)
      {
        sub[i] = new KSubsets() { parent = kGraph.Vertices[i], rank = 0 };
      }

      KEdge[] result = new KEdge[vert];
      while (e < vert - 1)
      {
        var objEdge = kGraph.EdgeList.ElementAt(k);
        // assume the vertices array is ordered by id
        // and vertex id is = array position
        // no need for 
        // Array.IndexOf(kGraph.Vertices, objEdge.V1)
        // Array.IndexOf(kGraph.Vertices, objEdge.V2) 
        KVertex x = Find(sub, objEdge.V1, objEdge.V1.Id, kGraph.Vertices);
        KVertex y = Find(sub, objEdge.V2, objEdge.V2.Id, kGraph.Vertices);
        if (x != y)
        {
          result[e] = objEdge;
          Union(sub, x, y, kGraph.Vertices);
          e++;
        }
        k++;
      }

      return result;
    }


    private static void Union (KSubsets[] sub, KVertex xr, KVertex yr, KVertex[] vertex)
    {
      KVertex x = Find(sub, xr, Array.IndexOf(vertex, xr), vertex);
      KVertex y = Find(sub, yr, Array.IndexOf(vertex, yr), vertex);

      if (sub[Array.IndexOf(vertex, x)].rank < sub[Array.IndexOf(vertex, y)].rank)
      {
        sub[Array.IndexOf(vertex, x)].parent = y;
      }
      else if (sub[Array.IndexOf(vertex, x)].rank > sub[Array.IndexOf(vertex, y)].rank)
      {
        sub[Array.IndexOf(vertex, y)].parent = x;
      }
      else
      {
        sub[Array.IndexOf(vertex, y)].parent = x;
        sub[Array.IndexOf(vertex, x)].rank++;
      }
    }

    private static KVertex Find (KSubsets[] sub, KVertex vertex, int k, KVertex[] vertdic)
    {
      if (sub[k].parent != vertex)
      {
        // Find(sub, vertex, Array.IndexOf(vertdic,vertex),vertdic);//sub.Select(j => j.parent).Where(v => v.Label == vertex.Label).FirstOrDefault();

        //int arrayIndex = Array.IndexOf(vertdic, sub.ElementAt(k).parent);
        int arrayIndex = sub[k].parent.Id;
        sub[k].parent = Find(sub, sub[k].parent, arrayIndex, vertdic);
      }

      return sub[k].parent;
    }





  }
}

