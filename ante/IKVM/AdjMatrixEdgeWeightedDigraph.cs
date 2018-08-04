public class AdjMatrixEdgeWeightedDigraph
{
	/*[Implements(new string[]
	{
		"java.util.Iterator",
		"java.lang.Iterable"
	}), InnerClass(null, Modifiers.Private), Modifiers(Modifiers.Super), Signature("Ljava/lang/Object;Ljava/util/Iterator<LDirectedEdge;>;Ljava/lang/Iterable<LDirectedEdge;>;"), SourceFile("AdjMatrixEdgeWeightedDigraph.java")]*/
	internal sealed class AdjIterator : IEnumerator<DirectedEdge>
	{
		private int v;
		private int w;
//[Modifiers(Modifiers.Final | Modifiers.Synthetic)]
		internal AdjMatrixEdgeWeightedDigraph graph;
		
		
		public bool MoveNext()
		{
			while (this.w < AdjMatrixEdgeWeightedDigraph.access_000(this.graph))
			{
				if (AdjMatrixEdgeWeightedDigraph.access_100(this.graph)[this.v][this.w] != null)
				{
					return true;
				}
				this.w++;
			}
			return false;
		}
		
		
		public DirectedEdge Current { get
      {
        if (MoveNext())
        {
          DirectedEdge[] vEdges = AdjMatrixEdgeWeightedDigraph.access_100(this.graph)[this.v];
          int num = this.w;          
          this.w++;
          return vEdges[num];
        }

        throw new InvalidOperationException();
      } }

    object IEnumerator.Current
    {
      get
      {
        return Current;
      }
    }

    public AdjIterator(AdjMatrixEdgeWeightedDigraph adjMatrixEdgeWeightedDigraph, int num)
		{
			this.w = 0;
			this.v = num;
		}
/*		[Signature("()Ljava/util/Iterator<LDirectedEdge;>;")]
		public virtual Iterator iterator()
		{
			return this;
		}*/
		
		
		public void Reset()
		{
			throw new NotSupportedException();
		}

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          // TODO: dispose managed state (managed objects).
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        disposedValue = true;
      }
    }

    // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    // ~AdjIterator() {
    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //   Dispose(false);
    // }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(true);
      // TODO: uncomment the following line if the finalizer is overridden above.
      // GC.SuppressFinalize(this);
    }
    #endregion
    /*		[LineNumberTable(115), Modifiers(Modifiers.Public | Modifiers.Volatile | Modifiers.Synthetic)]*/

  }



	private int V;
	private int E;
	private DirectedEdge[][] adj;
/*	[LineNumberTable(36), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
	internal static int access_000(AdjMatrixEdgeWeightedDigraph adjMatrixEdgeWeightedDigraph)
	{
		return adjMatrixEdgeWeightedDigraph.V;
	}
/*	[LineNumberTable(36), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
	internal static DirectedEdge[][] access_100(AdjMatrixEdgeWeightedDigraph adjMatrixEdgeWeightedDigraph)
	{
		return adjMatrixEdgeWeightedDigraph.adj;
	}
	
	
	public AdjMatrixEdgeWeightedDigraph(int i)
	{
		if (i < 0)
		{
			string arg_16_0 = "Number of vertices must be nonnegative";
			
			throw new RuntimeException(arg_16_0);
		}
		this.V = i;
		this.E = 0;
		int[] array = new int[]
		{
			0,
			i
		};
		array[0] = i;
		this.adj = (DirectedEdge[][])ByteCodeHelper.multianewarray(typeof(DirectedEdge[][]).TypeHandle, array);
	}
	
	
	public virtual void addEdge(DirectedEdge de)
	{
		int num = de.from();
		int num2 = de.to();
		if (this.adj[num][num2] == null)
		{
			this.E++;
			this.adj[num][num2] = de;
		}
	}
/*	[LineNumberTable(111), Signature("(I)Ljava/lang/Iterable<LDirectedEdge;>;")]*/
	
	public virtual Iterable adj(int i)
	{
		return new AdjMatrixEdgeWeightedDigraph.AdjIterator(this, i);
	}
	
	
	public AdjMatrixEdgeWeightedDigraph(int i1, int i2) : this(i1)
	{
		if (i2 < 0)
		{
			string arg_17_0 = "Number of edges must be nonnegative";
			
			throw new RuntimeException(arg_17_0);
		}
		if (i2 > i1 * i1)
		{
			string arg_2D_0 = "Too many edges";
			
			throw new RuntimeException(arg_2D_0);
		}
		while (this.E != i2)
		{
			int i3 = ByteCodeHelper.d2i((double)i1 * java.lang.Math.random());
			int i4 = ByteCodeHelper.d2i((double)i1 * java.lang.Math.random());
			double d = (double)java.lang.Math.round(100.0 * java.lang.Math.random()) / 100.0;
			this.addEdge(new DirectedEdge(i3, i4, d));
		}
	}
	public virtual int V()
	{
		return this.V;
	}
	public virtual int E()
	{
		return this.E;
	}
	
	
	public override string ToString()
	{
		string property = System.getProperty("line.separator");
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.append(new StringBuilder().append(this.V).append(" ").append(this.E).append(property).toString());
		for (int i = 0; i < this.V; i++)
		{
			stringBuilder.append(new StringBuilder().append(i).append(": ").toString());
			Iterator iterator = this.adj(i).iterator();
			while (iterator.hasNext())
			{
				DirectedEdge obj = (DirectedEdge)iterator.next();
				stringBuilder.append(new StringBuilder().append(obj).append("  ").toString());
			}
			stringBuilder.append(property);
		}
		return stringBuilder.toString();
	}
	
	
	/*public static void main(string[] strarr)
	{
		int i = Integer.parseInt(strarr[0]);
		int i2 = Integer.parseInt(strarr[1]);
		AdjMatrixEdgeWeightedDigraph obj = new AdjMatrixEdgeWeightedDigraph(i, i2);
		StdOut.println(obj);
	}*/
}