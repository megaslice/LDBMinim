
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable 1573, 1591

namespace MinimalRepro
{
	public partial class MinimalReproduction04ECD0D4E3 : DataConnection
	{
		public MinimalReproduction04ECD0D4E3()
		{
			InitDataContext();
		}

		public MinimalReproduction04ECD0D4E3(string configuration)
			: base(configuration)
		{
			InitDataContext();
		}

		public MinimalReproduction04ECD0D4E3(LinqToDBConnectionOptions<MinimalReproduction04ECD0D4E3> options)
			: base(options)
		{
			InitDataContext();
		}

		partial void InitDataContext();

		public ITable<Blort> Blorts => this.GetTable<Blort>();
		public ITable<Foo>   Foos   => this.GetTable<Foo>();
	}

	[Table("Blort")]
	public partial class Blort
	{
		[Column("X"        , IsPrimaryKey = true, PrimaryKeyOrder = 0)] public int X         { get; set; } // int
		[Column("Y"        , IsPrimaryKey = true, PrimaryKeyOrder = 1)] public int Y         { get; set; } // int
		[Column("Z"        , IsPrimaryKey = true, PrimaryKeyOrder = 2)] public int Z         { get; set; } // int
		[Column("Blortness"                                          )] public int Blortness { get; set; } // int

		#region Associations
		/// <summary>
		/// FK_Foo_Blort backreference
		/// </summary>
		[Association(ThisKey = nameof(X) + "," + nameof(Y) + "," + nameof(Z), OtherKey = nameof(Foo.BlortX) + "," + nameof(Foo.BlortY) + "," + nameof(Foo.BlortZ))]
		public IEnumerable<Foo> Foos { get; set; } = null!;
		#endregion
	}

	public static partial class ExtensionMethods
	{
		#region Table Extensions
		public static Blort? Find(this ITable<Blort> table, int x, int y, int z)
		{
			return table.FirstOrDefault(e => e.X == x && e.Y == y && e.Z == z);
		}

		public static Task<Blort?> FindAsync(this ITable<Blort> table, int x, int y, int z, CancellationToken cancellationToken = default)
		{
			return table.FirstOrDefaultAsync(e => e.X == x && e.Y == y && e.Z == z, cancellationToken);
		}

		public static Foo? Find(this ITable<Foo> table, int x, int y, int z)
		{
			return table.FirstOrDefault(e => e.X == x && e.Y == y && e.Z == z);
		}

		public static Task<Foo?> FindAsync(this ITable<Foo> table, int x, int y, int z, CancellationToken cancellationToken = default)
		{
			return table.FirstOrDefaultAsync(e => e.X == x && e.Y == y && e.Z == z, cancellationToken);
		}
		#endregion

		#region Scalar Functions
		#region ExampleFunction
		[Sql.Function("dbo.ExampleFunction", ServerSideOnly = true)]
		public static int? ExampleFunction(int? k)
		{
			throw new InvalidOperationException("Scalar function cannot be called outside of query");
		}
		#endregion
		#endregion
	}

	[Table("Foo")]
	public partial class Foo
	{
		[Column("X"      , IsPrimaryKey = true, PrimaryKeyOrder = 0)] public int X       { get; set; } // int
		[Column("Y"      , IsPrimaryKey = true, PrimaryKeyOrder = 1)] public int Y       { get; set; } // int
		[Column("Z"      , IsPrimaryKey = true, PrimaryKeyOrder = 2)] public int Z       { get; set; } // int
		[Column("BlortX"                                           )] public int BlortX  { get; set; } // int
		[Column("BlortY"                                           )] public int BlortY  { get; set; } // int
		[Column("BlortZ"                                           )] public int BlortZ  { get; set; } // int
		[Column("Fooness"                                          )] public int Fooness { get; set; } // int

		#region Associations
		/// <summary>
		/// FK_Foo_Blort
		/// </summary>
		[Association(CanBeNull = false, ThisKey = nameof(BlortX) + "," + nameof(BlortY) + "," + nameof(BlortZ), OtherKey = nameof(MinimalRepro.Blort.X) + "," + nameof(MinimalRepro.Blort.Y) + "," + nameof(MinimalRepro.Blort.Z))]
		public Blort Blort { get; set; } = null!;
		#endregion
	}
}
