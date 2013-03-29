namespace cyberzed.TechPro.ServiceStack_02.Server
{
	internal class IdGenerator
	{
		private static int currentId = 1;

		internal int Next()
		{
			return currentId++;
		}
	}
}