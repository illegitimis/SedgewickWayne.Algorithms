public class DijkstraAllPairsSP
{
	private DijkstraSP[] all;
	
	
	public virtual double dist(int i1, int i2)
	{
		return this.all[i1].distTo(i2);
	}
	
	
	public DijkstraAllPairsSP(EdgeWeightedDigraph ewd)
	{
		this.all = new DijkstraSP[ewd.V()];
		for (int i = 0; i < ewd.V(); i++)
		{
			this.all[i] = new DijkstraSP(ewd, i);
		}
	}
/*	[LineNumberTable(53), Signature("(II)Ljava/lang/Iterable<LDirectedEdge;>;")]*/
	
	public virtual Iterable path(int i1, int i2)
	{
		return this.all[i1].pathTo(i2);
	}
	
	
	public virtual bool hasPath(int i1, int i2)
	{
		return this.dist(i1, i2) < double.PositiveInfinity;
	}
}