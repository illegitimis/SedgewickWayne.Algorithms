public class CollisionSystem
{
	/*[Implements(new string[]
	{
		"java.lang.Comparable"
	}), InnerClass(null, Modifiers.Private | Modifiers.Static), Modifiers(Modifiers.Super), Signature("Ljava/lang/Object;Ljava/lang/Comparable<LCollisionSystem$Event;>;"), SourceFile("CollisionSystem.java")]*/
	internal sealed class Event : IComparable, IComparable<Event>
	{
//[Modifiers(Modifiers.Private | Modifiers.Final)]
		private double time;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
		private Particle a;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
		private Particle b;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
		private int countA;
//[Modifiers(Modifiers.Private | Modifiers.Final)]
		private int countB;
		
		
		public Event(double num, Particle particle, Particle particle2)
		{
			this.time = num;
			this.a = particle;
			this.b = particle2;
			if (particle != null)
			{
				this.countA = particle.count();
			}
			else
			{
				this.countA = -1;
			}
			if (particle2 != null)
			{
				this.countB = particle2.count();
			}
			else
			{
				this.countB = -1;
			}
		}
		
		
		public virtual bool isValid()
		{
			return (this.a == null || this.a.count() == this.countA) && (this.b == null || this.b.count() == this.countB);
		}
/*		[LineNumberTable(106), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static Particle access_000(CollisionSystem.Event @event)
		{
			return @event.a;
		}
/*		[LineNumberTable(106), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static Particle access_100(CollisionSystem.Event @event)
		{
			return @event.b;
		}
/*		[LineNumberTable(106), Modifiers(Modifiers.Static | Modifiers.Synthetic)]*/
		internal static double access_200(CollisionSystem.Event @event)
		{
			return @event.time;
		}
		
		

    public int CompareTo(object obj)
    {
      return this.CompareTo((CollisionSystem.Event)obj);
    }

    public int CompareTo(CollisionSystem.Event @event)
    {
      if (this.time < @event.time)
      {
        return -1;
      }
      if (this.time > @event.time)
      {
        return 1;
      }
      return 0;
    }

  }
//[Signature("LMinPQ<LCollisionSystem$Event;>;")]
	private MinPQ pq;
	private double t;
	private double hz;
	private Particle[] particles;
	
	
	private void predict(Particle particle, double num)
	{
		if (particle == null)
		{
			return;
		}
		for (int i = 0; i < this.particles.Length; i++)
		{
			double num2 = particle.timeToHit(this.particles[i]);
			if (this.t + num2 <= num)
			{
				this.pq.insert(new CollisionSystem.Event(this.t + num2, particle, this.particles[i]));
			}
		}
		double num3 = particle.timeToHitVerticalWall();
		double num4 = particle.timeToHitHorizontalWall();
		if (this.t + num3 <= num)
		{
			this.pq.insert(new CollisionSystem.Event(this.t + num3, particle, null));
		}
		if (this.t + num4 <= num)
		{
			this.pq.insert(new CollisionSystem.Event(this.t + num4, null, particle));
		}
	}
	
	
	private void redraw(double num)
	{
		StdDraw.clear();
		for (int i = 0; i < this.particles.Length; i++)
		{
			this.particles[i].draw();
		}
		StdDraw.show(20);
		if (this.t < num)
		{
			this.pq.insert(new CollisionSystem.Event(this.t + (double)1f / this.hz, null, null));
		}
	}
	
	
	public CollisionSystem(Particle[] parr)
	{
		this.t = (double)0f;
		this.hz = 0.5;
		this.particles = parr;
	}
	
	
	public virtual void simulate(double d)
	{
		this.pq = new MinPQ();
		for (int i = 0; i < this.particles.Length; i++)
		{
			this.predict(this.particles[i], d);
		}
		this.pq.insert(new CollisionSystem.Event((double)0f, null, null));
		while (!this.pq.isEmpty())
		{
			CollisionSystem.Event @event = (CollisionSystem.Event)this.pq.delMin();
			if (@event.isValid())
			{
				Particle particle = CollisionSystem.Event.access_000(@event);
				Particle particle2 = CollisionSystem.Event.access_100(@event);
				for (int j = 0; j < this.particles.Length; j++)
				{
					this.particles[j].move(CollisionSystem.Event.access_200(@event) - this.t);
				}
				this.t = CollisionSystem.Event.access_200(@event);
				if (particle != null && particle2 != null)
				{
					particle.bounceOff(particle2);
				}
				else if (particle != null && particle2 == null)
				{
					particle.bounceOffVerticalWall();
				}
				else if (particle == null && particle2 != null)
				{
					particle2.bounceOffHorizontalWall();
				}
				else if (particle == null && particle2 == null)
				{
					this.redraw(d);
				}
				this.predict(particle, d);
				this.predict(particle2, d);
			}
		}
	}
	
	
	/**/public static void main(string[] strarr)
	{
		StdDraw.setXscale(0.045454545454545456, 0.95454545454545459);
		StdDraw.setYscale(0.045454545454545456, 0.95454545454545459);
		StdDraw.show(0);
		Particle[] array;
		if (strarr.Length == 1)
		{
			int num = Integer.parseInt(strarr[0]);
			array = new Particle[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = new Particle();
			}
		}
		else
		{
			int num = StdIn.readInt();
			array = new Particle[num];
			for (int i = 0; i < num; i++)
			{
				double d = StdIn.readDouble();
				double d2 = StdIn.readDouble();
				double d3 = StdIn.readDouble();
				double d4 = StdIn.readDouble();
				double d5 = StdIn.readDouble();
				double d6 = StdIn.readDouble();
				int r = StdIn.readInt();
				int g = StdIn.readInt();
				int b = StdIn.readInt();
				Color c = new Color(r, g, b);
				array[i] = new Particle(d, d2, d3, d4, d5, d6, c);
			}
		}
		CollisionSystem collisionSystem = new CollisionSystem(array);
		collisionSystem.simulate(10000.0);
	}
}