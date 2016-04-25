using System;
using SQLite.Net.Async;

namespace IcatuzinhoApp
{
	public interface ISQLite
	{
		SQLiteAsyncConnection GetConnection ();
	}
}

